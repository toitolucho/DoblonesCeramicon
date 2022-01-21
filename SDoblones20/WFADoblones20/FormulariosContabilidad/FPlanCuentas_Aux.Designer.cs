namespace WFADoblones20.FormulariosContabilidad
{
    partial class FPlanCuentas_Aux
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPlanCuentas_Aux));
            this.tvPlanCuentas = new System.Windows.Forms.TreeView();
            this.ilPlanCuentas = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tvPlanCuentas
            // 
            this.tvPlanCuentas.Location = new System.Drawing.Point(12, 12);
            this.tvPlanCuentas.Name = "tvPlanCuentas";
            this.tvPlanCuentas.Size = new System.Drawing.Size(600, 418);
            this.tvPlanCuentas.TabIndex = 0;
            // 
            // ilPlanCuentas
            // 
            this.ilPlanCuentas.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPlanCuentas.ImageStream")));
            this.ilPlanCuentas.TransparentColor = System.Drawing.Color.Transparent;
            this.ilPlanCuentas.Images.SetKeyName(0, "0.png");
            this.ilPlanCuentas.Images.SetKeyName(1, "1.png");
            this.ilPlanCuentas.Images.SetKeyName(2, "2.png");
            this.ilPlanCuentas.Images.SetKeyName(3, "3.png");
            this.ilPlanCuentas.Images.SetKeyName(4, "4.png");
            this.ilPlanCuentas.Images.SetKeyName(5, "5.png");
            // 
            // FPlanCuentas_Aux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.tvPlanCuentas);
            this.Name = "FPlanCuentas_Aux";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FPlanCuentas_Aux";
            this.Load += new System.EventHandler(this.FPlanCuentas_Aux_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvPlanCuentas;
        private System.Windows.Forms.ImageList ilPlanCuentas;
    }
}