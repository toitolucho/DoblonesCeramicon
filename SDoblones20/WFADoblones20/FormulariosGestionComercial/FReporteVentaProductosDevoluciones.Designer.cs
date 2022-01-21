namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteVentaProductosDevoluciones
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
            this.CRVProductosDevoluciones = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVProductosDevoluciones
            // 
            this.CRVProductosDevoluciones.ActiveViewIndex = -1;
            this.CRVProductosDevoluciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVProductosDevoluciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVProductosDevoluciones.Location = new System.Drawing.Point(0, 0);
            this.CRVProductosDevoluciones.Name = "CRVProductosDevoluciones";
            this.CRVProductosDevoluciones.ShowGroupTreeButton = false;
            this.CRVProductosDevoluciones.ShowParameterPanelButton = false;
            this.CRVProductosDevoluciones.Size = new System.Drawing.Size(545, 426);
            this.CRVProductosDevoluciones.TabIndex = 0;
            this.CRVProductosDevoluciones.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteVentaProductosDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 426);
            this.Controls.Add(this.CRVProductosDevoluciones);
            this.Name = "FReporteVentaProductosDevoluciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Productos Devueltos de Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteVentaProductosDevoluciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVProductosDevoluciones;
    }
}