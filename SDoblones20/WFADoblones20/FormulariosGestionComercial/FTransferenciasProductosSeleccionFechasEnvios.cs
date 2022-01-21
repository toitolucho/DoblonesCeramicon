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
    public partial class FTransferenciasProductosSeleccionFechasEnvios : Form
    {
        public DSDoblones20GestionComercial2.ListarTransferenciasProductosFechasEnvioDataTable DTTransferenciasFechasEnvio;
        TransferenciasProductosDetalleRecepcionRecepcionCLN _TransferenciasProductosDetalleRecepcionRecepcionCLN;
        public bool OperacionConfirmada { get; set; }
        int NumeroAgencia, NumeroTransferenciaProducto;

        public FTransferenciasProductosSeleccionFechasEnvios(int NumeroAgencia, int NumeroTransferenciaProducto)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransferenciaProducto = NumeroTransferenciaProducto;

            _TransferenciasProductosDetalleRecepcionRecepcionCLN = new TransferenciasProductosDetalleRecepcionRecepcionCLN();
        }

        private void checkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
                foreach (DSDoblones20GestionComercial2.ListarTransferenciasProductosFechasEnvioRow DRFechasEnvio
                    in DTTransferenciasFechasEnvio.Rows)
                {
                    DRFechasEnvio.Seleccionar = checkSeleccionarTodos.Checked;
                }            
        }

        private void FTransferenciasProductosSeleccionFechasEnivos_Load(object sender, EventArgs e)
        {
            DTTransferenciasFechasEnvio = _TransferenciasProductosDetalleRecepcionRecepcionCLN.ListarTransferenciasProductosFechasEnvio(NumeroAgencia, NumeroTransferenciaProducto);
            dtGVTransferenciasFechasEnvios.AutoGenerateColumns = false;

            dtGVTransferenciasFechasEnvios.DataSource = DTTransferenciasFechasEnvio;
            dtGVTransferenciasFechasEnvios.CurrentCellDirtyStateChanged += new EventHandler(dtGVTransferenciasFechasEnvios_CurrentCellDirtyStateChanged);
        }

        void dtGVTransferenciasFechasEnvios_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtGVTransferenciasFechasEnvios.IsCurrentCellDirty && dtGVTransferenciasFechasEnvios.CurrentCell.ColumnIndex == DGCSeleccionar.Index)
            {
                dtGVTransferenciasFechasEnvios.CommitEdit(DataGridViewDataErrorContexts.Commit);
            } 
        }

        private void dtGVTransferenciasFechasEnvios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVTransferenciasFechasEnvios.RowCount > 0 && dtGVTransferenciasFechasEnvios.CurrentCell != null)
            {
                if (e.ColumnIndex == DGCSeleccionar.Index  && !checkSeleccionarTodos.Checked)
                {
                    foreach (DSDoblones20GestionComercial2.ListarTransferenciasProductosFechasEnvioRow DRFechasEnvio
                    in DTTransferenciasFechasEnvio.Select("Seleccionar = true"))
                    {
                        DRFechasEnvio.Seleccionar = false;
                    }

                    DTTransferenciasFechasEnvio[e.RowIndex].Seleccionar = true;
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (DTTransferenciasFechasEnvio.Compute("count(FechaEnvio)", "Seleccionar = true").ToString().Equals("0"))
            {
                MessageBox.Show(this, "Aun no ha seleccionado una Fecha de Envio para recepcionar", "Fecha No Seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OperacionConfirmada = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Aun no ha seleccionado una Fecha de Envio para recepcionar\r\n¿Desea Cancelar la Operación?", "Fecha No Seleccionada", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {                
                return;
            }
            OperacionConfirmada = false;
            this.Close();
        }

        private void FTransferenciasProductosSeleccionFechasEnivos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada && MessageBox.Show(this, "¿Se encuentra seguro de Cancelar la Operación?", "Fecha No Seleccionada", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public bool recepcionarTodosEnvios()
        {
            int CantidadSeleccionada = int.Parse(DTTransferenciasFechasEnvio.Compute("count(FechaEnvio)", "Seleccionar = true").ToString());
            if (CantidadSeleccionada == DTTransferenciasFechasEnvio.Count)
                return true;
            else
                return false;
        }

        public DateTime? getFechaEnvioSeleccionada()
        {
            if (recepcionarTodosEnvios())
                return null;
            else
            {
                return (DateTime)DTTransferenciasFechasEnvio.Select("Seleccionar = true")[0]["FechaEnvio"];
            }
        }
    }
}
