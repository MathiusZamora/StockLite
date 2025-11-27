namespace StockLite
{
    partial class FrmReportes
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
            btn_Entradas_Inventario = new Button();
            SuspendLayout();
            // 
            // btn_Entradas_Inventario
            // 
            btn_Entradas_Inventario.Location = new Point(50, 141);
            btn_Entradas_Inventario.Name = "btn_Entradas_Inventario";
            btn_Entradas_Inventario.Size = new Size(148, 38);
            btn_Entradas_Inventario.TabIndex = 0;
            btn_Entradas_Inventario.Text = "Reporte de Entradas al Inventario";
            btn_Entradas_Inventario.UseVisualStyleBackColor = true;
            btn_Entradas_Inventario.Click += btn_Entradas_Inventario_Click;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Entradas_Inventario);
            MaximizeBox = false;
            Name = "FrmReportes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reportes - StockLite";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Entradas_Inventario;
    }
}