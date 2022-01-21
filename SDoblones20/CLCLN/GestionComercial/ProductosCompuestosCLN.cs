using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    //[System.ComponentModel.DataObject]
    public class ProductosCompuestosCLN
    {
        private ProductosCompuestosTableAdapter _ProductosCompuestosAdapter = null;
        protected ProductosCompuestosTableAdapter Adapter
        {
            get
            {
                if (_ProductosCompuestosAdapter == null)
                    _ProductosCompuestosAdapter = new ProductosCompuestosTableAdapter();
                return _ProductosCompuestosAdapter;
            }
        }

        public ProductosCompuestosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarProductoCompuesto(string CodigoProducto, string CodigoProductoComponente, int NumeroComponente, int Cantidad)		
        {
            DSDoblones20GestionComercial.ProductosCompuestosDataTable ProductosCompuestos = new DSDoblones20GestionComercial.ProductosCompuestosDataTable();
            DSDoblones20GestionComercial.ProductosCompuestosRow ProductoCompuesto = ProductosCompuestos.NewProductosCompuestosRow();

            ProductoCompuesto.CodigoProducto = CodigoProducto;
            ProductoCompuesto.CodigoProductoComponente = CodigoProductoComponente;
            ProductoCompuesto.NumeroComponente = NumeroComponente;
            ProductoCompuesto.Cantidad = Cantidad;
                   
            ProductosCompuestos.AddProductosCompuestosRow(ProductoCompuesto);

            int rowsAffected = Adapter.Update(ProductosCompuestos);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarProductoCompuesto(string CodigoProducto, string CodigoProductoComponente, int NumeroComponente, int Cantidad)			
        {
            DSDoblones20GestionComercial.ProductosCompuestosDataTable ProductosCompuestos = Adapter.GetDataBy1(CodigoProducto, CodigoProductoComponente);
            if (ProductosCompuestos.Count == 0)
                return false;

            DSDoblones20GestionComercial.ProductosCompuestosRow ProductoCompuesto = ProductosCompuestos[0];

            ProductoCompuesto.CodigoProducto = CodigoProducto;
            ProductoCompuesto.CodigoProducto = CodigoProductoComponente;
            ProductoCompuesto.NumeroComponente = NumeroComponente;
            ProductoCompuesto.Cantidad = Cantidad;
            
            int rowsAffected = Adapter.Update(ProductoCompuesto);
            return rowsAffected == 1;
        }

        public void ActualizarComponenteProductoCompuesto(string CodigoProducto, string CodigoProductoComponenteAnterior, string CodigoProductoComponenteNuevo, int NumeroComponente, int Cantidad)
        {
            Adapter.ActualizarComponenteProductoCompuesto(CodigoProducto, CodigoProductoComponenteAnterior, CodigoProductoComponenteNuevo, NumeroComponente, Cantidad);
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarProductoCompuesto(string CodigoProducto, string CodigoProductoComponente)
        {
            int rowsAffected = Adapter.Delete(CodigoProducto, CodigoProductoComponente);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosCompuestos()
        {
            return Adapter.GetData();
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerProductoCompuesto(string CodigoProducto, string CodigoProductoComponente)
        {
            return Adapter.GetDataBy1(CodigoProducto, CodigoProductoComponente);
        }

        public DataTable ListarProductosCompuestosPorProducto(string CodigoProducto)
        {
            return Adapter.GetDataByListarProductosCompuestosPorProducto(CodigoProducto);
        }

        public int ObtenerSiguienteNumeroProductoImagen(string CodigoProducto)
        {
            FuncionesGestionComercial fgcaux1 = new FuncionesGestionComercial();
            return int.Parse(fgcaux1.ObtenerSiguienteNumeroProductoImagen(CodigoProducto.TrimEnd()).ToString());
        }

        public void CopiarProductosComponentes(string CodigoProductoOrigen, string CodigoProductoDestino)
        {
            Adapter.CopiarProductosComponentes(CodigoProductoOrigen, CodigoProductoDestino);
        }
    }
}
