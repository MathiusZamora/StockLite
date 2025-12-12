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
            label7 = new Label();
            cmbProveedor = new ComboBox();
            label8 = new Label();
            button1 = new Button();
            dateTimePicker1 = new DateTimePicker();
            button2 = new Button();
            label4 = new Label();
            comboBox2 = new ComboBox();
            label3 = new Label();
            dateTimePicker2 = new DateTimePicker();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label6 = new Label();
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
            cmbProducto.Location = new Point(317, 23);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(121, 23);
            cmbProducto.TabIndex = 4;
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(506, 23);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(121, 23);
            cmbCliente.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(254, 31);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 6;
            label1.Text = "Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(456, 31);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 7;
            label2.Text = "Cliente";
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
            dgvHistorial.Size = new Size(863, 369);
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
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(cmbProveedor);
            splitContainer1.Panel1.Controls.Add(label8);
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
            splitContainer1.Panel1.Controls.Add(comboBox2);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(dateTimePicker2);
            splitContainer1.Panel1.Controls.Add(comboBox1);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvHistorial);
            splitContainer1.Panel2MinSize = 200;
            splitContainer1.Size = new Size(863, 503);
            splitContainer1.SplitterDistance = 130;
            splitContainer1.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(645, 31);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 15;
            label7.Text = "Proveedor";
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(712, 25);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(121, 23);
            cmbProveedor.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(645, 31);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 16;
            label8.Text = "Cliente";
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
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(317, 23);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(456, 31);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 7;
            label3.Text = "Cliente";
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
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(506, 23);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 5;
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(254, 31);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 6;
            label6.Text = "Producto";
            // 
            // FrmHistorialStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(863, 503);
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
        private ComboBox comboBox2;
        private Label label3;
        private DateTimePicker dateTimePicker2;
        private ComboBox comboBox1;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox cmbProveedor;
        private Label label8;
    }
}