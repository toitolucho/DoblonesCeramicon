namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteListarProductosPreciosReporte
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
            this.CRVListadoPreciosProductos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVListadoPreciosProductos
            // 
            this.CRVListadoPreciosProductos.ActiveViewIndex = -1;
            this.CRVListadoPreciosProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVListadoPreciosProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVListadoPreciosProductos.Location = new System.Drawing.Point(0, 0);
            this.CRVListadoPreciosProductos.Name = "CRVListadoPreciosProductos";
            this.CRVListadoPreciosProductos.ShowParameterPanelButton = false;
            this.CRVListadoPreciosProductos.ShowRefreshButton = false;
            this.CRVListadoPreciosProductos.Size = new System.Drawing.Size(960, 642);
            this.CRVListadoPreciosProductos.TabIndex = 0;
            this.CRVListadoPreciosProductos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteListarProductosPreciosReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 642);
            this.Controls.Add(this.CRVListadoPreciosProductos);
            this.Name = "FReporteListarProductosPreciosReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Precios de Productos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FListarProductosPreciosReporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVListadoPreciosProductos;
    }
}