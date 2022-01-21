namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FReporteProductosEmpresasListaDetalle
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
            this.crvProductosEmpresasListaDetalle = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvProductosEmpresasListaDetalle
            // 
            this.crvProductosEmpresasListaDetalle.ActiveViewIndex = -1;
            this.crvProductosEmpresasListaDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvProductosEmpresasListaDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvProductosEmpresasListaDetalle.Location = new System.Drawing.Point(0, 0);
            this.crvProductosEmpresasListaDetalle.Name = "crvProductosEmpresasListaDetalle";
            this.crvProductosEmpresasListaDetalle.ShowGroupTreeButton = false;
            this.crvProductosEmpresasListaDetalle.Size = new System.Drawing.Size(632, 446);
            this.crvProductosEmpresasListaDetalle.TabIndex = 0;
            this.crvProductosEmpresasListaDetalle.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteProductosEmpresasListaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.crvProductosEmpresasListaDetalle);
            this.Name = "FReporteProductosEmpresasListaDetalle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lists de productos";
            this.Load += new System.EventHandler(this.FReporteProductosEmpresasListaDetalle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvProductosEmpresasListaDetalle;
    }
}