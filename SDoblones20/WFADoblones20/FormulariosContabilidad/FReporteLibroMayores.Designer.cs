namespace WFADoblones20.FormulariosContabilidad
{
    partial class FReporteLibroMayores
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
            this.crvLibroMayores = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvLibroMayores
            // 
            this.crvLibroMayores.ActiveViewIndex = -1;
            this.crvLibroMayores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvLibroMayores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvLibroMayores.Location = new System.Drawing.Point(0, 0);
            this.crvLibroMayores.Name = "crvLibroMayores";
            this.crvLibroMayores.SelectionFormula = "";
            this.crvLibroMayores.ShowGroupTreeButton = false;
            this.crvLibroMayores.Size = new System.Drawing.Size(632, 446);
            this.crvLibroMayores.TabIndex = 0;
            this.crvLibroMayores.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvLibroMayores.ViewTimeSelectionFormula = "";
            // 
            // FReporteLibroMayores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.crvLibroMayores);
            this.Name = "FReporteLibroMayores";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libro mayores";
            this.Load += new System.EventHandler(this.FReporteLibroMayores_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvLibroMayores;
    }
}