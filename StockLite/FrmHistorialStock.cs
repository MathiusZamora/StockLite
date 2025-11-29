using StockLite.Models;
using StockLite.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StockLite
{
    public partial class FrmHistorialStock : Form
    {
        public FrmHistorialStock()
        {
            InitializeComponent();
            this.Text = "Historial de Movimientos de Stock";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FrmHistorialStock_Load;
        }

        private void FrmHistorialStock_Load(object? sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarProductos();
            CargarClientes();
            CargarProveedores();

            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            CargarHistorial();
        }

        private void ConfigurarGrilla()
        {
            dgvHistorial.AutoGenerateColumns = false;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.BackgroundColor = Color.White;
            dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            dgvHistorial.Columns.Clear();
            dgvHistorial.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha", DataPropertyName = "Fecha", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } },
                new DataGridViewTextBoxColumn { Name = "Hora", HeaderText = "Hora", DataPropertyName = "Fecha", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm" } },
                new DataGridViewTextBoxColumn { Name = "Tipo", HeaderText = "Tipo", DataPropertyName = "Tipo", Width = 90 },
                new DataGridViewTextBoxColumn { Name = "Codigo", HeaderText = "Código", DataPropertyName = "Codigo", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Producto", HeaderText = "Producto", DataPropertyName = "Producto", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "Proveedor", HeaderText = "Proveedor", DataPropertyName = "Proveedor", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Stock", DataPropertyName = "Cantidad", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } },
                new DataGridViewTextBoxColumn { Name = "Cliente", HeaderText = "Cliente", DataPropertyName = "Cliente", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "Usuario", HeaderText = "Usuario", DataPropertyName = "Usuario", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Observacion", HeaderText = "Observación", DataPropertyName = "Observacion", Width = 250 }
            });

            dgvHistorial.CellFormatting += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                if (dgvHistorial.Columns[e.ColumnIndex].Name != "Tipo") return;

                var valorCelda = dgvHistorial.Rows[e.RowIndex].Cells["Tipo"].Value;

                if (valorCelda is string tipo && !string.IsNullOrEmpty(tipo))
                {
                    if (tipo.Equals("ENTRADA", StringComparison.OrdinalIgnoreCase))
                    {
                        e.CellStyle!.ForeColor = Color.Green;
                        e.CellStyle!.Font = new Font(dgvHistorial.Font, FontStyle.Bold);
                    }
                    else if (tipo.Equals("SALIDA", StringComparison.OrdinalIgnoreCase))
                    {
                        e.CellStyle!.ForeColor = Color.Red;
                        e.CellStyle!.Font = new Font(dgvHistorial.Font, FontStyle.Bold);
                    }
                }

                e.FormattingApplied = true;
            };

            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.RowHeadersWidth = 4;
            //dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarProductos()
        {
            var lista = new List<Producto> { new Producto { ProductoId = 0, Codigo = "", Nombre = "[Todos los productos]" } };
            lista.AddRange(ProductoService.GetAll().OrderBy(p => p.Codigo));

            cmbProducto.DataSource = lista;
            cmbProducto.DisplayMember = "CodigoNombre";
            cmbProducto.ValueMember = "ProductoId";
            cmbProducto.SelectedIndex = 0;
        }

        private void CargarClientes()
        {
            var lista = new List<Cliente> { new Cliente { ClienteId = 0, Nombre = "[Todos los clientes]" } };
            lista.AddRange(ClienteService.GetAll().OrderBy(c => c.Nombre));

            cmbCliente.DataSource = lista;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ClienteId";
            cmbCliente.SelectedIndex = 0;
        }

        private void CargarProveedores()
        {
            var lista = new List<Proveedor> { new Proveedor { ProveedorId = 0, Nombre = "[Todos los proveedores]" } };
            lista.AddRange(ProveedorService.GetAll().OrderBy(p => p.Nombre));

            cmbProveedor.DataSource = lista;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "ProveedorId";
            cmbProveedor.SelectedIndex = 0;
        }

        private void CargarHistorial()
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            int? productoId = cmbProducto.SelectedValue is int id && id > 0 ? id : null;
            int? clienteId = cmbCliente.SelectedValue is int cid && cid > 0 ? cid : null;
            int? proveedorId = cmbProveedor.SelectedValue is int pid && pid > 0 ? pid : null;

            var movimientos = MovimientoStockService.GetHistorial(desde, hasta, productoId, clienteId, proveedorId);
            dgvHistorial.DataSource = null;
            dgvHistorial.DataSource = movimientos;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            if (cmbProducto.Items.Count > 0) cmbProducto.SelectedIndex = 0;
            if (cmbCliente.Items.Count > 0) cmbCliente.SelectedIndex = 0;
            if (cmbProveedor.Items.Count > 0) cmbProveedor.SelectedIndex = 0;

            CargarHistorial();
        }
    }
}
