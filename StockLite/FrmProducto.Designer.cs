namespace StockLite
{
    partial class FrmProducto
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
            label5 = new Label();
            btnCancelar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            cmbCategoria = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtVenta = new TextBox();
            txtCosto = new TextBox();
            txtNombre = new TextBox();
            txtCodigo = new TextBox();
            dgvProductos = new DataGridView();
            txtBuscar = new TextBox();
            label6 = new Label();
            btnLimpiarBusqueda = new Button();
            label7 = new Label();
            cmbCategoriaFiltro = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(337, 400);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 30;
            label5.Text = "Categoria";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(559, 426);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 29;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(255, 128, 128);
            btnEliminar.Location = new Point(464, 426);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 28;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(0, 192, 0);
            btnGuardar.Location = new Point(367, 426);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 27;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(0, 192, 192);
            btnNuevo.Location = new Point(267, 426);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 26;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(398, 397);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(100, 23);
            cmbCategoria.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(665, 400);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 24;
            label4.Text = "Venta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(518, 400);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 23;
            label3.Text = "Costo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 400);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 22;
            label2.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 400);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 21;
            label1.Text = "Codigo";
            // 
            // txtVenta
            // 
            txtVenta.Location = new Point(705, 397);
            txtVenta.Name = "txtVenta";
            txtVenta.Size = new Size(100, 23);
            txtVenta.TabIndex = 20;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(559, 397);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(100, 23);
            txtCosto.TabIndex = 19;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(225, 397);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 18;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(60, 397);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 17;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 32);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(800, 359);
            dgvProductos.TabIndex = 16;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(200, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(100, 23);
            txtBuscar.TabIndex = 31;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 6);
            label6.Name = "label6";
            label6.Size = new Size(158, 15);
            label6.TabIndex = 32;
            label6.Text = "Buscar por código o nombre";
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Location = new Point(655, 4);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(65, 23);
            btnLimpiarBusqueda.TabIndex = 33;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            btnLimpiarBusqueda.Click += btnLimpiarBusqueda_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(313, 6);
            label7.Name = "label7";
            label7.Size = new Size(115, 15);
            label7.TabIndex = 34;
            label7.Text = "Filtrar por categorias";
            // 
            // cmbCategoriaFiltro
            // 
            cmbCategoriaFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoriaFiltro.FormattingEnabled = true;
            cmbCategoriaFiltro.Location = new Point(435, 4);
            cmbCategoriaFiltro.Name = "cmbCategoriaFiltro";
            cmbCategoriaFiltro.Size = new Size(121, 23);
            cmbCategoriaFiltro.TabIndex = 35;
            cmbCategoriaFiltro.SelectionChangeCommitted += cmbCategoriaFiltro_SelectionChangeCommitted;
            cmbCategoriaFiltro.TextChanged += txtBuscar_TextChanged;
            // 
            // FrmProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 461);
            Controls.Add(cmbCategoriaFiltro);
            Controls.Add(label7);
            Controls.Add(btnLimpiarBusqueda);
            Controls.Add(label6);
            Controls.Add(txtBuscar);
            Controls.Add(label5);
            Controls.Add(btnCancelar);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(cmbCategoria);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtVenta);
            Controls.Add(txtCosto);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Controls.Add(dgvProductos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmProducto";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Productos - StockLite";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Button btnCancelar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnNuevo;
        private ComboBox cmbCategoria;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtVenta;
        private TextBox txtCosto;
        private TextBox txtNombre;
        private TextBox txtCodigo;
        private DataGridView dgvProductos;
        private TextBox txtBuscar;
        private Label label6;
        private Button btnLimpiarBusqueda;
        private Label label7;
        private ComboBox cmbCategoriaFiltro;
    }
}