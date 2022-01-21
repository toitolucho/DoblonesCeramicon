namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteCompraProductosRecepcion
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
            this.CRVRecepcionProductos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVRecepcionProductos
            // 
            this.CRVRecepcionProductos.ActiveViewIndex = -1;
            this.CRVRecepcionProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVRecepcionProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVRecepcionProductos.Location = new System.Drawing.Point(0, 0);
            this.CRVRecepcionProductos.Name = "CRVRecepcionProductos";
            this.CRVRecepcionProductos.ShowGroupTreeButton = false;
            this.CRVRecepcionProductos.ShowParameterPanelButton = false;
            this.CRVRecepcionProductos.ShowRefreshButton = false;
            this.CRVRecepcionProductos.Size = new System.Drawing.Size(861, 607);
            this.CRVRecepcionProductos.TabIndex = 0;
            this.CRVRecepcionProductos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteCompraProductosRecepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 607);
            this.Controls.Add(this.CRVRecepcionProductos);
            this.Name = "FReporteCompraProductosRecepcion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Productos Recepcionados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteCompraProductosRecepcion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVRecepcionProductos;
    }
}