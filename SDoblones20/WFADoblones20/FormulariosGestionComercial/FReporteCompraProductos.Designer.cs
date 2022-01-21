namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteCompraProductos
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
            this.cRVComprasProductos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVComprasProductos
            // 
            this.cRVComprasProductos.ActiveViewIndex = -1;
            this.cRVComprasProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVComprasProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVComprasProductos.Location = new System.Drawing.Point(0, 0);
            this.cRVComprasProductos.Name = "cRVComprasProductos";
            this.cRVComprasProductos.Size = new System.Drawing.Size(749, 580);
            this.cRVComprasProductos.TabIndex = 0;
            // 
            // FReporteCompraProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 580);
            this.Controls.Add(this.cRVComprasProductos);
            this.Name = "FReporteCompraProductos";
            this.Text = "FReporteCompraProductos";
            this.Load += new System.EventHandler(this.FReporteCompraProductos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVComprasProductos;
    }
}