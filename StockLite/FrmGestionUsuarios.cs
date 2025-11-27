using BCrypt.Net;
using Microsoft.Data.SqlClient;
using StockLite.Models;
using System.Data;

namespace StockLite
{
    public partial class FrmGestionUsuarios : Form
    {
        private Usuario? usuarioEditar = null;

        public FrmGestionUsuarios()
        {
            InitializeComponent();
            ConfigurarDataGrid();
            CargarUsuarios();
        }

        private void ConfigurarDataGrid()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns.Clear();

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UsuarioId",
                HeaderText = "ID",
                Name = "UsuarioId",
                Width = 60,
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre Completo",
                Name = "Nombre",
                Width = 200,
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Usuario",
                HeaderText = "Usuario",
                Name = "Usuario",
                Width = 120,
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Rol",
                HeaderText = "Rol",
                Name = "Rol",
                Width = 100,
                ReadOnly = true
            });

            // NO agregamos columna Activo → nunca aparece
        }

        private void CargarUsuarios()
        {
            const string sql = " EXEC ListarUsuarios;";
            var dt = Db.Query(sql);
            dgvUsuarios.DataSource = dt;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            cmbRol.SelectedIndex = -1;
            usuarioEditar = null;
            btnGuardar.Text = "Guardar";
        }

        private void btnNuevo_Click(object sender, EventArgs e) => LimpiarCampos();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                //string.IsNullOrWhiteSpace(txtClave.Text) ||
                cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hash = BCrypt.Net.BCrypt.HashPassword(txtClave.Text);

            if (usuarioEditar == null)
            {
                const string sql = @"
                EXEC InsertarUsuario 
                    @nombre = @nombre,
                    @usuario = @usuario, 
                    @hash = @hash,
                    @rol = @rol";

                Db.Exec(sql,
                    new SqlParameter("@nombre", txtNombre.Text.Trim()),
                    new SqlParameter("@usuario", txtUsuario.Text.Trim()),
                    new SqlParameter("@hash", hash),
                    new SqlParameter("@rol", cmbRol.Text)
                );
            }
            else
            {
                // UPDATE → no tocamos Activo
                const string sql = """
                EXEC ActualizarUsuario 
                    @nombre = @nombre,
                    @usuario = @usuario, 
                    @hash = @hash,
                    @rol = @rol,
                    @id = @id
                """;

                Db.Exec(sql,
                    new SqlParameter("@nombre", txtNombre.Text.Trim()),
                    new SqlParameter("@usuario", txtUsuario.Text.Trim()),
                    new SqlParameter("@hash", txtClave.Text.Trim()),
                    new SqlParameter("@rol", cmbRol.Text),
                    new SqlParameter("@id", usuarioEditar.UsuarioId)
                );

                //if (!string.IsNullOrWhiteSpace(txtClave.Text))
                //{
                //    const string sqlPass = "UPDATE dbo.Usuario SET ClaveHash = @hash WHERE UsuarioId = @id";
                //    Db.Exec(sqlPass,
                //        new SqlParameter("@hash", hash),
                //        new SqlParameter("@id", usuarioEditar.UsuarioId)
                //    );
                //}
            }

            MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarUsuarios();
            LimpiarCampos();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvUsuarios.Rows[e.RowIndex];
            if (row.Cells["UsuarioId"].Value == null) return;

            usuarioEditar = new Usuario
            {
                UsuarioId = Convert.ToInt32(row.Cells["UsuarioId"].Value),
                Nombre = row.Cells["Nombre"].Value?.ToString() ?? "",
                NombreUsuario = row.Cells["Usuario"].Value?.ToString() ?? "",
                Rol = row.Cells["Rol"].Value?.ToString() ?? ""
            };

            txtNombre.Text = usuarioEditar.Nombre;
            txtUsuario.Text = usuarioEditar.NombreUsuario;
            txtClave.Clear();
            cmbRol.Text = usuarioEditar.Rol;
            btnGuardar.Text = "Actualizar";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioEditar == null)
            {
                MessageBox.Show("Selecciona un usuario para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Desactivar al usuario '{usuarioEditar.NombreUsuario}'?\nYa no podrá iniciar sesión.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                const string sql = "EXEC AnularUsuario @id";
                Db.Exec(sql, new SqlParameter("@id", usuarioEditar.UsuarioId));

                MessageBox.Show("Usuario desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
                LimpiarCampos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => LimpiarCampos();
    }
}