namespace WFADoblones20.FormulariosSistema
{
    partial class FAgencias
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
            this.bReportes = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tBNumeroSiguienteFactura = new System.Windows.Forms.TextBox();
            this.cBDepartamento = new System.Windows.Forms.ComboBox();
            this.cBProvincia = new System.Windows.Forms.ComboBox();
            this.cBLugar = new System.Windows.Forms.ComboBox();
            this.cBPais = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tBDireccion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBNITAgencia = new System.Windows.Forms.TextBox();
            this.bCerrar = new System.Windows.Forms.Button();
            this.bBuscar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bEliminar = new System.Windows.Forms.Button();
            this.bEditar = new System.Windows.Forms.Button();
            this.bNuevo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBNumeroAgencia = new System.Windows.Forms.TextBox();
            this.tBNombreAgencia = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tBNumeroAutorizacion = new System.Windows.Forms.TextBox();
            this.tBDIResponsable = new System.Windows.Forms.TextBox();
            this.tBNombreCompletoResponsable = new System.Windows.Forms.TextBox();
            this.bBuscarResponsable = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cBAgenciaSuperior = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bReportes
            // 
            this.bReportes.Location = new System.Drawing.Point(418, 286);
            this.bReportes.Name = "bReportes";
            this.bReportes.Size = new System.Drawing.Size(60, 23);
            this.bReportes.TabIndex = 20;
            this.bReportes.Text = "&Reporte";
            this.bReportes.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 13);
            this.label7.TabIndex = 204;
            this.label7.Text = "Numero siguiente factura";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBNumeroSiguienteFactura
            // 
            this.tBNumeroSiguienteFactura.Location = new System.Drawing.Point(139, 170);
            this.tBNumeroSiguienteFactura.Name = "tBNumeroSiguienteFactura";
            this.tBNumeroSiguienteFactura.Size = new System.Drawing.Size(100, 20);
            this.tBNumeroSiguienteFactura.TabIndex = 8;
            // 
            // cBDepartamento
            // 
            this.cBDepartamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBDepartamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBDepartamento.FormattingEnabled = true;
            this.cBDepartamento.Location = new System.Drawing.Point(459, 64);
            this.cBDepartamento.Name = "cBDepartamento";
            this.cBDepartamento.Size = new System.Drawing.Size(180, 21);
            this.cBDepartamento.TabIndex = 3;
            this.cBDepartamento.SelectedIndexChanged += new System.EventHandler(this.cBDepartamento_SelectedIndexChanged);
            // 
            // cBProvincia
            // 
            this.cBProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBProvincia.FormattingEnabled = true;
            this.cBProvincia.Location = new System.Drawing.Point(139, 91);
            this.cBProvincia.Name = "cBProvincia";
            this.cBProvincia.Size = new System.Drawing.Size(180, 21);
            this.cBProvincia.TabIndex = 4;
            this.cBProvincia.SelectedIndexChanged += new System.EventHandler(this.cBProvincia_SelectedIndexChanged);
            // 
            // cBLugar
            // 
            this.cBLugar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBLugar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBLugar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBLugar.FormattingEnabled = true;
            this.cBLugar.Location = new System.Drawing.Point(459, 89);
            this.cBLugar.Name = "cBLugar";
            this.cBLugar.Size = new System.Drawing.Size(180, 21);
            this.cBLugar.TabIndex = 5;
            // 
            // cBPais
            // 
            this.cBPais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBPais.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBPais.FormattingEnabled = true;
            this.cBPais.Location = new System.Drawing.Point(139, 64);
            this.cBPais.Name = "cBPais";
            this.cBPais.Size = new System.Drawing.Size(180, 21);
            this.cBPais.TabIndex = 2;
            this.cBPais.SelectedIndexChanged += new System.EventHandler(this.cBPais_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(83, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 209;
            this.label13.Text = "Dirección";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBDireccion
            // 
            this.tBDireccion.Location = new System.Drawing.Point(139, 118);
            this.tBDireccion.Name = "tBDireccion";
            this.tBDireccion.Size = new System.Drawing.Size(501, 20);
            this.tBDireccion.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(420, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 214;
            this.label14.Text = "Lugar";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(84, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 208;
            this.label15.Text = "Provincia";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(380, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 213;
            this.label16.Text = "Departamento";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 207;
            this.label5.Text = "Pais";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 203;
            this.label3.Text = "NIT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBNITAgencia
            // 
            this.tBNITAgencia.Location = new System.Drawing.Point(139, 144);
            this.tBNITAgencia.Name = "tBNITAgencia";
            this.tBNITAgencia.Size = new System.Drawing.Size(150, 20);
            this.tBNITAgencia.TabIndex = 7;
            // 
            // bCerrar
            // 
            this.bCerrar.Location = new System.Drawing.Point(574, 286);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(60, 23);
            this.bCerrar.TabIndex = 21;
            this.bCerrar.Text = "Cerrar";
            this.bCerrar.UseVisualStyleBackColor = true;
            this.bCerrar.Click += new System.EventHandler(this.bCerrar_Click);
            // 
            // bBuscar
            // 
            this.bBuscar.Location = new System.Drawing.Point(355, 286);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(60, 23);
            this.bBuscar.TabIndex = 19;
            this.bBuscar.Text = "&Buscar";
            this.bBuscar.UseVisualStyleBackColor = true;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(276, 286);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(60, 23);
            this.bCancelar.TabIndex = 18;
            this.bCancelar.Text = "&Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(213, 286);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(60, 23);
            this.bAceptar.TabIndex = 17;
            this.bAceptar.Text = "&Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bEliminar
            // 
            this.bEliminar.Location = new System.Drawing.Point(150, 286);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(60, 23);
            this.bEliminar.TabIndex = 16;
            this.bEliminar.Text = "E&liminar";
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // bEditar
            // 
            this.bEditar.Location = new System.Drawing.Point(87, 286);
            this.bEditar.Name = "bEditar";
            this.bEditar.Size = new System.Drawing.Size(60, 23);
            this.bEditar.TabIndex = 15;
            this.bEditar.Text = "&Editar";
            this.bEditar.UseVisualStyleBackColor = true;
            this.bEditar.Click += new System.EventHandler(this.bEditar_Click);
            // 
            // bNuevo
            // 
            this.bNuevo.Location = new System.Drawing.Point(24, 286);
            this.bNuevo.Name = "bNuevo";
            this.bNuevo.Size = new System.Drawing.Size(60, 23);
            this.bNuevo.TabIndex = 14;
            this.bNuevo.Text = "&Nuevo";
            this.bNuevo.UseVisualStyleBackColor = true;
            this.bNuevo.Click += new System.EventHandler(this.bNuevo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 200;
            this.label2.Text = "Nombre agencia";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 199;
            this.label1.Text = "Número agencia";
            // 
            // tBNumeroAgencia
            // 
            this.tBNumeroAgencia.BackColor = System.Drawing.SystemColors.Control;
            this.tBNumeroAgencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBNumeroAgencia.Location = new System.Drawing.Point(139, 12);
            this.tBNumeroAgencia.Name = "tBNumeroAgencia";
            this.tBNumeroAgencia.Size = new System.Drawing.Size(100, 20);
            this.tBNumeroAgencia.TabIndex = 0;
            // 
            // tBNombreAgencia
            // 
            this.tBNombreAgencia.Location = new System.Drawing.Point(139, 38);
            this.tBNombreAgencia.Name = "tBNombreAgencia";
            this.tBNombreAgencia.Size = new System.Drawing.Size(500, 20);
            this.tBNombreAgencia.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(29, 203);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 13);
            this.label20.TabIndex = 219;
            this.label20.Text = "Numero autorización";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBNumeroAutorizacion
            // 
            this.tBNumeroAutorizacion.Location = new System.Drawing.Point(139, 196);
            this.tBNumeroAutorizacion.Name = "tBNumeroAutorizacion";
            this.tBNumeroAutorizacion.Size = new System.Drawing.Size(100, 20);
            this.tBNumeroAutorizacion.TabIndex = 9;
            // 
            // tBDIResponsable
            // 
            this.tBDIResponsable.Location = new System.Drawing.Point(139, 224);
            this.tBDIResponsable.Name = "tBDIResponsable";
            this.tBDIResponsable.Size = new System.Drawing.Size(100, 20);
            this.tBDIResponsable.TabIndex = 10;
            // 
            // tBNombreCompletoResponsable
            // 
            this.tBNombreCompletoResponsable.BackColor = System.Drawing.SystemColors.Control;
            this.tBNombreCompletoResponsable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tBNombreCompletoResponsable.Location = new System.Drawing.Point(271, 225);
            this.tBNombreCompletoResponsable.Name = "tBNombreCompletoResponsable";
            this.tBNombreCompletoResponsable.ReadOnly = true;
            this.tBNombreCompletoResponsable.Size = new System.Drawing.Size(363, 20);
            this.tBNombreCompletoResponsable.TabIndex = 12;
            // 
            // bBuscarResponsable
            // 
            this.bBuscarResponsable.Enabled = false;
            this.bBuscarResponsable.Location = new System.Drawing.Point(245, 222);
            this.bBuscarResponsable.Name = "bBuscarResponsable";
            this.bBuscarResponsable.Size = new System.Drawing.Size(24, 23);
            this.bBuscarResponsable.TabIndex = 11;
            this.bBuscarResponsable.Text = "...";
            this.bBuscarResponsable.UseVisualStyleBackColor = true;
            this.bBuscarResponsable.Click += new System.EventHandler(this.bBuscarDeudor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 223;
            this.label4.Text = "Responsable";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cBAgenciaSuperior
            // 
            this.cBAgenciaSuperior.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBAgenciaSuperior.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBAgenciaSuperior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBAgenciaSuperior.FormattingEnabled = true;
            this.cBAgenciaSuperior.Location = new System.Drawing.Point(139, 252);
            this.cBAgenciaSuperior.Name = "cBAgenciaSuperior";
            this.cBAgenciaSuperior.Size = new System.Drawing.Size(180, 21);
            this.cBAgenciaSuperior.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 225;
            this.label6.Text = "Agencia superior";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FAgencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 323);
            this.Controls.Add(this.cBAgenciaSuperior);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tBDIResponsable);
            this.Controls.Add(this.tBNombreCompletoResponsable);
            this.Controls.Add(this.bBuscarResponsable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tBNumeroAutorizacion);
            this.Controls.Add(this.bReportes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tBNumeroSiguienteFactura);
            this.Controls.Add(this.cBDepartamento);
            this.Controls.Add(this.cBProvincia);
            this.Controls.Add(this.cBLugar);
            this.Controls.Add(this.cBPais);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tBDireccion);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBNITAgencia);
            this.Controls.Add(this.bCerrar);
            this.Controls.Add(this.bBuscar);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.bEditar);
            this.Controls.Add(this.bNuevo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBNumeroAgencia);
            this.Controls.Add(this.tBNombreAgencia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FAgencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agencias";
            this.Load += new System.EventHandler(this.FAgencias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bReportes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBNumeroSiguienteFactura;
        private System.Windows.Forms.ComboBox cBDepartamento;
        private System.Windows.Forms.ComboBox cBProvincia;
        private System.Windows.Forms.ComboBox cBLugar;
        private System.Windows.Forms.ComboBox cBPais;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tBDireccion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBNITAgencia;
        private System.Windows.Forms.Button bCerrar;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.Button bEditar;
        private System.Windows.Forms.Button bNuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBNumeroAgencia;
        private System.Windows.Forms.TextBox tBNombreAgencia;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tBNumeroAutorizacion;
        private System.Windows.Forms.TextBox tBDIResponsable;
        private System.Windows.Forms.TextBox tBNombreCompletoResponsable;
        private System.Windows.Forms.Button bBuscarResponsable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBAgenciaSuperior;
        private System.Windows.Forms.Label label6;
    }
}