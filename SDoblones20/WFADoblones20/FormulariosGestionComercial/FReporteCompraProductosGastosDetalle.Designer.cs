namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteCompraProductosGastosDetalle
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
            this.CRVCompraProductosGastosDetalle = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVCompraProductosGastosDetalle
            // 
            this.CRVCompraProductosGastosDetalle.ActiveViewIndex = -1;
            this.CRVCompraProductosGastosDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVCompraProductosGastosDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVCompraProductosGastosDetalle.Location = new System.Drawing.Point(0, 0);
            this.CRVCompraProductosGastosDetalle.Name = "CRVCompraProductosGastosDetalle";
            this.CRVCompraProductosGastosDetalle.ShowGroupTreeButton = false;
            this.CRVCompraProductosGastosDetalle.ShowParameterPanelButton = false;
            this.CRVCompraProductosGastosDetalle.ShowRefreshButton = false;
            this.CRVCompraProductosGastosDetalle.Size = new System.Drawing.Size(800, 476);
            this.CRVCompraProductosGastosDetalle.TabIndex = 0;
            this.CRVCompraProductosGastosDetalle.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteCompraProductosGastosDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.CRVCompraProductosGastosDetalle);
            this.Name = "FReporteCompraProductosGastosDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Gastos Por Compra de Productos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteCompraProductosGastosDetalle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVCompraProductosGastosDetalle;
    }
}