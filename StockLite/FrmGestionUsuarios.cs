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

            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.RowHeadersWidth = 4;
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
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Los campos Nombre, Usuario y Rol son obligatorios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si es un usuario NUEVO → contraseña OBLIGATORIA
            // Si es edición → contraseña OPCIONAL (solo si la escribe)
            bool esNuevo = usuarioEditar == null;
            bool tieneClave = !string.IsNullOrWhiteSpace(txtClave.Text);

            if (esNuevo && !tieneClave)
            {
                MessageBox.Show("La contraseña es obligatoria para nuevos usuarios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generar hash SOLO si hay contraseña (nuevo o cambio de clave)
            string hash = tieneClave ? BCrypt.Net.BCrypt.HashPassword(txtClave.Text.Trim()) : null;

            try
            {
                if (esNuevo)
                {
                    // === INSERTAR NUEVO USUARIO ===
                    const string sql = """
                EXEC InsertarUsuario 
                    @nombre = @nombre,
                    @usuario = @usuario,
                    @hash = @hash,
                    @rol = @rol
                """;

                    Db.Exec(sql,
                        new SqlParameter("@nombre", txtNombre.Text.Trim()),
                        new SqlParameter("@usuario", txtUsuario.Text.Trim()),
                        new SqlParameter("@hash", hash),
                        new SqlParameter("@rol", cmbRol.Text)
                    );
                }
                else
                {
                    // === ACTUALIZAR USUARIO EXISTENTE ===
                    if (tieneClave)
                    {
                        // Cambia nombre de usuario + contraseña
                        const string sql = """
                    EXEC ActualizarUsuario 
                        @id = @id,
                        @nombre = @nombre,
                        @usuario = @usuario,
                        @hash = @hash,
                        @rol = @rol
                    """;

                        Db.Exec(sql,
                            new SqlParameter("@id", usuarioEditar.UsuarioId),
                            new SqlParameter("@nombre", txtNombre.Text.Trim()),
                            new SqlParameter("@usuario", txtUsuario.Text.Trim()),
                            new SqlParameter("@hash", hash),           // ← HASH NUEVO
                            new SqlParameter("@rol", cmbRol.Text)
                        );
                    }
                    else
                    {
                        // Solo cambia datos (sin tocar contraseña)
                        const string sql = """
                    EXEC ActualizarUsuario 
                        @id = @id,
                        @nombre = @nombre,
                        @usuario = @usuario,
                        @hash = NULL,        -- ← Indica que NO cambie la contraseña
                        @rol = @rol
                    """;

                        Db.Exec(sql,
                            new SqlParameter("@id", usuarioEditar.UsuarioId),
                            new SqlParameter("@nombre", txtNombre.Text.Trim()),
                            new SqlParameter("@usuario", txtUsuario.Text.Trim()),
                            new SqlParameter("@rol", cmbRol.Text)
                        );
                    }
                }

                MessageBox.Show("Usuario guardado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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