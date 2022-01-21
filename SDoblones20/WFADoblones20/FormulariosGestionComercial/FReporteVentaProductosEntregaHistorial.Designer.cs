namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteVentaProductosEntregaHistorial
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
            this.CRVHistorialProductosEntregados = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVHistorialProductosEntregados
            // 
            this.CRVHistorialProductosEntregados.ActiveViewIndex = -1;
            this.CRVHistorialProductosEntregados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVHistorialProductosEntregados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVHistorialProductosEntregados.Location = new System.Drawing.Point(0, 0);
            this.CRVHistorialProductosEntregados.Name = "CRVHistorialProductosEntregados";
            this.CRVHistorialProductosEntregados.ShowGroupTreeButton = false;
            this.CRVHistorialProductosEntregados.ShowParameterPanelButton = false;
            this.CRVHistorialProductosEntregados.ShowRefreshButton = false;
            this.CRVHistorialProductosEntregados.Size = new System.Drawing.Size(867, 546);
            this.CRVHistorialProductosEntregados.TabIndex = 0;
            this.CRVHistorialProductosEntregados.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteVentaProductosEntregaHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 546);
            this.Controls.Add(this.CRVHistorialProductosEntregados);
            this.Name = "FReporteVentaProductosEntregaHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FReporteVentaProductosEntregaHistorial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteVentaProductosEntregaHistorial_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVHistorialProductosEntregados;
    }
}