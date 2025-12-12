using StockLite.Models;
using StockLite.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockLite
{
    public partial class FrmSalidaMovimientoStock : Form
    {
        private Producto? productoEntrada = null;
        private Producto? productoSalida = null;
        static int IdRequiza = 0;
        static bool esEntrada = false;
        public FrmSalidaMovimientoStock()
        {
            InitializeComponent();
            this.Text = "📦 Movimientos de Inventario - StockLite";
            CargarCombos();
            CargarClientes();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void CargarCombos()
        {
            CargarGrid();
            CargarProductos();
            

        }
        private void CargarClientes()
        {
            var lista = new List<Cliente> { new Cliente { ClienteId = 0, Nombre = "Sin Departamento" } };
            lista.AddRange(ClienteService.GetAll());
            cmbCliente.DataSource = null;
            cmbCliente.DataSource = lista;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ClienteId";
            cmbCliente.SelectedIndex = 0; // "Sin cliente" por defecto
        }
        private void CargarGrid()
        {
            try
            {
                IdRequiza = Convert.ToInt32(txt_NumeroRequiza.Text);
                gridRequiza.DataSource = MovimientoStockService.ListarSalidaDetalleMovimientoStock(false, IdRequiza);
                if (gridRequiza.Rows.Count > 0)
                {
                    gridRequiza.Columns[0].Visible = false;
                    gridRequiza.Columns[1].Visible = false;
                    gridRequiza.Columns[3].Visible = false;
                    gridRequiza.Columns[4].Visible = false;

                    gridRequiza.Columns[6].Visible = false;
                    gridRequiza.Columns[7].Visible = false;

                    gridRequiza.RowHeadersVisible = false;
                    gridRequiza.RowHeadersWidth = 4;
                    gridRequiza.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show($"Error al registrar Salida: {Ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool GenerarNumeroFactura()
        {
            try
            {
                MovimientoStock Entidad = new MovimientoStock();
                Entidad.Observacion = txtObsS.Text.Trim();

                
                int? clienteId = cmbCliente.SelectedValue is int id && id > 0 ? id : null;
                Entidad.ClienteId = clienteId;  

                IdRequiza = Convert.ToInt32(txt_NumeroRequiza.Text);

                if (IdRequiza > 0)
                {
                    Entidad.IdMovimiento = IdRequiza;
                    Entidad.EsEntrada = esEntrada;
                    bool Exito = MovimientoStockService.ActualizarMovimientoStock(Entidad);
                    return Exito;
                }
                else
                {
                    Entidad.EsEntrada = esEntrada;
                    int ID = MovimientoStockService.InsertarMovimiento(Entidad);

                    if (ID > 0)
                    {
                        // Actualizar el número de requiza en el textbox
                        txt_NumeroRequiza.Text = ID.ToString();
                        IdRequiza = ID;
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show($"Error al generar número de requiza: {Ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool Guardar()
        {
            try
            {




                Producto pr = new Producto();
                pr.ProductoId = Convert.ToInt32(cmbProductoSalida.SelectedValue);
                int Cantidad = Convert.ToInt32(nudCantidadS.Text);

                DataTable tableproducto = new DataTable();
                tableproducto = ProductoService.ListarProductos(false, pr.ProductoId);


                if (tableproducto.Rows.Count > 0)
                {
                    DataRow DR = tableproducto.Rows[0];
                }





                DetalleMovimientoView Entidad = new DetalleMovimientoView();
                Entidad.IdMovimiento = Convert.ToInt32(txt_NumeroRequiza.Text);
                Entidad.ProductoId = Convert.ToInt32(cmbProductoSalida.SelectedValue);
                Entidad.Cantidad = Convert.ToInt32(nudCantidadS.Text);


                MovimientoStockService.ActualizarStock(Cantidad, pr.ProductoId, esEntrada);







                Entidad.EsEntrada = esEntrada;
                int ID = MovimientoStockService.InsertarDetalleMovimientoStock(Entidad);


                CargarGrid();
                nudCantidadS.Value = 1;
                cmbProductoSalida.SelectedIndex = -1;
                CargarCombos();


                return ID > 0;



            }
            catch (Exception Ex)
            {

                return false;
            }
        }



        private void CargarProductos()
        {
            var productos = ProductoService.GetAll().OrderBy(p => p.Codigo).ToList();

            // ENTRADA - INDEPENDIENTE
            cmbProductoSalida.DataSource = null;
            cmbProductoSalida.DataSource = new List<Producto>(productos);
            cmbProductoSalida.DisplayMember = "CodigoNombre";
            cmbProductoSalida.ValueMember = "ProductoId";
            cmbProductoSalida.SelectedIndex = -1;



            productoEntrada = null;
            productoSalida = null;
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


        private void btnVerTodosS_Click(object sender, EventArgs e)
            => MostrarSelectorProducto(cmbProductoSalida, p =>
            {
                productoSalida = p; 
                cmbProductoSalida.Text = p.CodigoNombre;

            });




        private void cmbProductoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductoSalida.SelectedItem is Producto p)
            {
                productoSalida = p;

            }
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {

            // Validar producto seleccionado
            if (productoSalida == null)
            {
                MessageBox.Show("Debe seleccionar un producto para la salida.", "Falta producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validacion stock
            int cantidadSolicitada = (int)nudCantidadS.Value;
            int stockDisponible = productoSalida.StockActual;

            if (cantidadSolicitada > stockDisponible)
            {
                MessageBox.Show(
                    $"Stock insuficiente.\n\n" +
                    $"Cantidad solicitada: {cantidadSolicitada}\n" +
                    $"Stock disponible: {stockDisponible} unidad(es)",
                    "Error de stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                nudCantidadS.Focus();  
                return;                
            }

            if (GenerarNumeroFactura())
            {
                if (Guardar())
                {
                    MessageBox.Show($"Registro Guardado");
                }
                else
                {
                    MessageBox.Show($"Error al registrar salida");
                }
            }
        }
    }
}
