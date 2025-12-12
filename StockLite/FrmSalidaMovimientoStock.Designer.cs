namespace StockLite
{
    partial class FrmSalidaMovimientoStock
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
            panelSalida = new Panel();
            txt_NumeroRequiza = new TextBox();
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
            gridRequiza = new DataGridView();
            panelSalida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridRequiza).BeginInit();
            SuspendLayout();
            // 
            // panelSalida
            // 
            panelSalida.BackColor = Color.AliceBlue;
            panelSalida.BorderStyle = BorderStyle.FixedSingle;
            panelSalida.Controls.Add(txt_NumeroRequiza);
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
            panelSalida.Location = new Point(12, 26);
            panelSalida.Name = "panelSalida";
            panelSalida.Padding = new Padding(20);
            panelSalida.Size = new Size(440, 431);
            panelSalida.TabIndex = 3;
            // 
            // txt_NumeroRequiza
            // 
            txt_NumeroRequiza.Enabled = false;
            txt_NumeroRequiza.Location = new Point(16, 50);
            txt_NumeroRequiza.Name = "txt_NumeroRequiza";
            txt_NumeroRequiza.Size = new Size(399, 23);
            txt_NumeroRequiza.TabIndex = 12;
            txt_NumeroRequiza.Text = "0";
            // 
            // lblTituloSalida
            // 
            lblTituloSalida.AutoSize = true;
            lblTituloSalida.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTituloSalida.ForeColor = Color.FromArgb(220, 53, 69);
            lblTituloSalida.Location = new Point(23, 8);
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
            lblCliente.Location = new Point(35, 87);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(89, 15);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Departamento";
            // 
            // cmbCliente
            // 
            cmbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Font = new Font("Segoe UI", 9F);
            cmbCliente.Location = new Point(15, 105);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(400, 23);
            cmbCliente.TabIndex = 2;
            // 
            // lblProductoS
            // 
            lblProductoS.AutoSize = true;
            lblProductoS.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductoS.ForeColor = Color.FromArgb(73, 80, 87);
            lblProductoS.Location = new Point(35, 147);
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
            cmbProductoSalida.Location = new Point(15, 165);
            cmbProductoSalida.Name = "cmbProductoSalida";
            cmbProductoSalida.Size = new Size(340, 23);
            cmbProductoSalida.TabIndex = 4;
            cmbProductoSalida.SelectedIndexChanged += cmbProductoSalida_SelectedIndexChanged;
            // 
            // btnVerTodosS
            // 
            btnVerTodosS.BackColor = Color.FromArgb(0, 123, 255);
            btnVerTodosS.FlatAppearance.BorderSize = 0;
            btnVerTodosS.FlatStyle = FlatStyle.Flat;
            btnVerTodosS.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnVerTodosS.ForeColor = Color.White;
            btnVerTodosS.Location = new Point(365, 165);
            btnVerTodosS.Name = "btnVerTodosS";
            btnVerTodosS.Size = new Size(50, 28);
            btnVerTodosS.TabIndex = 5;
            btnVerTodosS.Text = "🔍";
            btnVerTodosS.UseVisualStyleBackColor = false;
            btnVerTodosS.Click += btnVerTodosS_Click;
            // 
            // lblCantidadS
            // 
            lblCantidadS.AutoSize = true;
            lblCantidadS.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCantidadS.ForeColor = Color.FromArgb(73, 80, 87);
            lblCantidadS.Location = new Point(35, 207);
            lblCantidadS.Name = "lblCantidadS";
            lblCantidadS.Size = new Size(58, 15);
            lblCantidadS.TabIndex = 6;
            lblCantidadS.Text = "Cantidad:";
            // 
            // nudCantidadS
            // 
            nudCantidadS.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            nudCantidadS.Location = new Point(15, 225);
            nudCantidadS.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
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
            lblObsS.Location = new Point(23, 267);
            lblObsS.Name = "lblObsS";
            lblObsS.Size = new Size(79, 15);
            lblObsS.TabIndex = 8;
            lblObsS.Text = "Observación:";
            // 
            // txtObsS
            // 
            txtObsS.Font = new Font("Segoe UI", 9F);
            txtObsS.Location = new Point(15, 285);
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
            btnSalida.Location = new Point(15, 375);
            btnSalida.Name = "btnSalida";
            btnSalida.Size = new Size(400, 34);
            btnSalida.TabIndex = 10;
            btnSalida.Text = " REGISTRAR SALIDA";
            btnSalida.UseVisualStyleBackColor = false;
            btnSalida.Click += btnSalida_Click;
            // 
            // gridRequiza
            // 
            gridRequiza.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridRequiza.Location = new Point(471, 26);
            gridRequiza.Name = "gridRequiza";
            gridRequiza.Size = new Size(249, 431);
            gridRequiza.TabIndex = 13;
            // 
            // FrmSalidaMovimientoStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(739, 472);
            Controls.Add(gridRequiza);
            Controls.Add(panelSalida);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmSalidaMovimientoStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmSalidaMovimientoStock";
            panelSalida.ResumeLayout(false);
            panelSalida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidadS).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridRequiza).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSalida;
        private Label lblTituloSalida;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Label lblProductoS;
        private ComboBox cmbProductoSalida;
        private Button btnVerTodosS;
        private Label lblCantidadS;
        private NumericUpDown nudCantidadS;
        private Label lblObsS;
        private TextBox txtObsS;
        private Button btnSalida;
        private TextBox txt_NumeroRequiza;
        private DataGridView gridRequiza;
    }
}