using Microsoft.Data.SqlClient;
using StockLite.Models;
using StockLite.Services;
namespace StockLite
{
    public partial class FrmCategoria : Form
    {
        private Categoria? seleccionado = null;
        private int UsuarioIdActual => FormMainMenu.UsuarioActual?.UsuarioId ?? 0;
        public FrmCategoria()
        {
            InitializeComponent();
            CargarCategorias();
        }
        private void CargarCategorias()
        {
            try
            {
                dgvCategorias.DataSource = CategoriaService.GetAll();
                dgvCategorias.Columns["Activo"].Visible = false; // Hide Activo column

                dgvCategorias.ReadOnly = true;
                dgvCategorias.RowHeadersVisible = false;
                dgvCategorias.RowHeadersWidth = 4;
                dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            seleccionado = null;
            btnGuardar.Text = "Guardar";
            txtNombre.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (seleccionado == null)
                {
                    CategoriaService.Insert(txtNombre.Text.Trim());
                }
                else
                {
                    CategoriaService.Update(seleccionado.CategoriaId, txtNombre.Text.Trim());
                }
                CargarCategorias();
                LimpiarCampos();
                MessageBox.Show("Categoría guardada correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (seleccionado == null)
            {
                MessageBox.Show("Selecciona una categoría para eliminar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // VALIDAR QUE NO TENGA PRODUCTOS ASOCIADOS
            const string sqlCheck = "SELECT COUNT(*) FROM Producto WHERE CategoriaId = @id AND Activo = 1";
            var count = (int)Db.Scalar(sqlCheck, new SqlParameter("@id", seleccionado.CategoriaId));

            if (count > 0)
            {
                MessageBox.Show(
                    $"No se puede eliminar la categoría '{seleccionado.Nombre}'.\n\n" +
                    $"Hay {count} producto(s) asociado(s) a esta categoría.\n" +
                    "Elimina o reasigna esos productos primero.",
                    "Eliminación no permitida",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show(
                $"¿Estás seguro de eliminar la categoría '{seleccionado.Nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    CategoriaService.Delete(seleccionado.CategoriaId);

                    MessageBox.Show("Categoría eliminada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarCategorias();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            seleccionado = dgvCategorias.Rows[e.RowIndex].DataBoundItem as Categoria;
            if (seleccionado != null)
            {
                txtNombre.Text = seleccionado.Nombre;
                btnGuardar.Text = "Actualizar";
            }
        }
        private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvCategorias_CellClick(sender, e);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow?.DataBoundItem is Categoria cat)
            {
                seleccionado = cat;
                txtNombre.Text = cat.Nombre;
                btnGuardar.Text = "Actualizar";
            }
        }
    }
}