namespace StockLite
{
    partial class FormMainMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el diseñador

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            menuStrip1 = new MenuStrip();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            pnlGestionUsuarios = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pnlCategorias = new Panel();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            pictureBox3 = new PictureBox();
            pnlClientes = new Panel();
            label3 = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnlGestionUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            pnlClientes.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cerrarSesiónToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(788, 24);
            menuStrip1.TabIndex = 0;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(88, 20);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3 });
            statusStrip1.Location = new Point(0, 496);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(788, 22);
            statusStrip1.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(53, 17);
            toolStripStatusLabel1.Text = "Usuario: ";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(684, 17);
            toolStripStatusLabel2.Spring = true;
            toolStripStatusLabel2.Text = "Rol: ";
            toolStripStatusLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(38, 17);
            toolStripStatusLabel3.Text = "Fecha";
            // 
            // pnlGestionUsuarios
            // 
            pnlGestionUsuarios.BackColor = Color.White;
            pnlGestionUsuarios.BorderStyle = BorderStyle.FixedSingle;
            pnlGestionUsuarios.Controls.Add(pictureBox1);
            pnlGestionUsuarios.Controls.Add(label1);
            pnlGestionUsuarios.Cursor = Cursors.Hand;
            pnlGestionUsuarios.Location = new Point(35, 58);
            pnlGestionUsuarios.Name = "pnlGestionUsuarios";
            pnlGestionUsuarios.Size = new Size(197, 226);
            pnlGestionUsuarios.TabIndex = 0;
            pnlGestionUsuarios.Click += pnlGestionUsuarios_Click;
            pnlGestionUsuarios.MouseEnter += PanelHover_Enter;
            pnlGestionUsuarios.MouseLeave += PanelHover_Leave;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(38, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(122, 131);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pnlGestionUsuarios_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(7, 139);
            label1.Name = "label1";
            label1.Size = new Size(189, 25);
            label1.TabIndex = 1;
            label1.Text = "Gestión de Usuarios";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCategorias
            // 
            pnlCategorias.BackColor = Color.White;
            pnlCategorias.BorderStyle = BorderStyle.FixedSingle;
            pnlCategorias.Controls.Add(pictureBox2);
            pnlCategorias.Controls.Add(label2);
            pnlCategorias.Cursor = Cursors.Hand;
            pnlCategorias.Location = new Point(278, 58);
            pnlCategorias.Name = "pnlCategorias";
            pnlCategorias.Size = new Size(197, 226);
            pnlCategorias.TabIndex = 2;
            pnlCategorias.Click += pnlCategorias_Click;
            pnlCategorias.MouseEnter += PanelHover_Enter;
            pnlCategorias.MouseLeave += PanelHover_Leave;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.categories;
            pictureBox2.Location = new Point(38, 15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(122, 131);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pnlCategorias_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(54, 139);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 1;
            label2.Text = "Categorias";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.newcustomer;
            pictureBox3.Location = new Point(38, 15);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(122, 131);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pnlClientes_Click;
            // 
            // pnlClientes
            // 
            pnlClientes.BackColor = Color.White;
            pnlClientes.BorderStyle = BorderStyle.FixedSingle;
            pnlClientes.Controls.Add(pictureBox3);
            pnlClientes.Controls.Add(label3);
            pnlClientes.Cursor = Cursors.Hand;
            pnlClientes.Location = new Point(526, 58);
            pnlClientes.Name = "pnlClientes";
            pnlClientes.Size = new Size(197, 226);
            pnlClientes.TabIndex = 3;
            pnlClientes.Click += pnlClientes_Click;
            pnlClientes.MouseEnter += PanelHover_Enter;
            pnlClientes.MouseLeave += PanelHover_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(54, 139);
            label3.Name = "label3";
            label3.Size = new Size(81, 25);
            label3.TabIndex = 1;
            label3.Text = "Clientes";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(788, 518);
            Controls.Add(pnlClientes);
            Controls.Add(pnlCategorias);
            Controls.Add(pnlGestionUsuarios);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormMainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StockLite - Menú Principal";
            Load += FormMainMenu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnlGestionUsuarios.ResumeLayout(false);
            pnlGestionUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlCategorias.ResumeLayout(false);
            pnlCategorias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            pnlClientes.ResumeLayout(false);
            pnlClientes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Panel pnlGestionUsuarios;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Panel pnlCategorias;
        private PictureBox pictureBox2;
        private Label label2;
        private PictureBox pictureBox3;
        private Panel pnlClientes;
        private Label label3;
    }
}