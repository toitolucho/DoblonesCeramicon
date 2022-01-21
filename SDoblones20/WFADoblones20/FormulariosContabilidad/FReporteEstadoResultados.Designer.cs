namespace WFADoblones20.FormulariosContabilidad
{
    partial class FReporteEstadoResultados
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
            this.crvEstadoResultados = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvEstadoResultados
            // 
            this.crvEstadoResultados.ActiveViewIndex = -1;
            this.crvEstadoResultados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvEstadoResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvEstadoResultados.Location = new System.Drawing.Point(0, 0);
            this.crvEstadoResultados.Name = "crvEstadoResultados";
            this.crvEstadoResultados.SelectionFormula = "";
            this.crvEstadoResultados.ShowGroupTreeButton = false;
            this.crvEstadoResultados.Size = new System.Drawing.Size(632, 446);
            this.crvEstadoResultados.TabIndex = 0;
            this.crvEstadoResultados.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvEstadoResultados.ViewTimeSelectionFormula = "";
            // 
            // FReporteEstadoResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.crvEstadoResultados);
            this.Name = "FReporteEstadoResultados";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estado de resultados";
            this.Load += new System.EventHandler(this.FReporteEstadoResultados_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvEstadoResultados;
    }
}