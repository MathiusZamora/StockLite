namespace StockLite
{
    partial class FrmEntradaMovimientoStock
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
            panelEntrada = new Panel();
            txt_NumeroRequiza = new TextBox();
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
            gridRequiza = new DataGridView();
            panelEntrada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridRequiza).BeginInit();
            SuspendLayout();
            // 
            // panelEntrada
            // 
            panelEntrada.BackColor = Color.AliceBlue;
            panelEntrada.BorderStyle = BorderStyle.FixedSingle;
            panelEntrada.Controls.Add(txt_NumeroRequiza);
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
            panelEntrada.Location = new Point(12, 12);
            panelEntrada.Name = "panelEntrada";
            panelEntrada.Padding = new Padding(20);
            panelEntrada.Size = new Size(440, 439);
            panelEntrada.TabIndex = 2;
            // 
            // txt_NumeroRequiza
            // 
            txt_NumeroRequiza.Enabled = false;
            txt_NumeroRequiza.Location = new Point(15, 52);
            txt_NumeroRequiza.Name = "txt_NumeroRequiza";
            txt_NumeroRequiza.Size = new Size(399, 23);
            txt_NumeroRequiza.TabIndex = 11;
            txt_NumeroRequiza.Text = "0";
            // 
            // lblTituloEntrada
            // 
            lblTituloEntrada.AutoSize = true;
            lblTituloEntrada.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTituloEntrada.ForeColor = Color.FromArgb(40, 167, 69);
            lblTituloEntrada.Location = new Point(35, -1);
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
            lblProveedor.Location = new Point(35, 93);
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
            cmbProveedor.Location = new Point(15, 121);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(400, 23);
            cmbProveedor.TabIndex = 2;
            // 
            // lblProductoE
            // 
            lblProductoE.AutoSize = true;
            lblProductoE.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductoE.ForeColor = Color.FromArgb(73, 80, 87);
            lblProductoE.Location = new Point(32, 163);
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
            cmbProductoEntrada.Location = new Point(15, 181);
            cmbProductoEntrada.Name = "cmbProductoEntrada";
            cmbProductoEntrada.Size = new Size(340, 23);
            cmbProductoEntrada.TabIndex = 4;
            cmbProductoEntrada.SelectedIndexChanged += cmbProductoEntrada_SelectedIndexChanged;
            // 
            // btnVerTodosE
            // 
            btnVerTodosE.BackColor = Color.FromArgb(0, 123, 255);
            btnVerTodosE.FlatAppearance.BorderSize = 0;
            btnVerTodosE.FlatStyle = FlatStyle.Flat;
            btnVerTodosE.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnVerTodosE.ForeColor = Color.White;
            btnVerTodosE.Location = new Point(365, 176);
            btnVerTodosE.Name = "btnVerTodosE";
            btnVerTodosE.Size = new Size(50, 28);
            btnVerTodosE.TabIndex = 5;
            btnVerTodosE.Text = "🔍";
            btnVerTodosE.UseVisualStyleBackColor = false;
            btnVerTodosE.Click += btnVerTodosE_Click;
            // 
            // lblCantidadE
            // 
            lblCantidadE.AutoSize = true;
            lblCantidadE.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCantidadE.ForeColor = Color.FromArgb(73, 80, 87);
            lblCantidadE.Location = new Point(32, 223);
            lblCantidadE.Name = "lblCantidadE";
            lblCantidadE.Size = new Size(58, 15);
            lblCantidadE.TabIndex = 6;
            lblCantidadE.Text = "Cantidad:";
            // 
            // nudCantidadE
            // 
            nudCantidadE.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            nudCantidadE.Location = new Point(15, 241);
            nudCantidadE.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
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
            lblObsE.Location = new Point(25, 283);
            lblObsE.Name = "lblObsE";
            lblObsE.Size = new Size(79, 15);
            lblObsE.TabIndex = 8;
            lblObsE.Text = "Observación:";
            // 
            // txtObsE
            // 
            txtObsE.Font = new Font("Segoe UI", 9F);
            txtObsE.Location = new Point(15, 301);
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
            btnEntrada.Location = new Point(15, 391);
            btnEntrada.Name = "btnEntrada";
            btnEntrada.Size = new Size(400, 34);
            btnEntrada.TabIndex = 10;
            btnEntrada.Text = " REGISTRAR ENTRADA";
            btnEntrada.UseVisualStyleBackColor = false;
            btnEntrada.Click += btnEntrada_Click;
            // 
            // gridRequiza
            // 
            gridRequiza.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridRequiza.Location = new Point(470, 12);
            gridRequiza.Name = "gridRequiza";
            gridRequiza.Size = new Size(249, 439);
            gridRequiza.TabIndex = 3;
            // 
            // FrmEntradaMovimientoStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(731, 463);
            Controls.Add(gridRequiza);
            Controls.Add(panelEntrada);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmEntradaMovimientoStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmEntradaMovimientoStock";
            panelEntrada.ResumeLayout(false);
            panelEntrada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadE).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridRequiza).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEntrada;
        private Label lblTituloEntrada;
        private Label lblProveedor;
        private ComboBox cmbProveedor;
        private Label lblProductoE;
        private ComboBox cmbProductoEntrada;
        private Button btnVerTodosE;
        private Label lblCantidadE;
        private NumericUpDown nudCantidadE;
        private Label lblObsE;
        private TextBox txtObsE;
        private Button btnEntrada;
        private DataGridView gridRequiza;
        private TextBox txt_NumeroRequiza;
    }
}