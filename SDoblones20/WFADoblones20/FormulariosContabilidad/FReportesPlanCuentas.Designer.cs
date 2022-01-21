namespace WFADoblones20.FormulariosContabilidad
{
    partial class FReportesPlanCuentas
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
            this.crvPlanCuentas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvPlanCuentas
            // 
            this.crvPlanCuentas.ActiveViewIndex = -1;
            this.crvPlanCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvPlanCuentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPlanCuentas.Location = new System.Drawing.Point(1, 0);
            this.crvPlanCuentas.Name = "crvPlanCuentas";
            this.crvPlanCuentas.ShowGroupTreeButton = false;
            this.crvPlanCuentas.Size = new System.Drawing.Size(623, 442);
            this.crvPlanCuentas.TabIndex = 0;
            this.crvPlanCuentas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReportesPlanCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.crvPlanCuentas);
            this.Name = "FReportesPlanCuentas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plan de cuentas";
            this.Load += new System.EventHandler(this.FReportesPlanCuentas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPlanCuentas;
    }
}