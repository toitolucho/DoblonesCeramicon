namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteCotizacionesVentasProductos
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
            this.CRVCotizacionesVentasProductos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVCotizacionesVentasProductos
            // 
            this.CRVCotizacionesVentasProductos.ActiveViewIndex = -1;
            this.CRVCotizacionesVentasProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVCotizacionesVentasProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVCotizacionesVentasProductos.Location = new System.Drawing.Point(0, 0);
            this.CRVCotizacionesVentasProductos.Name = "CRVCotizacionesVentasProductos";
            this.CRVCotizacionesVentasProductos.ShowGroupTreeButton = false;
            this.CRVCotizacionesVentasProductos.ShowParameterPanelButton = false;
            this.CRVCotizacionesVentasProductos.Size = new System.Drawing.Size(719, 473);
            this.CRVCotizacionesVentasProductos.TabIndex = 0;
            this.CRVCotizacionesVentasProductos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteCotizacionesVentasProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 473);
            this.Controls.Add(this.CRVCotizacionesVentasProductos);
            this.Name = "FReporteCotizacionesVentasProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FReporteCotizacionesVentasProductos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVCotizacionesVentasProductos;
    }
}