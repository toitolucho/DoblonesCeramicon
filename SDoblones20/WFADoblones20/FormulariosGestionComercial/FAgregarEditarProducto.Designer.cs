namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FAgregarEditarProducto
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
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.toolTipProductos = new System.Windows.Forms.ToolTip(this.components);
            this.btnUnidades = new System.Windows.Forms.Button();
            this.btnMarcas = new System.Windows.Forms.Button();
            this.oFDImagenProducto = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tBRendimientoDeseado1 = new System.Windows.Forms.TextBox();
            this.cBCopiarCodigo = new System.Windows.Forms.CheckBox();
            this.cBGenerarAutomaticamenteCodigoProducto = new System.Windows.Forms.CheckBox();
            this.tBCodigoProducto = new System.Windows.Forms.TextBox();
            this.tBCodigoProductoFabricante = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBDescripcion = new System.Windows.Forms.TextBox();
            this.cBCalcularPrecioVenta = new System.Windows.Forms.CheckBox();
            this.cBProductoSimple = new System.Windows.Forms.CheckBox();
            this.cBProductoTangible = new System.Windows.Forms.CheckBox();
            this.cBLlenarCodigoPE = new System.Windows.Forms.CheckBox();
            this.cBUnidad = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cBTipoCalculoInventario = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cBMarca = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBNombreProducto2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tBObservaciones = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBNombreProducto = new System.Windows.Forms.TextBox();
            this.tBNombreProducto1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tBRendimientoDeseado2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tBRendimientoDeseado3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bCancelar
            // 
            this.bCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancelar.ImageKey = "Undo.ico";
            this.bCancelar.Location = new System.Drawing.Point(544, 388);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(73, 29);
            this.bCancelar.TabIndex = 1;
            this.bCancelar.Text = "&Cancelar";
            this.bCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCancelar.UseVisualStyleBackColor = true;
            // 
            // bAceptar
            // 
            this.bAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAceptar.ImageKey = "Save.ico";
            this.bAceptar.Location = new System.Drawing.Point(462, 388);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 29);
            this.bAceptar.TabIndex = 0;
            this.bAceptar.Text = "&Aceptar";
            this.bAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // toolTipProductos
            // 
            this.toolTipProductos.IsBalloon = true;
            this.toolTipProductos.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnUnidades
            // 
            this.btnUnidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnidades.FlatAppearance.BorderSize = 0;
            this.btnUnidades.ImageIndex = 13;
            this.btnUnidades.Location = new System.Drawing.Point(325, 166);
            this.btnUnidades.Name = "btnUnidades";
            this.btnUnidades.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUnidades.Size = new System.Drawing.Size(24, 24);
            this.btnUnidades.TabIndex = 10;
            this.btnUnidades.Text = "...";
            this.toolTipProductos.SetToolTip(this.btnUnidades, "Registrar y Actualizar Unidades de Productos");
            this.btnUnidades.UseVisualStyleBackColor = true;
            this.btnUnidades.Click += new System.EventHandler(this.btnUnidades_Click_1);
            // 
            // btnMarcas
            // 
            this.btnMarcas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarcas.FlatAppearance.BorderSize = 0;
            this.btnMarcas.ImageIndex = 13;
            this.btnMarcas.Location = new System.Drawing.Point(425, 139);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMarcas.Size = new System.Drawing.Size(24, 24);
            this.btnMarcas.TabIndex = 8;
            this.btnMarcas.Text = "...";
            this.toolTipProductos.SetToolTip(this.btnMarcas, "Registrar y Actualizar Marcas de Productos");
            this.btnMarcas.UseVisualStyleBackColor = true;
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click_1);
            // 
            // oFDImagenProducto
            // 
            this.oFDImagenProducto.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoProducto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo Producto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ValorPropiedad";
            this.dataGridViewTextBoxColumn2.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 30;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Ruta";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // tBRendimientoDeseado1
            // 
            this.tBRendimientoDeseado1.Location = new System.Drawing.Point(209, 270);
            this.tBRendimientoDeseado1.Name = "tBRendimientoDeseado1";
            this.tBRendimientoDeseado1.Size = new System.Drawing.Size(69, 20);
            this.tBRendimientoDeseado1.TabIndex = 16;
            // 
            // cBCopiarCodigo
            // 
            this.cBCopiarCodigo.AutoSize = true;
            this.cBCopiarCodigo.Location = new System.Drawing.Point(276, 38);
            this.cBCopiarCodigo.Name = "cBCopiarCodigo";
            this.cBCopiarCodigo.Size = new System.Drawing.Size(136, 17);
            this.cBCopiarCodigo.TabIndex = 3;
            this.cBCopiarCodigo.Text = "Copiar codigo producto";
            this.cBCopiarCodigo.UseVisualStyleBackColor = true;
            this.cBCopiarCodigo.CheckedChanged += new System.EventHandler(this.cBCopiarCodigo_CheckedChanged);
            // 
            // cBGenerarAutomaticamenteCodigoProducto
            // 
            this.cBGenerarAutomaticamenteCodigoProducto.AutoSize = true;
            this.cBGenerarAutomaticamenteCodigoProducto.Checked = true;
            this.cBGenerarAutomaticamenteCodigoProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBGenerarAutomaticamenteCodigoProducto.Location = new System.Drawing.Point(226, 15);
            this.cBGenerarAutomaticamenteCodigoProducto.Name = "cBGenerarAutomaticamenteCodigoProducto";
            this.cBGenerarAutomaticamenteCodigoProducto.Size = new System.Drawing.Size(243, 17);
            this.cBGenerarAutomaticamenteCodigoProducto.TabIndex = 1;
            this.cBGenerarAutomaticamenteCodigoProducto.Text = "Generar automaticamente codigo de producto";
            this.cBGenerarAutomaticamenteCodigoProducto.UseVisualStyleBackColor = true;
            this.cBGenerarAutomaticamenteCodigoProducto.CheckedChanged += new System.EventHandler(this.cBGenerarAutomaticamenteCodigoProducto_CheckedChanged);
            // 
            // tBCodigoProducto
            // 
            this.tBCodigoProducto.Location = new System.Drawing.Point(118, 12);
            this.tBCodigoProducto.Name = "tBCodigoProducto";
            this.tBCodigoProducto.Size = new System.Drawing.Size(100, 20);
            this.tBCodigoProducto.TabIndex = 0;
            this.tBCodigoProducto.TextChanged += new System.EventHandler(this.tBCodigoProducto_TextChanged);
            // 
            // tBCodigoProductoFabricante
            // 
            this.tBCodigoProductoFabricante.Location = new System.Drawing.Point(119, 38);
            this.tBCodigoProductoFabricante.Name = "tBCodigoProductoFabricante";
            this.tBCodigoProductoFabricante.Size = new System.Drawing.Size(150, 20);
            this.tBCodigoProductoFabricante.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Descripcion";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBDescripcion
            // 
            this.tBDescripcion.Location = new System.Drawing.Point(118, 296);
            this.tBDescripcion.Multiline = true;
            this.tBDescripcion.Name = "tBDescripcion";
            this.tBDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBDescripcion.Size = new System.Drawing.Size(499, 40);
            this.tBDescripcion.TabIndex = 19;
            // 
            // cBCalcularPrecioVenta
            // 
            this.cBCalcularPrecioVenta.AutoSize = true;
            this.cBCalcularPrecioVenta.Location = new System.Drawing.Point(119, 247);
            this.cBCalcularPrecioVenta.Name = "cBCalcularPrecioVenta";
            this.cBCalcularPrecioVenta.Size = new System.Drawing.Size(231, 17);
            this.cBCalcularPrecioVenta.TabIndex = 15;
            this.cBCalcularPrecioVenta.Text = "Calcular automaticamente precio de venta?";
            this.cBCalcularPrecioVenta.UseVisualStyleBackColor = true;
            // 
            // cBProductoSimple
            // 
            this.cBProductoSimple.AutoSize = true;
            this.cBProductoSimple.Location = new System.Drawing.Point(517, 224);
            this.cBProductoSimple.Name = "cBProductoSimple";
            this.cBProductoSimple.Size = new System.Drawing.Size(107, 17);
            this.cBProductoSimple.TabIndex = 14;
            this.cBProductoSimple.Text = "Producto simple?";
            this.cBProductoSimple.UseVisualStyleBackColor = true;
            // 
            // cBProductoTangible
            // 
            this.cBProductoTangible.AutoSize = true;
            this.cBProductoTangible.Location = new System.Drawing.Point(356, 224);
            this.cBProductoTangible.Name = "cBProductoTangible";
            this.cBProductoTangible.Size = new System.Drawing.Size(115, 17);
            this.cBProductoTangible.TabIndex = 13;
            this.cBProductoTangible.Text = "Producto tangible?";
            this.cBProductoTangible.UseVisualStyleBackColor = true;
            // 
            // cBLlenarCodigoPE
            // 
            this.cBLlenarCodigoPE.AutoSize = true;
            this.cBLlenarCodigoPE.Location = new System.Drawing.Point(119, 224);
            this.cBLlenarCodigoPE.Name = "cBLlenarCodigoPE";
            this.cBLlenarCodigoPE.Size = new System.Drawing.Size(192, 17);
            this.cBLlenarCodigoPE.TabIndex = 12;
            this.cBLlenarCodigoPE.Text = "Llenar codigo producto especifico?";
            this.cBLlenarCodigoPE.UseVisualStyleBackColor = true;
            // 
            // cBUnidad
            // 
            this.cBUnidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBUnidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBUnidad.FormattingEnabled = true;
            this.cBUnidad.Location = new System.Drawing.Point(119, 169);
            this.cBUnidad.Name = "cBUnidad";
            this.cBUnidad.Size = new System.Drawing.Size(200, 21);
            this.cBUnidad.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(40, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 87;
            this.label11.Text = "Tipo inventario";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cBTipoCalculoInventario
            // 
            this.cBTipoCalculoInventario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBTipoCalculoInventario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBTipoCalculoInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBTipoCalculoInventario.FormattingEnabled = true;
            this.cBTipoCalculoInventario.Location = new System.Drawing.Point(119, 196);
            this.cBTipoCalculoInventario.Name = "cBTipoCalculoInventario";
            this.cBTipoCalculoInventario.Size = new System.Drawing.Size(200, 21);
            this.cBTipoCalculoInventario.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 86;
            this.label5.Text = "Unidad";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cBMarca
            // 
            this.cBMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMarca.FormattingEnabled = true;
            this.cBMarca.Location = new System.Drawing.Point(119, 142);
            this.cBMarca.Name = "cBMarca";
            this.cBMarca.Size = new System.Drawing.Size(300, 21);
            this.cBMarca.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 84;
            this.label8.Text = "Nombre producto 2";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBNombreProducto2
            // 
            this.tBNombreProducto2.Location = new System.Drawing.Point(119, 116);
            this.tBNombreProducto2.Name = "tBNombreProducto2";
            this.tBNombreProducto2.Size = new System.Drawing.Size(498, 20);
            this.tBNombreProducto2.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 81;
            this.label7.Text = "Código fabricante";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 345);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 89;
            this.label9.Text = "Observaciones";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBObservaciones
            // 
            this.tBObservaciones.Location = new System.Drawing.Point(118, 342);
            this.tBObservaciones.Multiline = true;
            this.tBObservaciones.Name = "tBObservaciones";
            this.tBObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBObservaciones.Size = new System.Drawing.Size(499, 40);
            this.tBObservaciones.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(75, 150);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 85;
            this.label17.Text = "Marca";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "Nombre producto 1";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "Nombre producto";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Código producto";
            // 
            // tBNombreProducto
            // 
            this.tBNombreProducto.Location = new System.Drawing.Point(119, 64);
            this.tBNombreProducto.Name = "tBNombreProducto";
            this.tBNombreProducto.Size = new System.Drawing.Size(498, 20);
            this.tBNombreProducto.TabIndex = 4;
            this.tBNombreProducto.Leave += new System.EventHandler(this.tBNombreProducto_Leave);
            // 
            // tBNombreProducto1
            // 
            this.tBNombreProducto1.Location = new System.Drawing.Point(119, 90);
            this.tBNombreProducto1.Name = "tBNombreProducto1";
            this.tBNombreProducto1.Size = new System.Drawing.Size(498, 20);
            this.tBNombreProducto1.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 90;
            this.label6.Text = "Rendimiento 1 [%]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(284, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 92;
            this.label10.Text = "Rendimiento 2 [%]";
            // 
            // tBRendimientoDeseado2
            // 
            this.tBRendimientoDeseado2.Location = new System.Drawing.Point(377, 270);
            this.tBRendimientoDeseado2.Name = "tBRendimientoDeseado2";
            this.tBRendimientoDeseado2.Size = new System.Drawing.Size(69, 20);
            this.tBRendimientoDeseado2.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(452, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 94;
            this.label12.Text = "Rendimiento 3  [%]";
            // 
            // tBRendimientoDeseado3
            // 
            this.tBRendimientoDeseado3.Location = new System.Drawing.Point(548, 270);
            this.tBRendimientoDeseado3.Name = "tBRendimientoDeseado3";
            this.tBRendimientoDeseado3.Size = new System.Drawing.Size(69, 20);
            this.tBRendimientoDeseado3.TabIndex = 18;
            // 
            // FAgregarEditarProducto
            // 
            this.AcceptButton = this.bAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancelar;
            this.ClientSize = new System.Drawing.Size(638, 425);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tBRendimientoDeseado3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tBRendimientoDeseado2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tBRendimientoDeseado1);
            this.Controls.Add(this.cBCopiarCodigo);
            this.Controls.Add(this.cBGenerarAutomaticamenteCodigoProducto);
            this.Controls.Add(this.btnUnidades);
            this.Controls.Add(this.btnMarcas);
            this.Controls.Add(this.tBCodigoProducto);
            this.Controls.Add(this.tBCodigoProductoFabricante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBDescripcion);
            this.Controls.Add(this.cBCalcularPrecioVenta);
            this.Controls.Add(this.cBProductoSimple);
            this.Controls.Add(this.cBProductoTangible);
            this.Controls.Add(this.cBLlenarCodigoPE);
            this.Controls.Add(this.cBUnidad);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cBTipoCalculoInventario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cBMarca);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tBNombreProducto2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tBObservaciones);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBNombreProducto);
            this.Controls.Add(this.tBNombreProducto1);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FAgregarEditarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.FAgregarEditarProducto_Load);
            this.Shown += new System.EventHandler(this.FAgregarEditarProducto_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolTip toolTipProductos;
        private System.Windows.Forms.OpenFileDialog oFDImagenProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox tBRendimientoDeseado1;
        private System.Windows.Forms.CheckBox cBCopiarCodigo;
        private System.Windows.Forms.CheckBox cBGenerarAutomaticamenteCodigoProducto;
        private System.Windows.Forms.Button btnUnidades;
        private System.Windows.Forms.Button btnMarcas;
        private System.Windows.Forms.TextBox tBCodigoProducto;
        private System.Windows.Forms.TextBox tBCodigoProductoFabricante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBDescripcion;
        private System.Windows.Forms.CheckBox cBCalcularPrecioVenta;
        private System.Windows.Forms.CheckBox cBProductoSimple;
        private System.Windows.Forms.CheckBox cBProductoTangible;
        private System.Windows.Forms.CheckBox cBLlenarCodigoPE;
        private System.Windows.Forms.ComboBox cBUnidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cBTipoCalculoInventario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBMarca;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBNombreProducto2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBObservaciones;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBNombreProducto;
        private System.Windows.Forms.TextBox tBNombreProducto1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBRendimientoDeseado3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBRendimientoDeseado2;
        private System.Windows.Forms.Label label6;
    }
}