namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReportesVentasAgrupaciones
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
            this.CRVVentasGrupos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVVentasGrupos
            // 
            this.CRVVentasGrupos.ActiveViewIndex = -1;
            this.CRVVentasGrupos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVVentasGrupos.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CRVVentasGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVVentasGrupos.Location = new System.Drawing.Point(0, 0);
            this.CRVVentasGrupos.Name = "CRVVentasGrupos";
            this.CRVVentasGrupos.ShowGroupTreeButton = false;
            this.CRVVentasGrupos.ShowParameterPanelButton = false;
            this.CRVVentasGrupos.Size = new System.Drawing.Size(787, 424);
            this.CRVVentasGrupos.TabIndex = 0;
            this.CRVVentasGrupos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReportesVentasAgrupaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 424);
            this.Controls.Add(this.CRVVentasGrupos);
            this.Name = "FReportesVentasAgrupaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Ventas de ............";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReportesVentasAgrupaciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVVentasGrupos;
    }
}