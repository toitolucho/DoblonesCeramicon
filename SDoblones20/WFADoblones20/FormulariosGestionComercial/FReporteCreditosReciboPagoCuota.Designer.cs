namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteCreditosReciboPagoCuota
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
            this.cRVCreditosReciboPagoCuota = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVCreditosReciboPagoCuota
            // 
            this.cRVCreditosReciboPagoCuota.ActiveViewIndex = -1;
            this.cRVCreditosReciboPagoCuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVCreditosReciboPagoCuota.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cRVCreditosReciboPagoCuota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVCreditosReciboPagoCuota.Location = new System.Drawing.Point(0, 0);
            this.cRVCreditosReciboPagoCuota.Name = "cRVCreditosReciboPagoCuota";
            this.cRVCreditosReciboPagoCuota.ShowGroupTreeButton = false;
            this.cRVCreditosReciboPagoCuota.Size = new System.Drawing.Size(492, 366);
            this.cRVCreditosReciboPagoCuota.TabIndex = 0;
            this.cRVCreditosReciboPagoCuota.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.cRVCreditosReciboPagoCuota.Load += new System.EventHandler(this.cRVClientes_Load);
            // 
            // FReporteCreditosReciboPagoCuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 366);
            this.Controls.Add(this.cRVCreditosReciboPagoCuota);
            this.Name = "FReporteCreditosReciboPagoCuota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibo pago cuota crédito";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVCreditosReciboPagoCuota;
    }
}