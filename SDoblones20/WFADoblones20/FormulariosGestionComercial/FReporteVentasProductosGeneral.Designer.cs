namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteVentasProductosGeneral
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
            this.CRVVentasProductos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVVentasProductos
            // 
            this.CRVVentasProductos.ActiveViewIndex = -1;
            this.CRVVentasProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVVentasProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVVentasProductos.Location = new System.Drawing.Point(0, 0);
            this.CRVVentasProductos.Name = "CRVVentasProductos";
            this.CRVVentasProductos.ShowGroupTreeButton = false;
            this.CRVVentasProductos.ShowParameterPanelButton = false;
            this.CRVVentasProductos.Size = new System.Drawing.Size(744, 580);
            this.CRVVentasProductos.TabIndex = 0;
            this.CRVVentasProductos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteVentasProductosGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 580);
            this.Controls.Add(this.CRVVentasProductos);
            this.Name = "FReporteVentasProductosGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FReporteVentasProductosGeneral";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteVentasProductosGeneral_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVVentasProductos;
    }
}