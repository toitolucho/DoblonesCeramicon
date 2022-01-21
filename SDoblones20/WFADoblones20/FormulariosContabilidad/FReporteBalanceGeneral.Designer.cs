namespace WFADoblones20.FormulariosContabilidad
{
    partial class FReporteBalanceGeneral
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
            this.crvBalanceGeneral = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvBalanceGeneral
            // 
            this.crvBalanceGeneral.ActiveViewIndex = -1;
            this.crvBalanceGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvBalanceGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvBalanceGeneral.Location = new System.Drawing.Point(0, 0);
            this.crvBalanceGeneral.Name = "crvBalanceGeneral";
            this.crvBalanceGeneral.ShowGroupTreeButton = false;
            this.crvBalanceGeneral.Size = new System.Drawing.Size(632, 446);
            this.crvBalanceGeneral.TabIndex = 0;
            this.crvBalanceGeneral.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteBalanceGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.crvBalanceGeneral);
            this.Name = "FReporteBalanceGeneral";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balance general";
            this.Load += new System.EventHandler(this.FReporteBalanceGeneral_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBalanceGeneral;

    }
}