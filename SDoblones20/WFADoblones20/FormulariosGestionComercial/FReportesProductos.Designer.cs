namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReportesGestionComercialProductos
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
            this.cRVProductos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVProductos
            // 
            this.cRVProductos.ActiveViewIndex = -1;
            this.cRVProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVProductos.Location = new System.Drawing.Point(0, 0);
            this.cRVProductos.Name = "cRVProductos";
            this.cRVProductos.Size = new System.Drawing.Size(492, 366);
            this.cRVProductos.TabIndex = 0;
            this.cRVProductos.Load += new System.EventHandler(this.cRVProductos_Load);
            // 
            // FReportesGestionComercialProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 366);
            this.Controls.Add(this.cRVProductos);
            this.Name = "FReportesGestionComercialProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportesGestionComercial productos";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVProductos;
    }
}