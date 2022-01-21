namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteVentaProductoReemplazo
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
            this.CRVVentasProductosReemplazo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVVentasProductosReemplazo
            // 
            this.CRVVentasProductosReemplazo.ActiveViewIndex = -1;
            this.CRVVentasProductosReemplazo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVVentasProductosReemplazo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVVentasProductosReemplazo.Location = new System.Drawing.Point(0, 0);
            this.CRVVentasProductosReemplazo.Name = "CRVVentasProductosReemplazo";
            this.CRVVentasProductosReemplazo.ShowGroupTreeButton = false;
            this.CRVVentasProductosReemplazo.ShowParameterPanelButton = false;
            this.CRVVentasProductosReemplazo.Size = new System.Drawing.Size(748, 606);
            this.CRVVentasProductosReemplazo.TabIndex = 0;
            this.CRVVentasProductosReemplazo.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteVentaProductoReemplazo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 606);
            this.Controls.Add(this.CRVVentasProductosReemplazo);
            this.Name = "FReporteVentaProductoReemplazo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Productos Reemplazo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteVentaProductoReemplazo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVVentasProductosReemplazo;
    }
}