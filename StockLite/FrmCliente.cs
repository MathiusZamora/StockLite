using StockLite.Models;
using StockLite.Services;

namespace StockLite
{
    public partial class FrmCliente : Form
    {
        private Cliente? seleccionado = null;
        private int UsuarioIdActual => FormMainMenu.UsuarioActual?.UsuarioId ?? 0;

        public FrmCliente()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarClientes();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ConfigurarGrid()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClienteId", HeaderText = "ID", Width = 70 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", Width = 250 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Contacto", HeaderText = "Contacto", Width = 100 });
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;

            dgvClientes.RowHeadersVisible = false;
            dgvClientes.RowHeadersWidth = 4;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarClientes() => dgvClientes.DataSource = ClienteService.GetAll()
            ;

        private void Limpiar()
        {
            txtNombre.Clear();
            txtContacto.Clear();
            seleccionado = null;
            btnGuardar.Text = "Guardar";
            txtNombre.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e) => Limpiar();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (seleccionado == null)
                    ClienteService.Insert(txtNombre.Text.Trim(), txtContacto.Text.Trim());
                else
                    ClienteService.Update(seleccionado.ClienteId, txtNombre.Text.Trim(), txtContacto.Text.Trim());

                CargarClientes();
                Limpiar();
                MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (seleccionado == null) return;

            if (MessageBox.Show($"¿Eliminar al cliente '{seleccionado.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClienteService.Delete(seleccionado.ClienteId);
                CargarClientes();
                Limpiar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        private void dgvClientes_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow?.DataBoundItem is Cliente c)
            {
                seleccionado = c;
                txtNombre.Text = c.Nombre;
                txtContacto.Text = c.Contacto ?? "";
                btnGuardar.Text = "Actualizar";
            }
        }

    
    }
}