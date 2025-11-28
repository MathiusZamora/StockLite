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
            this.Text = "Movimiento de Inventario";
            this.StartPosition = FormStartPosition.CenterScreen;

            CargarProductos();
            CargarClientes();
            CargarProveedores();
        }

        private void CargarProductos()
        {
            var productos = ProductoService.GetAll().OrderBy(p => p.Codigo).ToList();

            cmbProductoEntrada.DataSource = new List<Producto>(productos);
            cmbProductoEntrada.DisplayMember = "CodigoNombre";
            cmbProductoEntrada.ValueMember = "ProductoId";

            cmbProductoSalida.DataSource = new List<Producto>(productos);
            cmbProductoSalida.DisplayMember = "CodigoNombre";
            cmbProductoSalida.ValueMember = "ProductoId";

            cmbProductoEntrada.SelectedIndex = -1;
            cmbProductoSalida.SelectedIndex = -1;

            productoEntrada = null;
            productoSalida = null;
        }

        private void CargarClientes()
        {
            var lista = new List<Cliente> { new Cliente { ClienteId = 0, Nombre = "Sin cliente" } };
            lista.AddRange(ClienteService.GetAll());

            cmbCliente.DataSource = lista;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ClienteId";

            cmbCliente.SelectedIndex = -1;
        }

        private void CargarProveedores()
        {
            var lista = new List<Proveedor> { new Proveedor { ProveedorId = 0, Nombre = "Sin proveedor" } };
            lista.AddRange(ProveedorService.GetAll());

            cmbProveedor.DataSource = lista;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "ProveedorId";
            cmbProveedor.SelectedIndex = -1;
            cmbProveedor.Enabled = false;
            cmbProveedor.BackColor = SystemColors.Control;
            cmbProveedor.ForeColor = SystemColors.GrayText;

        }



        private void MostrarSelectorProducto(ComboBox combo, Action<Producto> onSelect)
        {
            using var f = new Form
            {
                Text = "Seleccionar Producto",
                Size = new Size(480, 600),
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

            };

            dgv.Columns.AddRange(new DataGridViewColumn[]
            {
        new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Código", Width = 100 },
        new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Producto", Width = 200 },
        new DataGridViewTextBoxColumn { DataPropertyName = "ProveedorNombre", HeaderText = "Proveedor", Width = 200 },
        new DataGridViewTextBoxColumn { DataPropertyName = "StockActual", HeaderText = "Stock", Width = 80 },
        new DataGridViewTextBoxColumn { DataPropertyName = "PrecioCosto", HeaderText = "Costo", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } },

            });

            dgv.DoubleClick += (s, e) =>
            {
                if (dgv.CurrentRow?.DataBoundItem is Producto p)
                {
                    onSelect(p);
                    combo.Text = $"{p.Codigo} - {p.Nombre}";
                    f.Close();
                }
            };

            f.Controls.Add(dgv);
            f.ShowDialog(this);

            
        }


        private void btnVerTodosE_Click(object sender, EventArgs e) => MostrarSelectorProducto(cmbProductoEntrada, p => productoEntrada = p);
        private void btnVerTodosS_Click(object sender, EventArgs e) => MostrarSelectorProducto(cmbProductoSalida, p => productoSalida = p);

        private void cmbProductoEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            productoEntrada = cmbProductoEntrada.SelectedItem as Producto;

            if (productoEntrada != null)
            {

                cmbProveedor.SelectedValue = productoEntrada.ProveedorId ?? 0;
                cmbProveedor.Enabled = false;
                cmbProveedor.BackColor = SystemColors.Control;
                cmbProveedor.ForeColor = SystemColors.GrayText;
            }
        }

        private void cmbProductoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            productoSalida = cmbProductoSalida.SelectedItem as Producto;


        }





        private void btnSalida_Click(object sender, EventArgs e)
        {
            if (productoSalida == null || cmbProductoSalida.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto para la salida.", "Falta producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (productoSalida.StockActual < nudCantidadS.Value)
            {
                MessageBox.Show("Stock insuficiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int? clienteId = cmbCliente.SelectedValue is int id && id > 0 ? id : null;

            MovimientoStockService.Insert(false, clienteId, txtObsS.Text.Trim(),
                new List<DetalleMovimientoView>
                {
                    new()
                    {
                        ProductoId = productoSalida.ProductoId,
                        Cantidad = (int)nudCantidadS.Value,
                        PrecioCompra = productoSalida.PrecioCosto,
                        PrecioVenta = productoSalida.PrecioVenta
                    }
                });

            MessageBox.Show("Salida registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarProductos();
            CargarClientes();
            nudCantidadS.Value = 1;
            txtObsS.Clear();
            cmbProveedor.SelectedIndex = -1;
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            if (productoEntrada == null || cmbProductoEntrada.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto para la entrada.", "Falta producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? proveedorId = cmbProveedor.SelectedValue is int pv && pv > 0 ? pv : null;


            MovimientoStockService.Insert(true, proveedorId, txtObsE.Text.Trim(),
                new List<DetalleMovimientoView>
                {
                    new()
                    {
                        ProductoId = productoEntrada.ProductoId,
                        Cantidad = (int)nudCantidadE.Value,
                        PrecioCompra = productoEntrada.PrecioCosto,
                        PrecioVenta = productoEntrada.PrecioVenta
                    }
                });

            MessageBox.Show("Entrada registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarProductos();
            CargarClientes();
            nudCantidadE.Value = 1;
            txtObsE.Clear();
            cmbProveedor.SelectedIndex = -1;
        }
    }
}