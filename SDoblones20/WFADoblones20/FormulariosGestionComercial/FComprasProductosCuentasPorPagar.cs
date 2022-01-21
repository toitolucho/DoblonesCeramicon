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
using WFADoblones20.FormulariosContabilidad;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FComprasProductosCuentasPorPagar : Form
    {
        ComprasProductosCLN _ComprasProductosCLN;
        ProveedoresCLN _ProveedoresCLN;
        CLCAD.DSDoblones20GestionComercial2.ListarCompraProductoCuentasPorPagarReporteDataTable DTListarCompraProductoCuentasPorPagarReporte;
        CLCAD.DSDoblones20GestionComercial2.ListarCompraProductoCuentasPorCobrarReporteDataTable DTListarCompraProductoCuentasPorCobrarReporte;
        int CodigoUsuario, NumeroAgencia, NumeroPC;
        DgvFilterPopup.DgvFilterManager DGVFilterManagerCuentasPorCobrar;
        DgvFilterPopup.DgvFilterManager DGVFilterManagerCuentasPorPagar;
        DataTable DTProveedoresCC, DTProveedoresCP;
        public FComprasProductosCuentasPorPagar(int NumeroAgencia, int NumeroPC, int CodigoUsuario)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.CodigoUsuario = CodigoUsuario;
            this.NumeroPC = NumeroPC;

            _ComprasProductosCLN = new ComprasProductosCLN();
            _ProveedoresCLN = new ProveedoresCLN();

            DTListarCompraProductoCuentasPorCobrarReporte = new DSDoblones20GestionComercial2.ListarCompraProductoCuentasPorCobrarReporteDataTable();
            DTListarCompraProductoCuentasPorPagarReporte = new DSDoblones20GestionComercial2.ListarCompraProductoCuentasPorPagarReporteDataTable();

            dtGVCuentasPorCobrar.AutoGenerateColumns = false;
            dtGVCuentasPorPagar.AutoGenerateColumns = false;

            DTListarCompraProductoCuentasPorCobrarReporte = _ComprasProductosCLN.ListarCompraProductoCuentasPorCobrarReporte(NumeroAgencia, null, null, null, null);
            DTListarCompraProductoCuentasPorPagarReporte = _ComprasProductosCLN.ListarCompraProductoCuentasPorPagarReporte(NumeroAgencia, null, null, null, null);
            DTProveedoresCC = _ProveedoresCLN.ListarProveedoresCompras();
            DTProveedoresCP = DTProveedoresCC.Copy();

            


            dtGVCuentasPorCobrar.DataSource = DTListarCompraProductoCuentasPorCobrarReporte;
            dtGVCuentasPorPagar.DataSource = DTListarCompraProductoCuentasPorPagarReporte;

            DGCNombreRazonSocial.ValueMember = "CodigoProveedor";
            DGCNombreRazonSocial.DisplayMember = "NombreRazonSocial";
            DGCNombreRazonSocial.DataPropertyName = "CodigoProveedor";
            DGCNombreRazonSocial.DataSource = DTProveedoresCP;

            DGCNombreRazonSocial2.ValueMember = "CodigoProveedor";
            DGCNombreRazonSocial2.DisplayMember = "NombreRazonSocial";
            DGCNombreRazonSocial2.DataPropertyName = "CodigoProveedor";
            DGCNombreRazonSocial2.DataSource = DTProveedoresCC;


            

            //new DgvFilterPopup.DgvFilterManager(dtGVProductosRequeridos);
            checkListartodos.Checked = true;
            DGVFilterManagerCuentasPorCobrar = new DgvFilterPopup.DgvFilterManager();
            DGVFilterManagerCuentasPorPagar = new DgvFilterPopup.DgvFilterManager();

            DGVFilterManagerCuentasPorCobrar.DataGridView = this.dtGVCuentasPorCobrar;
            DGVFilterManagerCuentasPorPagar.DataGridView = this.dtGVCuentasPorPagar;

            DTListarCompraProductoCuentasPorCobrarReporte.DefaultView.ListChanged += new ListChangedEventHandler(DefaultView_ListChanged);
            DTListarCompraProductoCuentasPorPagarReporte.DefaultView.ListChanged +=new ListChangedEventHandler(DefaultView_ListChanged);

            CargarResumenCuentasPorCobrar();
            CargarResumenCuentasPorPagar();
        }

        void DefaultView_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(sender.Equals(DTListarCompraProductoCuentasPorCobrarReporte.DefaultView))
                CargarResumenCuentasPorCobrar();
            else
                CargarResumenCuentasPorPagar();
        }

        public void CargarResumenCuentasPorPagar()
        {
            if (DGVFilterManagerCuentasPorPagar != null)
            {
                
                DataView DVCuentasPorPagar = ((DataTable)DGVFilterManagerCuentasPorPagar.DataGridView.DataSource).DefaultView;

                string MontoSumatoria = DVCuentasPorPagar.Table.Compute("Sum(MontoTotalCompra)", DVCuentasPorPagar.RowFilter).ToString();
                txtBoxTCompraCP.Text = String.IsNullOrEmpty(MontoSumatoria) ? "0.00" : MontoSumatoria;
                MontoSumatoria = DVCuentasPorPagar.Table.Compute("Sum(MontoCuentaPorPagar)", DVCuentasPorPagar.RowFilter).ToString();
                txtBoxTCuentaCP.Text = String.IsNullOrEmpty(MontoSumatoria) ? "0.00" : MontoSumatoria;
                MontoSumatoria = DVCuentasPorPagar.Table.Compute("Sum(MontoPagado)", DVCuentasPorPagar.RowFilter).ToString();
                txtBoxTPagadoCP.Text = String.IsNullOrEmpty(MontoSumatoria) ? "0.00" : MontoSumatoria;
                MontoSumatoria = DVCuentasPorPagar.Table.Compute("Sum(MontoDiferencia)", DVCuentasPorPagar.RowFilter).ToString();
                txtBoxTDiferenciaCP.Text = String.IsNullOrEmpty(MontoSumatoria) ? "0.00" : MontoSumatoria;
            }
        }

        public void CargarResumenCuentasPorCobrar()
        {
            if (DGVFilterManagerCuentasPorCobrar != null)
            {
                DataView DVCuentasPorCobrar = ((DataTable)DGVFilterManagerCuentasPorCobrar.DataGridView.DataSource).DefaultView;

                string MontoSumatoria = DVCuentasPorCobrar.Table.Compute("Sum(MontoTotalCompra)", DVCuentasPorCobrar.RowFilter).ToString();
                txtBoxTCompraCC.Text = String.IsNullOrEmpty(MontoSumatoria) ? "0.00" : MontoSumatoria;
                MontoSumatoria = DVCuentasPorCobrar.Table.Compute("Sum(MontoCuentaPorCobrar)", DVCuentasPorCobrar.RowFilter).ToString();
                txtBoxTCuentaCC.Text = String.IsNullOrEmpty(MontoSumatoria) ? "0.00" : MontoSumatoria;
                MontoSumatoria = DVCuentasPorCobrar.Table.Compute("Sum(MontoPagado)", DVCuentasPorCobrar.RowFilter).ToString();
                txtBoxTCobradoCC.Text = String.IsNullOrEmpty(MontoSumatoria) ? "0.00" : MontoSumatoria;
                MontoSumatoria = DVCuentasPorCobrar.Table.Compute("Sum(MontoDiferencia)", DVCuentasPorCobrar.RowFilter).ToString();
                txtBoxTDiferenciaCC.Text = String.IsNullOrEmpty(MontoSumatoria) ? "0.00" : MontoSumatoria;
            }
        }

        private void rBtnDetalleCompra_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if ((dtGVCuentasPorPagar.CurrentCell == null && tabControl1.SelectedIndex == 0)
                || (dtGVCuentasPorCobrar.CurrentCell == null && tabControl1.SelectedIndex == 1))
            {
                MessageBox.Show("Aún no ha seleccionado ninguna Fila");
                return;
            }
            if (rBtnDetalleCompra.Checked)
            {
                FComprasProductos formComprasProductos = new FComprasProductos(NumeroAgencia, NumeroPC, CodigoUsuario);
                formComprasProductos.emitirPermisos(false, false, false, true, false, false);
                formComprasProductos.cargarDatosCompras(tabControl1.SelectedIndex == 0 ?
                    int.Parse(dtGVCuentasPorPagar.CurrentRow.Cells[DGCNumeroCompraProducto.Name].Value.ToString())
                    : int.Parse(dtGVCuentasPorCobrar.CurrentRow.Cells[DGCNumeroCompraProducto2.Name].Value.ToString()));
                formComprasProductos.ShowDialog(this);
                formComprasProductos.Dispose();
            }
            else
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    FCuentasPorPagar formCuentasPorPagar = new FCuentasPorPagar(CodigoUsuario,NumeroAgencia,
                       int.Parse(dtGVCuentasPorPagar.CurrentRow.Cells[DGCNumeroCuentaPorPagar.Name].Value.ToString()), 
                        false, false, false, false, false);
                    formCuentasPorPagar.ShowDialog(this);
                    formCuentasPorPagar.Dispose();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    FCuentasPorCobrar formCuentasPorCobrar = new FCuentasPorCobrar(
                        int.Parse(dtGVCuentasPorPagar.CurrentRow.Cells[DGCNumeroCuentaPorCobrar.Name].Value.ToString()),
                        NumeroAgencia, false, false, false, false, false);
                    formCuentasPorCobrar.ShowDialog(this);
                    formCuentasPorCobrar.Dispose();
                }
            }
        }

        private void dtGVCuentasPorPagar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
                btnDetalle_Click(btnDetalle, e as EventArgs);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FComprasProductosCuentasPorPagar_Load(object sender, EventArgs e)
        {
            dPickeFechaHoraInicio.Value = DateTime.Parse("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtGVCuentasPorPagar_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                DGVFilterManagerCuentasPorPagar.ActivateAllFilters(false);
                if (checkListartodos.Checked)
                {
                    DTListarCompraProductoCuentasPorPagarReporte = _ComprasProductosCLN.ListarCompraProductoCuentasPorPagarReporte(NumeroAgencia, null, null, null, null);
                }
                else
                {
                    DTListarCompraProductoCuentasPorPagarReporte = _ComprasProductosCLN.ListarCompraProductoCuentasPorPagarReporte(NumeroAgencia,
                        String.IsNullOrEmpty(textBox1.Text.Trim()) ? (int?)null : int.Parse(textBox1.Text),
                        !String.IsNullOrEmpty(textBox1.Text.Trim()) ? (DateTime?)null : dPickeFechaHoraInicio.Value,
                        !String.IsNullOrEmpty(textBox1.Text.Trim()) ? (DateTime?)null : dPickerFechaHoraFin.Value,
                        null);
                }
                dtGVCuentasPorPagar.DataSource = DTListarCompraProductoCuentasPorPagarReporte;
                DGVFilterManagerCuentasPorPagar.DataGridView = dtGVCuentasPorPagar;                
                DTListarCompraProductoCuentasPorPagarReporte.DefaultView.ListChanged += new ListChangedEventHandler(DefaultView_ListChanged);
                CargarResumenCuentasPorPagar();
            }
            else
            {
                {
                    DGVFilterManagerCuentasPorCobrar.ActivateAllFilters(false);
                    if (checkListartodos.Checked)
                    {
                        DTListarCompraProductoCuentasPorCobrarReporte = _ComprasProductosCLN.ListarCompraProductoCuentasPorCobrarReporte(NumeroAgencia, null, null, null, null);
                    }
                    else
                    {
                        DTListarCompraProductoCuentasPorCobrarReporte = _ComprasProductosCLN.ListarCompraProductoCuentasPorCobrarReporte(NumeroAgencia,
                            String.IsNullOrEmpty(textBox1.Text.Trim()) ? (int?)null : int.Parse(textBox1.Text),
                            !String.IsNullOrEmpty(textBox1.Text.Trim()) ? (DateTime?)null : dPickeFechaHoraInicio.Value,
                            !String.IsNullOrEmpty(textBox1.Text.Trim()) ? (DateTime?)null : dPickerFechaHoraFin.Value,
                            null);
                    }
                    dtGVCuentasPorCobrar.DataSource = DTListarCompraProductoCuentasPorCobrarReporte;
                    DGVFilterManagerCuentasPorCobrar.DataGridView = dtGVCuentasPorCobrar;
                    DTListarCompraProductoCuentasPorCobrarReporte.DefaultView.ListChanged += new ListChangedEventHandler(DefaultView_ListChanged);
                    CargarResumenCuentasPorCobrar();
                }
            }
            
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            FReporteCuentasPorPagarCobrarTransacciones formReporteCuentas = new FReporteCuentasPorPagarCobrarTransacciones();
            if (tabControl1.SelectedIndex == 0)//pagar
            {
                formReporteCuentas.ListarCompraProductoCuentasPorPagarReporte(this.DTListarCompraProductoCuentasPorPagarReporte, dPickeFechaHoraInicio.Value, dPickerFechaHoraFin.Value);
                
            }
            else if (tabControl1.SelectedIndex == 1)//cobrar
            {
                formReporteCuentas.ListarCompraProductoCuentasPorCobrarReporte(this.DTListarCompraProductoCuentasPorCobrarReporte, dPickeFechaHoraInicio.Value, dPickerFechaHoraFin.Value);
            }
            formReporteCuentas.ShowDialog();
            formReporteCuentas.Dispose();
        }
    }
}
