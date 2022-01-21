namespace WFADoblones20.FormulariosContabilidad
{
    partial class FConfiguracionCuentas
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btCancel = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btModificar = new System.Windows.Forms.Button();
            this.btNuevo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTipos = new System.Windows.Forms.DataGridView();
            this.dgvcNumConf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombreConf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDescConf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lnklbPlanCuentas = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.dgvcNumCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNomCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDescCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCtaPadre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNivCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMontoTotalDEBE = new System.Windows.Forms.Label();
            this.lblMontoTotalHABER = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btQuitar = new System.Windows.Forms.Button();
            this.btAnadir = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.dgvConfCuentas = new System.Windows.Forms.DataGridView();
            this.dgvcNumConfCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNumCtaConf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNomCtaConf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTipo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DGCPorcentajeMontoTotalDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipos)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfCuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btCancel);
            this.splitContainer1.Panel1.Controls.Add(this.btEliminar);
            this.splitContainer1.Panel1.Controls.Add(this.btModificar);
            this.splitContainer1.Panel1.Controls.Add(this.btNuevo);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgvTipos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1003, 558);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancel.Location = new System.Drawing.Point(332, 215);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 28);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancelar";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEliminar.Location = new System.Drawing.Point(224, 215);
            this.btEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(100, 28);
            this.btEliminar.TabIndex = 3;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btModificar
            // 
            this.btModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModificar.Location = new System.Drawing.Point(116, 215);
            this.btModificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(100, 28);
            this.btModificar.TabIndex = 2;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btNuevo
            // 
            this.btNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNuevo.Location = new System.Drawing.Point(8, 215);
            this.btNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(100, 28);
            this.btNuevo.TabIndex = 1;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = true;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo:";
            // 
            // dgvTipos
            // 
            this.dgvTipos.AllowUserToAddRows = false;
            this.dgvTipos.AllowUserToDeleteRows = false;
            this.dgvTipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTipos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNumConf,
            this.dgvcNombreConf,
            this.dgvcDescConf});
            this.dgvTipos.Location = new System.Drawing.Point(0, 31);
            this.dgvTipos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTipos.MultiSelect = false;
            this.dgvTipos.Name = "dgvTipos";
            this.dgvTipos.ReadOnly = true;
            this.dgvTipos.RowHeadersVisible = false;
            this.dgvTipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTipos.ShowEditingIcon = false;
            this.dgvTipos.Size = new System.Drawing.Size(999, 177);
            this.dgvTipos.TabIndex = 0;
            this.dgvTipos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipos_CellEndEdit);
            this.dgvTipos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipos_CellEnter);
            this.dgvTipos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipos_CellLeave);
            this.dgvTipos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvTipos_CellValidating);
            this.dgvTipos.SelectionChanged += new System.EventHandler(this.dgvTipos_SelectionChanged);
            // 
            // dgvcNumConf
            // 
            this.dgvcNumConf.DataPropertyName = "NumeroConfiguracion";
            this.dgvcNumConf.FillWeight = 36F;
            this.dgvcNumConf.HeaderText = "Nº configuracion";
            this.dgvcNumConf.Name = "dgvcNumConf";
            this.dgvcNumConf.ReadOnly = true;
            // 
            // dgvcNombreConf
            // 
            this.dgvcNombreConf.DataPropertyName = "NombreConfiguracion";
            this.dgvcNombreConf.FillWeight = 50.277F;
            this.dgvcNombreConf.HeaderText = "Nombre";
            this.dgvcNombreConf.MaxInputLength = 250;
            this.dgvcNombreConf.Name = "dgvcNombreConf";
            this.dgvcNombreConf.ReadOnly = true;
            // 
            // dgvcDescConf
            // 
            this.dgvcDescConf.DataPropertyName = "DescripcionConfiguracion";
            this.dgvcDescConf.FillWeight = 114.7991F;
            this.dgvcDescConf.HeaderText = "Descripción";
            this.dgvcDescConf.Name = "dgvcDescConf";
            this.dgvcDescConf.ReadOnly = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lnklbPlanCuentas);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.dgvCuentas);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblMontoTotalDEBE);
            this.splitContainer2.Panel2.Controls.Add(this.lblMontoTotalHABER);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.btQuitar);
            this.splitContainer2.Panel2.Controls.Add(this.btAnadir);
            this.splitContainer2.Panel2.Controls.Add(this.btCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.btAceptar);
            this.splitContainer2.Panel2.Controls.Add(this.dgvConfCuentas);
            this.splitContainer2.Size = new System.Drawing.Size(1003, 302);
            this.splitContainer2.SplitterDistance = 301;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // lnklbPlanCuentas
            // 
            this.lnklbPlanCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnklbPlanCuentas.AutoSize = true;
            this.lnklbPlanCuentas.Location = new System.Drawing.Point(4, 262);
            this.lnklbPlanCuentas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnklbPlanCuentas.Name = "lnklbPlanCuentas";
            this.lnklbPlanCuentas.Size = new System.Drawing.Size(195, 17);
            this.lnklbPlanCuentas.TabIndex = 2;
            this.lnklbPlanCuentas.TabStop = true;
            this.lnklbPlanCuentas.Text = "Adminitrar el Plan de Cuentas";
            this.lnklbPlanCuentas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbPlanCuentas_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Plan de cuentas:";
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.AllowUserToDeleteRows = false;
            this.dgvCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCuentas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNumCta,
            this.dgvcNomCta,
            this.dgvcDescCta,
            this.dgvcCtaPadre,
            this.dgvcNivCta});
            this.dgvCuentas.Location = new System.Drawing.Point(0, 31);
            this.dgvCuentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCuentas.MultiSelect = false;
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.ReadOnly = true;
            this.dgvCuentas.RowHeadersVisible = false;
            this.dgvCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentas.ShowEditingIcon = false;
            this.dgvCuentas.Size = new System.Drawing.Size(293, 227);
            this.dgvCuentas.TabIndex = 0;
            // 
            // dgvcNumCta
            // 
            this.dgvcNumCta.DataPropertyName = "NumeroCuenta";
            this.dgvcNumCta.FillWeight = 60.9137F;
            this.dgvcNumCta.HeaderText = "Nº";
            this.dgvcNumCta.Name = "dgvcNumCta";
            this.dgvcNumCta.ReadOnly = true;
            // 
            // dgvcNomCta
            // 
            this.dgvcNomCta.DataPropertyName = "NombreCuenta";
            this.dgvcNomCta.FillWeight = 139.0863F;
            this.dgvcNomCta.HeaderText = "Nombre";
            this.dgvcNomCta.Name = "dgvcNomCta";
            this.dgvcNomCta.ReadOnly = true;
            // 
            // dgvcDescCta
            // 
            this.dgvcDescCta.DataPropertyName = "DescripcionCuenta";
            this.dgvcDescCta.HeaderText = "Descripcion";
            this.dgvcDescCta.Name = "dgvcDescCta";
            this.dgvcDescCta.ReadOnly = true;
            this.dgvcDescCta.Visible = false;
            // 
            // dgvcCtaPadre
            // 
            this.dgvcCtaPadre.DataPropertyName = "NumeroCuentaPadre";
            this.dgvcCtaPadre.HeaderText = "Cuenta padre";
            this.dgvcCtaPadre.Name = "dgvcCtaPadre";
            this.dgvcCtaPadre.ReadOnly = true;
            this.dgvcCtaPadre.Visible = false;
            // 
            // dgvcNivCta
            // 
            this.dgvcNivCta.DataPropertyName = "NivelCuenta";
            this.dgvcNivCta.HeaderText = "Nivel";
            this.dgvcNivCta.Name = "dgvcNivCta";
            this.dgvcNivCta.ReadOnly = true;
            this.dgvcNivCta.Visible = false;
            // 
            // lblMontoTotalDEBE
            // 
            this.lblMontoTotalDEBE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMontoTotalDEBE.AutoSize = true;
            this.lblMontoTotalDEBE.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotalDEBE.ForeColor = System.Drawing.Color.Red;
            this.lblMontoTotalDEBE.Location = new System.Drawing.Point(81, 278);
            this.lblMontoTotalDEBE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMontoTotalDEBE.Name = "lblMontoTotalDEBE";
            this.lblMontoTotalDEBE.Size = new System.Drawing.Size(148, 15);
            this.lblMontoTotalDEBE.TabIndex = 7;
            this.lblMontoTotalDEBE.Text = "Monto Total DEBE   = ";
            // 
            // lblMontoTotalHABER
            // 
            this.lblMontoTotalHABER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMontoTotalHABER.AutoSize = true;
            this.lblMontoTotalHABER.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotalHABER.ForeColor = System.Drawing.Color.Blue;
            this.lblMontoTotalHABER.Location = new System.Drawing.Point(81, 257);
            this.lblMontoTotalHABER.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMontoTotalHABER.Name = "lblMontoTotalHABER";
            this.lblMontoTotalHABER.Size = new System.Drawing.Size(149, 15);
            this.lblMontoTotalHABER.TabIndex = 6;
            this.lblMontoTotalHABER.Text = "Monto Total HABER = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cuentas configuradas:";
            // 
            // btQuitar
            // 
            this.btQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btQuitar.Location = new System.Drawing.Point(4, 148);
            this.btQuitar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btQuitar.Name = "btQuitar";
            this.btQuitar.Size = new System.Drawing.Size(73, 28);
            this.btQuitar.TabIndex = 2;
            this.btQuitar.Text = "Quitar";
            this.btQuitar.UseVisualStyleBackColor = true;
            this.btQuitar.Click += new System.EventHandler(this.btQuitar_Click);
            // 
            // btAnadir
            // 
            this.btAnadir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAnadir.Location = new System.Drawing.Point(4, 112);
            this.btAnadir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btAnadir.Name = "btAnadir";
            this.btAnadir.Size = new System.Drawing.Size(73, 28);
            this.btAnadir.TabIndex = 1;
            this.btAnadir.Text = "Añadir";
            this.btAnadir.UseVisualStyleBackColor = true;
            this.btAnadir.Click += new System.EventHandler(this.btAnadir_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Location = new System.Drawing.Point(579, 266);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(100, 28);
            this.btCancelar.TabIndex = 4;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAceptar.Location = new System.Drawing.Point(471, 266);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(100, 28);
            this.btAceptar.TabIndex = 3;
            this.btAceptar.Text = "Modificar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // dgvConfCuentas
            // 
            this.dgvConfCuentas.AllowUserToAddRows = false;
            this.dgvConfCuentas.AllowUserToDeleteRows = false;
            this.dgvConfCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConfCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConfCuentas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvConfCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNumConfCta,
            this.dgvcNumCtaConf,
            this.dgvcNomCtaConf,
            this.dgvcTipo,
            this.DGCPorcentajeMontoTotalDH});
            this.dgvConfCuentas.Location = new System.Drawing.Point(85, 31);
            this.dgvConfCuentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvConfCuentas.MultiSelect = false;
            this.dgvConfCuentas.Name = "dgvConfCuentas";
            this.dgvConfCuentas.RowHeadersWidth = 45;
            this.dgvConfCuentas.Size = new System.Drawing.Size(607, 223);
            this.dgvConfCuentas.TabIndex = 0;
            this.dgvConfCuentas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvConfCuentas_CellValidating);
            // 
            // dgvcNumConfCta
            // 
            this.dgvcNumConfCta.DataPropertyName = "NumeroConfiguracion";
            this.dgvcNumConfCta.HeaderText = "Nº";
            this.dgvcNumConfCta.Name = "dgvcNumConfCta";
            this.dgvcNumConfCta.ReadOnly = true;
            this.dgvcNumConfCta.Visible = false;
            // 
            // dgvcNumCtaConf
            // 
            this.dgvcNumCtaConf.DataPropertyName = "NumeroCuentaConfiguracion";
            this.dgvcNumCtaConf.HeaderText = "Nº cuenta";
            this.dgvcNumCtaConf.Name = "dgvcNumCtaConf";
            this.dgvcNumCtaConf.ReadOnly = true;
            // 
            // dgvcNomCtaConf
            // 
            this.dgvcNomCtaConf.DataPropertyName = "NombreCuenta";
            this.dgvcNomCtaConf.HeaderText = "Nombre de cuenta";
            this.dgvcNomCtaConf.Name = "dgvcNomCtaConf";
            this.dgvcNomCtaConf.ReadOnly = true;
            // 
            // dgvcTipo
            // 
            this.dgvcTipo.HeaderText = "Debe/Haber";
            this.dgvcTipo.MaxDropDownItems = 2;
            this.dgvcTipo.Name = "dgvcTipo";
            this.dgvcTipo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DGCPorcentajeMontoTotalDH
            // 
            this.DGCPorcentajeMontoTotalDH.DataPropertyName = "PorcentajeMontoTotalDH";
            this.DGCPorcentajeMontoTotalDH.FillWeight = 35F;
            this.DGCPorcentajeMontoTotalDH.HeaderText = "%";
            this.DGCPorcentajeMontoTotalDH.Name = "DGCPorcentajeMontoTotalDH";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NumeroConfiguracion";
            this.dataGridViewTextBoxColumn1.FillWeight = 36F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Nº configuracion";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 133;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreConfiguracion";
            this.dataGridViewTextBoxColumn2.FillWeight = 50.277F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 250;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 187;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DescripcionConfiguracion";
            this.dataGridViewTextBoxColumn3.FillWeight = 114.7991F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 425;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NumeroCuenta";
            this.dataGridViewTextBoxColumn4.FillWeight = 60.9137F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Nº";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 66;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NombreCuenta";
            this.dataGridViewTextBoxColumn5.FillWeight = 139.0863F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DescripcionCuenta";
            this.dataGridViewTextBoxColumn6.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "NumeroCuentaPadre";
            this.dataGridViewTextBoxColumn7.HeaderText = "Cuenta padre";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NivelCuenta";
            this.dataGridViewTextBoxColumn8.HeaderText = "Nivel";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NumeroConfiguracion";
            this.dataGridViewTextBoxColumn9.HeaderText = "Nº";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "NumeroCuentaConfiguracion";
            this.dataGridViewTextBoxColumn10.HeaderText = "Nº cuenta";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 127;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "NombreCuenta";
            this.dataGridViewTextBoxColumn11.HeaderText = "Nombre de cuenta";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 126;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "PorcentajeMontoTotalDH";
            this.dataGridViewTextBoxColumn12.FillWeight = 35F;
            this.dataGridViewTextBoxColumn12.HeaderText = "%";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 42;
            // 
            // FConfiguracionCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 558);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FConfiguracionCuentas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de cuentas";
            this.Load += new System.EventHandler(this.FConfiguracionCuentas_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipos)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfCuentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvTipos;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Button btNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btAnadir;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.DataGridView dgvConfCuentas;
        private System.Windows.Forms.Button btQuitar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNomCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCtaPadre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNivCta;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumConf;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombreConf;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescConf;
        private System.Windows.Forms.LinkLabel lnklbPlanCuentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumConfCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNumCtaConf;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNomCtaConf;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPorcentajeMontoTotalDH;
        private System.Windows.Forms.Label lblMontoTotalDEBE;
        private System.Windows.Forms.Label lblMontoTotalHABER;
    }
}