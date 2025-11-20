using StockLite.Models;
using StockLite.Services;

namespace StockLite
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        // Se ejecuta al cargar el formulario
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Crea el usuario admin/admin123 la primera vez que se ejecuta
            AuthService.CrearAdminSiNoExiste();
        }

        // Botón Ingresar
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show("Por favor ingresa usuario y contraseña.", "Datos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario? usuarioLogueado = AuthService.Login(usuario, clave);

            if (usuarioLogueado != null)
            {
                this.Hide();                                      // Oculta el login
                var principal = new FormMainMenu(usuarioLogueado);
                principal.FormClosed += (s, args) => this.Close(); // Cierra todo al cerrar principal
                principal.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClave.Clear();
                txtClave.Focus();
            }
        }

        // Permite ingresar con la tecla Enter desde el campo contraseña
        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar.PerformClick();
                e.SuppressKeyPress = true; // Evita el "ding" molesto
            }
        }

        // Opcional: botón Cancelar o cerrar con ESC
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }
    }
}