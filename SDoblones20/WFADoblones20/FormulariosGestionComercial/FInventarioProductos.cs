using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN;
using WFADoblones20.FormulariosGestionComercial;
using CLCLN.GestionComercial;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FInventarioProductos : Form
    {
        const int altoPanelBusqueda = 120;
        const int altoPanelBusquedaOpciones = 30;
        const char Cancelar = 'C';
        const char Editar = 'E';
        const char GuardarCambios = 'G';
        bool modoEdicion = false;
        bool mostarVentanaEspecificos = false;

        DataTable DTInventarioProductos = null;
        DataTable DTSistemaConfiguracion = null;
        
        InventariosProductosCLN inventarioCLN = new InventariosProductosCLN();        
        private int NumeroAgencia = 1;
        private int NumeroPC = 1;

        private decimal TazaInterezIVA = 0;
        bool existeCambioAutomaticoPrecio = false;
        bool existeCambioAutomaticoUtilidad = false;

        FInventarioProductosEspecificos finventarioProductosEspecificos = null;
        CLCLN.Sistema.PCsConfiguracionesCLN _PCsConfiguracionesCLN = null;

        public FInventarioProductos(int NumeroAgencia, int NumeroPC)
        {
            InitializeComponent();

            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            DTInventarioProductos = new DataTable();
            
            inventarioCLN = new InventariosProductosCLN();
            _PCsConfiguracionesCLN = new CLCLN.Sistema.PCsConfiguracionesCLN();

            DTSistemaConfiguracion = _PCsConfiguracionesCLN.ObtenerConfiguracionSistemaParaTransaccionesGC(NumeroPC);
            TazaInterezIVA = Decimal.Parse(DTSistemaConfiguracion.Rows[0]["PorcentajeImpuestoSistema"].ToString());

            dGVProductosBusqueda.DataSource = bSInventarioProductos;
            dGVProductosBusqueda.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dGVProductosBusqueda.BorderStyle = BorderStyle.Fixed3D;
            dGVProductosBusqueda.EditMode = DataGridViewEditMode.EditOnF2;
            dGVProductosBusqueda.AutoGenerateColumns = false;
            DTInventarioProductos = inventarioCLN.BuscarProductoInventario("1", "------",true, -20000, NumeroAgencia);
            bSInventarioProductos.DataSource = DTInventarioProductos;



            txtBosCodigoProducto.DataBindings.Add(new Binding("Text", bSInventarioProductos, "CodigoProducto", true));
            txtBoxNombreProducto.DataBindings.Add(new Binding("Text", bSInventarioProductos, "NombreProducto", true));
            txtBoxDescripcion.DataBindings.Add(new Binding("Text", bSInventarioProductos, "Descripcion", true));

            lblCantidadExistencia.DataBindings.Add(new Binding("Text", bSInventarioProductos, "CantidadExistencia", true));
            lblCantidadRequerida.DataBindings.Add(new Binding("Text", bSInventarioProductos, "CantidadRequerida", true));
            
            txtBoxCantidadExistencia.DataBindings.Add(new Binding("Text", bSInventarioProductos, "CantidadExistencia", true));
            txtCantidadRequerida.DataBindings.Add(new Binding("Text", bSInventarioProductos, "CantidadRequerida", true));

            nUDPorUtilidad1.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PorcentajeUtilidad1", true));
            nUDPorUtilidad2.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PorcentajeUtilidad2", true));
            nUDPorUtilidad3.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PorcentajeUtilidad3", true));
            nUDPorUtilidad4.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PorcentajeUtilidad4", true));
            nUDPorUtilidad5.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PorcentajeUtilidad5", true));
            nUDPorUtilidad6.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PorcentajeUtilidad6", true));

            nUDPrecioCompra.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PrecioUnitarioCompra", true));
            nUDPrecioVenta1.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PrecioUnitarioVenta1", true));
            nUDPrecioVenta2.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PrecioUnitarioVenta2", true));
            nUDPrecioVenta3.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PrecioUnitarioVenta3", true));
            nUDPrecioVenta4.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PrecioUnitarioVenta4", true));
            nUDPrecioVenta5.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PrecioUnitarioVenta5", true));
            nUDPrecioVenta6.DataBindings.Add(new Binding("Value", bSInventarioProductos, "PrecioUnitarioVenta6", true));
            nUDTiempoGarantia.DataBindings.Add(new Binding("Value", bSInventarioProductos, "TiempoGarantiaProducto", true));

            
            txtBoxStockMinimo.DataBindings.Add(new Binding("Text", bSInventarioProductos, "StockMinimo", true));

            checkDisponibleVenta.DataBindings.Add(new Binding("Checked", bSInventarioProductos, "MostrarParaVenta", true));
            checkTipoProducto.DataBindings.Add(new Binding("Checked", bSInventarioProductos, "ClaseProducto", true));
            checkEsProductoEspecifico.DataBindings.Add(new Binding("Checked", bSInventarioProductos, "EsProductoEspecifico", true));

            HabilitarCamposInventario(false);

            finventarioProductosEspecificos = new FInventarioProductosEspecificos();
            cBoxBuscarPor.SelectedIndex = 2;
        }



        private void btnOcultar_Click(object sender, EventArgs e)
        {
            pnlBusqueda.Visible = false;
            pnlBusqueda.Height -= altoPanelBusqueda;
        }

        private void FInventarioProductos_Load(object sender, EventArgs e)
        {               
            habilitarBotones(GuardarCambios);
            DGCCodigoProducto.Width = 85;
            DGCNombreProducto.Width = 230; 
        }

        private void dGVProductosBusqueda_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVProductosBusqueda.RowCount > 0)
            {
                if (Int32.Parse(DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["CantidadExistencia"].ToString()) > 0)
                {
                    this.lblAlerta.ForeColor = System.Drawing.Color.Red;
                    this.lblAlerta.Text = "Stock Existente";
                }
                else
                {
                    this.lblAlerta.ForeColor = System.Drawing.Color.Blue;
                    this.lblAlerta.Text = "Stock Inexistente";
                }
                object comparador =DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["ClaseProducto"];
                if (comparador.Equals("COMPUESTO"))
                {
                    checkTipoProducto.Checked = true;
                }
                else
                {
                    checkTipoProducto.Checked = false;
                }
            }
                
        }

        private void txtCodigoBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dGVProductosBusqueda.Focus();                
            }
            if (e.KeyCode == Keys.Escape)
            {
                txtNombreBusqueda.Clear();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e as EventArgs);                
            }
                
        }

        private void dGVProductosBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsLetter(e.KeyChar))
            {
                txtNombreBusqueda.Text = e.KeyChar.ToString();
                txtNombreBusqueda.Focus();
                txtNombreBusqueda.SelectionStart = 1;
            }
        }

        private void btnMinizar_Click(object sender, EventArgs e)
        {
            //pnlOpcionesBusqueda.Visible = false;
            //pnlOpcionesBusqueda.Height -= altoPanelBusquedaOpciones;
            groupBox1.Visible = false;            
            pnlBusqueda.Height -= groupBox1.Height;
            groupBox1.Height = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            pnlBusqueda.Height = altoPanelBusqueda;
            groupBox1.Visible = true;
            pnlOpcionesBusqueda.Visible = true;
            pnlBusqueda.Visible = true;
            txtNombreBusqueda.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlBusqueda.Visible = false;
            pnlBusqueda.Height = 0;
        }


        public void HabilitarCamposInventario(bool estadoHabilitacion)
        {
            this.nUDPorUtilidad1.Enabled = estadoHabilitacion;
            this.nUDPorUtilidad2.Enabled = estadoHabilitacion;
            this.nUDPorUtilidad3.Enabled = estadoHabilitacion;
            this.nUDPorUtilidad4.Enabled = estadoHabilitacion;
            this.nUDPorUtilidad5.Enabled = estadoHabilitacion;
            this.nUDPorUtilidad6.Enabled = estadoHabilitacion;

            this.nUDPrecioCompra.Enabled = estadoHabilitacion;

            this.nUDPrecioVenta1.Enabled = estadoHabilitacion;
            this.nUDPrecioVenta2.Enabled = estadoHabilitacion;
            this.nUDPrecioVenta3.Enabled = estadoHabilitacion;
            this.nUDPrecioVenta4.Enabled = estadoHabilitacion;
            this.nUDPrecioVenta5.Enabled = estadoHabilitacion;
            this.nUDPrecioVenta6.Enabled = estadoHabilitacion;

            this.nUDTiempoGarantia.Enabled = estadoHabilitacion;

            this.checkDecimales.Enabled = estadoHabilitacion;            
            txtCantidadRequerida.Visible = estadoHabilitacion;
            txtBoxCantidadExistencia.Visible = estadoHabilitacion;
            lblCantidadExistencia.Visible = !estadoHabilitacion;
            lblCantidadRequerida.Visible = !estadoHabilitacion;

            this.checkCalcularIVA.Enabled = estadoHabilitacion;

            txtBoxStockMinimo.Enabled = estadoHabilitacion;
            checkDisponibleVenta.Enabled = estadoHabilitacion;
            checkTipoProducto.Enabled = estadoHabilitacion;            
            checkEsProductoEspecifico.Enabled = estadoHabilitacion;
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            modoEdicion = true;
            dGVProductosBusqueda.Enabled = false;
            txtNombreBusqueda.ReadOnly = true;
            HabilitarCamposInventario(true);
            checkBox1_CheckedChanged(sender, e);
            nUDPrecioCompra.Focus();
            habilitarBotones(Editar);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                char tipoProducto = 'S';
                if (checkTipoProducto.Checked)
                    tipoProducto = 'C';                
                
                //string CodigoProducto = DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentCell.RowIndex][0].ToString();
                string CodigoProducto = txtBosCodigoProducto.Text;
                int CantidadExistencia =  Int32.Parse(txtBoxCantidadExistencia.Text);
                int CantidadRequerida = Int32.Parse(txtCantidadRequerida.Text);
                decimal PrecioUnitarioCompra = nUDPrecioCompra.Value;
                int TiempoGarantiaProducto = (int) nUDTiempoGarantia.Value;
                decimal PorcentajeUtilidad1 = nUDPorUtilidad1.Value;
                decimal PrecioUnitarioVenta1 = nUDPrecioVenta1.Value;
                decimal PorcentajeUtilidad2 = nUDPorUtilidad2.Value;
                decimal PrecioUnitarioVenta2 = nUDPrecioVenta2.Value;
                decimal PorcentajeUtilidad3 = nUDPorUtilidad3.Value;
                decimal PrecioUnitarioVenta3 = nUDPrecioVenta3.Value;
                decimal PorcentajeUtilidad4 = nUDPorUtilidad4.Value;
                decimal PrecioUnitarioVenta4 = nUDPrecioVenta4.Value;
                decimal PorcentajeUtilidad5 = nUDPorUtilidad5.Value;
                decimal PrecioUnitarioVenta5 = nUDPrecioVenta5.Value;
                decimal PorcentajeUtilidad6 = nUDPorUtilidad6.Value;
                decimal PrecioUnitarioVenta6 = nUDPrecioVenta6.Value;
                int StockMinimo = Int32.Parse(txtBoxStockMinimo.Text);
                bool MostrarParaVenta = checkDisponibleVenta.Checked;
                bool EsProductoEspecifico = checkEsProductoEspecifico.Checked;
                bool ProductoEspecificoGenerado = Boolean.Parse(DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["ProductoEspecificoInventariado"].ToString());


                
                //validación para el caso en que se cambia el estado de ProductoEspecifico a normal
                //en caso de que haya registros de codigosEspecifios en Inventario
                bool consideradoEspecifico = inventarioCLN.EsProductoEspecifico(NumeroAgencia, CodigoProducto);
                if (ProductoEspecificoGenerado && !checkEsProductoEspecifico.Checked)
                {
                    
                    if (consideradoEspecifico)
                    {
                        int cantidadRegistrada = inventarioCLN.ObtenerCantidadCodigosEspcificosInventariados(NumeroAgencia, CodigoProducto);
                        if (cantidadRegistrada > 0)
                        {
                            MessageBox.Show(this, "No puede Cambiar el Estado del Producto Seleccionado." + Environment.NewLine + "El Producto tiene aun referencias a Código Específicos para el mismo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["EsProductoEspecifico"] = true;
                            checkEsProductoEspecifico.Checked = true;
                            btnCancelar_Click(sender, e);
                            return;
                        }
                    }
                }

                /**para el Caso en el que la cantidad de existencia cambia de acuerdo a terminos del usuario
                 * en un producto que es considerado como Producto Especifico, y se altera el balance en Inventario de CodigosEspecificos
                 * 
                 * 
                */

                if (consideradoEspecifico)
                {
                    int CantidadExistenciaAnterior = Int32.Parse(lblCantidadExistencia.Text);
                    if (CantidadExistencia > CantidadExistenciaAnterior)
                    {
                        if (MessageBox.Show(this, "Esta intentando alterar la Cantidad de Existencia para un producto específico" + Environment.NewLine + "Esto puede ocacionar que no existan concordancia en su Inventario de codigos Específicos" + Environment.NewLine + "¿Desea Continuar la operación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            btnCancelar_Click(sender, e);
                            return;
                        }
                        else
                        {
                            mostarVentanaEspecificos = true;
                            DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["ProductoEspecificoInventariado"] = false;
                        }
                    }
                }

                try
                {
                    //inventarioCLN.ActualizarInventarioProducto(NumeroAgencia, CodigoProducto, CantidadExistencia, CantidadRequerida, PrecioUnitarioCompra, TiempoGarantiaProducto, PorcentajeUtilidad1, PrecioUnitarioVenta1, PorcentajeUtilidad2, PrecioUnitarioVenta2, PorcentajeUtilidad3, PrecioUnitarioVenta3, PorcentajeUtilidad4, PrecioUnitarioVenta4, PorcentajeUtilidad5, PrecioUnitarioVenta5, PorcentajeUtilidad6, PrecioUnitarioVenta6, StockMinimo, MostrarParaVenta, tipoProducto.ToString(), EsProductoEspecifico, ProductoEspecificoGenerado);
                    MessageBox.Show(this, "Los Cambios Realizados, fueron actualizados correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Mo se pudo Guardar Satisfactoriamente los cambios");
                    return;
                }
                int indiceActual = bSInventarioProductos.Position;
                lblCantidadExistencia.Text = CantidadExistencia.ToString();
                HabilitarCamposInventario(false);                
                dGVProductosBusqueda.Enabled = true;
                txtNombreBusqueda.ReadOnly = false;
                //checkBox1_CheckedChanged(sender, e);
                
                //if(checkRecordarBusqueda.Checked)
                //    DTInventarioProductos = inventarioCLN.BuscarProductoInventario(cBoxBuscarPor.SelectedIndex.ToString(), txtNombreBusqueda.Text.Trim(), checkExactamenteIgual.Checked,(int)nUDCantidadBusqueda.Value);
                //else
                //    DTInventarioProductos = inventarioCLN.BuscarProductoInventario("0", CodigoProducto,true, 1);
                //if (checkAgotados.Checked)
                //{
                //    checkAgotados_CheckedChanged(sender, e);
                //    bSInventarioProductos.Position = indiceActual;
                //}
                //else {                    
                //    bSInventarioProductos.DataSource = DTInventarioProductos;                    
                //}

                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["CantidadExistencia"] = CantidadExistencia;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["CantidadRequerida"] = CantidadRequerida;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PrecioUnitarioCompra"] = PrecioUnitarioCompra;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["TiempoGarantiaProducto"] = TiempoGarantiaProducto;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PorcentajeUtilidad1"] = PorcentajeUtilidad1;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PrecioUnitarioVenta1"] = PrecioUnitarioVenta1;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PorcentajeUtilidad2"] = PorcentajeUtilidad2;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PrecioUnitarioVenta2"] = PrecioUnitarioVenta2;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PorcentajeUtilidad3"] = PorcentajeUtilidad3;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PrecioUnitarioVenta3"] = PrecioUnitarioVenta3;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PorcentajeUtilidad4"] = PorcentajeUtilidad4;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PrecioUnitarioVenta4"] = PrecioUnitarioVenta4;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PorcentajeUtilidad5"] = PorcentajeUtilidad5;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PrecioUnitarioVenta5"] = PrecioUnitarioVenta5;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PorcentajeUtilidad6"] = PorcentajeUtilidad6;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["PrecioUnitarioVenta6"] = PrecioUnitarioVenta6;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["StockMinimo"] = StockMinimo;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["MostrarParaVenta"] = MostrarParaVenta;
                DTInventarioProductos.Columns["ClaseProducto"].ReadOnly = false;
                DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["ClaseProducto"] = tipoProducto == 'S' ? "SIMPLE" : "COMPUESTO";
                DTInventarioProductos.Columns["ClaseProducto"].ReadOnly = true;
                DTInventarioProductos.AcceptChanges();
                
                

                bSInventarioProductos.Position = indiceActual;
                dGVProductosBusqueda.ClearSelection();
                dGVProductosBusqueda.Rows[indiceActual].Selected = true;
                bSInventarioProductos.ResetBindings(false);
                habilitarBotones(GuardarCambios);
                modoEdicion = false;
                checkCalcularIVA.Checked = false;

                if (mostarVentanaEspecificos)
                {
                    btnCodigoEspecificos_Click(sender, e);                    
                }
                mostarVentanaEspecificos = false;
            }
        }

        private void bSInventarioProductos_CurrentChanged(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                HabilitarCamposInventario(false);
            }
        }

        private void btnCerraVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dGVProductosBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtNombreBusqueda.Clear();                
            }
        }

        private decimal calcularPrecioVenta(decimal precioCompra, decimal porcentajeGanancia)
        {
            return porcentajeGanancia * precioCompra / 100 + precioCompra;
        }


        private decimal calcularPorcentaUtilidad(decimal precioVenta, decimal precioCompra)
        {
            //return precioCompra * precioVenta / 100 + precioVenta;
            decimal aux = 0;
            aux = precioVenta - precioCompra;
            return precioCompra == 0 ? 0 : aux * 100 / precioCompra;            
        }

        private void nUDPorUtilidad1_ValueChanged(object sender, EventArgs e)
        {
            if (existeCambioAutomaticoUtilidad)
            {
                existeCambioAutomaticoUtilidad = false;
                return;
            }
            if (modoEdicion)
            {
                nUDPrecioVenta1.Value = calcularPrecioVenta(nUDPrecioCompra.Value, nUDPorUtilidad1.Value);
            }
        }

        private void nUDPorUtilidad2_ValueChanged(object sender, EventArgs e)
        {
            if (existeCambioAutomaticoUtilidad)
            {
                existeCambioAutomaticoUtilidad = false;
                return;
            }
            if (modoEdicion)
            {
                nUDPrecioVenta2.Value = calcularPrecioVenta(nUDPrecioCompra.Value, nUDPorUtilidad2.Value);
            }
        }

        private void nUDPorUtilidad3_ValueChanged(object sender, EventArgs e)
        {
            if (existeCambioAutomaticoUtilidad)
            {
                existeCambioAutomaticoUtilidad = false;
                return;
            }
            if (modoEdicion)
            {
                nUDPrecioVenta3.Value = calcularPrecioVenta(nUDPrecioCompra.Value, nUDPorUtilidad3.Value);
            }
        }

        private void nUDPorUtilidad4_ValueChanged(object sender, EventArgs e)
        {
            if (existeCambioAutomaticoUtilidad)
            {
                existeCambioAutomaticoUtilidad = false;
                return;
            }
            if (modoEdicion)
            {
                if (!checkCalcularIVA.Checked)
                    nUDPrecioVenta4.Value = calcularPrecioVenta(nUDPrecioCompra.Value, nUDPorUtilidad4.Value);
                else
                {
                    //nUDPrecioVenta4.Value = calcularPrecioVenta(nUDPrecioCompra.Value, TazaInterezIVA);
                }
            }
        }

        private void nUDPorUtilidad5_ValueChanged(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                if (!checkCalcularIVA.Checked)
                    nUDPrecioVenta5.Value = calcularPrecioVenta(nUDPrecioCompra.Value, nUDPorUtilidad5.Value);
                //else
                    //nUDPrecioVenta5.Value = calcularPrecioVenta(nUDPrecioCompra.Value, TazaInterezIVA);  
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDecimales.Checked)
            {
                nUDIncremento.Enabled = true;
                if (nUDIncremento.Value.ToString().Length != 0)
                {
                    decimal cantidad = 0;
                    try
                    {
                        cantidad = nUDIncremento.Value;                        
                    }
                    catch (Exception )
                    {
                        MessageBox.Show(this,"Debe introducir Correctamente la Cantidad de Incremento","Introducción de datos Incorrecta",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    if (cantidad == 0)
                        cantidad = 1;
                    nUDPorUtilidad1.DecimalPlaces = 2;
                    nUDPorUtilidad2.DecimalPlaces = 2;
                    nUDPorUtilidad3.DecimalPlaces = 2;
                    nUDPorUtilidad4.DecimalPlaces = 2;
                    nUDPorUtilidad5.DecimalPlaces = 2;
                    nUDPorUtilidad6.DecimalPlaces = 2;

                    nUDPorUtilidad1.Increment = cantidad;
                    nUDPorUtilidad2.Increment = cantidad;
                    nUDPorUtilidad3.Increment = cantidad;
                    nUDPorUtilidad4.Increment = cantidad;
                    nUDPorUtilidad5.Increment = cantidad;
                    nUDPorUtilidad6.Increment = cantidad;
                }
                else
                {
                    nUDPorUtilidad1.DecimalPlaces = 0;
                    nUDPorUtilidad2.DecimalPlaces = 0;
                    nUDPorUtilidad3.DecimalPlaces = 0;
                    nUDPorUtilidad4.DecimalPlaces = 0;
                    nUDPorUtilidad5.DecimalPlaces = 0;
                    nUDPorUtilidad6.DecimalPlaces = 0;

                    nUDPorUtilidad1.Increment = 1;
                    nUDPorUtilidad2.Increment = 1;
                    nUDPorUtilidad3.Increment = 1;
                    nUDPorUtilidad4.Increment = 1;
                    nUDPorUtilidad5.Increment = 1;
                    nUDPorUtilidad6.Increment = 1;
                }
            }
            else
            {
                nUDIncremento.Enabled = false;
                nUDIncremento.Value = 1;
                nUDPorUtilidad1.DecimalPlaces = 0;
                nUDPorUtilidad2.DecimalPlaces = 0;
                nUDPorUtilidad3.DecimalPlaces = 0;
                nUDPorUtilidad4.DecimalPlaces = 0;
                nUDPorUtilidad5.DecimalPlaces = 0;
                nUDPorUtilidad6.DecimalPlaces = 0;
            }
        }

        private void txtBoxNroDecimales_TextChanged(object sender, EventArgs e)
        {
            checkBox1_CheckedChanged(sender, e);
        }

        private void rbtnMayorA_CheckedChanged(object sender, EventArgs e)
        {
            nUDCantidadBusqueda.Minimum = 1;
            nUDCantidadBusqueda.Maximum = 1000000;
        }

        private void rbtnMenoIgualA_CheckedChanged(object sender, EventArgs e)
        {
            nUDCantidadBusqueda.Minimum = -100000;
            nUDCantidadBusqueda.Maximum = 0;
        }

        private void dGVProductosBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGVProductosBusqueda.RowCount > 0 && e.RowIndex >= 0)
            {
                string CodigoProducto = DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["CodigoProducto"].ToString();
                object esProductoEspecifico = DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["EsProductoEspecifico"];
                if (!esProductoEspecifico.Equals(true))
                {
                    MessageBox.Show(this, "El Producto Seleccionado no es Considerado Específico", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    return;
                }
                finventarioProductosEspecificos.CodigoProducto = dGVProductosBusqueda[0, dGVProductosBusqueda.CurrentRow.Index].Value.ToString();
                finventarioProductosEspecificos.NumeroAgencia = NumeroAgencia;
                finventarioProductosEspecificos.NombreProducto = dGVProductosBusqueda[1, dGVProductosBusqueda.CurrentRow.Index].Value.ToString();
                //si ya tiene registrado sus productos Especificos
                if (dGVProductosBusqueda[4, dGVProductosBusqueda.CurrentRow.Index].Value.Equals(1))
                {
                    finventarioProductosEspecificos.MostrarHistorial = true;
                }
                else
                {
                    finventarioProductosEspecificos.MostrarHistorial = false;
                }
                finventarioProductosEspecificos.ShowDialog(this);
                //se debe actualizar la grilla para mostrar que ya han sido generados sus Códigos Especificos
                if (finventarioProductosEspecificos.codigosPEGeneradosTodos)
                {
                    DTInventarioProductos.Rows[dGVProductosBusqueda.CurrentRow.Index]["ProductoEspecificoInventariado"] = true;
                }
                int indice = bSInventarioProductos.Position;                
                bSInventarioProductos.Position = indice;
            }
            else
            {
                MessageBox.Show(this, "Probablemente aun no ha seleccionado un producto." + Environment.NewLine + "Porfavor, proceda a buscar un Productos y seleccionelo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombreBusqueda.Text.Trim()) && checkAgotados.Checked == false)
            {
                MessageBox.Show(this, "Aun no ha Ingresado un Datos para la Busqueda, porfavor, Proceda a proporcionarlos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreBusqueda.Focus();
                txtNombreBusqueda.SelectAll();
            }
            else
            {
                DTInventarioProductos = inventarioCLN.BuscarProductoInventario(cBoxBuscarPor.SelectedIndex.ToString(), txtNombreBusqueda.Text,checkExactamenteIgual.Checked, (int)nUDCantidadBusqueda.Value, NumeroAgencia);
                if (DTInventarioProductos != null)
                {
                    this.bSInventarioProductos.DataSource = DTInventarioProductos;

                    if (txtNombreBusqueda.Focused)
                        txtNombreBusqueda.SelectAll();
                    if (DTInventarioProductos.Rows.Count == 0)
                    {
                        btnEditar.Enabled = false;
                    }
                    else
                    {
                        btnEditar.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("No se Encontraron registros, probablemente esta utilizando este Caracter [' ' ']");
                    txtNombreBusqueda.Focus();
                    txtNombreBusqueda.SelectAll();
                }
            }
        }

        private void btnCodigoEspecificos_Click(object sender, EventArgs e)
        {           

            DataGridViewCellEventArgs es;
            if (dGVProductosBusqueda.RowCount > 0)
                es = new DataGridViewCellEventArgs(dGVProductosBusqueda.CurrentCell.ColumnIndex, dGVProductosBusqueda.CurrentCell.RowIndex);
            else
            {
                es = new DataGridViewCellEventArgs(-1,-1);
            }
            dGVProductosBusqueda_CellDoubleClick(sender, es);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modoEdicion = false;            
            HabilitarCamposInventario(false);
            dGVProductosBusqueda.Enabled = true;
            txtNombreBusqueda.ReadOnly = false;
            habilitarBotones(Cancelar);
            DTInventarioProductos.RejectChanges();
            bSInventarioProductos.ResetBindings(true);            
        }

        private void dGVProductosBusqueda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dGVProductosBusqueda.Enabled && !modoEdicion)
            {
                if (MessageBox.Show(this, "Actualmente se esta llevando a cabo la Edición de un Producto" + Environment.NewLine + "¿Desea Cancelar el Estado de Edición?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnCancelar_Click(sender, e as EventArgs);
                }
                else
                {
                    nUDPrecioCompra.Focus();
                    nUDPrecioCompra.Select(0,nUDPrecioCompra.Value.ToString().Length-1);
                }

            }
        }

        /// <summary>
        /// Se encarga de Habilitar los Botones de la Configuración del formulario
        /// 'E'-> Editar,
        /// 'C'-> Cancelar,
        /// 'G'-> Guardar Cambios
        /// 'I'-> Inventario de Productos Especificos
        /// 
        /// </summary>
        /// <param name="tipoAccion"></param>
        public void habilitarBotones(char tipoAccion)
        {
            switch (tipoAccion)
            {
                case 'E'://Editar
                    btnEditar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnActualizar.Enabled = true;
                    btnCerrar.Enabled = false;
                    btnBuscar.Enabled = false;
                    btnCodigoEspecificos.Enabled = false;
                    btnBuscarProductos.Enabled = false;
                    break;
                case 'C': //Cancelar
                    btnEditar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnActualizar.Enabled = false;
                    btnCerrar.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnCodigoEspecificos.Enabled = true;
                    btnBuscarProductos.Enabled = true;
                    break;
                case 'G'://Guardar Cambios
                    btnEditar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnActualizar.Enabled = false;
                    btnCerrar.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnCodigoEspecificos.Enabled = true;
                    btnBuscarProductos.Enabled = true;
                    break;
                case 'I':
                    break;
                default:
                    break;
            }
        }

        private void checkAgotados_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAgotados.Checked)
            {               
                txtNombreBusqueda.Clear();
                rbtnMenoIgualA.Checked = true;
                button1_Click(sender, e);
            }
            else
            {
                DTInventarioProductos.Clear();
                rbtnMayorA.Checked = true;
                txtNombreBusqueda.Focus();
                txtNombreBusqueda.SelectAll();
            }
                       
        }
        private void nUDPorUtilidad6_ValueChanged(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                if (!checkCalcularIVA.Checked)
                    nUDPrecioVenta6.Value = calcularPrecioVenta(nUDPrecioCompra.Value, nUDPorUtilidad6.Value);
                //else
                    //nUDPrecioVenta6.Value = calcularPrecioVenta(nUDPrecioCompra.Value, TazaInterezIVA);  
            }
        }

        private void nUDPrecioVenta1_ValueChanged(object sender, EventArgs e)
        {
            if (existeCambioAutomaticoPrecio)
            {
                existeCambioAutomaticoPrecio = false;
                return;
            }
            if (modoEdicion)
            {
                if (checkCalcularIVA.Checked)
                    nUDPrecioVenta4.Value = calcularPrecioVenta(nUDPrecioVenta1.Value, TazaInterezIVA);
                decimal PorcentajeUtilidad = calcularPorcentaUtilidad(nUDPrecioVenta1.Value, nUDPrecioCompra.Value);
                if (PorcentajeUtilidad > 0)
                {
                    existeCambioAutomaticoUtilidad = !existeCambioAutomaticoUtilidad;
                    nUDPorUtilidad1.Value = PorcentajeUtilidad;
                }
                else
                {
                    //MessageBox.Show(this, "No puede Dar un porcentaje de Utilidad Negativo");
                }
            }
        }

        private void nUDPrecioVenta2_ValueChanged(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                if (checkCalcularIVA.Checked)
                    nUDPrecioVenta5.Value = calcularPrecioVenta(nUDPrecioVenta2.Value, TazaInterezIVA);
                decimal PorcentajeUtilidad = calcularPorcentaUtilidad(nUDPrecioVenta2.Value, nUDPrecioCompra.Value);
                if (PorcentajeUtilidad > 0)
                {
                    existeCambioAutomaticoUtilidad = true;
                    nUDPorUtilidad2.Value = PorcentajeUtilidad;
                }
                else
                {
                    //MessageBox.Show(this, "No puede Dar un porcentaje de Utilidad Negativo");
                }
            }
        }

        private void nUDPrecioVenta3_ValueChanged(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                if (checkCalcularIVA.Checked)
                    nUDPrecioVenta6.Value = calcularPrecioVenta(nUDPrecioVenta3.Value, TazaInterezIVA);
                decimal PorcentajeUtilidad = calcularPorcentaUtilidad(nUDPrecioVenta3.Value, nUDPrecioCompra.Value);
                if (PorcentajeUtilidad > 0)
                {
                    existeCambioAutomaticoUtilidad = true;
                    nUDPorUtilidad3.Value = PorcentajeUtilidad;
                }
                else
                {
                    //MessageBox.Show(this, "No puede Dar un porcentaje de Utilidad Negativo");
                }
            }
        }

        private void checkCalcularIVA_CheckedChanged(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                if (checkCalcularIVA.Checked)
                {
                    nUDPrecioVenta1_ValueChanged(sender, e);
                    nUDPrecioVenta2_ValueChanged(sender, e);
                    nUDPrecioVenta3_ValueChanged(sender, e);
                }
                else
                {
                    nUDPorUtilidad4_ValueChanged(sender, e);
                    nUDPorUtilidad5_ValueChanged(sender, e);
                    nUDPorUtilidad6_ValueChanged(sender, e);
                }
            }
        }

        private void InventarioGeneral_Click(object sender, EventArgs e)
        {
            DataTable DTInventarioProductosGeneral = inventarioCLN.ListarInventarioGeneral(NumeroAgencia);
            FReporteInventarioGeneral formReporteInventario = new FReporteInventarioGeneral(DTInventarioProductosGeneral);
            formReporteInventario.ShowDialog(this);
            formReporteInventario.Dispose();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DataTable DTInventarioProductosGeneral = inventarioCLN.ListarInvetarioProductosAgotadosGeneral(NumeroAgencia);
            FReporteInventarioGeneral formReporteInventario = new FReporteInventarioGeneral(DTInventarioProductosGeneral);
            formReporteInventario.ShowDialog(this);
            formReporteInventario.Dispose();
        }

        private void txtBoxCantidadExistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && (((Keys)e.KeyChar)) != Keys.Back)
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void FInventarioProductos_Shown(object sender, EventArgs e)
        {
            if (dGVProductosBusqueda.RowCount == 0)
            {
                btnEditar.Enabled = false;
            }
        }

        private void pnlOpcionesBusqueda_MouseHover(object sender, EventArgs e)
        {
            pnlBusqueda.Height = altoPanelBusqueda;
            groupBox1.Visible = true;
            pnlOpcionesBusqueda.Visible = true;
            pnlBusqueda.Visible = true;
            txtNombreBusqueda.Focus();            
        }

        private void nUDPrecioVenta4_ValueChanged(object sender, EventArgs e)
        {
            /* if (modoEdicion)
            {
                if (checkCalcularIVA.Checked)
                    nUDPrecioVenta6.Value = calcularPrecioVenta(nUDPrecioVenta3.Value, TazaInterezIVA);
                decimal PorcentajeUtilidad = calcularPorcentaUtilidad(nUDPrecioVenta3.Value, nUDPrecioCompra.Value);
                if (PorcentajeUtilidad > 0)
                {
                    existeCambioAutomaticoUtilidad = true;
                    nUDPorUtilidad3.Value = PorcentajeUtilidad;
                }
                else
                {
                    //MessageBox.Show(this, "No puede Dar un porcentaje de Utilidad Negativo");
                }
            }*/


            if (modoEdicion)
            {
                NumericUpDown nUDPrecioVenta = sender as NumericUpDown;
                decimal PorcentajeUtilidad = calcularPorcentaUtilidad(nUDPrecioVenta.Value, nUDPrecioCompra.Value);
                if (PorcentajeUtilidad > 0)
                {
                    existeCambioAutomaticoUtilidad = true;
                    String NombreUtilidad = "nUDPorUtilidad" + nUDPrecioVenta.Name.Substring(nUDPrecioVenta.Name.Length - 1);
                    NumericUpDown nUDPorUtilidad =  this.Controls.Find(NombreUtilidad, true)[0] as NumericUpDown;
                    existeCambioAutomaticoUtilidad = true;
                    nUDPorUtilidad.Value = PorcentajeUtilidad;
                    //nUDPorUtilidad3.Value = PorcentajeUtilidad;
                }
                else
                {
                    //MessageBox.Show(this, "No puede Ingresar un porcentaje de Utilidad Negativo");
                }
            }
        }

        private void btnHistorialInventario_Click(object sender, EventArgs e)
        {
            FInventarioKardex fomInventarioHistorial = new FInventarioKardex(NumeroAgencia);
            fomInventarioHistorial.ShowDialog(this);
            fomInventarioHistorial.Dispose();
        }       

    }
}




/*
 * he solution for this exception is very simple. You only have to remove the 'static' modifier at line 54 of DataGridViewNumericUpDownCell.cs

The 'static' modifier is there for performance / memory reasons to prevent a separate object being created for every cell in the column.
An alternative solution to McBain's might be to leave the 'static' modifier in, but edit the constructor routine (line 77 in my code) to read:
Code
if (paintingNumericUpDown == null || paintingNumericUpDown.Disposing || paintingNumericUpDown.IsDisposed)

 */