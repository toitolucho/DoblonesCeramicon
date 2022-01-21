namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReportesVentasProductosPorClientes
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
            this.CRVVentasProductosPorCliente = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVVentasProductosPorCliente
            // 
            this.CRVVentasProductosPorCliente.ActiveViewIndex = -1;
            this.CRVVentasProductosPorCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVVentasProductosPorCliente.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CRVVentasProductosPorCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVVentasProductosPorCliente.Location = new System.Drawing.Point(0, 0);
            this.CRVVentasProductosPorCliente.Name = "CRVVentasProductosPorCliente";
            this.CRVVentasProductosPorCliente.ShowGroupTreeButton = false;
            this.CRVVentasProductosPorCliente.ShowParameterPanelButton = false;
            this.CRVVentasProductosPorCliente.ShowRefreshButton = false;
            this.CRVVentasProductosPorCliente.Size = new System.Drawing.Size(669, 379);
            this.CRVVentasProductosPorCliente.TabIndex = 0;
            this.CRVVentasProductosPorCliente.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReportesVentasProductosPorClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 379);
            this.Controls.Add(this.CRVVentasProductosPorCliente);
            this.Name = "FReportesVentasProductosPorClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Ventas Agrupados por Clientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReportesVentasProductosPorClientes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVVentasProductosPorCliente;
    }
}