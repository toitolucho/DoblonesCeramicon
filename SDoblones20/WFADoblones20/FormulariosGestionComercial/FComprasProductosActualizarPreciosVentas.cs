using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FComprasProductosActualizarPreciosVentas : Form
    {
        decimal PorcentajeImpuestoCalculoPrecioVenta = 15.5M;
        int NumeroAgencia = 1;
        int NumeroCompraProducto = -1;
        string ProductosDetalleXML;
        

        CLCAD.DSDoblones20GestionComercial2.ListarProductosActualizacionNuevosPreciosDataTable DTListarProductosActualizacionNuevosPrecios;
        InventariosProductosCLN _InventariosProductosCLN;

        public FComprasProductosActualizarPreciosVentas(decimal PorcentajeImpuestoCalculoPrecioVenta, string ProductosDetalleXML, int NumeroAgencia = 1, int NumeroCompraProducto = -1)
        {
            InitializeComponent();

            this.PorcentajeImpuestoCalculoPrecioVenta = PorcentajeImpuestoCalculoPrecioVenta;
            this.ProductosDetalleXML = ProductosDetalleXML;
            this.label1.Text = "Porcentaje Impuesto Calculo Venta : " + PorcentajeImpuestoCalculoPrecioVenta.ToString();
            _InventariosProductosCLN = new InventariosProductosCLN();

            DTListarProductosActualizacionNuevosPrecios = _InventariosProductosCLN.ListarProductosActualizacionNuevosPrecios(NumeroAgencia, NumeroCompraProducto, ProductosDetalleXML, "P");
            //DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta1Column.Expression = "(PrecioCompraCalculado * PorcentajeUtilidad1 /100) + PrecioCompraCalculado";
            //DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta2Column.Expression = "(PrecioCompraCalculado * PorcentajeUtilidad2 /100) + PrecioCompraCalculado";
            //DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta3Column.Expression = "(PrecioCompraCalculado * PorcentajeUtilidad3 /100) + PrecioCompraCalculado";
            ////string expresion = "(PrecioCompraCalculado * " + PorcentajeImpuestoCalculoPrecioVenta.ToString() + "/ 100) + (PrecioCompraCalculado * PorcentajeUtilidad4 / 100) + PrecioCompraCalculado";
            //string expresion = String.Format("PrecioCompraCalculado + PrecioCompraCalculado *(({0} + PorcentajeUtilidad4)/100)", PorcentajeImpuestoCalculoPrecioVenta);
            //expresion = expresion.Replace(",", ".");
            //DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta4Column.Expression = expresion;
            //DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta5Column.Expression = expresion.Replace("4","5");
            //DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta6Column.Expression = expresion.Replace("4", "6");
            DTListarProductosActualizacionNuevosPrecios.PrecioCompraCalculadoColumn.ReadOnly = false;
            dtGVGastosActualizacion.AutoGenerateColumns = false;
            dtGVGastosActualizacion.DataSource = DTListarProductosActualizacionNuevosPrecios;

            dtGVGastosActualizacion.CellValidating += new DataGridViewCellValidatingEventHandler(dtGVGastosActualizacion_CellValidating);
            dtGVGastosActualizacion.CellValueChanged += new DataGridViewCellEventHandler(dtGVGastosActualizacion_CellValueChanged);
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void dtGVGastosActualizacion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtGVGastosActualizacion.RowCount > 0
                        && dtGVGastosActualizacion.CurrentRow != null && e.RowIndex >= 0)
                {
                    string CodigoProducto = dtGVGastosActualizacion.CurrentRow.Cells["DGCCodigoProducto"].Value.ToString();
                    string NombreProducto = dtGVGastosActualizacion.CurrentRow.Cells["DGCCodigoProducto"].Value.ToString();

                    CLCAD.DSDoblones20GestionComercial2.ListarProductosActualizacionNuevosPreciosRow DRProducto =
                        (CLCAD.DSDoblones20GestionComercial2.ListarProductosActualizacionNuevosPreciosRow)
                        DTListarProductosActualizacionNuevosPrecios.Select("CodigoProducto = '" + CodigoProducto + "'")[0];

                    decimal PrecioCompraCalculado = 0, PorcentajeUtilidad = 0, PrecioUnitarioVenta = 0;
                    PrecioCompraCalculado = decimal.Parse(dtGVGastosActualizacion.CurrentRow.Cells["DGCPrecioCompraPG"].Value.ToString());
                    switch (dtGVGastosActualizacion.Columns[e.ColumnIndex].Name)
                    {
                        case "DGCPorcentajeUtilidad1":
                        case "DGCPorcentajeUtilidad2":
                        case "DGCPorcentajeUtilidad3":
                        case "DGCPorcentajeUtilidad4":
                        case "DGCPorcentajeUtilidad5":
                        case "DGCPorcentajeUtilidad6":
                            PorcentajeUtilidad = decimal.Parse(dtGVGastosActualizacion.CurrentRow.Cells[dtGVGastosActualizacion.Columns[e.ColumnIndex].Name].Value.ToString());
                            break;
                        case "DGCPrecioVenta1":
                        case "DGCPrecioVenta2":
                        case "DGCPrecioVenta3":
                        case "DGCPrecioUnitarioVenta4":
                        case "DGCPrecioUnitarioVenta5":
                        case "DGCPrecioUnitarioVenta6":
                            PrecioUnitarioVenta = decimal.Parse(dtGVGastosActualizacion.CurrentRow.Cells[dtGVGastosActualizacion.Columns[e.ColumnIndex].Name].Value.ToString());
                            break;

                    }

                    if (e.ColumnIndex == DGCPorcentajeUtilidad1.Index)
                    {
                        DRProducto.PrecioUnitarioVenta1 = decimal.Round((PrecioCompraCalculado * PorcentajeUtilidad / 100) + PrecioCompraCalculado, 2);
                        DRProducto.AcceptChanges();
                        dtGVGastosActualizacion.CurrentRow.Cells["DGCPorcentajeUtilidad4"].Value = DRProducto.PorcentajeUtilidad1;
                        //DRProducto.PorcentajeUtilidad4 = DRProducto.PorcentajeUtilidad1;
                    }
                    if (e.ColumnIndex == DGCPorcentajeUtilidad2.Index)
                    {
                        DRProducto.PrecioUnitarioVenta2 = DRProducto.PrecioUnitarioVenta5 = decimal.Round((PrecioCompraCalculado * PorcentajeUtilidad / 100) + PrecioCompraCalculado, 2);
                        DRProducto.AcceptChanges();
                        dtGVGastosActualizacion.CurrentRow.Cells["DGCPorcentajeUtilidad5"].Value = DRProducto.PorcentajeUtilidad2;
                        //DRProducto.PorcentajeUtilidad5 = DRProducto.PorcentajeUtilidad2;
                    }
                    if (e.ColumnIndex == DGCPorcentajeUtilidad3.Index)
                    {
                        DRProducto.PrecioUnitarioVenta3 = DRProducto.PrecioUnitarioVenta6 = decimal.Round((PrecioCompraCalculado * PorcentajeUtilidad / 100) + PrecioCompraCalculado, 2);
                        DRProducto.AcceptChanges();
                        dtGVGastosActualizacion.CurrentRow.Cells["DGCPorcentajeUtilidad6"].Value = DRProducto.PorcentajeUtilidad3;
                        //DRProducto.PorcentajeUtilidad6 = DRProducto.PorcentajeUtilidad3;
                    }
                    if (e.ColumnIndex == DGCPorcentajeUtilidad4.Index)
                    {
                        DRProducto.PrecioUnitarioVenta4 = decimal.Round(PrecioCompraCalculado + PrecioCompraCalculado * ((PorcentajeImpuestoCalculoPrecioVenta + PorcentajeUtilidad) / 100), 2);
                    }
                    if (e.ColumnIndex == DGCPorcentajeUtilidad5.Index)
                    {
                        DRProducto.PrecioUnitarioVenta5 = decimal.Round(PrecioCompraCalculado + PrecioCompraCalculado * ((PorcentajeImpuestoCalculoPrecioVenta + PorcentajeUtilidad) / 100), 2);
                    }
                    if (e.ColumnIndex == DGCPorcentajeUtilidad6.Index)
                    {
                        DRProducto.PrecioUnitarioVenta6 = decimal.Round(PrecioCompraCalculado + PrecioCompraCalculado * ((PorcentajeImpuestoCalculoPrecioVenta + PorcentajeUtilidad) / 100), 2);
                    }


                    //DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad3Column.Expression = "(PrecioUnitarioVenta3/PrecioCompraCalculado -1) * 100";
                    //string expresion = String.Format("((PrecioUnitarioVenta4 - PrecioCompraCalculado)/ PrecioCompraCalculado * 100) - {0}", PorcentajeImpuestoCalculoPrecioVenta);
                    if (e.ColumnIndex == DGCPrecioVenta1.Index)
                    {
                        DRProducto.PorcentajeUtilidad1 = decimal.Round((PrecioUnitarioVenta / PrecioCompraCalculado - 1) * 100, 2);
                        dtGVGastosActualizacion.CurrentRow.Cells["DGCPorcentajeUtilidad4"].Value = DRProducto.PorcentajeUtilidad1;
                    }
                    if (e.ColumnIndex == DGCPrecioVenta2.Index)
                    {
                        DRProducto.PorcentajeUtilidad2 = decimal.Round((PrecioUnitarioVenta / PrecioCompraCalculado - 1) * 100, 2);
                        dtGVGastosActualizacion.CurrentRow.Cells["DGCPorcentajeUtilidad5"].Value = DRProducto.PorcentajeUtilidad2;
                    }
                    if (e.ColumnIndex == DGCPrecioVenta3.Index)
                    {
                        DRProducto.PorcentajeUtilidad3 = decimal.Round((PrecioUnitarioVenta / PrecioCompraCalculado - 1) * 100, 2);
                        dtGVGastosActualizacion.CurrentRow.Cells["DGCPorcentajeUtilidad6"].Value = DRProducto.PorcentajeUtilidad3;
                    }
                    if (e.ColumnIndex == DGCPrecioUnitarioVenta4.Index)
                    {
                        DRProducto.PorcentajeUtilidad4 = decimal.Round(((PrecioUnitarioVenta - PrecioCompraCalculado) / PrecioCompraCalculado * 100) - PorcentajeImpuestoCalculoPrecioVenta, 2);
                    }
                    if (e.ColumnIndex == DGCPrecioUnitarioVenta5.Index)
                    {
                        DRProducto.PorcentajeUtilidad5 = decimal.Round(((PrecioUnitarioVenta - PrecioCompraCalculado) / PrecioCompraCalculado * 100) - PorcentajeImpuestoCalculoPrecioVenta, 2);
                    }
                    if (e.ColumnIndex == DGCPrecioUnitarioVenta6.Index)
                    {
                        DRProducto.PorcentajeUtilidad6 = decimal.Round(((PrecioUnitarioVenta - PrecioCompraCalculado) / PrecioCompraCalculado * 100) - PorcentajeImpuestoCalculoPrecioVenta, 2);
                    }

                    if (e.ColumnIndex == DGCPrecioCompraPG.Index)
                    {
                        dtGVGastosActualizacion_CellValueChanged(dtGVGastosActualizacion, new DataGridViewCellEventArgs(DGCPorcentajeUtilidad1.Index, e.RowIndex));
                        dtGVGastosActualizacion_CellValueChanged(dtGVGastosActualizacion, new DataGridViewCellEventArgs(DGCPorcentajeUtilidad2.Index, e.RowIndex));
                        dtGVGastosActualizacion_CellValueChanged(dtGVGastosActualizacion, new DataGridViewCellEventArgs(DGCPorcentajeUtilidad3.Index, e.RowIndex));
                    }

                    DRProducto.AcceptChanges();
                    DTListarProductosActualizacionNuevosPrecios.AcceptChanges();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ocurrió la siguiente excepción " + ex.Message + ". Probablmente el precio de Compra tiene un valor de 0, modifique los Precios de Compra",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void dtGVGastosActualizacion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal PrecioPorcentajeVenta;

            this.dtGVGastosActualizacion.Rows[e.RowIndex].ErrorText = "";

            // No cell validation for new rows. New rows are validated on Row Validation.
            if (this.dtGVGastosActualizacion.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dtGVGastosActualizacion.IsCurrentCellDirty)
            {
                switch (this.dtGVGastosActualizacion.Columns[e.ColumnIndex].Name)
                {

                    case "DGCPrecioVenta1":
                    case "DGCPrecioVenta2":
                    case "DGCPrecioVenta3":
                    case "DGCPrecioUnitarioVenta4":
                    case "DGCPrecioUnitarioVenta5":
                    case "DGCPrecioUnitarioVenta6":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVGastosActualizacion.Rows[e.RowIndex].ErrorText = "   El Precio de Venta no puede estar en Blanco.";
                            e.Cancel = true;
                        }
                        else if (!decimal.TryParse(e.FormattedValue.ToString(), out PrecioPorcentajeVenta) || PrecioPorcentajeVenta <= 0)
                        {
                            this.dtGVGastosActualizacion.Rows[e.RowIndex].ErrorText = "   El Precio de Venta debe ser un entero positivo.";
                            e.Cancel = true;
                        }
                        break;

                    case "DGCPorcentajeUtilidad":
                    case "DGCPorcentajeUtilidad1":
                    case "DGCPorcentajeUtilidad2":
                    case "DGCPorcentajeUtilidad3":
                    case "DGCPorcentajeUtilidad4":
                    case "DGCPorcentajeUtilidad5":
                    case "DGCPorcentajeUtilidad6":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVGastosActualizacion.Rows[e.RowIndex].ErrorText = "   El Porcentaje de Utilidad de Venta no puede estar en Blanco.";
                            e.Cancel = true;
                        }

                        else if (!decimal.TryParse(e.FormattedValue.ToString(), out PrecioPorcentajeVenta) || PrecioPorcentajeVenta < 0)
                        {
                            this.dtGVGastosActualizacion.Rows[e.RowIndex].ErrorText = "   El Porcentaje de Utilidad de Venta debe ser un entero positivo.";
                            e.Cancel = true;
                        }
                        break;
                }

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            DTListarProductosActualizacionNuevosPrecios.Columns.Remove(DTListarProductosActualizacionNuevosPrecios.NombreProductoColumn);
            DataSet DSProductos = new DataSet("Productos");
            DTListarProductosActualizacionNuevosPrecios.TableName = "ProductosHistorial";
            DSProductos.Tables.Add(DTListarProductosActualizacionNuevosPrecios);
            string ListadoProductosDetalleXML =  DTListarProductosActualizacionNuevosPrecios.DataSet.GetXml();
            _InventariosProductosCLN.ActualizarPreciosVentaUtilidadXML(NumeroAgencia, NumeroCompraProducto, ListadoProductosDetalleXML);
            this.Close();
        }

        //private void rBtnCalcularPrecios_CheckedChanged(object sender, EventArgs e)
        //{
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad1Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad2Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad3Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad4Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad5Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad6Column.Expression = String.Empty;
        //    DGCPorcentajeUtilidad2.ReadOnly = DGCPorcentajeUtilidad1.ReadOnly = DGCPorcentajeUtilidad6.ReadOnly =
        //        DGCPorcentajeUtilidad3.ReadOnly = DGCPorcentajeUtilidad4.ReadOnly = DGCPorcentajeUtilidad5.ReadOnly = false;

        //    DGCPrecioVenta1.ReadOnly = DGCPrecioVenta2.ReadOnly = DGCPrecioVenta3.ReadOnly =
        //        DGCPrecioUnitarioVenta4.ReadOnly = DGCPrecioUnitarioVenta5.ReadOnly = DGCPrecioUnitarioVenta6.ReadOnly = true;

        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta1Column.Expression = "(PrecioCompraCalculado * PorcentajeUtilidad1 /100) + PrecioCompraCalculado";
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta2Column.Expression = "(PrecioCompraCalculado * PorcentajeUtilidad2 /100) + PrecioCompraCalculado";
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta3Column.Expression = "(PrecioCompraCalculado * PorcentajeUtilidad3 /100) + PrecioCompraCalculado";
        //    string expresion = String.Format("PrecioCompraCalculado + PrecioCompraCalculado *(({0} + PorcentajeUtilidad4)/100)", PorcentajeImpuestoCalculoPrecioVenta);
        //    expresion = expresion.Replace(",", ".");
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta4Column.Expression = expresion;
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta5Column.Expression = expresion.Replace("4", "5");
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta6Column.Expression = expresion.Replace("4", "6");

            
        //}

        //private void rBtnCalcularPorcentaje_CheckedChanged(object sender, EventArgs e)
        //{
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta1Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta2Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta3Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta4Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta5Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta6Column.Expression = String.Empty;

        //    DGCPrecioVenta1.ReadOnly = DGCPrecioVenta2.ReadOnly = DGCPrecioVenta3.ReadOnly =
        //        DGCPrecioUnitarioVenta4.ReadOnly = DGCPrecioUnitarioVenta5.ReadOnly = DGCPrecioUnitarioVenta6.ReadOnly = false;

            
            

        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad1Column.Expression = "(PrecioUnitarioVenta1/PrecioCompraCalculado -1) * 100";
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad2Column.Expression = "(PrecioUnitarioVenta2/PrecioCompraCalculado -1) * 100";
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad3Column.Expression = "(PrecioUnitarioVenta3/PrecioCompraCalculado -1) * 100";
        //    string expresion = String.Format("((PrecioUnitarioVenta4 - PrecioCompraCalculado)/ PrecioCompraCalculado * 100) - {0}", PorcentajeImpuestoCalculoPrecioVenta);
        //    expresion = expresion.Replace(",", ".");
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad4Column.Expression = expresion;
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad5Column.Expression = expresion.Replace("4", "5");
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad6Column.Expression = expresion.Replace("4", "5");


        //    DGCPorcentajeUtilidad2.ReadOnly = DGCPorcentajeUtilidad1.ReadOnly = DGCPorcentajeUtilidad6.ReadOnly =
        //        DGCPorcentajeUtilidad3.ReadOnly = DGCPorcentajeUtilidad4.ReadOnly = DGCPorcentajeUtilidad5.ReadOnly = true;

            
        //}

        //private void rBtnCalcularManualmente_CheckedChanged(object sender, EventArgs e)
        //{
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad1Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad2Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad3Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad4Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad5Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PorcentajeUtilidad6Column.Expression = String.Empty;

        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta1Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta2Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta3Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta4Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta5Column.Expression = String.Empty;
        //    DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta6Column.Expression = String.Empty;

        //    DGCPorcentajeUtilidad2.ReadOnly = DGCPorcentajeUtilidad1.ReadOnly = DGCPorcentajeUtilidad6.ReadOnly =
        //        DGCPorcentajeUtilidad3.ReadOnly = DGCPorcentajeUtilidad4.ReadOnly = DGCPorcentajeUtilidad5.ReadOnly = false;

        //    DGCPrecioVenta1.ReadOnly = DGCPrecioVenta2.ReadOnly = DGCPrecioVenta3.ReadOnly =
        //        DGCPrecioUnitarioVenta4.ReadOnly = DGCPrecioUnitarioVenta5.ReadOnly = DGCPrecioUnitarioVenta6.ReadOnly = false;
        //}
    }
}
