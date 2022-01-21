using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN;
using System.Globalization;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FCompraProductosSeleccionActualizarPrecios : Form
    {
        public CLCAD.DSDoblones20GestionComercial.ListarComprasProductosDetalleEntregaParaRecepcionDataTable DTCompraProductosRecepcionHistorial{get; set;}
        public DataTable DTListadoFechas{get; set;}
        public DataTable DTDetalleProductos { get; set; }
        public DataTable DTProductosRecepcionReciente{get; set;}

        int NumeroAgencia, NumeroCompraProducto;
        private int NumeroPC = 0;
        CLCLN.GestionComercial.ComprasProductosDetalleEntregaCLN _ComprasProductosDetalleEntregaCLN;
        public bool OperacionConfirmada = false;
        Font fuenteDefecto;
        DateTime FechaActualRecepcion;
        

        public FCompraProductosSeleccionActualizarPrecios(int NumeroAgencia, int NumeroPC, int NumeroCompraProducto, DateTime FechaRecepcion)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.NumeroCompraProducto = NumeroCompraProducto;
            this.FechaActualRecepcion = FechaRecepcion;
            _ComprasProductosDetalleEntregaCLN = new CLCLN.GestionComercial.ComprasProductosDetalleEntregaCLN();
        }

        private void FComprProductosSeleccionActualizarPrecios_Load(object sender, EventArgs e)
        {
            DGVProductosRecepcionados.AutoGenerateColumns = false;
            DGVCompraProductosRecepciones.AutoGenerateColumns = false;

            DTCompraProductosRecepcionHistorial = _ComprasProductosDetalleEntregaCLN.ListarComprasProductosDetalleEntregaParaRecepcion(NumeroAgencia, NumeroCompraProducto);
            
            DTDetalleProductos = DTCompraProductosRecepcionHistorial.Clone();

            foreach (DataRow FilaProducto in DTProductosRecepcionReciente.Select("NuevaCantidad > 0"))
            {
                CLCAD.DSDoblones20GestionComercial.ListarComprasProductosDetalleEntregaParaRecepcionRow FilaNueva = DTCompraProductosRecepcionHistorial.NewListarComprasProductosDetalleEntregaParaRecepcionRow();
                FilaNueva.BeginEdit();
                FilaNueva["CodigoProducto"] = FilaProducto["CodigoProducto"];
                FilaNueva["NombreProducto"] = FilaProducto["NombreProducto"];
                FilaNueva["CantidadEntregada"] = FilaProducto["NuevaCantidad"];
                FilaNueva["FechaHoraEntrega"] = FechaActualRecepcion;
                
                
                DTCompraProductosRecepcionHistorial.Rows.Add(FilaNueva);
                FilaNueva.AcceptChanges();
                DTCompraProductosRecepcionHistorial.AcceptChanges();
            }

            DTListadoFechas = new DataTable();
            DataColumn DCFechaRecepcion = new DataColumn("FechaRecepcion",Type.GetType("System.String"));
            DCFechaRecepcion.AllowDBNull = false;
            DCFechaRecepcion.Unique = true;

            DataColumn DCSeleccionar = new DataColumn("Seleccionar", Type.GetType("System.Boolean"));

            DTListadoFechas.Columns.Add(DCFechaRecepcion);
            DTListadoFechas.Columns.Add(DCSeleccionar);
            DTListadoFechas.DefaultView.Sort = "FechaRecepcion ASC";
            DTListadoFechas.Rows.Add(new object[]{FechaActualRecepcion,false});

            foreach (CLCAD.DSDoblones20GestionComercial.ListarComprasProductosDetalleEntregaParaRecepcionRow DRProductoRecepcion in DTCompraProductosRecepcionHistorial.Rows)
            {
                try
                {
                    DTListadoFechas.Rows.Add(new object[] { DRProductoRecepcion.FechaHoraEntrega, false });
                }
                catch (Exception)
                {                  
                    
                }
            }

            DGVCompraProductosRecepciones.DataSource = DTListadoFechas;
            DGVProductosRecepcionados.DataSource = DTDetalleProductos;
            

            DGCCodigoProducto.Width = 110;
            DGCCantidadRecepcionada.Width = 160;
            
            fuenteDefecto = DGVCompraProductosRecepciones.DefaultCellStyle.Font;

           

            //si los Gastos Existentes, solamente se pueden aplicar a
            //la recepción actual, ya que es la única existente
            if (DTCompraProductosRecepcionHistorial.Rows.Count == 1)
                DTListadoFechas.Rows[0]["Seleccionar"] = true;

            DTListadoFechas.AcceptChanges();

            DGVCompraProductosRecepciones.CellFormatting += new DataGridViewCellFormattingEventHandler(DGVCompraProductosRecepciones_CellFormatting);            
            DGVCompraProductosRecepciones.Click += new EventHandler(DGVCompraProductosRecepciones_Click);
            DGVCompraProductosRecepciones_Click(DGVCompraProductosRecepciones, e);

            DGVCompraProductosRecepciones.ClearSelection();
            DGVProductosRecepcionados.ClearSelection();
        }

        void DGVCompraProductosRecepciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DTListadoFechas.Rows.Count > 0)
            {

                if (DGVCompraProductosRecepciones.Rows[e.RowIndex].Cells[0].Value != null && e.RowIndex == DGVCompraProductosRecepciones.RowCount - 1)
                {
                    DGVCompraProductosRecepciones.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    DGVCompraProductosRecepciones.Rows[e.RowIndex].Cells["DGCFechaRecepcion"].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                }
            }
        }

        void DGVCompraProductosRecepciones_Click(object sender, EventArgs e)
        {
            if (DGVCompraProductosRecepciones.RowCount > 0 && DGVCompraProductosRecepciones.CurrentRow != null)
            {
                DTDetalleProductos.Clear();                

                DateTime FechaRecepcion = DateTime.Parse(DGVCompraProductosRecepciones[0, DGVCompraProductosRecepciones.CurrentRow.Index].Value.ToString());

                CLCAD.DSDoblones20GestionComercial.ListarComprasProductosDetalleEntregaParaRecepcionRow[] DRProductoRecepcion
                    = (CLCAD.DSDoblones20GestionComercial.ListarComprasProductosDetalleEntregaParaRecepcionRow[])
                    //DTCompraProductosRecepcionHistorial.Select("FechaHoraEntrega = #" + String.Format("{0:dd/MM/yyyy HH:mm}", FechaRecepcion) + "#");
                    //DTCompraProductosRecepcionHistorial.Select("FechaHoraEntrega = #" + String.Format("{0:u}", FechaRecepcion) + "#");
                    //DTCompraProductosRecepcionHistorial.Select("FechaHoraEntrega = #" + FechaRecepcion + "#");
                    DTCompraProductosRecepcionHistorial.Select("FechaHoraEntrega >= #" + FechaRecepcion.ToString(DateTimeFormatInfo.InvariantInfo) +
                    "# and FechaHoraEntrega < #" + FechaRecepcion.AddSeconds(1).ToString(DateTimeFormatInfo.InvariantInfo) + "#");
                //dt.Select("Date = #" + String.Format("{0:s}",datetimevalue) + "#");

                groupBox4.Text = "Listado de Productos entregados en la Fecha " + String.Format("{0:dd/MM/yyyy HH:mm:ss}", FechaRecepcion);
                foreach (CLCAD.DSDoblones20GestionComercial.ListarComprasProductosDetalleEntregaParaRecepcionRow DRProducto in DRProductoRecepcion)
                {
                    DTDetalleProductos.Rows.Add(DRProducto.ItemArray);
                }
                
                
            }            
        }

        private void checkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow Fila in DTListadoFechas.Rows)
            {
                Fila["Seleccionar"] = checkSeleccionarTodos.Checked;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (DTListadoFechas.Compute("count(Seleccionar)", "Seleccionar = true").Equals(0))
            {
                MessageBox.Show(this, "Aun no ha seleccionado ninguna Fecha de Recepción", "Ninguna Recepción Seleccioanda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OperacionConfirmada = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OperacionConfirmada = false;
            this.Close();
        }

        private void FComprProductosSeleccionActualizarPrecios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada)
            {
                if(MessageBox.Show(this,"¿Esta seguro de Cancelar la operación?", "Operación Cancelada", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.No)
                {
                    e.Cancel = true;
                    return;                    
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
