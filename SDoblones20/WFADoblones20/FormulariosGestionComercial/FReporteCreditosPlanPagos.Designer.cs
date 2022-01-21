namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteCreditosPlanPagos
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
            this.cRVCreditosPlanPagos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVCreditosPlanPagos
            // 
            this.cRVCreditosPlanPagos.ActiveViewIndex = -1;
            this.cRVCreditosPlanPagos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVCreditosPlanPagos.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cRVCreditosPlanPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVCreditosPlanPagos.Location = new System.Drawing.Point(0, 0);
            this.cRVCreditosPlanPagos.Name = "cRVCreditosPlanPagos";
            this.cRVCreditosPlanPagos.ShowGroupTreeButton = false;
            this.cRVCreditosPlanPagos.Size = new System.Drawing.Size(492, 366);
            this.cRVCreditosPlanPagos.TabIndex = 0;
            this.cRVCreditosPlanPagos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.cRVCreditosPlanPagos.Load += new System.EventHandler(this.cRVClientes_Load);
            // 
            // FReporteCreditosPlanPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 366);
            this.Controls.Add(this.cRVCreditosPlanPagos);
            this.Name = "FReporteCreditosPlanPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibo pago cuota crédito";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVCreditosPlanPagos;
    }
}