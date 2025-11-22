using StockLite.Models;
using StockLite.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace StockLite
{
    public partial class FrmProducto : Form
    {
        private Producto? seleccionado = null;

        public FrmProducto()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarCategoriasCombo();        
            CargarComboFiltroCategoria();  

            CargarProductos();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ConfigurarGrid()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductoId", HeaderText = "ID", Width = 60 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Código", Width = 90 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Producto", Width = 190 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CategoriaNombre", HeaderText = "Categoría", Width = 150 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioCosto",
                HeaderText = "Costo",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioVenta",
                HeaderText = "Precio Venta",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StockActual",
                HeaderText = "Stock",
                Width = 80
            });

            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.CellClick += dgvProductos_CellClick;
        }

        private void CargarProductos()
        {
            string texto = txtBuscar.Text.Trim();
            int? categoriaId = cmbCategoriaFiltro.SelectedValue as int?; 

            var lista = ProductoService.GetAll();

            if (!string.IsNullOrEmpty(texto))
            {
                lista = lista.Where(p =>
                    p.Codigo.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            if (categoriaId.HasValue && categoriaId.Value > 0)
            {
                lista = lista.Where(p => p.CategoriaId == categoriaId.Value).ToList();
            }

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = lista;

            if (dgvProductos.Rows.Count > 0)
            {
                dgvProductos.Rows[0].Selected = true;
                MostrarProductoSeleccionado();
            }
            else
            {
                Limpiar();
            }
        }

        private void CargarCategoriasCombo()
        {
            var categorias = CategoriaService.GetAll();
            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaId";
            cmbCategoria.SelectedIndex = -1;
        }

        
        private void CargarComboFiltroCategoria()
        {
            var categorias = CategoriaService.GetAll();

            cmbCategoriaFiltro.DataSource = categorias;
            cmbCategoriaFiltro.DisplayMember = "Nombre";
            cmbCategoriaFiltro.ValueMember = "CategoriaId";
            cmbCategoriaFiltro.SelectedIndex = -1;         
            cmbCategoriaFiltro.Text = "Filtrar por categoría";
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCosto.Clear();
            txtVenta.Clear();
            cmbCategoria.SelectedIndex = -1;
            seleccionado = null;
            btnGuardar.Text = "Guardar";
            txtCodigo.Focus();
        }

        private void MostrarProductoSeleccionado()
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is Producto p)
            {
                seleccionado = p;
                txtCodigo.Text = p.Codigo;
                txtNombre.Text = p.Nombre;
                txtCosto.Text = p.PrecioCosto.ToString("N2");
                txtVenta.Text = p.PrecioVenta.ToString("N2");
                cmbCategoria.SelectedValue = p.CategoriaId;
                btnGuardar.Text = "Actualizar";
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                MostrarProductoSeleccionado();
        }

        private void btnNuevo_Click(object sender, EventArgs e) => Limpiar();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                cmbCategoria.SelectedValue == null ||
                !decimal.TryParse(txtCosto.Text, out _) ||
                !decimal.TryParse(txtVenta.Text, out _))
            {
                MessageBox.Show("Complete todos los campos correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var categoriaId = (int)cmbCategoria.SelectedValue;
                var costo = decimal.Parse(txtCosto.Text);
                var precioVenta = decimal.Parse(txtVenta.Text);

                if (seleccionado == null)
                    ProductoService.Insert(txtCodigo.Text.Trim(), txtNombre.Text.Trim(), categoriaId, costo, precioVenta);
                else
                    ProductoService.Update(seleccionado.ProductoId, txtCodigo.Text.Trim(), txtNombre.Text.Trim(), categoriaId, costo, precioVenta);

                CargarProductos();
                Limpiar();
                MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (seleccionado == null) return;
            if (MessageBox.Show($"¿Eliminar el producto '{seleccionado.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProductoService.Delete(seleccionado.ProductoId);
                CargarProductos();
                Limpiar();
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cmbCategoriaFiltro.SelectedIndex = -1;
            cmbCategoriaFiltro.Text = "Filtrar por categoría";
            txtBuscar.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e) => Limpiar();

        private void txtBuscar_TextChanged(object sender, EventArgs e) => CargarProductos();
        private void cmbCategoriaFiltro_SelectionChangeCommitted(object sender, EventArgs e) => CargarProductos();
    }
}