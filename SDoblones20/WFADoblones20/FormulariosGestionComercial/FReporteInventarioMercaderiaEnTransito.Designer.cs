namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteInventarioMercaderiaEnTransito
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
            this.CRVMercaderiaEnTransito = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVMercaderiaEnTransito
            // 
            this.CRVMercaderiaEnTransito.ActiveViewIndex = -1;
            this.CRVMercaderiaEnTransito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVMercaderiaEnTransito.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVMercaderiaEnTransito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVMercaderiaEnTransito.Location = new System.Drawing.Point(0, 0);
            this.CRVMercaderiaEnTransito.Name = "CRVMercaderiaEnTransito";
            this.CRVMercaderiaEnTransito.ShowParameterPanelButton = false;
            this.CRVMercaderiaEnTransito.Size = new System.Drawing.Size(284, 262);
            this.CRVMercaderiaEnTransito.TabIndex = 0;
            this.CRVMercaderiaEnTransito.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteInventarioMercaderiaEnTransito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.CRVMercaderiaEnTransito);
            this.Name = "FReporteInventarioMercaderiaEnTransito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mercaderia en Transito";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVMercaderiaEnTransito;
    }
}