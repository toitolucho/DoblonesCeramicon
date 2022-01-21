namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteCompraProductosGeneral
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
            this.CRVCompraProductos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVCompraProductos
            // 
            this.CRVCompraProductos.ActiveViewIndex = -1;
            this.CRVCompraProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVCompraProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVCompraProductos.Location = new System.Drawing.Point(0, 0);
            this.CRVCompraProductos.Name = "CRVCompraProductos";
            this.CRVCompraProductos.ShowGroupTreeButton = false;
            this.CRVCompraProductos.ShowParameterPanelButton = false;
            this.CRVCompraProductos.Size = new System.Drawing.Size(292, 266);
            this.CRVCompraProductos.TabIndex = 0;
            this.CRVCompraProductos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteCompraProductosGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.CRVCompraProductos);
            this.Name = "FReporteCompraProductosGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Compra de Productos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVCompraProductos;
    }
}