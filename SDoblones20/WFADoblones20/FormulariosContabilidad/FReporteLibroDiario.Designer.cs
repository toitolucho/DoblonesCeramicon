namespace WFADoblones20.FormulariosContabilidad
{
    partial class FReporteLibroDiario
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
            this.crvLibroDiario = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvLibroDiario
            // 
            this.crvLibroDiario.ActiveViewIndex = -1;
            this.crvLibroDiario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvLibroDiario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvLibroDiario.Location = new System.Drawing.Point(0, 0);
            this.crvLibroDiario.Name = "crvLibroDiario";
            this.crvLibroDiario.SelectionFormula = "";
            this.crvLibroDiario.ShowGroupTreeButton = false;
            this.crvLibroDiario.Size = new System.Drawing.Size(632, 446);
            this.crvLibroDiario.TabIndex = 0;
            this.crvLibroDiario.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvLibroDiario.ViewTimeSelectionFormula = "";
            // 
            // FReporteLibroDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.crvLibroDiario);
            this.Name = "FReporteLibroDiario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libro diario";
            this.Load += new System.EventHandler(this.FReporteLibroDiario_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvLibroDiario;
    }
}