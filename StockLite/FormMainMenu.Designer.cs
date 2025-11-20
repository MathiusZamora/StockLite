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
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnlGestionUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            pnlGestionUsuarios.MouseEnter += pnlGestionUsuarios_MouseEnter;
            pnlGestionUsuarios.MouseLeave += pnlGestionUsuarios_MouseLeave;
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
            // FormMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(788, 518);
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
    }
}