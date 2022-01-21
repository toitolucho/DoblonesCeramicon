namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteCreditosPagosRealizados
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
            this.cRVCreditosPagosRealizados = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVCreditosPagosRealizados
            // 
            this.cRVCreditosPagosRealizados.ActiveViewIndex = -1;
            this.cRVCreditosPagosRealizados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVCreditosPagosRealizados.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cRVCreditosPagosRealizados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVCreditosPagosRealizados.Location = new System.Drawing.Point(0, 0);
            this.cRVCreditosPagosRealizados.Name = "cRVCreditosPagosRealizados";
            this.cRVCreditosPagosRealizados.ShowGroupTreeButton = false;
            this.cRVCreditosPagosRealizados.Size = new System.Drawing.Size(492, 366);
            this.cRVCreditosPagosRealizados.TabIndex = 0;
            this.cRVCreditosPagosRealizados.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.cRVCreditosPagosRealizados.Load += new System.EventHandler(this.cRVClientes_Load);
            // 
            // FReporteCreditosPagosRealizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 366);
            this.Controls.Add(this.cRVCreditosPagosRealizados);
            this.Name = "FReporteCreditosPagosRealizados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibo pago cuota crédito";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVCreditosPagosRealizados;
    }
}