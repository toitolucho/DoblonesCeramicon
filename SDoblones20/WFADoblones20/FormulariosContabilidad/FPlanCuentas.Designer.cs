namespace WFADoblones20.FormulariosContabilidad
{
    partial class FPlanCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPlanCuentas));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbtModificar = new System.Windows.Forms.ToolStripButton();
            this.tsbtEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtImprimir = new System.Windows.Forms.ToolStripButton();
            this.tcPlanCuentas = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvPlanCuentas = new System.Windows.Forms.TreeView();
            this.cmsTvPlanCuentas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbOk = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumCta5 = new System.Windows.Forms.TextBox();
            this.tbNumCta4 = new System.Windows.Forms.TextBox();
            this.tbNumCta3 = new System.Windows.Forms.TextBox();
            this.tbNumCta2 = new System.Windows.Forms.TextBox();
            this.tbNumCta1 = new System.Windows.Forms.TextBox();
            this.chbSelCtaPadre = new System.Windows.Forms.CheckBox();
            this.tbNomCtaPadre = new System.Windows.Forms.TextBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btModificar = new System.Windows.Forms.Button();
            this.btNuevo = new System.Windows.Forms.Button();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNombreCta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mtbCtaPadre = new System.Windows.Forms.MaskedTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvPlanCuentas = new System.Windows.Forms.DataGridView();
            this.dgvcNumeroCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombreCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNumeroCuentaPadre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNivelCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDescripcionCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ilPlanCuentas = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            this.tcPlanCuentas.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmsTvPlanCuentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanCuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(704, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtNuevo,
            this.tsbtModificar,
            this.tsbtEliminar,
            this.toolStripSeparator1,
            this.tsbtImprimir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(704, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtNuevo
            // 
            this.tsbtNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtNuevo.Enabled = false;
            this.tsbtNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtNuevo.Image")));
            this.tsbtNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtNuevo.Name = "tsbtNuevo";
            this.tsbtNuevo.Size = new System.Drawing.Size(84, 22);
            this.tsbtNuevo.Text = "Nueva cuenta";
            this.tsbtNuevo.Click += new System.EventHandler(this.tsbtNuevo_Click);
            // 
            // tsbtModificar
            // 
            this.tsbtModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtModificar.Enabled = false;
            this.tsbtModificar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtModificar.Image")));
            this.tsbtModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtModificar.Name = "tsbtModificar";
            this.tsbtModificar.Size = new System.Drawing.Size(101, 22);
            this.tsbtModificar.Text = "Modificar cuenta";
            this.tsbtModificar.Click += new System.EventHandler(this.tsbtModificar_Click);
            // 
            // tsbtEliminar
            // 
            this.tsbtEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtEliminar.Enabled = false;
            this.tsbtEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtEliminar.Image")));
            this.tsbtEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtEliminar.Name = "tsbtEliminar";
            this.tsbtEliminar.Size = new System.Drawing.Size(93, 22);
            this.tsbtEliminar.Text = "Eliminar cuenta";
            this.tsbtEliminar.Click += new System.EventHandler(this.tsbtEliminar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtImprimir
            // 
            this.tsbtImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsbtImprimir.Image")));
            this.tsbtImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtImprimir.Name = "tsbtImprimir";
            this.tsbtImprimir.Size = new System.Drawing.Size(57, 22);
            this.tsbtImprimir.Text = "Imprimir";
            this.tsbtImprimir.Click += new System.EventHandler(this.tsbtImprimir_Click);
            // 
            // tcPlanCuentas
            // 
            this.tcPlanCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPlanCuentas.Controls.Add(this.tabPage1);
            this.tcPlanCuentas.Controls.Add(this.tabPage2);
            this.tcPlanCuentas.Location = new System.Drawing.Point(0, 28);
            this.tcPlanCuentas.Name = "tcPlanCuentas";
            this.tcPlanCuentas.SelectedIndex = 0;
            this.tcPlanCuentas.Size = new System.Drawing.Size(704, 389);
            this.tcPlanCuentas.TabIndex = 1;
            this.tcPlanCuentas.SelectedIndexChanged += new System.EventHandler(this.tcPlanCuentas_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(696, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vista árbol";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvPlanCuentas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbOk);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.tbNumCta5);
            this.splitContainer1.Panel2.Controls.Add(this.tbNumCta4);
            this.splitContainer1.Panel2.Controls.Add(this.tbNumCta3);
            this.splitContainer1.Panel2.Controls.Add(this.tbNumCta2);
            this.splitContainer1.Panel2.Controls.Add(this.tbNumCta1);
            this.splitContainer1.Panel2.Controls.Add(this.chbSelCtaPadre);
            this.splitContainer1.Panel2.Controls.Add(this.tbNomCtaPadre);
            this.splitContainer1.Panel2.Controls.Add(this.btCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btAceptar);
            this.splitContainer1.Panel2.Controls.Add(this.btEliminar);
            this.splitContainer1.Panel2.Controls.Add(this.btModificar);
            this.splitContainer1.Panel2.Controls.Add(this.btNuevo);
            this.splitContainer1.Panel2.Controls.Add(this.tbDescripcion);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.tbNombreCta);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.mtbCtaPadre);
            this.splitContainer1.Size = new System.Drawing.Size(690, 357);
            this.splitContainer1.SplitterDistance = 370;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvPlanCuentas
            // 
            this.tvPlanCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvPlanCuentas.ContextMenuStrip = this.cmsTvPlanCuentas;
            this.tvPlanCuentas.HideSelection = false;
            this.tvPlanCuentas.HotTracking = true;
            this.tvPlanCuentas.Location = new System.Drawing.Point(3, 3);
            this.tvPlanCuentas.Name = "tvPlanCuentas";
            this.tvPlanCuentas.Size = new System.Drawing.Size(360, 352);
            this.tvPlanCuentas.TabIndex = 0;
            this.tvPlanCuentas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPlanCuentas_AfterSelect);
            // 
            // cmsTvPlanCuentas
            // 
            this.cmsTvPlanCuentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.cmsTvPlanCuentas.Name = "cmsTvPlanCuentas";
            this.cmsTvPlanCuentas.Size = new System.Drawing.Size(126, 70);
            this.cmsTvPlanCuentas.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTvPlanCuentas_Opening);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // pbOk
            // 
            this.pbOk.Image = ((System.Drawing.Image)(resources.GetObject("pbOk.Image")));
            this.pbOk.Location = new System.Drawing.Point(240, 108);
            this.pbOk.Name = "pbOk";
            this.pbOk.Size = new System.Drawing.Size(39, 32);
            this.pbOk.TabIndex = 21;
            this.pbOk.TabStop = false;
            this.pbOk.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "-";
            // 
            // tbNumCta5
            // 
            this.tbNumCta5.Location = new System.Drawing.Point(206, 120);
            this.tbNumCta5.MaxLength = 3;
            this.tbNumCta5.Name = "tbNumCta5";
            this.tbNumCta5.ReadOnly = true;
            this.tbNumCta5.Size = new System.Drawing.Size(28, 20);
            this.tbNumCta5.TabIndex = 7;
            this.tbNumCta5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNumCta5.Leave += new System.EventHandler(this.tbNumCta5_Leave);
            this.tbNumCta5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNumCta5_KeyUp);
            this.tbNumCta5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumCta5_KeyPress);
            // 
            // tbNumCta4
            // 
            this.tbNumCta4.Location = new System.Drawing.Point(156, 120);
            this.tbNumCta4.MaxLength = 2;
            this.tbNumCta4.Name = "tbNumCta4";
            this.tbNumCta4.ReadOnly = true;
            this.tbNumCta4.Size = new System.Drawing.Size(28, 20);
            this.tbNumCta4.TabIndex = 6;
            this.tbNumCta4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNumCta4.Leave += new System.EventHandler(this.tbNumCta4_Leave);
            this.tbNumCta4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNumCta4_KeyUp);
            this.tbNumCta4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumCta4_KeyPress);
            // 
            // tbNumCta3
            // 
            this.tbNumCta3.Location = new System.Drawing.Point(106, 120);
            this.tbNumCta3.MaxLength = 2;
            this.tbNumCta3.Name = "tbNumCta3";
            this.tbNumCta3.ReadOnly = true;
            this.tbNumCta3.Size = new System.Drawing.Size(28, 20);
            this.tbNumCta3.TabIndex = 5;
            this.tbNumCta3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNumCta3.Leave += new System.EventHandler(this.tbNumCta3_Leave);
            this.tbNumCta3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNumCta3_KeyUp);
            this.tbNumCta3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumCta3_KeyPress);
            // 
            // tbNumCta2
            // 
            this.tbNumCta2.Location = new System.Drawing.Point(56, 120);
            this.tbNumCta2.MaxLength = 1;
            this.tbNumCta2.Name = "tbNumCta2";
            this.tbNumCta2.ReadOnly = true;
            this.tbNumCta2.Size = new System.Drawing.Size(28, 20);
            this.tbNumCta2.TabIndex = 4;
            this.tbNumCta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNumCta2.Leave += new System.EventHandler(this.tbNumCta2_Leave);
            this.tbNumCta2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNumCta2_KeyUp);
            this.tbNumCta2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumCta2_KeyPress);
            // 
            // tbNumCta1
            // 
            this.tbNumCta1.Location = new System.Drawing.Point(6, 120);
            this.tbNumCta1.MaxLength = 1;
            this.tbNumCta1.Name = "tbNumCta1";
            this.tbNumCta1.ReadOnly = true;
            this.tbNumCta1.Size = new System.Drawing.Size(28, 20);
            this.tbNumCta1.TabIndex = 3;
            this.tbNumCta1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNumCta1.Leave += new System.EventHandler(this.tbNumCta1_Leave);
            this.tbNumCta1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNumCta1_KeyUp);
            this.tbNumCta1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumCta1_KeyPress);
            // 
            // chbSelCtaPadre
            // 
            this.chbSelCtaPadre.AutoSize = true;
            this.chbSelCtaPadre.Enabled = false;
            this.chbSelCtaPadre.Location = new System.Drawing.Point(6, 12);
            this.chbSelCtaPadre.Name = "chbSelCtaPadre";
            this.chbSelCtaPadre.Size = new System.Drawing.Size(90, 17);
            this.chbSelCtaPadre.TabIndex = 0;
            this.chbSelCtaPadre.Text = "Cuenta padre";
            this.chbSelCtaPadre.UseVisualStyleBackColor = true;
            this.chbSelCtaPadre.CheckedChanged += new System.EventHandler(this.chbSelCtaPadre_CheckedChanged);
            // 
            // tbNomCtaPadre
            // 
            this.tbNomCtaPadre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNomCtaPadre.Location = new System.Drawing.Point(6, 61);
            this.tbNomCtaPadre.MaxLength = 250;
            this.tbNomCtaPadre.Name = "tbNomCtaPadre";
            this.tbNomCtaPadre.ReadOnly = true;
            this.tbNomCtaPadre.Size = new System.Drawing.Size(303, 20);
            this.tbNomCtaPadre.TabIndex = 2;
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Location = new System.Drawing.Point(234, 327);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 14;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAceptar.Location = new System.Drawing.Point(153, 327);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 13;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEliminar.Location = new System.Drawing.Point(234, 298);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(75, 23);
            this.btEliminar.TabIndex = 12;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btModificar
            // 
            this.btModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModificar.Location = new System.Drawing.Point(153, 298);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(75, 23);
            this.btModificar.TabIndex = 11;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btNuevo
            // 
            this.btNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNuevo.Location = new System.Drawing.Point(72, 298);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(75, 23);
            this.btNuevo.TabIndex = 10;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = true;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescripcion.Location = new System.Drawing.Point(6, 238);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.ReadOnly = true;
            this.tbDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescripcion.Size = new System.Drawing.Size(303, 54);
            this.tbDescripcion.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Descripción:";
            // 
            // tbNombreCta
            // 
            this.tbNombreCta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNombreCta.Location = new System.Drawing.Point(3, 168);
            this.tbNombreCta.MaxLength = 250;
            this.tbNombreCta.Name = "tbNombreCta";
            this.tbNombreCta.ReadOnly = true;
            this.tbNombreCta.Size = new System.Drawing.Size(303, 20);
            this.tbNombreCta.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre de cuenta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nº de cuenta:";
            // 
            // mtbCtaPadre
            // 
            this.mtbCtaPadre.Location = new System.Drawing.Point(6, 35);
            this.mtbCtaPadre.Mask = "0-0-00-00-000";
            this.mtbCtaPadre.Name = "mtbCtaPadre";
            this.mtbCtaPadre.ReadOnly = true;
            this.mtbCtaPadre.Size = new System.Drawing.Size(96, 20);
            this.mtbCtaPadre.TabIndex = 1;
            this.mtbCtaPadre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbCtaPadre.Leave += new System.EventHandler(this.mtbCtaPadre_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvPlanCuentas);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(696, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vista tabla";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvPlanCuentas
            // 
            this.dgvPlanCuentas.AllowUserToAddRows = false;
            this.dgvPlanCuentas.AllowUserToDeleteRows = false;
            this.dgvPlanCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlanCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlanCuentas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPlanCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNumeroCuenta,
            this.dgvcNombreCuenta,
            this.dgvcNumeroCuentaPadre,
            this.dgvcNivelCuenta,
            this.dgvcDescripcionCuenta});
            this.dgvPlanCuentas.Location = new System.Drawing.Point(0, 0);
            this.dgvPlanCuentas.MultiSelect = false;
            this.dgvPlanCuentas.Name = "dgvPlanCuentas";
            this.dgvPlanCuentas.ReadOnly = true;
            this.dgvPlanCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanCuentas.ShowEditingIcon = false;
            this.dgvPlanCuentas.Size = new System.Drawing.Size(696, 363);
            this.dgvPlanCuentas.TabIndex = 3;
            this.dgvPlanCuentas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvPlanCuentas_MouseDoubleClick);
            // 
            // dgvcNumeroCuenta
            // 
            this.dgvcNumeroCuenta.DataPropertyName = "NumeroCuenta";
            this.dgvcNumeroCuenta.HeaderText = "Nº cuenta";
            this.dgvcNumeroCuenta.Name = "dgvcNumeroCuenta";
            this.dgvcNumeroCuenta.ReadOnly = true;
            // 
            // dgvcNombreCuenta
            // 
            this.dgvcNombreCuenta.DataPropertyName = "NombreCuenta";
            this.dgvcNombreCuenta.HeaderText = "Nombre de cuenta";
            this.dgvcNombreCuenta.Name = "dgvcNombreCuenta";
            this.dgvcNombreCuenta.ReadOnly = true;
            // 
            // dgvcNumeroCuentaPadre
            // 
            this.dgvcNumeroCuentaPadre.DataPropertyName = "NumeroCuentaPadre";
            this.dgvcNumeroCuentaPadre.HeaderText = "Nº cuenta padre";
            this.dgvcNumeroCuentaPadre.Name = "dgvcNumeroCuentaPadre";
            this.dgvcNumeroCuentaPadre.ReadOnly = true;
            this.dgvcNumeroCuentaPadre.Visible = false;
            // 
            // dgvcNivelCuenta
            // 
            this.dgvcNivelCuenta.DataPropertyName = "NivelCuenta";
            this.dgvcNivelCuenta.HeaderText = "Nivel";
            this.dgvcNivelCuenta.Name = "dgvcNivelCuenta";
            this.dgvcNivelCuenta.ReadOnly = true;
            // 
            // dgvcDescripcionCuenta
            // 
            this.dgvcDescripcionCuenta.DataPropertyName = "DescripcionCuenta";
            this.dgvcDescripcionCuenta.HeaderText = "Descripción";
            this.dgvcDescripcionCuenta.Name = "dgvcDescripcionCuenta";
            this.dgvcDescripcionCuenta.ReadOnly = true;
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
            this.ilPlanCuentas.Images.SetKeyName(6, "1");
            this.ilPlanCuentas.Images.SetKeyName(7, "2");
            this.ilPlanCuentas.Images.SetKeyName(8, "3");
            this.ilPlanCuentas.Images.SetKeyName(9, "4");
            this.ilPlanCuentas.Images.SetKeyName(10, "5");
            // 
            // FPlanCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.tcPlanCuentas);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FPlanCuentas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestionar plan de cuentas";
            this.Load += new System.EventHandler(this.FPlanCuentas_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tcPlanCuentas.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.cmsTvPlanCuentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanCuentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtNuevo;
        private System.Windows.Forms.ToolStripButton tsbtModificar;
        private System.Windows.Forms.ToolStripButton tsbtEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtImprimir;
        private System.Windows.Forms.TabControl tcPlanCuentas;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvPlanCuentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombreCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumeroCuentaPadre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNivelCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescripcionCuenta;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvPlanCuentas;
        private System.Windows.Forms.TextBox tbNombreCta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtbCtaPadre;
        private System.Windows.Forms.Button btNuevo;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.ImageList ilPlanCuentas;
        private System.Windows.Forms.TextBox tbNomCtaPadre;
        private System.Windows.Forms.CheckBox chbSelCtaPadre;
        private System.Windows.Forms.PictureBox pbOk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNumCta5;
        private System.Windows.Forms.TextBox tbNumCta4;
        private System.Windows.Forms.TextBox tbNumCta3;
        private System.Windows.Forms.TextBox tbNumCta2;
        private System.Windows.Forms.TextBox tbNumCta1;
        private System.Windows.Forms.ContextMenuStrip cmsTvPlanCuentas;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
    }
}