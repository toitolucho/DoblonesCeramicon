namespace WFADoblones20.FormulariosSistema
{
    partial class FAsignacionSistemaGruposPorUsuario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dGVAgencias = new System.Windows.Forms.DataGridView();
            this.DGVCNombreGrupoSistema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombreAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBoxListadoGrupos = new System.Windows.Forms.GroupBox();
            this.pnlAbajoBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.bCerrar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.sSEstadoAsignacion = new System.Windows.Forms.StatusStrip();
            this.tSSLCodigoUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dGVSistemaGrupos = new System.Windows.Forms.DataGridView();
            this.CCodigoGrupoSistema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSeleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tSSLNombreUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSLEstado = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dGVAgencias)).BeginInit();
            this.gBoxListadoGrupos.SuspendLayout();
            this.pnlAbajoBotones.SuspendLayout();
            this.sSEstadoAsignacion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSistemaGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVAgencias
            // 
            this.dGVAgencias.AllowUserToAddRows = false;
            this.dGVAgencias.AllowUserToDeleteRows = false;
            this.dGVAgencias.AllowUserToOrderColumns = true;
            this.dGVAgencias.AllowUserToResizeColumns = false;
            this.dGVAgencias.AllowUserToResizeRows = false;
            this.dGVAgencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVAgencias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVAgencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dGVAgencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVAgencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVCNombreGrupoSistema,
            this.CNombreAgencia});
            this.dGVAgencias.Dock = System.Windows.Forms.DockStyle.Top;
            this.dGVAgencias.Location = new System.Drawing.Point(3, 16);
            this.dGVAgencias.Name = "dGVAgencias";
            this.dGVAgencias.ReadOnly = true;
            this.dGVAgencias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dGVAgencias.RowHeadersVisible = false;
            this.dGVAgencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVAgencias.Size = new System.Drawing.Size(473, 164);
            this.dGVAgencias.TabIndex = 0;
            this.dGVAgencias.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVAgencias_RowEnter);
            // 
            // DGVCNombreGrupoSistema
            // 
            this.DGVCNombreGrupoSistema.DataPropertyName = "NumeroAgencia";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DGVCNombreGrupoSistema.DefaultCellStyle = dataGridViewCellStyle6;
            this.DGVCNombreGrupoSistema.FillWeight = 47.71574F;
            this.DGVCNombreGrupoSistema.HeaderText = "Nº agencia";
            this.DGVCNombreGrupoSistema.Name = "DGVCNombreGrupoSistema";
            this.DGVCNombreGrupoSistema.ReadOnly = true;
            this.DGVCNombreGrupoSistema.ToolTipText = "Numero de agencia en la que se desea habilitar un usuario";
            // 
            // CNombreAgencia
            // 
            this.CNombreAgencia.DataPropertyName = "NombreAgencia";
            this.CNombreAgencia.FillWeight = 152.2843F;
            this.CNombreAgencia.HeaderText = "Nombre agencia";
            this.CNombreAgencia.Name = "CNombreAgencia";
            this.CNombreAgencia.ReadOnly = true;
            this.CNombreAgencia.ToolTipText = "Nombre de agencia en la que se desea habilitar un usuario";
            // 
            // gBoxListadoGrupos
            // 
            this.gBoxListadoGrupos.Controls.Add(this.dGVAgencias);
            this.gBoxListadoGrupos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxListadoGrupos.Location = new System.Drawing.Point(0, 0);
            this.gBoxListadoGrupos.Name = "gBoxListadoGrupos";
            this.gBoxListadoGrupos.Size = new System.Drawing.Size(479, 183);
            this.gBoxListadoGrupos.TabIndex = 1;
            this.gBoxListadoGrupos.TabStop = false;
            this.gBoxListadoGrupos.Text = "Seleccione la agencia donde desea habilitar este usuario";
            // 
            // pnlAbajoBotones
            // 
            this.pnlAbajoBotones.Controls.Add(this.bCerrar);
            this.pnlAbajoBotones.Controls.Add(this.bCancelar);
            this.pnlAbajoBotones.Controls.Add(this.bAceptar);
            this.pnlAbajoBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAbajoBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlAbajoBotones.Location = new System.Drawing.Point(0, 467);
            this.pnlAbajoBotones.Name = "pnlAbajoBotones";
            this.pnlAbajoBotones.Size = new System.Drawing.Size(479, 34);
            this.pnlAbajoBotones.TabIndex = 2;
            // 
            // bCerrar
            // 
            this.bCerrar.Location = new System.Drawing.Point(401, 3);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(75, 23);
            this.bCerrar.TabIndex = 2;
            this.bCerrar.Text = "Cerrar";
            this.bCerrar.UseVisualStyleBackColor = true;
            this.bCerrar.Click += new System.EventHandler(this.bCerrar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(320, 3);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 1;
            this.bCancelar.Text = "&Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(239, 3);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 23);
            this.bAceptar.TabIndex = 0;
            this.bAceptar.Text = "&Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // sSEstadoAsignacion
            // 
            this.sSEstadoAsignacion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLCodigoUsuario,
            this.tSSLNombreUsuario,
            this.tSSLEstado});
            this.sSEstadoAsignacion.Location = new System.Drawing.Point(0, 501);
            this.sSEstadoAsignacion.Name = "sSEstadoAsignacion";
            this.sSEstadoAsignacion.Size = new System.Drawing.Size(479, 24);
            this.sSEstadoAsignacion.TabIndex = 2;
            this.sSEstadoAsignacion.Text = "statusStrip1";
            // 
            // tSSLCodigoUsuario
            // 
            this.tSSLCodigoUsuario.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tSSLCodigoUsuario.Name = "tSSLCodigoUsuario";
            this.tSSLCodigoUsuario.Size = new System.Drawing.Size(95, 19);
            this.tSSLCodigoUsuario.Text = "Codigo usuario:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dGVSistemaGrupos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 284);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el grupo en el que desea habilitar este usuario";
            // 
            // dGVSistemaGrupos
            // 
            this.dGVSistemaGrupos.AllowUserToAddRows = false;
            this.dGVSistemaGrupos.AllowUserToDeleteRows = false;
            this.dGVSistemaGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVSistemaGrupos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVSistemaGrupos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dGVSistemaGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVSistemaGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CCodigoGrupoSistema,
            this.dataGridViewTextBoxColumn2,
            this.CSeleccion});
            this.dGVSistemaGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVSistemaGrupos.Location = new System.Drawing.Point(3, 16);
            this.dGVSistemaGrupos.Name = "dGVSistemaGrupos";
            this.dGVSistemaGrupos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dGVSistemaGrupos.RowHeadersVisible = false;
            this.dGVSistemaGrupos.Size = new System.Drawing.Size(473, 265);
            this.dGVSistemaGrupos.TabIndex = 0;
            this.dGVSistemaGrupos.CurrentCellChanged += new System.EventHandler(this.dGVSistemaGrupos_CurrentCellChanged);
            // 
            // CCodigoGrupoSistema
            // 
            this.CCodigoGrupoSistema.DataPropertyName = "CodigoGrupoSistema";
            this.CCodigoGrupoSistema.HeaderText = "CodigoGrupoSistema";
            this.CCodigoGrupoSistema.Name = "CCodigoGrupoSistema";
            this.CCodigoGrupoSistema.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreGrupoSistema";
            this.dataGridViewTextBoxColumn2.FillWeight = 179.6954F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Grupo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Grupo al que se desea incluir al usuario";
            // 
            // CSeleccion
            // 
            this.CSeleccion.FillWeight = 20.30457F;
            this.CSeleccion.HeaderText = "?";
            this.CSeleccion.Name = "CSeleccion";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NombreGrupoSistema";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn1.FillWeight = 47.71574F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre de Grupo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Nombre del Grupo al cual el usuario se encuentra Subscrito";
            this.dataGridViewTextBoxColumn1.Width = 384;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NombreGrupoSistema";
            this.dataGridViewTextBoxColumn3.FillWeight = 179.6954F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Grupo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.ToolTipText = "Grupo al que se desea incluir al usuario";
            this.dataGridViewTextBoxColumn3.Width = 422;
            // 
            // tSSLNombreUsuario
            // 
            this.tSSLNombreUsuario.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tSSLNombreUsuario.Name = "tSSLNombreUsuario";
            this.tSSLNombreUsuario.Size = new System.Drawing.Size(100, 19);
            this.tSSLNombreUsuario.Text = "Nombre usuario:";
            // 
            // tSSLEstado
            // 
            this.tSSLEstado.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tSSLEstado.Name = "tSSLEstado";
            this.tSSLEstado.Size = new System.Drawing.Size(49, 19);
            this.tSSLEstado.Text = "Estado:";
            // 
            // FAsignacionSistemaGruposPorUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 525);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBoxListadoGrupos);
            this.Controls.Add(this.pnlAbajoBotones);
            this.Controls.Add(this.sSEstadoAsignacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FAsignacionSistemaGruposPorUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación usuario, agencia  y sistema grupo";
            this.Load += new System.EventHandler(this.FListadoSistemaGruposPorUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVAgencias)).EndInit();
            this.gBoxListadoGrupos.ResumeLayout(false);
            this.pnlAbajoBotones.ResumeLayout(false);
            this.sSEstadoAsignacion.ResumeLayout(false);
            this.sSEstadoAsignacion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVSistemaGrupos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVAgencias;
        private System.Windows.Forms.GroupBox gBoxListadoGrupos;
        private System.Windows.Forms.FlowLayoutPanel pnlAbajoBotones;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.StatusStrip sSEstadoAsignacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVCNombreGrupoSistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombreAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView dGVSistemaGrupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCodigoGrupoSistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CSeleccion;
        private System.Windows.Forms.ToolStripStatusLabel tSSLCodigoUsuario;
        private System.Windows.Forms.Button bCerrar;
        private System.Windows.Forms.ToolStripStatusLabel tSSLNombreUsuario;
        private System.Windows.Forms.ToolStripStatusLabel tSSLEstado;
    }
}