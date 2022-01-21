namespace WFADoblones20.FormulariosGestionComercial
{
    partial class FCompraProductosPagosIE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCompraProductosPagosIE));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBoxProveedorTelf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxProveedorCuentaBanco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxProveedorNIT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxProveedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtBoxMonto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboxMoneda = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxCuentas = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblDatosTransaccion = new System.Windows.Forms.Label();
            this.txtBoxMontoPagado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBoxMontoTotalCompra = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtGVPagosDetalle = new System.Windows.Forms.DataGridView();
            this.DGCNombreCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCMontoCanceladoMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreMoneda = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DGCMontoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdSourcePagosDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.bdNavigatorPagosDetalle = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtBoxMontoDiferencia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPagosDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourcePagosDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavigatorPagosDetalle)).BeginInit();
            this.bdNavigatorPagosDetalle.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoxProveedorTelf);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBoxProveedorCuentaBanco);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBoxProveedorNIT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBoxProveedor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(829, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Compra Proveedor";
            // 
            // txtBoxProveedorTelf
            // 
            this.txtBoxProveedorTelf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxProveedorTelf.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxProveedorTelf.Location = new System.Drawing.Point(733, 25);
            this.txtBoxProveedorTelf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxProveedorTelf.Name = "txtBoxProveedorTelf";
            this.txtBoxProveedorTelf.Size = new System.Drawing.Size(87, 21);
            this.txtBoxProveedorTelf.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(696, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Telf.";
            // 
            // txtBoxProveedorCuentaBanco
            // 
            this.txtBoxProveedorCuentaBanco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxProveedorCuentaBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxProveedorCuentaBanco.Location = new System.Drawing.Point(591, 25);
            this.txtBoxProveedorCuentaBanco.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxProveedorCuentaBanco.Name = "txtBoxProveedorCuentaBanco";
            this.txtBoxProveedorCuentaBanco.Size = new System.Drawing.Size(96, 21);
            this.txtBoxProveedorCuentaBanco.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(496, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cuenta Banco";
            // 
            // txtBoxProveedorNIT
            // 
            this.txtBoxProveedorNIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxProveedorNIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxProveedorNIT.Location = new System.Drawing.Point(381, 25);
            this.txtBoxProveedorNIT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxProveedorNIT.Name = "txtBoxProveedorNIT";
            this.txtBoxProveedorNIT.Size = new System.Drawing.Size(105, 21);
            this.txtBoxProveedorNIT.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(344, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "NIT";
            // 
            // txtBoxProveedor
            // 
            this.txtBoxProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxProveedor.Location = new System.Drawing.Point(92, 25);
            this.txtBoxProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxProveedor.Name = "txtBoxProveedor";
            this.txtBoxProveedor.Size = new System.Drawing.Size(251, 21);
            this.txtBoxProveedor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.txtBoxMonto);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cboxMoneda);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboxCuentas);
            this.groupBox2.Location = new System.Drawing.Point(16, 80);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(829, 50);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccion de Pagos";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.Location = new System.Drawing.Point(787, 15);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(35, 28);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "+";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtBoxMonto
            // 
            this.txtBoxMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMonto.BackColor = System.Drawing.Color.Black;
            this.txtBoxMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMonto.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtBoxMonto.Location = new System.Drawing.Point(652, 17);
            this.txtBoxMonto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxMonto.Name = "txtBoxMonto";
            this.txtBoxMonto.Size = new System.Drawing.Size(132, 22);
            this.txtBoxMonto.TabIndex = 12;
            this.txtBoxMonto.Text = "0.00";
            this.txtBoxMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBoxMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxMonto_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(601, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Monto";
            // 
            // cboxMoneda
            // 
            this.cboxMoneda.FormattingEnabled = true;
            this.cboxMoneda.Location = new System.Drawing.Point(469, 17);
            this.cboxMoneda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxMoneda.Name = "cboxMoneda";
            this.cboxMoneda.Size = new System.Drawing.Size(123, 24);
            this.cboxMoneda.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(400, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Moneda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cuenta";
            // 
            // cboxCuentas
            // 
            this.cboxCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCuentas.FormattingEnabled = true;
            this.cboxCuentas.Location = new System.Drawing.Point(72, 17);
            this.cboxCuentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxCuentas.Name = "cboxCuentas";
            this.cboxCuentas.Size = new System.Drawing.Size(324, 24);
            this.cboxCuentas.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblDatosTransaccion);
            this.groupBox3.Controls.Add(this.txtBoxMontoPagado);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtBoxMontoTotalCompra);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.dtGVPagosDetalle);
            this.groupBox3.Controls.Add(this.bdNavigatorPagosDetalle);
            this.groupBox3.Controls.Add(this.txtBoxMontoDiferencia);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(16, 138);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(829, 352);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalle de Pagos";
            // 
            // lblDatosTransaccion
            // 
            this.lblDatosTransaccion.AutoSize = true;
            this.lblDatosTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosTransaccion.Location = new System.Drawing.Point(13, 278);
            this.lblDatosTransaccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatosTransaccion.Name = "lblDatosTransaccion";
            this.lblDatosTransaccion.Size = new System.Drawing.Size(247, 18);
            this.lblDatosTransaccion.TabIndex = 20;
            this.lblDatosTransaccion.Text = "Cambio :7.01 Moneda : Dolares";
            // 
            // txtBoxMontoPagado
            // 
            this.txtBoxMontoPagado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMontoPagado.BackColor = System.Drawing.Color.Black;
            this.txtBoxMontoPagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMontoPagado.ForeColor = System.Drawing.Color.White;
            this.txtBoxMontoPagado.Location = new System.Drawing.Point(681, 299);
            this.txtBoxMontoPagado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxMontoPagado.Name = "txtBoxMontoPagado";
            this.txtBoxMontoPagado.ReadOnly = true;
            this.txtBoxMontoPagado.Size = new System.Drawing.Size(132, 22);
            this.txtBoxMontoPagado.TabIndex = 19;
            this.txtBoxMontoPagado.Text = "0.00";
            this.txtBoxMontoPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(577, 304);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = "Monto Pagado";
            // 
            // txtBoxMontoTotalCompra
            // 
            this.txtBoxMontoTotalCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMontoTotalCompra.BackColor = System.Drawing.Color.Black;
            this.txtBoxMontoTotalCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMontoTotalCompra.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtBoxMontoTotalCompra.Location = new System.Drawing.Point(681, 274);
            this.txtBoxMontoTotalCompra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxMontoTotalCompra.Name = "txtBoxMontoTotalCompra";
            this.txtBoxMontoTotalCompra.ReadOnly = true;
            this.txtBoxMontoTotalCompra.Size = new System.Drawing.Size(132, 22);
            this.txtBoxMontoTotalCompra.TabIndex = 17;
            this.txtBoxMontoTotalCompra.Text = "0.00";
            this.txtBoxMontoTotalCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(545, 279);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Monto Total Compra";
            // 
            // dtGVPagosDetalle
            // 
            this.dtGVPagosDetalle.AllowUserToAddRows = false;
            this.dtGVPagosDetalle.AllowUserToResizeRows = false;
            this.dtGVPagosDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGVPagosDetalle.AutoGenerateColumns = false;
            this.dtGVPagosDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVPagosDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVPagosDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPagosDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCNombreCuenta,
            this.DGCMontoCanceladoMoneda,
            this.DGCNombreMoneda,
            this.DGCMontoPago});
            this.dtGVPagosDetalle.DataSource = this.bdSourcePagosDetalle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGVPagosDetalle.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVPagosDetalle.Location = new System.Drawing.Point(8, 54);
            this.dtGVPagosDetalle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtGVPagosDetalle.MultiSelect = false;
            this.dtGVPagosDetalle.Name = "dtGVPagosDetalle";
            this.dtGVPagosDetalle.RowHeadersWidth = 30;
            this.dtGVPagosDetalle.Size = new System.Drawing.Size(808, 215);
            this.dtGVPagosDetalle.TabIndex = 0;
            this.dtGVPagosDetalle.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtGVPagosDetalle_CellValidating);
            this.dtGVPagosDetalle.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVPagosDetalle_CellValueChanged);
            this.dtGVPagosDetalle.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtGVPagosDetalle_DataError);
            // 
            // DGCNombreCuenta
            // 
            this.DGCNombreCuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCNombreCuenta.DataPropertyName = "NombreCuenta";
            this.DGCNombreCuenta.HeaderText = "Cuenta";
            this.DGCNombreCuenta.Name = "DGCNombreCuenta";
            this.DGCNombreCuenta.ReadOnly = true;
            // 
            // DGCMontoCanceladoMoneda
            // 
            this.DGCMontoCanceladoMoneda.DataPropertyName = "MontoCanceladoMoneda";
            this.DGCMontoCanceladoMoneda.HeaderText = "Monto Ing";
            this.DGCMontoCanceladoMoneda.Name = "DGCMontoCanceladoMoneda";
            // 
            // DGCNombreMoneda
            // 
            this.DGCNombreMoneda.DataPropertyName = "CodigoMoneda";
            this.DGCNombreMoneda.HeaderText = "Moneda";
            this.DGCNombreMoneda.Name = "DGCNombreMoneda";
            this.DGCNombreMoneda.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCNombreMoneda.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DGCMontoPago
            // 
            this.DGCMontoPago.DataPropertyName = "MontoCancelado";
            this.DGCMontoPago.HeaderText = "Monto Moneda";
            this.DGCMontoPago.Name = "DGCMontoPago";
            this.DGCMontoPago.ReadOnly = true;
            this.DGCMontoPago.ToolTipText = "Monto a Descontar de la Cuenta Actual";
            // 
            // bdNavigatorPagosDetalle
            // 
            this.bdNavigatorPagosDetalle.AddNewItem = this.bindingNavigatorCountItem;
            this.bdNavigatorPagosDetalle.BindingSource = this.bdSourcePagosDetalle;
            this.bdNavigatorPagosDetalle.CountItem = this.bindingNavigatorCountItem;
            this.bdNavigatorPagosDetalle.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bdNavigatorPagosDetalle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bdNavigatorPagosDetalle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorDeleteItem});
            this.bdNavigatorPagosDetalle.Location = new System.Drawing.Point(4, 19);
            this.bdNavigatorPagosDetalle.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdNavigatorPagosDetalle.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdNavigatorPagosDetalle.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdNavigatorPagosDetalle.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdNavigatorPagosDetalle.Name = "bdNavigatorPagosDetalle";
            this.bdNavigatorPagosDetalle.PositionItem = this.bindingNavigatorPositionItem;
            this.bdNavigatorPagosDetalle.Size = new System.Drawing.Size(821, 27);
            this.bdNavigatorPagosDetalle.TabIndex = 15;
            this.bdNavigatorPagosDetalle.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(48, 24);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorDeleteItem.Text = "Eliminar";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(65, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // txtBoxMontoDiferencia
            // 
            this.txtBoxMontoDiferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMontoDiferencia.BackColor = System.Drawing.Color.Black;
            this.txtBoxMontoDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMontoDiferencia.ForeColor = System.Drawing.Color.Red;
            this.txtBoxMontoDiferencia.Location = new System.Drawing.Point(683, 324);
            this.txtBoxMontoDiferencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxMontoDiferencia.Name = "txtBoxMontoDiferencia";
            this.txtBoxMontoDiferencia.ReadOnly = true;
            this.txtBoxMontoDiferencia.Size = new System.Drawing.Size(132, 22);
            this.txtBoxMontoDiferencia.TabIndex = 14;
            this.txtBoxMontoDiferencia.Text = "0.00";
            this.txtBoxMontoDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(620, 329);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Direncia";
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnAceptar);
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 497);
            this.pnlBotones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(861, 47);
            this.pnlBotones.TabIndex = 4;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(637, 9);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(745, 9);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NombreCuenta";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cuenta";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MontoPago";
            this.dataGridViewTextBoxColumn2.HeaderText = "Monto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ToolTipText = "Monto a Descontar de la Cuenta Actual";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MontoCancelado";
            this.dataGridViewTextBoxColumn3.HeaderText = "Monto Moneda";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.ToolTipText = "Monto a Descontar de la Cuenta Actual";
            // 
            // FCompraProductosPagosIE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(861, 544);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FCompraProductosPagosIE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago de Compras";
            this.Load += new System.EventHandler(this.FCompraProductosPagosIE_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPagosDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourcePagosDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavigatorPagosDetalle)).EndInit();
            this.bdNavigatorPagosDetalle.ResumeLayout(false);
            this.bdNavigatorPagosDetalle.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtBoxProveedorTelf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxProveedorCuentaBanco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxProveedorNIT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxCuentas;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtBoxMonto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboxMoneda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dtGVPagosDetalle;
        private System.Windows.Forms.BindingSource bdSourcePagosDetalle;
        private System.Windows.Forms.BindingNavigator bdNavigatorPagosDetalle;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox txtBoxMontoDiferencia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBoxMontoPagado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBoxMontoTotalCompra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblDatosTransaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCMontoCanceladoMoneda;
        private System.Windows.Forms.DataGridViewComboBoxColumn DGCNombreMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCMontoPago;
    }
}