namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteInventarioKardex
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
            this.CRVHistorialInventario = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVHistorialInventario
            // 
            this.CRVHistorialInventario.ActiveViewIndex = -1;
            this.CRVHistorialInventario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVHistorialInventario.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CRVHistorialInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVHistorialInventario.Location = new System.Drawing.Point(0, 0);
            this.CRVHistorialInventario.Name = "CRVHistorialInventario";
            this.CRVHistorialInventario.ShowGroupTreeButton = false;
            this.CRVHistorialInventario.ShowParameterPanelButton = false;
            this.CRVHistorialInventario.Size = new System.Drawing.Size(677, 374);
            this.CRVHistorialInventario.TabIndex = 0;
            this.CRVHistorialInventario.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteInventarioKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 374);
            this.Controls.Add(this.CRVHistorialInventario);
            this.Name = "FReporteInventarioKardex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de Productos en Inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReporteInventarioKardex_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVHistorialInventario;
    }
}