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
    public partial class FVentasProductosSeleccionPE : Form
    {        
        public int NumeroAgencia { get; set; }        
        private string NombreProducto;
        private string CodigoProducto;
        int CantidadSeleccionada;
        public bool OperacionConfirmada { get; set; }

        TransferenciasProductosEspecificosCLN _TransferenciasProductosEspecificosCLN;
        public DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasDataTable DTProductosEspecificos;
        public DataTable DTProductosEspecificosSeleccionados = null;

        public FVentasProductosSeleccionPE(int NumeroAgencia, string CodigoProducto, string NombreProducto, int CantidadSeleccionada)
        {
            InitializeComponent();

            this.NumeroAgencia = NumeroAgencia;            
            
            this.CodigoProducto = CodigoProducto;
            this.NombreProducto = NombreProducto;
            this.CantidadSeleccionada = CantidadSeleccionada;

            _TransferenciasProductosEspecificosCLN = new TransferenciasProductosEspecificosCLN();
            DTProductosEspecificos = new DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasDataTable();
            this.dtGVProductosEspecificos.CurrentCellDirtyStateChanged += new EventHandler(dtGVProductosEspecificos_CurrentCellDirtyStateChanged);
        }

        private void gBoxDetalleCodigosEspecificos_Enter(object sender, EventArgs e)
        {

        }

        void dtGVProductosEspecificos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtGVProductosEspecificos.IsCurrentCellDirty && dtGVProductosEspecificos.CurrentCell.ColumnIndex == DGCSeleccionar.Index)
            {
                dtGVProductosEspecificos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void FVentasProductosSeleccionPE_Load(object sender, EventArgs e)
        {
            this.lblCantidad.Text = CantidadSeleccionada.ToString();
            this.lblDatosProductos.Text = NombreProducto.ToUpper() + "(" + CodigoProducto + ")";


            DTProductosEspecificos = _TransferenciasProductosEspecificosCLN.ListarCodigosProductosEspecificosTransferencias(NumeroAgencia, -1, CodigoProducto, "E");
            DTProductosEspecificos.RowChanged += new DataRowChangeEventHandler(DTProductosEspecificos_RowChanged);
            dtGVProductosEspecificos.AutoGenerateColumns = false;
            dtGVProductosEspecificos.DataSource = DTProductosEspecificos;
            if (DTProductosEspecificos.Count > 0)
            {
                this.toolTip1.SetToolTip(checkSeleccionarTodo, "Seleccionar los Primeros " + CantidadSeleccionada.ToString() + " Codigos");                
            }
            else
            {
                MessageBox.Show(this, "No Existe ningún código específico para seleccionar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAceptar.Enabled = false;
                btnAgregar.Enabled = false;
                txtBoxCodigoEspcifico.Enabled = false;
                OperacionConfirmada = false;
            }
        }

        void DTProductosEspecificos_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (DTProductosEspecificos.Count > 0)
            {
                int CantidadSeleccion = int.Parse(DTProductosEspecificos.Compute("count(CodigoProductoEspecifico)", "Seleccionar = true").ToString());
                lblCantidad.Text = "Cant a Entregar " + CantidadSeleccionada.ToString() + ", Cant. Seleccionada : " + CantidadSeleccion.ToString();
                if (CantidadSeleccion >= CantidadSeleccionada)
                {
                    txtBoxCodigoEspcifico .Enabled = false;
                    btnAgregar.Enabled = false;
                }
                else
                {
                    txtBoxCodigoEspcifico.Enabled = true;
                    btnAgregar.Enabled = true;
                }
            }
        }
    }
}
