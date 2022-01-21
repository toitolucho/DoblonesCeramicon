namespace WFADoblones20.FormulariosContabilidad
{
    partial class FReporteCuentasPorPagar
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
            this.crvCuentasPorPagar = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCuentasPorPagar
            // 
            this.crvCuentasPorPagar.ActiveViewIndex = -1;
            this.crvCuentasPorPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCuentasPorPagar.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCuentasPorPagar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCuentasPorPagar.Location = new System.Drawing.Point(0, 0);
            this.crvCuentasPorPagar.Name = "crvCuentasPorPagar";
            this.crvCuentasPorPagar.Size = new System.Drawing.Size(784, 562);
            this.crvCuentasPorPagar.TabIndex = 0;
            this.crvCuentasPorPagar.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvCuentasPorPagar.Load += new System.EventHandler(this.crvCuentasPorPagar_Load);
            // 
            // FReporteCuentasPorPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.crvCuentasPorPagar);
            this.Name = "FReporteCuentasPorPagar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas por pagar";
            this.Load += new System.EventHandler(this.FReporteCuentasPorPagar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCuentasPorPagar;
    }
}