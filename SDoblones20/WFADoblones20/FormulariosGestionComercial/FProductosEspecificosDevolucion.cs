using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FProductosEspecificosDevolucion : Form
    {
        private int NumeroAgencia;
        private int NumeroTransaccion;
        private string TipoTransaccion;
        private string CodigoProducto;
        private int CantidadPermitida;
        private bool operacionConfirmada = false;

        public bool OperacionConfirmada
        {
            get { return operacionConfirmada; }
        }

        private DataTable _DTProductosEspecifcos = null;
        public DataTable DTProductosEspecifcos
        {
            get{
                if (_DTProductosEspecifcos == null)
                    _DTProductosEspecifcos = new DataTable();
                return _DTProductosEspecifcos;
            }
            set
            {
                _DTProductosEspecifcos = value;
            }
        }

        private TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        public FProductosEspecificosDevolucion(int NumeroAgencia, int NumeroTransaccion, string codigoProducto, string TipoTransaccion)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransaccion = NumeroTransaccion;
            this.CodigoProducto = codigoProducto;
            this.TipoTransaccion = TipoTransaccion;

            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();

            DTProductosEspecifcos = _TransaccionesUtilidadesCLN.ObtenerCodigoProductoEspecificoParaDevolucion(NumeroAgencia, NumeroTransaccion, TipoTransaccion, CodigoProducto);

            dtGVProductosEspecificos.DataSource = DTProductosEspecifcos;
        }

        public FProductosEspecificosDevolucion()
        {
            InitializeComponent();           

            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();            

            dtGVProductosEspecificos.DataSource = DTProductosEspecifcos;
        }

        public void Darformato(string NombreProducto)
        {
            //this.gBoxPatronBusqueda.Text = "Detalle de Productos Especificos Entregados para "+ NombreProducto;
            lblDatosProducto.Text = "Codigo Producto : "+ CodigoProducto.Trim() +", Nombre : "+ NombreProducto.Trim();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            string CodigoProductoEspecifico = string.Empty;
            if (String.IsNullOrEmpty(txtBoxCodigoProductoEspecifico.Text))
            {
                MessageBox.Show(this, "No puede Seleccionar un producto, cuya información aún no ha insertado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                txtBoxCodigoProductoEspecifico.Focus();
                txtBoxCodigoProductoEspecifico.SelectAll();
                return;
            }
            decimal precio = 0;
            if( !Decimal.TryParse(txtBoxPrecioDevolucion.Text, out precio))
            {
                MessageBox.Show(this, "Probablemente el precio que introdució es erroneo, porfavor Corrijalo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxPrecioDevolucion.Focus();
                txtBoxPrecioDevolucion.SelectAll();
                return;
            }

            CodigoProductoEspecifico = txtBoxCodigoProductoEspecifico.Text.Trim();
            object cantidadSeleccionada = DTProductosEspecifcos.Compute("count(Devolver)", "Devolver = true");
            if (cantidadSeleccionada.Equals(DTProductosEspecifcos.Rows.Count))
            {
                if (MessageBox.Show(this, "Ya fueron seleccionados Todos los Productos existentes en la Lista" + Environment.NewLine + "Desea concluir la opercion y continuar con la devolución con todos los Productos Seleccionados", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //cerrar ventana
                    return;
                }
            }

            DataRow FilaBusqueda = DTProductosEspecifcos.Rows.Find(CodigoProductoEspecifico);

            if (FilaBusqueda == null)
            {
                MessageBox.Show(this, "El Código que ingresó, no se Encuentra dentro de la Lista de códigos Especificos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxCodigoProductoEspecifico.Focus();
                txtBoxCodigoProductoEspecifico.SelectAll();
            }
            else
            {
                int indice = DTProductosEspecifcos.Rows.IndexOf(FilaBusqueda);
                if (FilaBusqueda["Devolver"].Equals(true) && MessageBox.Show(this, "El Producto ya se encuentra seleccionado. ¿Desea Cancelar su Devolución?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DTProductosEspecifcos.Rows[indice]["Devolver"] = false;
                    DTProductosEspecifcos.AcceptChanges();
                }

                else
                {
                    DTProductosEspecifcos.Rows[indice]["Devolver"] = true;
                    DTProductosEspecifcos.Rows[indice]["PrecioDevolucion"] = precio;
                    DTProductosEspecifcos.AcceptChanges();
                }
                dtGVProductosEspecificos.ClearSelection();
                dtGVProductosEspecificos.Rows[indice].Selected = true;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int  cantidadSeleccionada = (int)DTProductosEspecifcos.Compute("count(Devolver)", "Devolver = true");
            if (cantidadSeleccionada > 0 && cantidadSeleccionada == CantidadPermitida)
            {
                operacionConfirmada = true;
                this.Close();
            }
            else if (cantidadSeleccionada == 0)
            {
                MessageBox.Show("Aun no ha Seleccionado ningún Producto a Devolver");
            }
            else {
                MessageBox.Show(this, "Usted solicitó la devolución de " + CantidadPermitida.ToString() + " unidades de este producto " + CodigoProducto.Trim() + "." + Environment.NewLine + "No Puede Sobrepasar esa cantidad, ni seleccionar una cantidad inferior a la mencionada", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            operacionConfirmada = false;
        }

        private void FProductosEspecificosDevolucion_FormClosing(object sender, FormClosingEventArgs e)
        {
            int cantidadSeleccionada = (int)DTProductosEspecifcos.Compute("count(Devolver)", "Devolver = true");
            if (cantidadSeleccionada > 0 && !operacionConfirmada)
            {
                if (MessageBox.Show(this, "Tiene algunos Productos Especificos seleccionados a ser devueltos" + Environment.NewLine + "¿ esta Seguro de Cancelar la Operación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    operacionConfirmada = false;
                }                
            }            
        }

        private void txtBoxCodigoProductoEspecifico_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCodigoProductoEspecifico.Text.Length == 30)
            {
                btnSeleccionar_Click(sender, e);
            }

        }

        public void formatearOpcionesIniciales(int NumeroAgencia, int NumeroTransaccion, string codigoProducto, string TipoTransaccion, int CantidadPermitida)
        {
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransaccion = NumeroTransaccion;
            this.CodigoProducto = codigoProducto;
            this.TipoTransaccion = TipoTransaccion;
            this.CantidadPermitida = CantidadPermitida;

            DTProductosEspecifcos = _TransaccionesUtilidadesCLN.ObtenerCodigoProductoEspecificoParaDevolucion(NumeroAgencia, NumeroTransaccion, TipoTransaccion, CodigoProducto);

            dtGVProductosEspecificos.DataSource = DTProductosEspecifcos;
        }


        public void formatearOpcionesEdicion(int NumeroAgencia, int NumeroTransaccion, string codigoProducto, string TipoTransaccion, int CantidadPermitida, DataTable DTProductosEspecificosEdicion)
        {
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransaccion = NumeroTransaccion;
            this.CodigoProducto = codigoProducto;
            this.TipoTransaccion = TipoTransaccion;
            this.CantidadPermitida = CantidadPermitida;

            DTProductosEspecifcos = _TransaccionesUtilidadesCLN.ObtenerCodigoProductoEspecificoParaDevolucion(NumeroAgencia, NumeroTransaccion, TipoTransaccion, CodigoProducto);

            dtGVProductosEspecificos.DataSource = DTProductosEspecifcos;
            //DataView DVProductosEspecificos = DTProductosEspecificosEdicion.DefaultView;

            //DVProductosEspecificos.RowFilter = "CodigoProducto = " + "'" + this.CodigoProducto + "'";
            //string CodigoProductoEspecifico="";
            //foreach (DataRow FilaProductosPE in DTProductosEspecificosEdicion.Rows)
            //{
            //    CodigoProductoEspecifico = FilaProductosPE["CodigoProductoEspecifico"].ToString().Trim();                
            //    txtBoxCodigoProductoEspecifico.Text = CodigoProductoEspecifico;
            //    if (CodigoProductoEspecifico.Length < 20)
            //        btnSeleccionar_Click(btnSeleccionar, new EventArgs());
            //}

            string CodigoProductoEspecifico = "";
            decimal precio = 0;
            foreach (DataRow FilaProductosPE in DTProductosEspecificosEdicion.Rows)
            {
                CodigoProductoEspecifico = FilaProductosPE["CodigoProductoEspecifico"].ToString().Trim();
                precio = decimal.Parse(FilaProductosPE["PrecioUnitarioDevolucionPE"].ToString().Trim());
                DataRow FilaBusqueda = DTProductosEspecifcos.Rows.Find(CodigoProductoEspecifico);

                if (FilaBusqueda != null)
                {                   
                    int indice = DTProductosEspecifcos.Rows.IndexOf(FilaBusqueda);
                    DTProductosEspecifcos.Rows[indice]["Devolver"] = true;
                    DTProductosEspecifcos.Rows[indice]["PrecioDevolucion"] = precio;
                    DTProductosEspecifcos.AcceptChanges();                    
                }
            }
            
        }
    }
}
