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
    public partial class FInventarioKardex : Form
    {
        DateTime FechaInicio = DateTime.Now.AddMonths(-1);
        DateTime FechaFin = DateTime.Now;
        int NumeroAgencia;
        InventariosProductosCLN _InventariosProductosCLN = new InventariosProductosCLN();
        DataTable DTInventarioProductos;

        public FInventarioKardex(int NumeroAgencia)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            dtGVListadoProductos.AutoGenerateColumns = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFin.Value < dateTimePickerInicio.Value)
            {
                MessageBox.Show("No puede Ingresar una Fecha Fin superior a la Fecha Inicial");
                dateTimePickerFin.Focus();
                return;
            }
            FechaInicio = dateTimePickerInicio.Value;
            FechaFin = dateTimePickerFin.Value;
            DTInventarioProductos = _InventariosProductosCLN.ListarHistorialInventarioPorFecha(NumeroAgencia, FechaInicio, FechaFin);
            //DataColumn DCSeleccionar = new DataColumn("Seleccionar", Type.GetType("System.Boolean"));
            //DCSeleccionar.DefaultValue = false;
            //DTInventarioProductos.Columns.Add(DCSeleccionar);


            dtGVListadoProductos.DataSource = DTInventarioProductos;
            new DgvFilterPopup.DgvFilterManager(dtGVListadoProductos);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            //MessageBox.Show((dtGVListadoProductos.DataSource as DataTable).DefaultView.Count.ToString() + "  Tabla "+(dtGVListadoProductos.DataSource as DataTable).DefaultView.ToTable().Rows.Count.ToString() );
            //return;
            WFADoblones20.FormulariosGestionComercial.FReporteInventarioKardex formReporteInventarioKardex;
            if (rBtnGeneral.Checked)
            {
                formReporteInventarioKardex = new FReporteInventarioKardex((dtGVListadoProductos.DataSource as DataTable).DefaultView.ToTable(), true, FechaInicio, FechaFin);
                
            }
            else
            {
                if (dtGVListadoProductos.RowCount == 0)
                {
                    MessageBox.Show(this, "Tiene la Opcion de Mostrar un Producto, embargo no ha seleccionado aún un Producto de la Lista", "Reporte Detallado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                DataTable DTHistorialDetalladoProducto = _InventariosProductosCLN.ListarMovimientosKardexProductos(
                    checkAgencias.Checked ? -1 : NumeroAgencia, checkFechas.Checked ? ((DateTime?)dateTimePickerInicio.Value) : null,
                    checkFechas.Checked ? ((DateTime?)dateTimePickerFin.Value) : null,
                    checkProductos.Checked ? dtGVListadoProductos.CurrentRow.Cells["DGCCodigoProducto"].Value.ToString() : null);

                formReporteInventarioKardex = new FReporteInventarioKardex(DTHistorialDetalladoProducto, false, FechaInicio, FechaFin);

            }
            formReporteInventarioKardex.Show(this);
        }

        private void dtGVListadoProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 2 || e.ColumnIndex == 3 ) && (Int32.Parse(e.Value.ToString()) > 0))
            {
                //e.CellStyle.BackColor = Color.LightBlue;                
                //DataGridViewCell Celda = dtGVListadoProductos.Rows[e.RowIndex].Cells[e.ColumnIndex - 1];
                //Font Fuente = new Font(e.CellStyle.Font.FontFamily, 7, FontStyle.Bold);
                //Celda.Style.Font = Fuente;
                //Celda.Style.BackColor = Color.LightBlue;

                dtGVListadoProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                dtGVListadoProductos.Rows[e.RowIndex].Cells[0].Style.Font = new Font(e.CellStyle.Font.FontFamily, 7, FontStyle.Bold);
                dtGVListadoProductos.Rows[e.RowIndex].Cells[1].Style.Font = new Font(e.CellStyle.Font.FontFamily, 7, FontStyle.Bold);
            }
        }

        private void FInventarioKardex_Load(object sender, EventArgs e)
        {
            DGCNombreProducto.Width = 200;
            DGCCodigoProducto.Width = 75;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rBtnDetallado_CheckedChanged(object sender, EventArgs e)
        {
            checkAgencias.Visible = checkProductos.Visible = checkFechas.Visible = rBtnDetallado.Checked;
        }

        private void dtGVListadoProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVListadoProductos.RowCount > 0 && e.RowIndex >= 0)
            {
                checkProductos.Checked = true;
                rBtnDetallado.Checked = true;
                checkAgencias.Checked = false;
                btnReporte_Click(btnReporte, e as EventArgs);
            }
        }

    }
}
