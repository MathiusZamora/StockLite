using BCrypt.Net;
using Microsoft.Data.SqlClient;
using StockLite.Models;
using StockLite.Services;

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
                Name = "UsuarioId",  // ← IMPORTANTE
                Width = 60
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre Completo",
                Name = "Nombre",     // ← IMPORTANTE
                Width = 200
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Usuario",
                HeaderText = "Usuario",
                Name = "Usuario",    // ← IMPORTANTE
                Width = 120
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Rol",
                HeaderText = "Rol",
                Name = "Rol",        // ← IMPORTANTE
                Width = 100
            });

        
        }

        private void CargarUsuarios()
        {
            const string sql = "SELECT UsuarioId, Nombre, Usuario, Rol, Activo FROM dbo.Usuario ORDER BY Nombre";
            var dt = Db.Query(sql);
            dgvUsuarios.DataSource = dt;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            cmbRol.SelectedIndex = -1;
            chkActivo.Checked = true;
            usuarioEditar = null;
            btnGuardar.Text = "Guardar";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text) ||
                cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hash = BCrypt.Net.BCrypt.HashPassword(txtClave.Text);

            if (usuarioEditar == null)
            {
                // INSERT
                const string sql = """
                    INSERT INTO dbo.Usuario (Nombre, Usuario, ClaveHash, Rol, Activo)
                    VALUES (@nombre, @usuario, @hash, @rol, @activo)
                    """;

                Db.Exec(sql,
                    new SqlParameter("@nombre", txtNombre.Text.Trim()),
                    new SqlParameter("@usuario", txtUsuario.Text.Trim()),
                    new SqlParameter("@hash", hash),
                    new SqlParameter("@rol", cmbRol.Text),
                    new SqlParameter("@activo", chkActivo.Checked)
                );
            }
            else
            {
                // UPDATE
                const string sql = """
                    UPDATE dbo.Usuario 
                    SET Nombre = @nombre, Usuario = @usuario, Rol = @rol, Activo = @activo
                    WHERE UsuarioId = @id
                    """;

                Db.Exec(sql,
                    new SqlParameter("@nombre", txtNombre.Text.Trim()),
                    new SqlParameter("@usuario", txtUsuario.Text.Trim()),
                    new SqlParameter("@rol", cmbRol.Text),
                    new SqlParameter("@activo", chkActivo.Checked),
                    new SqlParameter("@id", usuarioEditar.UsuarioId)
                );

                // Si cambió la contraseña
                if (!string.IsNullOrWhiteSpace(txtClave.Text))
                {
                    const string sqlPass = "UPDATE dbo.Usuario SET ClaveHash = @hash WHERE UsuarioId = @id";
                    Db.Exec(sqlPass,
                        new SqlParameter("@hash", hash),
                        new SqlParameter("@id", usuarioEditar.UsuarioId)
                    );
                }
            }

            MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarUsuarios();
            LimpiarCampos();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Prevenir errores al hacer clic en encabezados o filas inválidas
            if (e.RowIndex < 0 || e.RowIndex >= dgvUsuarios.Rows.Count)
                return;

            var row = dgvUsuarios.Rows[e.RowIndex];

            // Verificar que la fila tenga datos reales (no sea una fila vacía de "nueva fila")
            if (row.Cells[0].Value == null)
                return;

            try
            {
                usuarioEditar = new Usuario
                {
                    UsuarioId = Convert.ToInt32(row.Cells["UsuarioId"].Value),
                    Nombre = row.Cells["Nombre"].Value?.ToString() ?? "",
                    NombreUsuario = row.Cells["Usuario"].Value?.ToString() ?? "",
                    Rol = row.Cells["Rol"].Value?.ToString() ?? "",
                    Activo = Convert.ToBoolean(row.Cells["Activo"].Value)
                };

                // Llenar campos
                txtNombre.Text = usuarioEditar.Nombre;
                txtUsuario.Text = usuarioEditar.NombreUsuario;
                txtClave.Clear(); // No mostramos la contraseña
                cmbRol.Text = usuarioEditar.Rol;
                chkActivo.Checked = usuarioEditar.Activo;
                btnGuardar.Text = "Actualizar";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioEditar == null)
            {
                MessageBox.Show("Selecciona un usuario para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Eliminar permanentemente al usuario '{usuarioEditar.NombreUsuario}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                const string sql = "DELETE FROM dbo.Usuario WHERE UsuarioId = @id";
                Db.Exec(sql, new SqlParameter("@id", usuarioEditar.UsuarioId));
                MessageBox.Show("Usuario eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
                LimpiarCampos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}