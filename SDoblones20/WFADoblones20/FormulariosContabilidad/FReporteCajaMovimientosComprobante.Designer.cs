namespace WFADoblones20.FormulariosContabilidad
{
    partial class FReporteCajaMovimientosComprobante
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
            this.crvCajaMovimientoDetalle = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCajaMovimientoDetalle
            // 
            this.crvCajaMovimientoDetalle.ActiveViewIndex = -1;
            this.crvCajaMovimientoDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCajaMovimientoDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCajaMovimientoDetalle.Location = new System.Drawing.Point(0, 0);
            this.crvCajaMovimientoDetalle.Name = "crvCajaMovimientoDetalle";
            this.crvCajaMovimientoDetalle.ShowGroupTreeButton = false;
            this.crvCajaMovimientoDetalle.Size = new System.Drawing.Size(632, 446);
            this.crvCajaMovimientoDetalle.TabIndex = 0;
            this.crvCajaMovimientoDetalle.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FReporteCajaMovimientosComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.crvCajaMovimientoDetalle);
            this.Name = "FReporteCajaMovimientosComprobante";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimiento de caja";
            this.Load += new System.EventHandler(this.FReporteCajaMovimientosDetalle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCajaMovimientoDetalle;
    }
}