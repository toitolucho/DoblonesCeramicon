namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteTransferenciaProductosDetalleRecepcionEnvioGeneral
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
            this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVTransferenciaProductosDetalleRecepcionEnvioGeneral
            // 
            this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral.ActiveViewIndex = -1;
            this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral.Location = new System.Drawing.Point(0, 0);
            this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral.Name = "CRVTransferenciaProductosDetalleRecepcionEnvioGeneral";
            this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral.ShowGroupTreeButton = false;
            this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral.ShowParameterPanelButton = false;
            this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral.ShowRefreshButton = false;
            this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral.Size = new System.Drawing.Size(874, 262);
            this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral.TabIndex = 0;
            this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteTransferenciaProductosDetalleRecepcionEnvioGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 262);
            this.Controls.Add(this.CRVTransferenciaProductosDetalleRecepcionEnvioGeneral);
            this.Name = "FReporteTransferenciaProductosDetalleRecepcionEnvioGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen General de Trnasferencia de Productos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteTransferenciaProductosDetalleRecepcionEnvioGeneral_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVTransferenciaProductosDetalleRecepcionEnvioGeneral;
    }
}