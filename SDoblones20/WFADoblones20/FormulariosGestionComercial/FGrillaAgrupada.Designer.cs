namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FGrillaAgrupada
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
            this.button1 = new System.Windows.Forms.Button();
            this.dtGVVentaProductosEspecificos = new OutlookStyleControls.OutlookGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVVentaProductosEspecificos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarProductos
            // 
            this.button1.Location = new System.Drawing.Point(245, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            //this.btnBuscarProductos.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtGVVentaProductosEspecificos
            // 
            this.dtGVVentaProductosEspecificos.CollapseIcon = null;
            this.dtGVVentaProductosEspecificos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVVentaProductosEspecificos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVVentaProductosEspecificos.ExpandIcon = null;
            this.dtGVVentaProductosEspecificos.Location = new System.Drawing.Point(0, 0);
            this.dtGVVentaProductosEspecificos.Name = "outlookGrid1";
            this.dtGVVentaProductosEspecificos.Size = new System.Drawing.Size(816, 487);
            this.dtGVVentaProductosEspecificos.TabIndex = 0;
            this.dtGVVentaProductosEspecificos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.outlookGrid1_CellClick);
            // 
            // FGrillaAgrupada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 487);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtGVVentaProductosEspecificos);
            this.Name = "FGrillaAgrupada";
            this.Text = "FGrillaAgrupada";
            this.Load += new System.EventHandler(this.FGrillaAgrupada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVVentaProductosEspecificos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OutlookStyleControls.OutlookGrid dtGVVentaProductosEspecificos;
        private System.Windows.Forms.Button button1;
    }
}