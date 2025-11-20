using StockLite.Models;
using System.Windows.Forms;

namespace StockLite
{
    public partial class FormMainMenu : Form
    {
        private readonly Usuario _usuario;

        public FormMainMenu(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            // StatusStrip
            toolStripStatusLabel1.Text = $"Usuario: {_usuario.NombreUsuario}";
            toolStripStatusLabel2.Text = $"Rol: {_usuario.Rol}";
            toolStripStatusLabel3.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy - HH:mm");

            // Mostrar botón de Gestión de Usuarios solo si es Administrador
            bool esAdmin = _usuario.Rol == "Administrador";
            pnlGestionUsuarios.Visible = esAdmin;

            // Opcional: cambiar título
            this.Text = $"StockLite - Bienvenido, {_usuario.Nombre}";
        }

        // Evento del botón grande de Gestión de Usuarios
        private void pnlGestionUsuarios_Click(object sender, EventArgs e)
        {
            new FrmGestionUsuarios().ShowDialog();
        }

        private void pnlGestionUsuarios_MouseEnter(object sender, EventArgs e)
        {
            pnlGestionUsuarios.BackColor = Color.FromArgb(220, 240, 255);
        }

        private void pnlGestionUsuarios_MouseLeave(object sender, EventArgs e)
        {
            pnlGestionUsuarios.BackColor = Color.White;
        }

        // Cerrar sesión
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar sesión y volver al login?", "Cerrar sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                new FrmLogin().Show();
            }
        }
    }
}