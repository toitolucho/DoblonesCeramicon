namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteDevolucionGeneral
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
            this.CRVVentaProductosDevolucion = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVVentaProductosDevolucion
            // 
            this.CRVVentaProductosDevolucion.ActiveViewIndex = -1;
            this.CRVVentaProductosDevolucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVVentaProductosDevolucion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVVentaProductosDevolucion.Location = new System.Drawing.Point(0, 0);
            this.CRVVentaProductosDevolucion.Name = "CRVVentaProductosDevolucion";
            this.CRVVentaProductosDevolucion.ShowGroupTreeButton = false;
            this.CRVVentaProductosDevolucion.ShowParameterPanelButton = false;
            this.CRVVentaProductosDevolucion.Size = new System.Drawing.Size(639, 514);
            this.CRVVentaProductosDevolucion.TabIndex = 0;
            this.CRVVentaProductosDevolucion.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteDevolucionGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 514);
            this.Controls.Add(this.CRVVentaProductosDevolucion);
            this.Name = "FReporteDevolucionGeneral";
            this.Text = "FReporteDevolucionGeneral";
            this.Load += new System.EventHandler(this.FReporteDevolucionGeneral_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVVentaProductosDevolucion;
    }
}