namespace WFADoblones20.FormulariosContabilidad
{
    partial class FReporteCuentasPorCobrar
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
            this.crvCuentasPorCobrar = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCuentasPorCobrar
            // 
            this.crvCuentasPorCobrar.ActiveViewIndex = -1;
            this.crvCuentasPorCobrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCuentasPorCobrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCuentasPorCobrar.Location = new System.Drawing.Point(0, 0);
            this.crvCuentasPorCobrar.Name = "crvCuentasPorCobrar";
            this.crvCuentasPorCobrar.Size = new System.Drawing.Size(784, 562);
            this.crvCuentasPorCobrar.TabIndex = 0;
            this.crvCuentasPorCobrar.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteCuentasPorCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.crvCuentasPorCobrar);
            this.Name = "FReporteCuentasPorCobrar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas por cobrar";
            this.Load += new System.EventHandler(this.FReporteCuentasPorCobrar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCuentasPorCobrar;
    }
}