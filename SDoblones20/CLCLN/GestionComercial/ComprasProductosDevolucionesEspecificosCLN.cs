using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using System.Data;

namespace CLCLN.GestionComercial
{
    public class ComprasProductosDevolucionesEspecificosCLN
    {
        private ComprasProductosDevolucionesEspecificosTableAdapter _VentasProductosDevoluciones = null;
        protected ComprasProductosDevolucionesEspecificosTableAdapter Adapter
        {
            get
            {
                if (_VentasProductosDevoluciones == null)
                    _VentasProductosDevoluciones = new ComprasProductosDevolucionesEspecificosTableAdapter();
                return _VentasProductosDevoluciones;
            }
        }

        public ComprasProductosDevolucionesEspecificosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCompraProductoDevolucionEspecifico(int NumeroAgencia, int NumeroDevolucion, string CodigoProducto, string CodigoProductoEspecifico, decimal PrecioUnitarioDevolucionPE)
        {
            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesEspecificosDataTable ComprasProductosDevolucionesEspecificos = new CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesEspecificosDataTable();
            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesEspecificosRow CompraProductoDevolucionEspecifico = ComprasProductosDevolucionesEspecificos.NewComprasProductosDevolucionesEspecificosRow();

            CompraProductoDevolucionEspecifico.NumeroAgencia = NumeroAgencia;
            CompraProductoDevolucionEspecifico.NumeroDevolucion = NumeroDevolucion;
            CompraProductoDevolucionEspecifico.CodigoProducto = CodigoProducto;
            CompraProductoDevolucionEspecifico.CodigoProductoEspecifico = CodigoProductoEspecifico;
            CompraProductoDevolucionEspecifico.PrecioUnitarioDevolucionPE = PrecioUnitarioDevolucionPE;


            ComprasProductosDevolucionesEspecificos.AddComprasProductosDevolucionesEspecificosRow(CompraProductoDevolucionEspecifico);

            int rowsAffected = Adapter.Update(ComprasProductosDevolucionesEspecificos);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCompraProductoDevolucionEspecifico(int NumeroAgencia, int NumeroDevolucion, string CodigoProducto, string CodigoProductoEspecifico, decimal PrecioUnitarioDevolucionPE)
        {
            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesEspecificosDataTable ComprasProductosDevolucionesEspecificos = Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico);
            if (ComprasProductosDevolucionesEspecificos.Count == 0)
                return false;

            CLCAD.DSDoblones20GestionComercial.ComprasProductosDevolucionesEspecificosRow CompraProductoDevolucionEspecifico = ComprasProductosDevolucionesEspecificos[0];


            CompraProductoDevolucionEspecifico.PrecioUnitarioDevolucionPE = PrecioUnitarioDevolucionPE;

            int rowsAffected = Adapter.Update(CompraProductoDevolucionEspecifico);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProductoDevolucionEspecifico(int NumeroAgencia, int NumeroDevolucion, string CodigoProducto, string CodigoProductoEspecifico)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarComprasProductosDevolucionesEspecificos(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]        
        public DataTable ObtenerCompraProductoDevolucionEspecifico(int NumeroAgencia, int NumeroDevolucion, string CodigoProducto, string CodigoProductoEspecifico)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico);
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarComprasProductosDevolucionesEspecificosParaDevoluciones(int NumeroAgencia, int NumeroDevolucion)
        {
            ListarComprasProductosDevolucionesEspecificosParaDevolucionesTableAdapter AdapterAux = new ListarComprasProductosDevolucionesEspecificosParaDevolucionesTableAdapter();
            return AdapterAux.GetData(NumeroAgencia, NumeroDevolucion);
        }

    }
}
