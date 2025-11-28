namespace StockLite
{
    partial class FrmMovimientoStock
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
            lblTituloEntrada = new Label();
            lblProductoE = new Label();
            cmbProductoEntrada = new ComboBox();
            btnVerTodosE = new Button();
            lblCantidadE = new Label();
            nudCantidadE = new NumericUpDown();
            lblObsE = new Label();
            txtObsE = new TextBox();
            btnEntrada = new Button();
            btnSalida = new Button();
            txtObsS = new TextBox();
            lblObsS = new Label();
            nudCantidadS = new NumericUpDown();
            lblCantidadS = new Label();
            btnVerTodosS = new Button();
            cmbProductoSalida = new ComboBox();
            lblProductoS = new Label();
            lblTituloSalida = new Label();
            cmbCliente = new ComboBox();
            lblCliente = new Label();
            cmbProveedor = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudCantidadE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidadS).BeginInit();
            SuspendLayout();
            // 
            // lblTituloEntrada
            // 
            lblTituloEntrada.AutoSize = true;
            lblTituloEntrada.Location = new Point(84, 33);
            lblTituloEntrada.Name = "lblTituloEntrada";
            lblTituloEntrada.Size = new Size(116, 15);
            lblTituloEntrada.TabIndex = 0;
            lblTituloEntrada.Text = "ENTRADA DE STOCK";
            // 
            // lblProductoE
            // 
            lblProductoE.AutoSize = true;
            lblProductoE.Location = new Point(68, 94);
            lblProductoE.Name = "lblProductoE";
            lblProductoE.Size = new Size(56, 15);
            lblProductoE.TabIndex = 1;
            lblProductoE.Text = "Producto";
            // 
            // cmbProductoEntrada
            // 
            cmbProductoEntrada.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProductoEntrada.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProductoEntrada.FormattingEnabled = true;
            cmbProductoEntrada.Location = new Point(146, 86);
            cmbProductoEntrada.Name = "cmbProductoEntrada";
            cmbProductoEntrada.Size = new Size(121, 23);
            cmbProductoEntrada.TabIndex = 2;
            cmbProductoEntrada.SelectedIndexChanged += cmbProductoEntrada_SelectedIndexChanged;
            // 
            // btnVerTodosE
            // 
            btnVerTodosE.Location = new Point(103, 55);
            btnVerTodosE.Name = "btnVerTodosE";
            btnVerTodosE.Size = new Size(75, 23);
            btnVerTodosE.TabIndex = 3;
            btnVerTodosE.Text = "Ver todos";
            btnVerTodosE.UseVisualStyleBackColor = true;
            btnVerTodosE.Click += btnVerTodosE_Click;
            // 
            // lblCantidadE
            // 
            lblCantidadE.AutoSize = true;
            lblCantidadE.Location = new Point(68, 184);
            lblCantidadE.Name = "lblCantidadE";
            lblCantidadE.Size = new Size(55, 15);
            lblCantidadE.TabIndex = 4;
            lblCantidadE.Text = "Cantidad";
            // 
            // nudCantidadE
            // 
            nudCantidadE.Location = new Point(146, 176);
            nudCantidadE.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudCantidadE.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidadE.Name = "nudCantidadE";
            nudCantidadE.Size = new Size(120, 23);
            nudCantidadE.TabIndex = 5;
            nudCantidadE.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblObsE
            // 
            lblObsE.AutoSize = true;
            lblObsE.Location = new Point(67, 242);
            lblObsE.Name = "lblObsE";
            lblObsE.Size = new Size(73, 15);
            lblObsE.TabIndex = 6;
            lblObsE.Text = "Observacion";
            // 
            // txtObsE
            // 
            txtObsE.Location = new Point(146, 234);
            txtObsE.Multiline = true;
            txtObsE.Name = "txtObsE";
            txtObsE.ScrollBars = ScrollBars.Vertical;
            txtObsE.Size = new Size(165, 23);
            txtObsE.TabIndex = 7;
            // 
            // btnEntrada
            // 
            btnEntrada.BackColor = Color.FromArgb(0, 192, 0);
            btnEntrada.Location = new Point(68, 295);
            btnEntrada.Name = "btnEntrada";
            btnEntrada.Size = new Size(137, 23);
            btnEntrada.TabIndex = 8;
            btnEntrada.Text = "Registrar Entrada";
            btnEntrada.UseVisualStyleBackColor = false;
            btnEntrada.Click += btnEntrada_Click;
            // 
            // btnSalida
            // 
            btnSalida.BackColor = Color.FromArgb(255, 128, 128);
            btnSalida.Location = new Point(460, 295);
            btnSalida.Name = "btnSalida";
            btnSalida.Size = new Size(137, 23);
            btnSalida.TabIndex = 17;
            btnSalida.Text = "Registrar Salida";
            btnSalida.UseVisualStyleBackColor = false;
            btnSalida.Click += btnSalida_Click;
            // 
            // txtObsS
            // 
            txtObsS.Location = new Point(538, 234);
            txtObsS.Multiline = true;
            txtObsS.Name = "txtObsS";
            txtObsS.ScrollBars = ScrollBars.Vertical;
            txtObsS.Size = new Size(165, 23);
            txtObsS.TabIndex = 16;
            // 
            // lblObsS
            // 
            lblObsS.AutoSize = true;
            lblObsS.Location = new Point(459, 242);
            lblObsS.Name = "lblObsS";
            lblObsS.Size = new Size(73, 15);
            lblObsS.TabIndex = 15;
            lblObsS.Text = "Observacion";
            // 
            // nudCantidadS
            // 
            nudCantidadS.Location = new Point(538, 184);
            nudCantidadS.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudCantidadS.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidadS.Name = "nudCantidadS";
            nudCantidadS.Size = new Size(120, 23);
            nudCantidadS.TabIndex = 14;
            nudCantidadS.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCantidadS
            // 
            lblCantidadS.AutoSize = true;
            lblCantidadS.Location = new Point(460, 187);
            lblCantidadS.Name = "lblCantidadS";
            lblCantidadS.Size = new Size(55, 15);
            lblCantidadS.TabIndex = 13;
            lblCantidadS.Text = "Cantidad";
            // 
            // btnVerTodosS
            // 
            btnVerTodosS.Location = new Point(493, 55);
            btnVerTodosS.Name = "btnVerTodosS";
            btnVerTodosS.Size = new Size(75, 23);
            btnVerTodosS.TabIndex = 12;
            btnVerTodosS.Text = "Ver todos";
            btnVerTodosS.UseVisualStyleBackColor = true;
            btnVerTodosS.Click += btnVerTodosS_Click;
            // 
            // cmbProductoSalida
            // 
            cmbProductoSalida.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProductoSalida.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProductoSalida.FormattingEnabled = true;
            cmbProductoSalida.Location = new Point(537, 135);
            cmbProductoSalida.Name = "cmbProductoSalida";
            cmbProductoSalida.Size = new Size(121, 23);
            cmbProductoSalida.TabIndex = 11;
            cmbProductoSalida.SelectedIndexChanged += cmbProductoSalida_SelectedIndexChanged;
            // 
            // lblProductoS
            // 
            lblProductoS.AutoSize = true;
            lblProductoS.Location = new Point(459, 138);
            lblProductoS.Name = "lblProductoS";
            lblProductoS.Size = new Size(56, 15);
            lblProductoS.TabIndex = 10;
            lblProductoS.Text = "Producto";
            // 
            // lblTituloSalida
            // 
            lblTituloSalida.AutoSize = true;
            lblTituloSalida.Location = new Point(482, 33);
            lblTituloSalida.Name = "lblTituloSalida";
            lblTituloSalida.Size = new Size(102, 15);
            lblTituloSalida.TabIndex = 9;
            lblTituloSalida.Text = "SALIDA DE STOCK";
            // 
            // cmbCliente
            // 
            cmbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(537, 86);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(121, 23);
            cmbCliente.TabIndex = 19;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(459, 94);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 18;
            lblCliente.Text = "Cliente";
            // 
            // cmbProveedor
            // 
            cmbProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(146, 130);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(121, 23);
            cmbProveedor.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 138);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 20;
            label1.Text = "Proveedor";
            // 
            // FrmMovimientoStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 400);
            Controls.Add(cmbProveedor);
            Controls.Add(label1);
            Controls.Add(cmbCliente);
            Controls.Add(lblCliente);
            Controls.Add(btnSalida);
            Controls.Add(txtObsS);
            Controls.Add(lblObsS);
            Controls.Add(nudCantidadS);
            Controls.Add(lblCantidadS);
            Controls.Add(btnVerTodosS);
            Controls.Add(cmbProductoSalida);
            Controls.Add(lblProductoS);
            Controls.Add(lblTituloSalida);
            Controls.Add(btnEntrada);
            Controls.Add(txtObsE);
            Controls.Add(lblObsE);
            Controls.Add(nudCantidadE);
            Controls.Add(lblCantidadE);
            Controls.Add(btnVerTodosE);
            Controls.Add(cmbProductoEntrada);
            Controls.Add(lblProductoE);
            Controls.Add(lblTituloEntrada);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMovimientoStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movimiento de Stock - StockLite";
            ((System.ComponentModel.ISupportInitialize)nudCantidadE).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidadS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloEntrada;
        private Label lblProductoE;
        private ComboBox cmbProductoEntrada;
        private Button btnVerTodosE;
        private Label lblCantidadE;
        private NumericUpDown nudCantidadE;
        private Label lblObsE;
        private TextBox txtObsE;
        private Button btnEntrada;
        private Button btnSalida;
        private TextBox txtObsS;
        private Label lblObsS;
        private NumericUpDown nudCantidadS;
        private Label lblCantidadS;
        private Button btnVerTodosS;
        private ComboBox cmbProductoSalida;
        private Label lblProductoS;
        private Label lblTituloSalida;
        private ComboBox cmbCliente;
        private Label lblCliente;
        private ComboBox cmbProveedor;
        private Label label1;
    }
}