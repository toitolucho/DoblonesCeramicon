namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReportesGestionComercialClientes
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
            this.cRVClientes = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVClientes
            // 
            this.cRVClientes.ActiveViewIndex = -1;
            this.cRVClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVClientes.Location = new System.Drawing.Point(0, 0);
            this.cRVClientes.Name = "cRVClientes";
            this.cRVClientes.Size = new System.Drawing.Size(492, 366);
            this.cRVClientes.TabIndex = 0;
            this.cRVClientes.Load += new System.EventHandler(this.cRVClientes_Load);
            // 
            // FReportesGestionComercialClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 366);
            this.Controls.Add(this.cRVClientes);
            this.Name = "FReportesGestionComercialClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportesGestionComercial clientes";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVClientes;
    }
}