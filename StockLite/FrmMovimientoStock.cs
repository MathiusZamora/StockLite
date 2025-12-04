using StockLite.Models;
using StockLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StockLite
{
    public partial class FrmMovimientoStock : Form
    {
        private Producto? productoEntrada = null;
        private Producto? productoSalida = null;

        public FrmMovimientoStock()
        {
            InitializeComponent();
            this.Text = "📦 Movimientos de Inventario - StockLite";
            CargarCombos();
        }

        private void CargarCombos()
        {
            CargarProductos();
            CargarClientes();
            CargarProveedores();
        }

        private void CargarProductos()
        {
            var productos = ProductoService.GetAll().OrderBy(p => p.Codigo).ToList();

            // ENTRADA - INDEPENDIENTE
            cmbProductoEntrada.DataSource = null;
            cmbProductoEntrada.DataSource = new List<Producto>(productos);
            cmbProductoEntrada.DisplayMember = "CodigoNombre";
            cmbProductoEntrada.ValueMember = "ProductoId";
            cmbProductoEntrada.SelectedIndex = -1;

            // SALIDA - INDEPENDIENTE  
            cmbProductoSalida.DataSource = null;
            cmbProductoSalida.DataSource = new List<Producto>(productos);
            cmbProductoSalida.DisplayMember = "CodigoNombre";
            cmbProductoSalida.ValueMember = "ProductoId";
            cmbProductoSalida.SelectedIndex = -1;

            productoEntrada = null;
            productoSalida = null;
        }

        private void CargarClientes()
        {
            var lista = new List<Cliente> { new Cliente { ClienteId = 0, Nombre = "Sin cliente" } };
            lista.AddRange(ClienteService.GetAll());
            cmbCliente.DataSource = null;
            cmbCliente.DataSource = lista;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ClienteId";
            cmbCliente.SelectedIndex = 0; // "Sin cliente" por defecto
        }

        private void CargarProveedores()
        {
            var lista = new List<Proveedor> { new Proveedor { ProveedorId = 0, Nombre = "Sin proveedor" } };
            lista.AddRange(ProveedorService.GetAll());
            cmbProveedor.DataSource = null;
            cmbProveedor.DataSource = lista;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "ProveedorId";
            cmbProveedor.SelectedIndex = 0; // "Sin proveedor" por defecto
            cmbProveedor.Enabled = false;
        }

        private void MostrarSelectorProducto(ComboBox combo, Action<Producto> onSelect)
        {
            using var f = new Form
            {
                Text = "🔍 Seleccionar Producto",
                Size = new Size(800, 500),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };

            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = ProductoService.GetAll(),
                ReadOnly = true,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                RowHeadersWidth = 4,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };

            dgv.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Código", FillWeight = 12 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Producto", FillWeight = 30 },
                new DataGridViewTextBoxColumn { DataPropertyName = "ProveedorNombre", HeaderText = "Proveedor", FillWeight = 25 },
                new DataGridViewTextBoxColumn { DataPropertyName = "StockActual", HeaderText = "Stock", FillWeight = 10 },
                new DataGridViewTextBoxColumn { DataPropertyName = "PrecioCosto", HeaderText = "Costo", FillWeight = 12, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } },
                new DataGridViewTextBoxColumn { DataPropertyName = "PrecioVenta", HeaderText = "P. Venta", FillWeight = 12, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } }
            });

            dgv.DoubleClick += (s, e) =>
            {
                if (dgv.CurrentRow?.DataBoundItem is Producto p)
                {
                    onSelect(p);
                    combo.Text = p.CodigoNombre;
                    f.Close();
                }
            };

            f.Controls.Add(dgv);
            f.ShowDialog(this);
        }

        
        private void btnVerTodosE_Click(object sender, EventArgs e)
            => MostrarSelectorProducto(cmbProductoEntrada, p =>
            {
                productoEntrada = p;
                ActualizarProveedorEntrada();
            });

        private void btnVerTodosS_Click(object sender, EventArgs e)
            => MostrarSelectorProducto(cmbProductoSalida, p => productoSalida = p);

        
        private void cmbProductoEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductoEntrada.SelectedItem is Producto p)
            {
                productoEntrada = p;
                ActualizarProveedorEntrada();
            }
        }

        private void cmbProductoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductoSalida.SelectedItem is Producto p)
                productoSalida = p;
        }

        
        private void ActualizarProveedorEntrada()
        {
            if (productoEntrada != null && productoEntrada.ProveedorId.HasValue)
            {
                cmbProveedor.SelectedValue = productoEntrada.ProveedorId.Value;
                cmbProveedor.Enabled = false;
                cmbProveedor.BackColor = Color.FromArgb(240, 248, 255);
                cmbProveedor.ForeColor = Color.FromArgb(73, 80, 87);
            }
            else
            {
                cmbProveedor.SelectedIndex = 0; 
                cmbProveedor.Enabled = true;
                cmbProveedor.BackColor = Color.White;
                cmbProveedor.ForeColor = Color.Black;
            }
        }

        
        private void btnEntrada_Click(object sender, EventArgs e)
        {
            //if (productoEntrada == null)
            //{
            //    MessageBox.Show("Debe seleccionar un producto para la entrada.", "Falta producto",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

           
            //int? clienteId = null;  // ← ¡¡SIEMPRE NULL para entrada!!

            //try
            //{
            //    MovimientoStockService.Insert(
            //        esEntrada: true,                    // Entrada
            //        clienteId: clienteId,               // NULL
            //        observacion: txtObsE.Text.Trim(),   // Observación
            //        detalles: new List<DetalleMovimientoView>
            //        {
            //    new()
            //    {
            //        ProductoId = productoEntrada.ProductoId,
            //        Cantidad = (int)nudCantidadE.Value,
            //        PrecioCompra = productoEntrada.PrecioCosto,
            //        PrecioVenta = productoEntrada.PrecioVenta
            //    }
            //        });

            //    MessageBox.Show("Entrada registrada correctamente.", "Éxito",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    // LIMPIAR
            //    nudCantidadE.Value = 1;
            //    txtObsE.Clear();
            //    cmbProductoEntrada.SelectedIndex = -1;
            //    CargarCombos();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al registrar entrada: {ex.Message}", "Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        private void btnSalida_Click(object sender, EventArgs e)
        {
            if (productoSalida == null)
            {
                MessageBox.Show("Debe seleccionar un producto para la salida.", "Falta producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (productoSalida.StockActual < nudCantidadS.Value)
            {
                MessageBox.Show($"Stock insuficiente. Disponible: {productoSalida.StockActual}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ PARA SALIDA: clienteId real o NULL
            int? clienteId = cmbCliente.SelectedValue is int id && id > 0 ? id : null;

            //try
            //{
            //    MovimientoStockService.Insert(
            //        esEntrada: false,                   // Salida
            //        clienteId: clienteId,               // Cliente real o NULL
            //        observacion: txtObsS.Text.Trim(),   // Observación
            //        detalles: new List<DetalleMovimientoView>
            //        {
            //    new()
            //    {
            //        ProductoId = productoSalida.ProductoId,
            //        Cantidad = (int)nudCantidadS.Value,
            //        PrecioCompra = productoSalida.PrecioCosto,
            //        PrecioVenta = productoSalida.PrecioVenta
            //    }
            //        });

            //    MessageBox.Show("Salida registrada correctamente.", "Éxito",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    // LIMPIAR
            //    nudCantidadS.Value = 1;
            //    txtObsS.Clear();
            //    cmbProductoSalida.SelectedIndex = -1;
            //    CargarCombos();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al registrar salida: {ex.Message}", "Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}