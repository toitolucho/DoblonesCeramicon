namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReportesGestionComercialVentasProductos
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cRVVentasProductos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(822, 445);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // cRVVentasProductos
            // 
            this.cRVVentasProductos.ActiveViewIndex = -1;
            this.cRVVentasProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVVentasProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVVentasProductos.EnableRefresh = false;
            this.cRVVentasProductos.Location = new System.Drawing.Point(0, 0);
            this.cRVVentasProductos.Name = "cRVVentasProductos";
            this.cRVVentasProductos.ShowRefreshButton = false;
            this.cRVVentasProductos.Size = new System.Drawing.Size(822, 445);
            this.cRVVentasProductos.TabIndex = 1;
            // 
            // FReportesGestionComercialVentasProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 445);
            this.Controls.Add(this.cRVVentasProductos);
            this.Controls.Add(this.crystalReportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FReportesGestionComercialVentasProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReportesGestionComercialVentasProductos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVVentasProductos;
    }
}