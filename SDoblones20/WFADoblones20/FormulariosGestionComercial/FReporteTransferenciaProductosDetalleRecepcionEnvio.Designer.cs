namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteTransferenciaProductosDetalleRecepcionEnvio
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
            this.CRVTransferenciaProductosDetalleRecepcionEnvio = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVTransferenciaProductosDetalleRecepcionEnvio
            // 
            this.CRVTransferenciaProductosDetalleRecepcionEnvio.ActiveViewIndex = -1;
            this.CRVTransferenciaProductosDetalleRecepcionEnvio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVTransferenciaProductosDetalleRecepcionEnvio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVTransferenciaProductosDetalleRecepcionEnvio.Location = new System.Drawing.Point(0, 0);
            this.CRVTransferenciaProductosDetalleRecepcionEnvio.Name = "CRVTransferenciaProductosDetalleRecepcionEnvio";
            this.CRVTransferenciaProductosDetalleRecepcionEnvio.ShowGroupTreeButton = false;
            this.CRVTransferenciaProductosDetalleRecepcionEnvio.ShowParameterPanelButton = false;
            this.CRVTransferenciaProductosDetalleRecepcionEnvio.ShowRefreshButton = false;
            this.CRVTransferenciaProductosDetalleRecepcionEnvio.Size = new System.Drawing.Size(284, 262);
            this.CRVTransferenciaProductosDetalleRecepcionEnvio.TabIndex = 0;
            this.CRVTransferenciaProductosDetalleRecepcionEnvio.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteTransferenciaProductosDetalleRecepcionEnvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.CRVTransferenciaProductosDetalleRecepcionEnvio);
            this.Name = "FReporteTransferenciaProductosDetalleRecepcionEnvio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencia de Productos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteTransferenciaProductosDetalleRecepcionEnvio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVTransferenciaProductosDetalleRecepcionEnvio;
    }
}