using StockLite.Models;
using StockLite.Services;
using System;
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
            LimpiarEntrada();
            LimpiarSalida();
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
        }

        private void CargarClientes()
        {
            var lista = new List<Cliente> { new Cliente { ClienteId = 0, Nombre = "Sin cliente" } };
            lista.AddRange(ClienteService.GetAll());
            cmbCliente.DataSource = lista;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ClienteId";
        }

        private void MostrarSelectorProducto(ComboBox combo, Action<Producto> onSelect)
        {
            using var f = new Form { Text = "Seleccionar Producto", Size = new Size(850, 600), StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false };
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = ProductoService.GetAll(),
                ReadOnly = true,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dgv.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Código", Width = 110 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Producto", Width = 380 },
                new DataGridViewTextBoxColumn { DataPropertyName = "StockActual", HeaderText = "Stock", Width = 100 },
                new DataGridViewTextBoxColumn { DataPropertyName = "PrecioCosto", HeaderText = "Costo", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } }
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
            if (cmbProductoEntrada.SelectedItem is Producto p) productoEntrada = p;
        }

        private void cmbProductoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductoSalida.SelectedItem is Producto p) productoSalida = p;
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            if (productoEntrada == null) { MessageBox.Show("Seleccione un producto."); return; }

            MovimientoStockService.Insert(true, null, txtObsE.Text.Trim(),
                new List<DetalleMovimientoView> { new() { ProductoId = productoEntrada.ProductoId, Cantidad = (int)nudCantidadE.Value, PrecioCompra = productoEntrada.PrecioCosto, PrecioVenta = productoEntrada.PrecioVenta } });

            MessageBox.Show("Entrada registrada correctamente.");
            cmbProductoEntrada.SelectedIndex = -1; nudCantidadE.Value = 1; txtObsE.Clear(); productoEntrada = null;


            CargarProductos();
            LimpiarEntrada();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            if (productoSalida == null) { MessageBox.Show("Seleccione un producto."); return; }
            if (productoSalida.StockActual < nudCantidadS.Value) { MessageBox.Show("Stock insuficiente."); return; }

            int? clienteId = cmbCliente.SelectedValue is int id && id > 0 ? id : null;

            MovimientoStockService.Insert(false, clienteId, txtObsS.Text.Trim(),
                new List<DetalleMovimientoView> { new() { ProductoId = productoSalida.ProductoId, Cantidad = (int)nudCantidadS.Value, PrecioCompra = productoSalida.PrecioCosto, PrecioVenta = productoSalida.PrecioVenta } });

            MessageBox.Show("Salida registrada correctamente.");
            cmbProductoSalida.SelectedIndex = -1; nudCantidadS.Value = 1; txtObsS.Clear(); productoSalida = null;


            CargarProductos();
            LimpiarSalida();

        }

        private void LimpiarEntrada()
        {
            cmbProductoEntrada.SelectedIndex = -1;
            nudCantidadE.Value = 1;
            txtObsE.Clear();
            productoEntrada = null;   
        }
        private void LimpiarSalida()
        {
            cmbProductoSalida.SelectedIndex = -1;
            nudCantidadS.Value = 1;
            txtObsS.Clear();
            productoSalida = null;    
        }
    }
}