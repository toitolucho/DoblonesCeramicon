namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteInventarioGeneral
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
            this.CRVInventarioGeneral = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVInventarioGeneral
            // 
            this.CRVInventarioGeneral.ActiveViewIndex = -1;
            this.CRVInventarioGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVInventarioGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVInventarioGeneral.Location = new System.Drawing.Point(0, 0);
            this.CRVInventarioGeneral.Name = "CRVInventarioGeneral";
            this.CRVInventarioGeneral.ShowGroupTreeButton = false;
            this.CRVInventarioGeneral.ShowParameterPanelButton = false;
            this.CRVInventarioGeneral.Size = new System.Drawing.Size(659, 479);
            this.CRVInventarioGeneral.TabIndex = 0;
            this.CRVInventarioGeneral.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteInventarioGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 479);
            this.Controls.Add(this.CRVInventarioGeneral);
            this.Name = "FReporteInventarioGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe de Productos en Inventario General";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteInventarioGeneral_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVInventarioGeneral;
    }
}