namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteTransferenciaProductos
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
            this.CRVTransferenciaProductos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVTransferenciaProductos
            // 
            this.CRVTransferenciaProductos.ActiveViewIndex = -1;
            this.CRVTransferenciaProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVTransferenciaProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVTransferenciaProductos.Location = new System.Drawing.Point(0, 0);
            this.CRVTransferenciaProductos.Name = "CRVTransferenciaProductos";
            this.CRVTransferenciaProductos.ShowGroupTreeButton = false;
            this.CRVTransferenciaProductos.ShowParameterPanelButton = false;
            this.CRVTransferenciaProductos.ShowRefreshButton = false;
            this.CRVTransferenciaProductos.Size = new System.Drawing.Size(784, 543);
            this.CRVTransferenciaProductos.TabIndex = 0;
            this.CRVTransferenciaProductos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteTransferenciaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 543);
            this.Controls.Add(this.CRVTransferenciaProductos);
            this.Name = "FReporteTransferenciaProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Transferencia de Productos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteTransferenciaProductos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVTransferenciaProductos;
    }
}