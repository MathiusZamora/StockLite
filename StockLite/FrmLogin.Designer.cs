namespace StockLite
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            panelPrincipal = new Panel();
            pictureBox1 = new PictureBox();
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblClave = new Label();
            txtClave = new TextBox();
            btnIngresar = new Button();
            btnCancelar = new Button();
            panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.AliceBlue;
            panelPrincipal.BorderStyle = BorderStyle.FixedSingle;
            panelPrincipal.Controls.Add(pictureBox1);
            panelPrincipal.Controls.Add(lblTitulo);
            panelPrincipal.Controls.Add(lblUsuario);
            panelPrincipal.Controls.Add(txtUsuario);
            panelPrincipal.Controls.Add(lblClave);
            panelPrincipal.Controls.Add(txtClave);
            panelPrincipal.Controls.Add(btnIngresar);
            panelPrincipal.Controls.Add(btnCancelar);
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 0);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Padding = new Padding(35, 38, 35, 38);
            panelPrincipal.Size = new Size(385, 488);
            panelPrincipal.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(128, 106);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(139, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(31, 97, 141);
            lblTitulo.Location = new Point(38, 38);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(135, 37);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "StockLite";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(52, 58, 64);
            lblUsuario.Location = new Point(44, 253);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(60, 19);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.White;
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 10F);
            txtUsuario.Location = new Point(44, 277);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(298, 25);
            txtUsuario.TabIndex = 3;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClave.ForeColor = Color.FromArgb(52, 58, 64);
            lblClave.Location = new Point(44, 319);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(84, 19);
            lblClave.TabIndex = 4;
            lblClave.Text = "Contraseña";
            // 
            // txtClave
            // 
            txtClave.BackColor = Color.White;
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Font = new Font("Segoe UI", 10F);
            txtClave.Location = new Point(44, 342);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(298, 25);
            txtClave.TabIndex = 5;
            txtClave.UseSystemPasswordChar = true;
            txtClave.KeyDown += txtClave_KeyDown;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(40, 167, 69);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(44, 394);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(140, 42);
            btnIngresar.TabIndex = 6;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(108, 117, 125);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(201, 394);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 42);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 73, 94);
            ClientSize = new Size(385, 488);
            Controls.Add(panelPrincipal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StockLite - Iniciar Sesión";
            Load += FrmLogin_Load;
            KeyDown += FrmLogin_KeyDown;
            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Panel panelPrincipal;
    }
}