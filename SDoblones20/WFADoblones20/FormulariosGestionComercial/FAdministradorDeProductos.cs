using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using CLCLN.Sistema;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FAdministradorDeProductos : Form
    {
        private DataTable VariablesConfiguracionSistemaGC;
        private PCsConfiguracionesCLN PCConfiguracion;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        MonedasCLN _MonedasCLN;
        public Button btnCerrarReporte;
        CLCAD.DSDoblones20GestionComercial.ListarBusquedaProductosDataTable DTProductos;
        DataTable DTMonedas;

        public int NumeroAgencia { get; set; }
        public decimal PorcentajeIVA{get; set;}
        int CodigoMonedaSistema;
        private int NumeroPC;
        private int CodigoUsuario;
        public FAdministradorDeProductos(int NumeroAgencia, int CodigoUsuario, int NumeroPC)
        {
            InitializeComponent();
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
            this.NumeroAgencia = NumeroAgencia;
            this.CodigoUsuario = CodigoUsuario;
            this.NumeroPC = NumeroPC;

            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _MonedasCLN = new MonedasCLN();

            cBBuscarPor.Items.Add("Codigo producto");
	        cBBuscarPor.Items.Add("Codigo fabrica");
	        cBBuscarPor.Items.Add("Codigo Producto Especifico");
	        cBBuscarPor.Items.Add("Marca Producto");
	        cBBuscarPor.Items.Add("Unidad Medida");
	        cBBuscarPor.Items.Add("Descripcion");
	        cBBuscarPor.Items.Add("Observacion");
	        cBBuscarPor.Items.Add("Nombre producto");
	        cBBuscarPor.Items.Add("Nombre producto 1");
            cBBuscarPor.Items.Add("Nombre producto 2");
            
            
            this.dtGVProductosBusqueda.CellFormatting += new DataGridViewCellFormattingEventHandler(dtGVProductosBusqueda_CellFormatting);

            DTMonedas = _MonedasCLN.ListarMonedas();
            cBoxMoneda.DataSource = DTMonedas;
            cBoxMoneda.DisplayMember = "NombreMoneda";
            cBoxMoneda.ValueMember = "CodigoMoneda";


            //Inicio codigo agregado
            VariablesConfiguracionSistemaGC = new DataTable();
            PCConfiguracion = new PCsConfiguracionesCLN();
            VariablesConfiguracionSistemaGC = PCConfiguracion.ObtenerConfiguracionSistemaParaTransaccionesGC(NumeroPC);

            this.CodigoMonedaSistema = int.Parse(VariablesConfiguracionSistemaGC.Rows[0][3].ToString());            
            //Fin codigo agregado

        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void dtGVProductosBusqueda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == DGCCantidadExistencia.Index) && (int.Parse(dtGVProductosBusqueda["DGCCantidadExistencia", e.RowIndex].Value.ToString())  <= 0 ))
            {                
                //e.CellStyle.BackColor = Color.LightCoral;
                dtGVProductosBusqueda.Rows[e.RowIndex].Cells["DGCCantidadExistencia"].Style.BackColor = Color.LightCoral;
            }
        }

        private void FAdministradorDeProductos_Load(object sender, EventArgs e)
        {
            DGCCodigoProducto.Width = 75;
            DGCNombreProducto.Width = 250;
            DGCNombreUnidad.Width = 100;
            DGCNombreMarcaProducto.Width = 100;

            cBBuscarPor.SelectedIndex = 7;
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            int? NumeroAge = NumeroAgencia;
            int CodigoAmbitoBusqueda = cBBuscarPor.SelectedIndex;
            DTProductos = (CLCAD.DSDoblones20GestionComercial.ListarBusquedaProductosDataTable)_TransaccionesUtilidadesCLN.ListarBusquedaProductos(
                CodigoAmbitoBusqueda.ToString(), tBTextoBusqueda.Text, 
                (CodigoAmbitoBusqueda == 6 || CodigoAmbitoBusqueda == 5) ? false : cBBusquedaExacta.Checked, 
                checkBuscarTodasAgencias.Checked ? null : NumeroAge, int.Parse(cBoxMoneda.SelectedValue.ToString()), 
                checkConExistencia.Checked);
            dtGVProductosBusqueda.DataSource = DTProductos;

            lblNroRegistros.Text = "Nro de Registros Encontrados " + dtGVProductosBusqueda.Rows.Count.ToString();

            tBTextoBusqueda.Focus();
            tBTextoBusqueda.SelectAll();
        }

        private void tBTextoBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(tBTextoBusqueda.Text))
                {
                    MessageBox.Show(this, "Aun no ha Introducido un Texto a Buscar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tBTextoBusqueda.Focus();
                    tBTextoBusqueda.SelectAll();
                    return;
                }
                bBuscar_Click(bBuscar, e);
            }
            else if (e.KeyCode == Keys.Up && dtGVProductosBusqueda.Rows.Count > 0)
            {
                dtGVProductosBusqueda.Focus();
                dtGVProductosBusqueda.Rows[dtGVProductosBusqueda.Rows.Count - 1].Selected = true;
            }
            else if( e.KeyCode == Keys.Down && dtGVProductosBusqueda.Rows.Count > 0)
            {
                dtGVProductosBusqueda.Focus();
                dtGVProductosBusqueda.Rows[0].Selected = true;
            }
        }

        private void tBTextoBusqueda_Enter(object sender, EventArgs e)
        {
            tBTextoBusqueda.SelectAll();
        }

        private void dtGVProductosBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar))
            {
                tBTextoBusqueda.Focus();
                tBTextoBusqueda.SelectAll();
                tBTextoBusqueda.Text = e.KeyChar.ToString();
                tBTextoBusqueda.SelectionStart = tBTextoBusqueda.Text.Length;
            }
        }


        public void actualizarPrecioFactura(int indiceFila, int indiceColumna)
        {
            decimal PrecioActual = decimal.Parse(dtGVProductosBusqueda[indiceColumna, indiceFila].Value.ToString());
            dtGVProductosBusqueda[indiceColumna + 3, indiceFila].Value = PrecioActual + PrecioActual * PorcentajeIVA / 100;
        }

        private void todosPrecioConFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DGCPrecioUnitarioVenta1.Visible = !DGCPrecioUnitarioVenta1.Visible;
            //DGCPrecioUnitarioVenta2.Visible = !DGCPrecioUnitarioVenta2.Visible;
            //DGCPrecioUnitarioVenta2.Visible = !DGCPrecioUnitarioVenta2.Visible;

            dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta1"].Visible = !dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta1"].Visible;
            dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta2"].Visible = !dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta2"].Visible;
            dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta3"].Visible = !dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta3"].Visible;
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DGCPrecioUnitarioVenta4.Visible = !DGCPrecioUnitarioVenta4.Visible;
            //DGCPrecioUnitarioVenta5.Visible = !DGCPrecioUnitarioVenta5.Visible;
            //DGCPrecioUnitarioVenta6.Visible = !DGCPrecioUnitarioVenta6.Visible;

            dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta4"].Visible = !dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta4"].Visible;
            dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta5"].Visible = !dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta5"].Visible;
            dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta6"].Visible = !dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta6"].Visible;
        }

        private void precio1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuPrecio = sender as ToolStripMenuItem;
            string numero =menuPrecio.Name.Substring( 6, 1);
            DataGridViewColumn columna = dtGVProductosBusqueda.Columns["DGCPrecioUnitarioVenta" + numero]; 
            columna.Visible = !columna.Visible;
        }

        private void ocutarUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DGCNombreUnidad.Visible = !DGCNombreUnidad.Visible;
            
            dtGVProductosBusqueda.Columns["DGCNombreUnidad"].Visible = !dtGVProductosBusqueda.Columns["DGCNombreUnidad"].Visible;
        }

        private void ocutarMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DGCNombreMarcaProducto.Visible = !DGCNombreMarcaProducto.Visible;
            dtGVProductosBusqueda.Columns["DGCNombreMarcaProducto"].Visible = !dtGVProductosBusqueda.Columns["DGCNombreMarcaProducto"].Visible;
        }

        public void ObtenerListaProductosSeleccionados()
        {

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            FAdministradorDeProductosConfiguracionReporte formConfiguracion = new FAdministradorDeProductosConfiguracionReporte();
            if (formConfiguracion.ShowDialog() == DialogResult.OK)
            {
                DataTable DTListarProductosPreciosReporte = _TransaccionesUtilidadesCLN.ListarProductosPreciosReporte(
                    null, checkConExistencia.Checked,
                    int.Parse(cBoxMoneda.SelectedValue.ToString()), NumeroAgencia);
                FReporteListarProductosPreciosReporte formListarProductosPreciosReporte = new FReporteListarProductosPreciosReporte(
                    DTListarProductosPreciosReporte, formConfiguracion.TipoSeleccionPrecios);
                formListarProductosPreciosReporte.ShowDialog();
                formListarProductosPreciosReporte.Dispose();
            }
            formConfiguracion.Dispose();
        }

        private void cBoxMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tBTextoBusqueda.Text) || dtGVProductosBusqueda.RowCount > 0)
            {
                bBuscar_Click(bBuscar, e);
            }
        }

        public void setCodigoMonedaSistema(int CodigoMonedaSistema)
        {
            this.CodigoMonedaSistema = CodigoMonedaSistema;
            cBoxMoneda.SelectedValue = CodigoMonedaSistema;
        }

        


    }
}
