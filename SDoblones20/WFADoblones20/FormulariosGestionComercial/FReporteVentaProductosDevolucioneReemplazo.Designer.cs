namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteVentaProductosDevolucioneReemplazo
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
            this.CRVVentasProductosReemDevo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVVentasProductosReemDevo
            // 
            this.CRVVentasProductosReemDevo.ActiveViewIndex = -1;
            this.CRVVentasProductosReemDevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVVentasProductosReemDevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVVentasProductosReemDevo.Location = new System.Drawing.Point(0, 0);
            this.CRVVentasProductosReemDevo.Name = "CRVVentasProductosReemDevo";
            this.CRVVentasProductosReemDevo.ShowGroupTreeButton = false;
            this.CRVVentasProductosReemDevo.ShowParameterPanelButton = false;
            this.CRVVentasProductosReemDevo.Size = new System.Drawing.Size(564, 451);
            this.CRVVentasProductosReemDevo.TabIndex = 0;
            this.CRVVentasProductosReemDevo.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteVentaProductosDevolucioneReemplazo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 451);
            this.Controls.Add(this.CRVVentasProductosReemDevo);
            this.Name = "FReporteVentaProductosDevolucioneReemplazo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de las Devoluciones con sus correspondientes Reemplazos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteVentaProductosDevolucioneReemplazo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVVentasProductosReemDevo;
    }
}