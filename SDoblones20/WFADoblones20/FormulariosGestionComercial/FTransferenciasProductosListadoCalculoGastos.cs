using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCAD;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FTransferenciasProductosListadoCalculoGastos : Form
    {
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        TransferenciasProductosDetalleCLN _TransferenciasProductosDetalleCLN;
        TransferenciasProductosGastosDetalleCLN _TransferenciasProductosGastosDetalleCLN;

        public DSDoblones20GestionComercial2.ListarTransferenciasProductosDetalleGastosDataTable DTProductosGastosTiposCalculo;
        DSDoblones20GestionComercial2.ListarGastosPorTransferenciasDataTable DTGastosTransferencias;
        int NumeroAgencia;
        int NumeroTransferenciaProducto;
        string CodigoTipoEnvioRecepcion;
        string ListadoProductos;

        public CheckBox ChecUtilizarGastosActuales {
            get { return checkUtilizarGastosActuales; }
        }

        string TipoCalculoPrecio = "";        
        decimal MontoTotalGasto = 0;
        public bool OperacionConfirmada = false;

        public FTransferenciasProductosListadoCalculoGastos(int NumeroAgencia, int NumeroTransferenciaProducto, string CodigoTipoEnvioRecepcion, string ListadoProductos)
        {
            InitializeComponent();

            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransferenciaProducto = NumeroTransferenciaProducto;
            this.CodigoTipoEnvioRecepcion = CodigoTipoEnvioRecepcion;
            this.ListadoProductos = ListadoProductos;

            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _TransferenciasProductosDetalleCLN = new TransferenciasProductosDetalleCLN();
            _TransferenciasProductosGastosDetalleCLN = new TransferenciasProductosGastosDetalleCLN();

            dtGVGastos.AutoGenerateColumns = false;
            dtGVProductos.AutoGenerateColumns = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            dtGVProductos.CurrentCellDirtyStateChanged += new EventHandler(dtGVProductos_CurrentCellDirtyStateChanged);
        }

        void dtGVProductos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtGVProductos.IsCurrentCellDirty && dtGVProductos.CurrentCell.ColumnIndex != DGCMontoGastoProducto.Index)
            {
                dtGVProductos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void FTransferenciasProductosListadoCalculoGastos_Load(object sender, EventArgs e)
        {

            DTProductosGastosTiposCalculo = _TransferenciasProductosDetalleCLN.ListarTransferenciasProductosDetalleGastos(NumeroAgencia, NumeroTransferenciaProducto, ListadoProductos, CodigoTipoEnvioRecepcion);
            DTGastosTransferencias = _TransferenciasProductosGastosDetalleCLN.ListarGastosPorTransferencias(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);

            dtGVProductos.DataSource = DTProductosGastosTiposCalculo;
            dtGVGastos.DataSource = DTGastosTransferencias;


            DGCNombreGasto.Width = 600;
            DGCNombreProducto.Width = 300;
            

            DataColumn DTColunm = new DataColumn("ActualizarPrecioVenta", Type.GetType("System.Boolean"));
            DTColunm.DefaultValue = true;
            DTProductosGastosTiposCalculo.Columns.Add(DTColunm);

            DTColunm = new DataColumn("Promedio", Type.GetType("System.Boolean"));
            DTColunm.DefaultValue = false;
            DTProductosGastosTiposCalculo.Columns.Add(DTColunm);

            DTColunm = new DataColumn("UltimaRecepcion", Type.GetType("System.Boolean"));
            DTColunm.DefaultValue = false;
            DTProductosGastosTiposCalculo.Columns.Add(DTColunm);

            DTColunm = new DataColumn("MontoGastoProducto", Type.GetType("System.Decimal"));
            DTColunm.DefaultValue = 0;
            DTProductosGastosTiposCalculo.Columns.Add(DTColunm);


            

            if (DTGastosTransferencias.Count > 0)
            {
                MontoTotalGasto = decimal.Parse(DTGastosTransferencias.Compute("sum(MontoPagoGasto)", "").ToString());
            }

            txtMontoTotalGastos.Text = MontoTotalGasto.ToString();
            DTProductosGastosTiposCalculo.RowChanged += new DataRowChangeEventHandler(DTProductosGastosTiposCalculo_RowChanged);

            if (TipoCalculoPrecio == "R")
            {
                int CantidadTotal = int.Parse(DTProductosGastosTiposCalculo.Compute("Sum(CantidadTransferencia)", "").ToString());
                decimal PrecioAdicional = MontoTotalGasto / CantidadTotal;
                foreach (DataRow FilaProducto in DTProductosGastosTiposCalculo.Rows)
                {
                    FilaProducto["MontoGastoProducto"] = Math.Round(PrecioAdicional,2);
                }
                DTProductosGastosTiposCalculo.AcceptChanges();
                DGCMontoGastoProducto.ReadOnly = true;
            }

            if (CodigoTipoEnvioRecepcion == "E")
            {
                DGCActualizarPrecioVenta.Visible = false;
                checkUtilizarGastosActuales.Visible = false;
            }
        }

        void DTProductosGastosTiposCalculo_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (TipoCalculoPrecio == "P")
            {

                decimal MontoPersonalizadoGasto = decimal.Parse(DTProductosGastosTiposCalculo.Compute("sum(MontoGastoProducto)", "").ToString());
                decimal MontoDiferencia = MontoTotalGasto - MontoPersonalizadoGasto;

                if (MontoDiferencia > 0)
                {
                    txtBoxMontoRestantePersonalizado.ForeColor = Color.Gold;
                }
                else
                {
                    if (MontoDiferencia < 0)
                    {
                        txtBoxMontoRestantePersonalizado.ForeColor = Color.Red;
                    }
                    else // MontoDiferencia == 0
                    {
                        this.txtBoxMontoRestantePersonalizado.ForeColor = System.Drawing.Color.GreenYellow;
                    }
                }
                txtBoxMontoRestantePersonalizado.Text = MontoDiferencia.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OperacionConfirmada = false;
            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (TipoCalculoPrecio == "P" && checkUtilizarGastosActuales.Checked)
            {
                decimal MontoDiferencia = MontoTotalGasto - decimal.Parse(DTProductosGastosTiposCalculo.Compute("sum(MontoGastoProducto)", "").ToString());
                if (MontoDiferencia != 0)
                {
                    MessageBox.Show(this, "No puede Confirmar aún esta Transferencia, debido a que aun no ha terminado de igualar las cantidades de gastos", "Recepción de Mercadería", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }

            OperacionConfirmada = true;
            this.Hide();
        }

        private void FTransferenciasProductosListadoCalculoGastos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada)
            {
                if (MessageBox.Show(this, "¿Esta Seguro de Cancelar la Operación Actual?", "Recepción de Productos a Almacenes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }


        public void formatearParaTransferenciaConGastosPersonalizados()
        {            
            TipoCalculoPrecio = "P";
        }

        public void formatearParaTransferenciaConGastosRepartidos()
        {
            TipoCalculoPrecio = "R";            

        }
        public void formatearParaTransferenciaSinGastos()
        {
            lblMensaje.Text = "Debe seleccionar a que Productos aplicará el Tipo de Calculo para su Actualización en inventario con los respectivos precios de Venta";
            groupBox2.Visible = false;
            gBoxProductos.Dock = DockStyle.Fill;
            DGCPromedio.Visible = false;
            DGCUltimaRecepcion.Visible = false;
            DGCMontoGastoProducto.Visible = false;
            TipoCalculoPrecio = "";            
            checkUtilizarGastosActuales.Checked = false;
            checkUtilizarGastosActuales.Enabled = false;

        }

        private void dtGVProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DTProductosGastosTiposCalculo != null && DTProductosGastosTiposCalculo.Count > 0)
                DTProductosGastosTiposCalculo.AcceptChanges();

            //DTProductosGastosTiposCalculo.AcceptChanges();
            if (dtGVProductos.RowCount > 0 && dtGVProductos.CurrentRow != null)
            {
                if (DTProductosGastosTiposCalculo.Rows[e.RowIndex] != null && DTProductosGastosTiposCalculo[e.RowIndex]["ActualizarPrecioVenta"].Equals(true))
                {
                    if (e.ColumnIndex == DGCPromedio.Index && DTProductosGastosTiposCalculo[e.RowIndex]["Promedio"].Equals(true))
                    {
                        DTProductosGastosTiposCalculo.Rows[e.RowIndex]["UltimaRecepcion"] = false;
                    }

                    else if (e.ColumnIndex == DGCUltimaRecepcion.Index && DTProductosGastosTiposCalculo[e.RowIndex]["UltimaRecepcion"].Equals(true))
                    {
                        DTProductosGastosTiposCalculo[e.RowIndex]["Promedio"] = false;
                    }
                }
                else if (DTProductosGastosTiposCalculo.Rows[e.RowIndex] != null && DTProductosGastosTiposCalculo[e.RowIndex]["ActualizarPrecioVenta"].Equals(false))
                {
                    DTProductosGastosTiposCalculo[e.RowIndex]["Promedio"] = false;
                    DTProductosGastosTiposCalculo[e.RowIndex]["UltimaRecepcion"] = false;
                }
            }
        }
    }
}
