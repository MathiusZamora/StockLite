using Microsoft.Data.SqlClient;
using StockLite.Models;
using StockLite.Services;
using System;
using System.Windows.Forms;

namespace StockLite
{
    public partial class FrmProveedor : Form
    {
        private Proveedor? seleccionado = null;

        public FrmProveedor()
        {
            InitializeComponent();
            ConfigurarGrilla();
            CargarProveedores();
            this.Text = "Proveedores";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(850, 550);
            LimpiarCampos();
        }

        private void ConfigurarGrilla()
        {
            dgvProveedores.AutoGenerateColumns = false;
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.ReadOnly = true;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Dock = DockStyle.Fill;
            
            dgvProveedores.Columns.Clear();
            dgvProveedores.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "ProveedorId", HeaderText = "ID", Width = 60 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Proveedor", Width = 280 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Contacto", HeaderText = "Contacto", Width = 180 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Telefono", HeaderText = "Teléfono", Width = 130 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Width = 220 }
                
            });

            dgvProveedores.CellClick += (s, e) => { if (e.RowIndex >= 0) MostrarSeleccionado(); };

            dgvProveedores.RowHeadersVisible = false;
            dgvProveedores.RowHeadersWidth = 4;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarProveedores()
        {
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = ProveedorService.GetAll();
            if (dgvProveedores.Rows.Count > 0)
            {
                dgvProveedores.Rows[0].Selected = true;
                MostrarSeleccionado();
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void MostrarSeleccionado()
        {
            if (dgvProveedores.CurrentRow?.DataBoundItem is Proveedor p)
            {
                seleccionado = p;
                txtNombre.Text = p.Nombre;
                txtContacto.Text = p.Contacto ?? "";
                txtTelefono.Text = p.Telefono ?? "";
                txtEmail.Text = p.Email ?? "";
                btnGuardar.Text = "Actualizar";
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            seleccionado = null;
            btnGuardar.Text = "Guardar";
            txtNombre.Focus();
           

        }

        private void btnNuevo_Click(object sender, EventArgs e) => LimpiarCampos();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del proveedor es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var prov = new Proveedor
                {
                    ProveedorId = seleccionado?.ProveedorId ?? 0,
                    Nombre = txtNombre.Text.Trim(),
                    Contacto = string.IsNullOrWhiteSpace(txtContacto.Text) ? null : txtContacto.Text.Trim(),
                    Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Activo = true 
                };

                if (seleccionado == null)
                    ProveedorService.Insert(prov);
                else
                    ProveedorService.Update(prov);

                CargarProveedores();
                LimpiarCampos();
                MessageBox.Show("Proveedor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (seleccionado == null) return;

            // VALIDAR QUE NO TENGA PRODUCTOS ASOCIADOS
            const string sqlCheck = "SELECT COUNT(*) FROM Producto WHERE ProveedorId = @id AND Activo = 1";
            var count = (int)Db.Scalar(sqlCheck, new SqlParameter("@id", seleccionado.ProveedorId));

            if (count > 0)
            {
                MessageBox.Show(
                    $"No se puede eliminar el proveedor '{seleccionado.Nombre}'.\n\n" +
                    $"Tiene {count} producto(s) asociado(s) en el sistema.\n" +
                    "Elimina o reasigna esos productos antes de continuar.",
                    "Eliminación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

           
            if (MessageBox.Show(
                $"¿Eliminar permanentemente el proveedor '{seleccionado.Nombre}'?\n\n" +
                "Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ProveedorService.Delete(seleccionado.ProveedorId);

                    MessageBox.Show("Proveedor eliminado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarProveedores();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => LimpiarCampos();
    }
}