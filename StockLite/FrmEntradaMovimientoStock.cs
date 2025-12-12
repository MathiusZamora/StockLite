using Microsoft.VisualBasic;
using StockLite.Models;
using StockLite.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockLite
{
    public partial class FrmEntradaMovimientoStock : Form
    {
        private Producto? productoEntrada = null;
        private Producto? productoSalida = null;
        static int IdRequiza = 0;
        static bool esEntrada = true;
        public FrmEntradaMovimientoStock()
        {
            InitializeComponent();
            this.Text = "📦 Movimientos de Inventario - StockLite";
            CargarCombos();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void CargarCombos()
        {
            CargarGrid();
            CargarProductos();
            CargarProveedores();
        }

        private void CargarGrid()
        {
            try
            {
                IdRequiza = Convert.ToInt32(txt_NumeroRequiza.Text);
                gridRequiza.DataSource = MovimientoStockService.ListarEntradaDetalleMovimientoStock(false, IdRequiza);
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
                MessageBox.Show($"Error al registrar entrada: {Ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool GenerarNumeroFactura()
        {
            try
            {

                MovimientoStock Entidad = new MovimientoStock();
                

                Entidad.Observacion = txtObsE.Text;
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
                    int? clienteId = null;
                    Entidad.ClienteId = clienteId;
                    Entidad.EsEntrada = esEntrada;
                    int ID = MovimientoStockService.InsertarMovimiento(Entidad);

                    DataTable dtRequiza = new DataTable();
                    MovimientoStock movimientoStock = new MovimientoStock();
                    dtRequiza = MovimientoStockService.ListarEntradaMovimientoStock(false, ID);


                    movimientoStock.IdMovimiento = Convert.ToInt32(dtRequiza.Rows[0]["MovimientoId"]);


                    double NumeroRequiza = Convert.ToInt32(dtRequiza.Rows[0]["MovimientoId"]);
                    string MostrarNumeroRequiza = Convert.ToString(NumeroRequiza);
                    txt_NumeroRequiza.Text = MostrarNumeroRequiza;

                    
                    return ID > 0;

                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show($"Error al registrar entrada: {Ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool Guardar()
        {
            try
            {




                Producto pr = new Producto();
                pr.ProductoId = Convert.ToInt32(cmbProductoEntrada.SelectedValue);
                int Cantidad = Convert.ToInt32(nudCantidadE.Text);

                DataTable tableproducto = new DataTable();
                tableproducto = ProductoService.ListarProductos(false, pr.ProductoId);


                if (tableproducto.Rows.Count > 0)
                {
                    DataRow DR = tableproducto.Rows[0];
                }





                DetalleMovimientoView Entidad = new DetalleMovimientoView();
                Entidad.IdMovimiento = Convert.ToInt32(txt_NumeroRequiza.Text);
                Entidad.ProductoId = Convert.ToInt32(cmbProductoEntrada.SelectedValue);
                Entidad.Cantidad = Convert.ToInt32(nudCantidadE.Text);


                MovimientoStockService.ActualizarStock(Cantidad, pr.ProductoId, esEntrada);







                Entidad.EsEntrada = esEntrada;
                int ID = MovimientoStockService.InsertarDetalleMovimientoStock(Entidad);


                CargarGrid();
                nudCantidadE.Value = 1;
                cmbProductoEntrada.SelectedIndex = -1;
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
            cmbProductoEntrada.DataSource = null;
            cmbProductoEntrada.DataSource = new List<Producto>(productos);
            cmbProductoEntrada.DisplayMember = "CodigoNombre";
            cmbProductoEntrada.ValueMember = "ProductoId";
            cmbProductoEntrada.SelectedIndex = -1;



            productoEntrada = null;
            productoSalida = null;
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




        private void cmbProductoEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductoEntrada.SelectedItem is Producto p)
            {
                productoEntrada = p;
                ActualizarProveedorEntrada();
            }
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
            if (GenerarNumeroFactura())
            {
                if (Guardar()){
                    MessageBox.Show($"Registro Guardado");
                }
                else
                {
                    MessageBox.Show($"Error al registrar entrada");
                }
            }
        }
    }
}
