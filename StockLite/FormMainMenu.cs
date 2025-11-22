using StockLite.Models;
using System.Windows.Forms;

namespace StockLite
{
    public partial class FormMainMenu : Form
    {
        private readonly Usuario _usuario;
        public static Usuario? UsuarioActual { get; private set; } 

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

            UsuarioActual = _usuario; 
        }

        // Evento del botón grande de Gestión de Usuarios
        private void pnlGestionUsuarios_Click(object sender, EventArgs e)
        {
            new FrmGestionUsuarios().ShowDialog();
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

        private void PanelHover_Enter(object sender, EventArgs e)
        {
            if (sender is Panel p)
            {
                p.BackColor = Color.FromArgb(41, 121, 255); 
                p.ForeColor = Color.White;
            }
        }

        private void PanelHover_Leave(object sender, EventArgs e)
        {
            if (sender is Panel p)
            {
                p.BackColor = Color.White;  
                p.ForeColor = Color.Black;
            }
        }

        private void pnlCategorias_Click(object sender, EventArgs e)
        {
            new FrmCategoria().ShowDialog();

        }

        private void pnlClientes_Click(object sender, EventArgs e)
        {
            new FrmCliente().ShowDialog();

        }


        private void pnlProductos_Click(object sender, EventArgs e)
        {
            new FrmProducto().ShowDialog();

        }





    }
}