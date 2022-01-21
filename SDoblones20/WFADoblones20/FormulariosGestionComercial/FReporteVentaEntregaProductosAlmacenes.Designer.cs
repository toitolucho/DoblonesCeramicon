namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteVentaEntregaProductosAlmacenes
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
            this.CRVReporteVentaEntregaProductosAlmacenes = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVReporteVentaEntregaProductosAlmacenes
            // 
            this.CRVReporteVentaEntregaProductosAlmacenes.ActiveViewIndex = -1;
            this.CRVReporteVentaEntregaProductosAlmacenes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVReporteVentaEntregaProductosAlmacenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVReporteVentaEntregaProductosAlmacenes.Location = new System.Drawing.Point(0, 0);
            this.CRVReporteVentaEntregaProductosAlmacenes.Name = "CRVReporteVentaEntregaProductosAlmacenes";
            this.CRVReporteVentaEntregaProductosAlmacenes.ShowGroupTreeButton = false;
            this.CRVReporteVentaEntregaProductosAlmacenes.ShowParameterPanelButton = false;
            this.CRVReporteVentaEntregaProductosAlmacenes.ShowRefreshButton = false;
            this.CRVReporteVentaEntregaProductosAlmacenes.Size = new System.Drawing.Size(734, 480);
            this.CRVReporteVentaEntregaProductosAlmacenes.TabIndex = 0;
            this.CRVReporteVentaEntregaProductosAlmacenes.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteVentaEntregaProductosAlmacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 480);
            this.Controls.Add(this.CRVReporteVentaEntregaProductosAlmacenes);
            this.Name = "FReporteVentaEntregaProductosAlmacenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Recojo y Pago de Productos Vendidos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteVentaEntregaProductosAlmacenes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVReporteVentaEntregaProductosAlmacenes;
    }
}