namespace StockLite
{
    partial class FrmHistorialStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            lblDesde = new Label();
            lblHasta = new Label();
            cmbProducto = new ComboBox();
            cmbCliente = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btnBuscar = new Button();
            dgvHistorial = new DataGridView();
            btnLimpiar = new Button();
            splitContainer1 = new SplitContainer();
            label19 = new Label();
            cmbmovHistorial = new ComboBox();
            label7 = new Label();
            cmbProveedor = new ComboBox();
            button1 = new Button();
            dateTimePicker1 = new DateTimePicker();
            button2 = new Button();
            label4 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label5 = new Label();
            button3 = new Button();
            dateTimePicker3 = new DateTimePicker();
            button4 = new Button();
            label11 = new Label();
            dateTimePicker4 = new DateTimePicker();
            label13 = new Label();
            button5 = new Button();
            dateTimePicker5 = new DateTimePicker();
            button6 = new Button();
            label15 = new Label();
            dateTimePicker6 = new DateTimePicker();
            label17 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // dtpDesde
            // 
            dtpDesde.CustomFormat = "";
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(102, 23);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(111, 23);
            dtpDesde.TabIndex = 0;
            // 
            // dtpHasta
            // 
            dtpHasta.CustomFormat = "";
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(102, 64);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(111, 23);
            dtpHasta.TabIndex = 1;
            dtpHasta.Value = new DateTime(2025, 11, 24, 22, 24, 42, 0);
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(57, 26);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(39, 15);
            lblDesde.TabIndex = 2;
            lblDesde.Text = "Desde";
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(59, 67);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(37, 15);
            lblHasta.TabIndex = 3;
            lblHasta.Text = "Hasta";
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(303, 23);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(121, 23);
            cmbProducto.TabIndex = 4;
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(551, 23);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(121, 23);
            cmbCliente.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(235, 31);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 6;
            label1.Text = "Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(462, 31);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 7;
            label2.Text = "Departamento";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(0, 192, 0);
            btnBuscar.ForeColor = Color.Black;
            btnBuscar.Location = new Point(363, 65);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvHistorial
            // 
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.Location = new Point(0, 0);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.Size = new Size(883, 369);
            dgvHistorial.TabIndex = 9;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(255, 128, 128);
            btnLimpiar.Location = new Point(444, 65);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label19);
            splitContainer1.Panel1.Controls.Add(cmbmovHistorial);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(cmbProveedor);
            splitContainer1.Panel1.Controls.Add(btnLimpiar);
            splitContainer1.Panel1.Controls.Add(dtpDesde);
            splitContainer1.Panel1.Controls.Add(btnBuscar);
            splitContainer1.Panel1.Controls.Add(lblDesde);
            splitContainer1.Panel1.Controls.Add(cmbProducto);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(dtpHasta);
            splitContainer1.Panel1.Controls.Add(cmbCliente);
            splitContainer1.Panel1.Controls.Add(lblHasta);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(dateTimePicker1);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(dateTimePicker2);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(dateTimePicker3);
            splitContainer1.Panel1.Controls.Add(button4);
            splitContainer1.Panel1.Controls.Add(label11);
            splitContainer1.Panel1.Controls.Add(dateTimePicker4);
            splitContainer1.Panel1.Controls.Add(label13);
            splitContainer1.Panel1.Controls.Add(button5);
            splitContainer1.Panel1.Controls.Add(dateTimePicker5);
            splitContainer1.Panel1.Controls.Add(button6);
            splitContainer1.Panel1.Controls.Add(label15);
            splitContainer1.Panel1.Controls.Add(dateTimePicker6);
            splitContainer1.Panel1.Controls.Add(label17);
            splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvHistorial);
            splitContainer1.Panel2MinSize = 200;
            splitContainer1.Size = new Size(883, 503);
            splitContainer1.SplitterDistance = 130;
            splitContainer1.TabIndex = 13;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(647, 74);
            label19.Name = "label19";
            label19.Size = new Size(92, 15);
            label19.TabIndex = 18;
            label19.Text = "N° Movimiento:";
            // 
            // cmbmovHistorial
            // 
            cmbmovHistorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbmovHistorial.FormattingEnabled = true;
            cmbmovHistorial.Location = new Point(745, 66);
            cmbmovHistorial.Name = "cmbmovHistorial";
            cmbmovHistorial.Size = new Size(121, 23);
            cmbmovHistorial.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(678, 33);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 15;
            label7.Text = "Proveedor";
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(745, 25);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(121, 23);
            cmbProveedor.TabIndex = 13;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 128, 128);
            button1.Location = new Point(444, 65);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Limpiar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnLimpiar_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "";
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(102, 23);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(111, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 192, 0);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(363, 65);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "Buscar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnBuscar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 26);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 2;
            label4.Text = "Desde";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "";
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(102, 64);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(111, 23);
            dateTimePicker2.TabIndex = 1;
            dateTimePicker2.Value = new DateTime(2025, 11, 24, 22, 24, 42, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(59, 67);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 3;
            label5.Text = "Hasta";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 128, 128);
            button3.Location = new Point(444, 65);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 12;
            button3.Text = "Limpiar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnLimpiar_Click;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.CustomFormat = "";
            dateTimePicker3.Format = DateTimePickerFormat.Short;
            dateTimePicker3.Location = new Point(102, 23);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(111, 23);
            dateTimePicker3.TabIndex = 0;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(0, 192, 0);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(363, 65);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 8;
            button4.Text = "Buscar";
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnBuscar_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(57, 26);
            label11.Name = "label11";
            label11.Size = new Size(39, 15);
            label11.TabIndex = 2;
            label11.Text = "Desde";
            // 
            // dateTimePicker4
            // 
            dateTimePicker4.CustomFormat = "";
            dateTimePicker4.Format = DateTimePickerFormat.Short;
            dateTimePicker4.Location = new Point(102, 64);
            dateTimePicker4.Name = "dateTimePicker4";
            dateTimePicker4.Size = new Size(111, 23);
            dateTimePicker4.TabIndex = 1;
            dateTimePicker4.Value = new DateTime(2025, 11, 24, 22, 24, 42, 0);
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(59, 67);
            label13.Name = "label13";
            label13.Size = new Size(37, 15);
            label13.TabIndex = 3;
            label13.Text = "Hasta";
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 128, 128);
            button5.Location = new Point(444, 65);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 12;
            button5.Text = "Limpiar";
            button5.UseVisualStyleBackColor = false;
            button5.Click += btnLimpiar_Click;
            // 
            // dateTimePicker5
            // 
            dateTimePicker5.CustomFormat = "";
            dateTimePicker5.Format = DateTimePickerFormat.Short;
            dateTimePicker5.Location = new Point(102, 23);
            dateTimePicker5.Name = "dateTimePicker5";
            dateTimePicker5.Size = new Size(111, 23);
            dateTimePicker5.TabIndex = 0;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(0, 192, 0);
            button6.ForeColor = Color.Black;
            button6.Location = new Point(363, 65);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 8;
            button6.Text = "Buscar";
            button6.UseVisualStyleBackColor = false;
            button6.Click += btnBuscar_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(57, 26);
            label15.Name = "label15";
            label15.Size = new Size(39, 15);
            label15.TabIndex = 2;
            label15.Text = "Desde";
            // 
            // dateTimePicker6
            // 
            dateTimePicker6.CustomFormat = "";
            dateTimePicker6.Format = DateTimePickerFormat.Short;
            dateTimePicker6.Location = new Point(102, 64);
            dateTimePicker6.Name = "dateTimePicker6";
            dateTimePicker6.Size = new Size(111, 23);
            dateTimePicker6.TabIndex = 1;
            dateTimePicker6.Value = new DateTime(2025, 11, 24, 22, 24, 42, 0);
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(59, 67);
            label17.Name = "label17";
            label17.Size = new Size(37, 15);
            label17.TabIndex = 3;
            label17.Text = "Hasta";
            // 
            // FrmHistorialStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(883, 503);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmHistorialStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial de Stock - StockLite";
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Label lblDesde;
        private Label lblHasta;
        private ComboBox cmbProducto;
        private ComboBox cmbCliente;
        private Label label1;
        private Label label2;
        private Button btnBuscar;
        private DataGridView dgvHistorial;
        private Button btnLimpiar;
        private SplitContainer splitContainer1;
        private Button button1;
        private DateTimePicker dateTimePicker1;
        private Button button2;
        private Label label4;
        private DateTimePicker dateTimePicker2;
        private Label label5;
        private Label label7;
        private ComboBox cmbProveedor;
        private Button button3;
        private DateTimePicker dateTimePicker3;
        private Button button4;
        private Label label11;
        private DateTimePicker dateTimePicker4;
        private Label label13;
        private Button button5;
        private DateTimePicker dateTimePicker5;
        private Button button6;
        private Label label15;
        private DateTimePicker dateTimePicker6;
        private Label label17;
        private ComboBox cmbmovHistorial;
        protected Label label19;
    }
}