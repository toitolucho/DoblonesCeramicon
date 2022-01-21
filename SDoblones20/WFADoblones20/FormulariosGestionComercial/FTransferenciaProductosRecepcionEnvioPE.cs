using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using CLCAD;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FTransferenciaProductosRecepcionEnvioPE : Form
    {

        string CodigoTipoEnvioRecepcion { get; set; }
        public int NumeroAgencia { get; set; }
        public int NumeroTransferenciaProducto { get; set; }
        private string NombreProducto;
        private string CodigoProducto;
        int CantidadSeleccionada;
        public bool OperacionConfirmada { get; set; }

        TransferenciasProductosEspecificosCLN _TransferenciasProductosEspecificosCLN;
        public DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasDataTable DTProductosEspecificos;
        public DataTable DTProductosEspecificosSeleccionados = null;


        public FTransferenciaProductosRecepcionEnvioPE(int NumeroAgencia, int NumeroTransferenciaProducto, string CodigoProducto, string CodigoTipoEnvioRecepcion, string NombreProducto, int CantidadSeleccionada)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransferenciaProducto = NumeroTransferenciaProducto;
            this.CodigoTipoEnvioRecepcion = CodigoTipoEnvioRecepcion;
            this.CodigoProducto = CodigoProducto;
            this.NombreProducto = NombreProducto;
            this.CantidadSeleccionada = CantidadSeleccionada;

            _TransferenciasProductosEspecificosCLN = new TransferenciasProductosEspecificosCLN();
            DTProductosEspecificos = new DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasDataTable();            
            this.dtGVProductosEspecificos.CurrentCellDirtyStateChanged +=new EventHandler(dtGVProductosEspecificos_CurrentCellDirtyStateChanged);

        }

        void dtGVProductosEspecificos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtGVProductosEspecificos.IsCurrentCellDirty && dtGVProductosEspecificos.CurrentCell.ColumnIndex == DGCSeleccionar.Index)
            {
                dtGVProductosEspecificos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        void DTProductosEspecificos_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (DTProductosEspecificos.Count > 0)
            {
                int CantidadSeleccion = int.Parse(DTProductosEspecificos.Compute("count(CodigoProductoEspecifico)", "Seleccionar = true").ToString());
                lblCantidadSeleccionada.Text = "Cantidad Seleccionada : " + CantidadSeleccion.ToString();
                if (CantidadSeleccion >= CantidadSeleccionada)
                {
                    txtBoxCodEspecifico.Enabled = false;
                    btnIngresarSeleccionar.Enabled = false;
                }
                else
                {
                    txtBoxCodEspecifico.Enabled = true;
                    btnIngresarSeleccionar.Enabled = true;
                }
            }
        }

        private void FTransferenciaProductosRecepcionEnvioPE_Load(object sender, EventArgs e)
        {
            DGCCodigoProductoEspecifico.Width = dtGVProductosEspecificos.Width - 160;

            this.lblCantidad.Text = CantidadSeleccionada.ToString();
            this.lblDatosProductos.Text = NombreProducto.ToUpper() + "(" + CodigoProducto + ")";
            

            DTProductosEspecificos = _TransferenciasProductosEspecificosCLN.ListarCodigosProductosEspecificosTransferencias(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion);
            DTProductosEspecificos.RowChanged += new DataRowChangeEventHandler(DTProductosEspecificos_RowChanged);
            dtGVProductosEspecificos.AutoGenerateColumns = false;
            dtGVProductosEspecificos.DataSource = DTProductosEspecificos;
            if (DTProductosEspecificos.Count > 0)
            {
                if (CodigoTipoEnvioRecepcion == "E")
                {
                    this.toolTip1.SetToolTip(checkSeleccionarTodo, "Seleccionar los Primeros " + CantidadSeleccionada.ToString() + " Codigos");
                }
                else if (CodigoTipoEnvioRecepcion == "R")
                {
                    this.toolTip1.SetToolTip(checkSeleccionarTodo, "Seleccionar Todos");
                }
            }
            else
            {
                MessageBox.Show(this, "No Existe ningún código específico para seleccionar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAceptar.Enabled = false;
                btnIngresarSeleccionar.Enabled = false;
                txtBoxCodEspecifico.Enabled = false;
                OperacionConfirmada = false;
            }
        }

        private void checkSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSeleccionarTodo.Checked)
            {
                if (CodigoTipoEnvioRecepcion == "R")
                {
                    foreach (DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasRow DRProductoEspecifico in DTProductosEspecificos.Rows)
                    {
                        DRProductoEspecifico.Seleccionar = true;
                    }
                }
                else if (CodigoTipoEnvioRecepcion == "E")
                {
                    int contador = 0;
                    foreach (DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasRow DRProductoEspecifico in DTProductosEspecificos.Rows)
                    {
                        dtGVProductosEspecificos.Rows[contador].ErrorText = "";
                        contador++;
                        if (contador <= CantidadSeleccionada)
                            DRProductoEspecifico.Seleccionar = true;
                        else                        
                            DRProductoEspecifico.Seleccionar = false;                        
                    }

                }
            }
            else
            {

                foreach (DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasRow DRProductoEspecifico in DTProductosEspecificos.Select("Seleccionar = true"))
                {
                    DRProductoEspecifico.Seleccionar = false;
                }
            }
        }

        private void btnIngresarSeleccionar_Click(object sender, EventArgs e)
        {
            string CodigoProductoEspecifico = "";
            if (!String.IsNullOrEmpty(txtBoxCodEspecifico.Text.Trim()))
            {
                CodigoProductoEspecifico = txtBoxCodEspecifico.Text;
                DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasRow DRCodigoProductoEspecifico = DTProductosEspecificos.FindByCodigoProductoEspecifico(CodigoProductoEspecifico);
                if (DRCodigoProductoEspecifico != null)
                {
                    int indice = DTProductosEspecificos.Rows.IndexOf(DRCodigoProductoEspecifico);
                    if (DRCodigoProductoEspecifico.Seleccionar)
                    {
                        dtGVProductosEspecificos.Rows[indice].ErrorText = "Este Código ya se Encuentra Seleccionado";
                    }
                    else
                    {
                        dtGVProductosEspecificos.Rows[indice].ErrorText = "";
                        DRCodigoProductoEspecifico.Seleccionar = true;
                    }
                    dtGVProductosEspecificos.ClearSelection();
                    dtGVProductosEspecificos.Rows[indice].Selected = true;
                    dtGVProductosEspecificos.CurrentCell = dtGVProductosEspecificos[0, indice];
                }
                else
                {
                    MessageBox.Show(this, "No se encuentra el Produto que usted ha Seleccioando", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Aun no ha ingresado un Código válido");
            }

        }

        private void txtBoxCodEspecifico_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCodEspecifico.Text.Trim().Length == 30)
            {
                btnIngresarSeleccionar_Click(btnIngresarSeleccionar, e);
            }
        }

        private void dtGVProductosEspecificos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGCSeleccionar.Index && dtGVProductosEspecificos.Rows.Count > 0)
            {
                dtGVProductosEspecificos.Rows[e.RowIndex].ErrorText = "";
                DTProductosEspecificos[e.RowIndex].AcceptChanges();
            }
        }

        private void FTransferenciaProductosRecepcionEnvioPE_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada && MessageBox.Show(this,"Aun no ha seleccionado todos los Códigos Especificos ¿Desea Cancelar la operacion de Selección?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (DTProductosEspecificos.Count > 0)
            {
                int CantidadSeleccion = int.Parse(DTProductosEspecificos.Compute("count(CodigoProductoEspecifico)", "Seleccionar = true").ToString());
                if (CantidadSeleccion == CantidadSeleccionada)
                {
                    OperacionConfirmada = true;
                    this.Close();
                }
                else
                {
                    if (CantidadSeleccion > CantidadSeleccionada)
                        MessageBox.Show("Ha sobrepasado la Cantidad de Selección");
                    else
                        MessageBox.Show("Aun no ha seleccionado Todos los Códigos");
                    OperacionConfirmada = false;                    
                }
            }
        }

        private void FTransferenciaProductosRecepcionEnvioPE_Shown(object sender, EventArgs e)
        {
            //Volvemos a seleccionar los que ya fueron Seleccionados
            if (DTProductosEspecificosSeleccionados != null)
            {
                if (CodigoTipoEnvioRecepcion == "E")
                {
                    foreach (DataRow DRCodigoEspecifico in DTProductosEspecificosSeleccionados.Select("CodigoProducto = '" + CodigoProducto + "'"))
                    {
                        string CodigoProductoEspecifico = DRCodigoEspecifico["CodigoProductoEspecifico"].ToString();
                        DTProductosEspecificos.FindByCodigoProductoEspecifico(CodigoProductoEspecifico).Seleccionar = true;
                    }
                    DTProductosEspecificos.AcceptChanges();
                }
                else if (CodigoTipoEnvioRecepcion == "R")
                {
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OperacionConfirmada = false;
            this.Close();
        }
    }
}
