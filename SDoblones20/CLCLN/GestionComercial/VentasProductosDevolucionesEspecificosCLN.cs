using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using System.Data;

namespace CLCLN.GestionComercial
{
    public class VentasProductosDevolucionesEspecificosCLN
    {
        private VentasProductosDevolucionesEspecificosTableAdapter _VentasProductosDevoluciones = null;
        protected VentasProductosDevolucionesEspecificosTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosDevoluciones == null)
                    _VentasProductosDevoluciones = new VentasProductosDevolucionesEspecificosTableAdapter();
                return _VentasProductosDevoluciones;
            }
        }

        public VentasProductosDevolucionesEspecificosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaProductoDevolucionEspecifico(int NumeroAgencia, int NumeroDevolucion, string CodigoProducto, string CodigoProductoEspecifico, decimal PrecioUnitarioDevolucionPE)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesEspecificosDataTable VentasProductosDevolucionesEspecificos = new CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesEspecificosDataTable();
            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesEspecificosRow VentaProductoDevolucionEspecifico = VentasProductosDevolucionesEspecificos.NewVentasProductosDevolucionesEspecificosRow();

            VentaProductoDevolucionEspecifico.NumeroAgencia = NumeroAgencia;
            VentaProductoDevolucionEspecifico.NumeroDevolucion = NumeroDevolucion;
            VentaProductoDevolucionEspecifico.CodigoProducto = CodigoProducto;
            VentaProductoDevolucionEspecifico.CodigoProductoEspecifico = CodigoProductoEspecifico;
            VentaProductoDevolucionEspecifico.PrecioUnitarioDevolucionPE = PrecioUnitarioDevolucionPE;

            VentasProductosDevolucionesEspecificos.AddVentasProductosDevolucionesEspecificosRow(VentaProductoDevolucionEspecifico);

            int rowsAffected = Adapter.Update(VentasProductosDevolucionesEspecificos);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaProductoDevolucionEspecifico(int NumeroAgencia, int NumeroDevolucion, string CodigoProducto, string CodigoProductoEspecifico, decimal PrecioUnitarioDevolucionPE)
        {
            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesEspecificosDataTable VentasProductosDevolucionesEspecificos = Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico);
            if (VentasProductosDevolucionesEspecificos.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.VentasProductosDevolucionesEspecificosRow VentaProductoDevolucionEspecifico = VentasProductosDevolucionesEspecificos[0];


            VentaProductoDevolucionEspecifico.PrecioUnitarioDevolucionPE = PrecioUnitarioDevolucionPE;

            int rowsAffected = Adapter.Update(VentaProductoDevolucionEspecifico);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaProductoDevolucionEspecifico(int NumeroAgencia, int NumeroDevolucion, string CodigoProducto, string CodigoProductoEspecifico)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosDevolucionesEspecificos(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]        
        public DataTable ObtenerVentaProductoDevolucionEspecifico(int NumeroAgencia, int NumeroDevolucion, string CodigoProducto, string CodigoProductoEspecifico)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasProductosDevolucionesEspecificosParaDevolucionesEspecificos(int NumeroAgencia, int NumeroDevolucion)
        {
            ListarVentasProductosDevolucionesEspecificosParaDevolucionTableAdapter AdapterAux = new ListarVentasProductosDevolucionesEspecificosParaDevolucionTableAdapter();
            return AdapterAux.GetData(NumeroAgencia, NumeroDevolucion);
        }

    }
}
