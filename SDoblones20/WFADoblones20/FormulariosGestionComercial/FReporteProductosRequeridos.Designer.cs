namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteProductosRequeridos
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
            this.CRVProductosRequeridos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVProductosRequeridos
            // 
            this.CRVProductosRequeridos.ActiveViewIndex = -1;
            this.CRVProductosRequeridos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVProductosRequeridos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVProductosRequeridos.Location = new System.Drawing.Point(0, 0);
            this.CRVProductosRequeridos.Name = "CRVProductosRequeridos";
            this.CRVProductosRequeridos.ShowGroupTreeButton = false;
            this.CRVProductosRequeridos.ShowParameterPanelButton = false;
            this.CRVProductosRequeridos.ShowRefreshButton = false;
            this.CRVProductosRequeridos.Size = new System.Drawing.Size(813, 512);
            this.CRVProductosRequeridos.TabIndex = 0;
            this.CRVProductosRequeridos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteProductosRequeridos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 512);
            this.Controls.Add(this.CRVProductosRequeridos);
            this.Name = "FReporteProductosRequeridos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos Requeridos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteProductosRequeridos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVProductosRequeridos;
    }
}