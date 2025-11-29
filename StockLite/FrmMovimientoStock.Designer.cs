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
            lblTitulo = new Label();
            panelEntrada = new Panel();
            lblTituloEntrada = new Label();
            lblProveedor = new Label();
            cmbProveedor = new ComboBox();
            lblProductoE = new Label();
            cmbProductoEntrada = new ComboBox();
            btnVerTodosE = new Button();
            lblCantidadE = new Label();
            nudCantidadE = new NumericUpDown();
            lblObsE = new Label();
            txtObsE = new TextBox();
            btnEntrada = new Button();
            panelSalida = new Panel();
            lblTituloSalida = new Label();
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            lblProductoS = new Label();
            cmbProductoSalida = new ComboBox();
            btnVerTodosS = new Button();
            lblCantidadS = new Label();
            nudCantidadS = new NumericUpDown();
            lblObsS = new Label();
            txtObsS = new TextBox();
            btnSalida = new Button();
            panelEntrada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadE).BeginInit();
            panelSalida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadS).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(31, 96, 141);
            lblTitulo.Location = new Point(329, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(343, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "MOVIMIENTOS DE STOCK";
            // 
            // panelEntrada
            // 
            panelEntrada.BackColor = Color.FromArgb(248, 249, 250);
            panelEntrada.BorderStyle = BorderStyle.FixedSingle;
            panelEntrada.Controls.Add(lblTituloEntrada);
            panelEntrada.Controls.Add(lblProveedor);
            panelEntrada.Controls.Add(cmbProveedor);
            panelEntrada.Controls.Add(lblProductoE);
            panelEntrada.Controls.Add(cmbProductoEntrada);
            panelEntrada.Controls.Add(btnVerTodosE);
            panelEntrada.Controls.Add(lblCantidadE);
            panelEntrada.Controls.Add(nudCantidadE);
            panelEntrada.Controls.Add(lblObsE);
            panelEntrada.Controls.Add(txtObsE);
            panelEntrada.Controls.Add(btnEntrada);
            panelEntrada.Location = new Point(30, 70);
            panelEntrada.Name = "panelEntrada";
            panelEntrada.Padding = new Padding(20);
            panelEntrada.Size = new Size(440, 388);
            panelEntrada.TabIndex = 1;
            // 
            // lblTituloEntrada
            // 
            lblTituloEntrada.AutoSize = true;
            lblTituloEntrada.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTituloEntrada.ForeColor = Color.FromArgb(40, 167, 69);
            lblTituloEntrada.Location = new Point(15, 15);
            lblTituloEntrada.Name = "lblTituloEntrada";
            lblTituloEntrada.Size = new Size(152, 30);
            lblTituloEntrada.TabIndex = 0;
            lblTituloEntrada.Text = "📥 ENTRADA";
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProveedor.ForeColor = Color.FromArgb(73, 80, 87);
            lblProveedor.Location = new Point(15, 55);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(69, 15);
            lblProveedor.TabIndex = 1;
            lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            cmbProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.Font = new Font("Segoe UI", 9F);
            cmbProveedor.Location = new Point(15, 75);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(400, 23);
            cmbProveedor.TabIndex = 2;
            // 
            // lblProductoE
            // 
            lblProductoE.AutoSize = true;
            lblProductoE.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductoE.ForeColor = Color.FromArgb(73, 80, 87);
            lblProductoE.Location = new Point(15, 115);
            lblProductoE.Name = "lblProductoE";
            lblProductoE.Size = new Size(61, 15);
            lblProductoE.TabIndex = 3;
            lblProductoE.Text = "Producto:";
            // 
            // cmbProductoEntrada
            // 
            cmbProductoEntrada.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProductoEntrada.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProductoEntrada.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductoEntrada.Font = new Font("Segoe UI", 9F);
            cmbProductoEntrada.Location = new Point(15, 135);
            cmbProductoEntrada.Name = "cmbProductoEntrada";
            cmbProductoEntrada.Size = new Size(340, 23);
            cmbProductoEntrada.TabIndex = 4;
            // 
            // btnVerTodosE
            // 
            btnVerTodosE.BackColor = Color.FromArgb(0, 123, 255);
            btnVerTodosE.FlatAppearance.BorderSize = 0;
            btnVerTodosE.FlatStyle = FlatStyle.Flat;
            btnVerTodosE.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnVerTodosE.ForeColor = Color.White;
            btnVerTodosE.Location = new Point(365, 135);
            btnVerTodosE.Name = "btnVerTodosE";
            btnVerTodosE.Size = new Size(50, 28);
            btnVerTodosE.TabIndex = 5;
            btnVerTodosE.Text = "🔍";
            btnVerTodosE.UseVisualStyleBackColor = false;
            // 
            // lblCantidadE
            // 
            lblCantidadE.AutoSize = true;
            lblCantidadE.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCantidadE.ForeColor = Color.FromArgb(73, 80, 87);
            lblCantidadE.Location = new Point(15, 175);
            lblCantidadE.Name = "lblCantidadE";
            lblCantidadE.Size = new Size(58, 15);
            lblCantidadE.TabIndex = 6;
            lblCantidadE.Text = "Cantidad:";
            // 
            // nudCantidadE
            // 
            nudCantidadE.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            nudCantidadE.Location = new Point(15, 195);
            nudCantidadE.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudCantidadE.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidadE.Name = "nudCantidadE";
            nudCantidadE.Size = new Size(100, 25);
            nudCantidadE.TabIndex = 7;
            nudCantidadE.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblObsE
            // 
            lblObsE.AutoSize = true;
            lblObsE.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblObsE.ForeColor = Color.FromArgb(73, 80, 87);
            lblObsE.Location = new Point(15, 235);
            lblObsE.Name = "lblObsE";
            lblObsE.Size = new Size(79, 15);
            lblObsE.TabIndex = 8;
            lblObsE.Text = "Observación:";
            // 
            // txtObsE
            // 
            txtObsE.Font = new Font("Segoe UI", 9F);
            txtObsE.Location = new Point(15, 255);
            txtObsE.Multiline = true;
            txtObsE.Name = "txtObsE";
            txtObsE.ScrollBars = ScrollBars.Vertical;
            txtObsE.Size = new Size(400, 80);
            txtObsE.TabIndex = 9;
            // 
            // btnEntrada
            // 
            btnEntrada.BackColor = Color.FromArgb(40, 167, 69);
            btnEntrada.FlatAppearance.BorderSize = 0;
            btnEntrada.FlatStyle = FlatStyle.Flat;
            btnEntrada.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEntrada.ForeColor = Color.White;
            btnEntrada.Location = new Point(15, 345);
            btnEntrada.Name = "btnEntrada";
            btnEntrada.Size = new Size(400, 34);
            btnEntrada.TabIndex = 10;
            btnEntrada.Text = " REGISTRAR ENTRADA";
            btnEntrada.UseVisualStyleBackColor = false;
            // 
            // panelSalida
            // 
            panelSalida.BackColor = Color.FromArgb(248, 249, 250);
            panelSalida.BorderStyle = BorderStyle.FixedSingle;
            panelSalida.Controls.Add(lblTituloSalida);
            panelSalida.Controls.Add(lblCliente);
            panelSalida.Controls.Add(cmbCliente);
            panelSalida.Controls.Add(lblProductoS);
            panelSalida.Controls.Add(cmbProductoSalida);
            panelSalida.Controls.Add(btnVerTodosS);
            panelSalida.Controls.Add(lblCantidadS);
            panelSalida.Controls.Add(nudCantidadS);
            panelSalida.Controls.Add(lblObsS);
            panelSalida.Controls.Add(txtObsS);
            panelSalida.Controls.Add(btnSalida);
            panelSalida.Location = new Point(530, 70);
            panelSalida.Name = "panelSalida";
            panelSalida.Padding = new Padding(20);
            panelSalida.Size = new Size(440, 388);
            panelSalida.TabIndex = 2;
            // 
            // lblTituloSalida
            // 
            lblTituloSalida.AutoSize = true;
            lblTituloSalida.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTituloSalida.ForeColor = Color.FromArgb(220, 53, 69);
            lblTituloSalida.Location = new Point(15, 15);
            lblTituloSalida.Name = "lblTituloSalida";
            lblTituloSalida.Size = new Size(126, 30);
            lblTituloSalida.TabIndex = 0;
            lblTituloSalida.Text = "📤 SALIDA";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCliente.ForeColor = Color.FromArgb(73, 80, 87);
            lblCliente.Location = new Point(15, 55);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(49, 15);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Font = new Font("Segoe UI", 9F);
            cmbCliente.Location = new Point(15, 75);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(400, 23);
            cmbCliente.TabIndex = 2;
            // 
            // lblProductoS
            // 
            lblProductoS.AutoSize = true;
            lblProductoS.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductoS.ForeColor = Color.FromArgb(73, 80, 87);
            lblProductoS.Location = new Point(15, 115);
            lblProductoS.Name = "lblProductoS";
            lblProductoS.Size = new Size(61, 15);
            lblProductoS.TabIndex = 3;
            lblProductoS.Text = "Producto:";
            // 
            // cmbProductoSalida
            // 
            cmbProductoSalida.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProductoSalida.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProductoSalida.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductoSalida.Font = new Font("Segoe UI", 9F);
            cmbProductoSalida.Location = new Point(15, 135);
            cmbProductoSalida.Name = "cmbProductoSalida";
            cmbProductoSalida.Size = new Size(340, 23);
            cmbProductoSalida.TabIndex = 4;
            // 
            // btnVerTodosS
            // 
            btnVerTodosS.BackColor = Color.FromArgb(0, 123, 255);
            btnVerTodosS.FlatAppearance.BorderSize = 0;
            btnVerTodosS.FlatStyle = FlatStyle.Flat;
            btnVerTodosS.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnVerTodosS.ForeColor = Color.White;
            btnVerTodosS.Location = new Point(365, 135);
            btnVerTodosS.Name = "btnVerTodosS";
            btnVerTodosS.Size = new Size(50, 28);
            btnVerTodosS.TabIndex = 5;
            btnVerTodosS.Text = "🔍";
            btnVerTodosS.UseVisualStyleBackColor = false;
            // 
            // lblCantidadS
            // 
            lblCantidadS.AutoSize = true;
            lblCantidadS.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCantidadS.ForeColor = Color.FromArgb(73, 80, 87);
            lblCantidadS.Location = new Point(15, 175);
            lblCantidadS.Name = "lblCantidadS";
            lblCantidadS.Size = new Size(58, 15);
            lblCantidadS.TabIndex = 6;
            lblCantidadS.Text = "Cantidad:";
            // 
            // nudCantidadS
            // 
            nudCantidadS.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            nudCantidadS.Location = new Point(15, 195);
            nudCantidadS.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudCantidadS.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidadS.Name = "nudCantidadS";
            nudCantidadS.Size = new Size(100, 25);
            nudCantidadS.TabIndex = 7;
            nudCantidadS.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblObsS
            // 
            lblObsS.AutoSize = true;
            lblObsS.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblObsS.ForeColor = Color.FromArgb(73, 80, 87);
            lblObsS.Location = new Point(15, 235);
            lblObsS.Name = "lblObsS";
            lblObsS.Size = new Size(79, 15);
            lblObsS.TabIndex = 8;
            lblObsS.Text = "Observación:";
            // 
            // txtObsS
            // 
            txtObsS.Font = new Font("Segoe UI", 9F);
            txtObsS.Location = new Point(15, 255);
            txtObsS.Multiline = true;
            txtObsS.Name = "txtObsS";
            txtObsS.ScrollBars = ScrollBars.Vertical;
            txtObsS.Size = new Size(400, 80);
            txtObsS.TabIndex = 9;
            // 
            // btnSalida
            // 
            btnSalida.BackColor = Color.FromArgb(220, 53, 69);
            btnSalida.FlatAppearance.BorderSize = 0;
            btnSalida.FlatStyle = FlatStyle.Flat;
            btnSalida.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSalida.ForeColor = Color.White;
            btnSalida.Location = new Point(15, 345);
            btnSalida.Name = "btnSalida";
            btnSalida.Size = new Size(400, 34);
            btnSalida.TabIndex = 10;
            btnSalida.Text = " REGISTRAR SALIDA";
            btnSalida.UseVisualStyleBackColor = false;
            // 
            // FrmMovimientoStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
            Controls.Add(lblTitulo);
            Controls.Add(panelEntrada);
            Controls.Add(panelSalida);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMovimientoStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "📦 Movimientos de Stock - StockLite";
            panelEntrada.ResumeLayout(false);
            panelEntrada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadE).EndInit();
            panelSalida.ResumeLayout(false);
            panelSalida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadS).EndInit();
            ResumeLayout(false);
            PerformLayout();

            btnVerTodosE.Click += btnVerTodosE_Click;
            btnVerTodosS.Click += btnVerTodosS_Click;
            btnEntrada.Click += btnEntrada_Click;
            btnSalida.Click += btnSalida_Click;
            cmbProductoEntrada.SelectedIndexChanged += cmbProductoEntrada_SelectedIndexChanged;
            cmbProductoSalida.SelectedIndexChanged += cmbProductoSalida_SelectedIndexChanged;
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
        private Panel panelEntrada;
        private Panel panelSalida;
        private Label lblTitulo;
        private Label lblProveedor;
    }
}