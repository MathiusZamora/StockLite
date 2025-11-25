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
            pictureBox4 = new PictureBox();
            pnlProductos = new Panel();
            label4 = new Label();
            pnlStock = new Panel();
            pictureBox5 = new PictureBox();
            label5 = new Label();
            pnlProveedores = new Panel();
            pictureBox6 = new PictureBox();
            label6 = new Label();
            pnlHistorial = new Panel();
            pictureBox7 = new PictureBox();
            label7 = new Label();
            pnlReportes = new Panel();
            pictureBox8 = new PictureBox();
            label8 = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnlGestionUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            pnlClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            pnlProductos.SuspendLayout();
            pnlStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            pnlProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            pnlHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            pnlReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
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
            pnlGestionUsuarios.Size = new Size(152, 171);
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
            pictureBox1.Size = new Size(77, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pnlGestionUsuarios_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(6, 113);
            label1.Name = "label1";
            label1.Size = new Size(141, 19);
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
            pnlCategorias.Location = new Point(212, 58);
            pnlCategorias.Name = "pnlCategorias";
            pnlCategorias.Size = new Size(150, 171);
            pnlCategorias.TabIndex = 2;
            pnlCategorias.Click += pnlCategorias_Click;
            pnlCategorias.MouseEnter += PanelHover_Enter;
            pnlCategorias.MouseLeave += PanelHover_Leave;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.categories;
            pictureBox2.Location = new Point(40, 15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(69, 76);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pnlCategorias_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(38, 113);
            label2.Name = "label2";
            label2.Size = new Size(81, 19);
            label2.TabIndex = 1;
            label2.Text = "Categorias";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.newcustomer;
            pictureBox3.Location = new Point(38, 15);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(77, 76);
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
            pnlClientes.Location = new Point(400, 58);
            pnlClientes.Name = "pnlClientes";
            pnlClientes.Size = new Size(152, 171);
            pnlClientes.TabIndex = 3;
            pnlClientes.Click += pnlClientes_Click;
            pnlClientes.MouseEnter += PanelHover_Enter;
            pnlClientes.MouseLeave += PanelHover_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(45, 113);
            label3.Name = "label3";
            label3.Size = new Size(61, 19);
            label3.TabIndex = 1;
            label3.Text = "Clientes";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.item;
            pictureBox4.Location = new Point(37, 15);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(84, 76);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pnlProductos_Click;
            // 
            // pnlProductos
            // 
            pnlProductos.BackColor = Color.White;
            pnlProductos.BorderStyle = BorderStyle.FixedSingle;
            pnlProductos.Controls.Add(pictureBox4);
            pnlProductos.Controls.Add(label4);
            pnlProductos.Cursor = Cursors.Hand;
            pnlProductos.Location = new Point(35, 292);
            pnlProductos.Name = "pnlProductos";
            pnlProductos.Size = new Size(152, 171);
            pnlProductos.TabIndex = 4;
            pnlProductos.Click += pnlProductos_Click;
            pnlProductos.MouseEnter += PanelHover_Enter;
            pnlProductos.MouseLeave += PanelHover_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(40, 112);
            label4.Name = "label4";
            label4.Size = new Size(77, 19);
            label4.TabIndex = 1;
            label4.Text = "Productos";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlStock
            // 
            pnlStock.BackColor = Color.White;
            pnlStock.BorderStyle = BorderStyle.FixedSingle;
            pnlStock.Controls.Add(pictureBox5);
            pnlStock.Controls.Add(label5);
            pnlStock.Cursor = Cursors.Hand;
            pnlStock.Location = new Point(212, 292);
            pnlStock.Name = "pnlStock";
            pnlStock.Size = new Size(150, 171);
            pnlStock.TabIndex = 5;
            pnlStock.Click += pnlStock_Click;
            pnlStock.MouseEnter += PanelHover_Enter;
            pnlStock.MouseLeave += PanelHover_Leave;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.iconstock;
            pictureBox5.Location = new Point(38, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(75, 94);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pnlStock_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(-2, 112);
            label5.Name = "label5";
            label5.Size = new Size(152, 19);
            label5.TabIndex = 1;
            label5.Text = "Movimiento de Stock";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlProveedores
            // 
            pnlProveedores.BackColor = Color.White;
            pnlProveedores.BorderStyle = BorderStyle.FixedSingle;
            pnlProveedores.Controls.Add(pictureBox6);
            pnlProveedores.Controls.Add(label6);
            pnlProveedores.Cursor = Cursors.Hand;
            pnlProveedores.Location = new Point(585, 58);
            pnlProveedores.Name = "pnlProveedores";
            pnlProveedores.Size = new Size(152, 171);
            pnlProveedores.TabIndex = 4;
            pnlProveedores.Click += pnlProveedores_Click;
            pnlProveedores.MouseEnter += PanelHover_Enter;
            pnlProveedores.MouseLeave += PanelHover_Leave;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.proveedores;
            pictureBox6.Location = new Point(36, 15);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(87, 86);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 0;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pnlProveedores_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(30, 113);
            label6.Name = "label6";
            label6.Size = new Size(95, 19);
            label6.TabIndex = 1;
            label6.Text = "Proveedores";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHistorial
            // 
            pnlHistorial.BackColor = Color.White;
            pnlHistorial.BorderStyle = BorderStyle.FixedSingle;
            pnlHistorial.Controls.Add(pictureBox7);
            pnlHistorial.Controls.Add(label7);
            pnlHistorial.Cursor = Cursors.Hand;
            pnlHistorial.Location = new Point(400, 292);
            pnlHistorial.Name = "pnlHistorial";
            pnlHistorial.Size = new Size(152, 171);
            pnlHistorial.TabIndex = 4;
            pnlHistorial.Click += pnlHistorial_Click;
            pnlHistorial.MouseEnter += PanelHover_Enter;
            pnlHistorial.MouseLeave += PanelHover_Leave;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.historial;
            pictureBox7.Location = new Point(38, 15);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(77, 76);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 0;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pnlHistorial_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(12, 112);
            label7.Name = "label7";
            label7.Size = new Size(128, 19);
            label7.TabIndex = 1;
            label7.Text = "Historial de Stock";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlReportes
            // 
            pnlReportes.BackColor = Color.White;
            pnlReportes.BorderStyle = BorderStyle.FixedSingle;
            pnlReportes.Controls.Add(pictureBox8);
            pnlReportes.Controls.Add(label8);
            pnlReportes.Cursor = Cursors.Hand;
            pnlReportes.Location = new Point(585, 292);
            pnlReportes.Name = "pnlReportes";
            pnlReportes.Size = new Size(152, 171);
            pnlReportes.TabIndex = 4;
            pnlReportes.Click += pnlReportes_Click;
            pnlReportes.MouseEnter += PanelHover_Enter;
            pnlReportes.MouseLeave += PanelHover_Leave;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = Properties.Resources.reporte;
            pictureBox8.Location = new Point(38, 15);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(77, 76);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 0;
            pictureBox8.TabStop = false;
            pictureBox8.Click += pnlReportes_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(45, 113);
            label8.Name = "label8";
            label8.Size = new Size(69, 19);
            label8.TabIndex = 1;
            label8.Text = "Reportes";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(788, 518);
            Controls.Add(pnlReportes);
            Controls.Add(pnlHistorial);
            Controls.Add(pnlProveedores);
            Controls.Add(pnlStock);
            Controls.Add(pnlProductos);
            Controls.Add(pnlClientes);
            Controls.Add(pnlCategorias);
            Controls.Add(pnlGestionUsuarios);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
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
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            pnlProductos.ResumeLayout(false);
            pnlProductos.PerformLayout();
            pnlStock.ResumeLayout(false);
            pnlStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            pnlProveedores.ResumeLayout(false);
            pnlProveedores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            pnlHistorial.ResumeLayout(false);
            pnlHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            pnlReportes.ResumeLayout(false);
            pnlReportes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
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
        private PictureBox pictureBox4;
        private Panel pnlProductos;
        private Label label4;
        private Panel pnlStock;
        private PictureBox pictureBox5;
        private Label label5;
        private Panel pnlProveedores;
        private PictureBox pictureBox6;
        private Label label6;
        private Panel pnlHistorial;
        private PictureBox pictureBox7;
        private Label label7;
        private Panel pnlReportes;
        private PictureBox pictureBox8;
        private Label label8;
    }
}