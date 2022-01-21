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
    public class ProductosDescripcionCLN
    {
        private ProductosDescripcionTableAdapter _ProductosDescripcionAdapter = null;
        protected ProductosDescripcionTableAdapter Adapter
        {
            get
            {
                if (_ProductosDescripcionAdapter == null)
                    _ProductosDescripcionAdapter = new ProductosDescripcionTableAdapter();
                return _ProductosDescripcionAdapter;
            }
        }

        public ProductosDescripcionCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarProductoDescripcion(string CodigoProducto, int CodigoPropiedad, string ValorPropiedad)		
        {
            DSDoblones20GestionComercial.ProductosDescripcionDataTable ProductosDescripcion = new DSDoblones20GestionComercial.ProductosDescripcionDataTable();
            DSDoblones20GestionComercial.ProductosDescripcionRow ProductoDescripcion = ProductosDescripcion.NewProductosDescripcionRow();

            ProductoDescripcion.CodigoProducto = CodigoProducto;
            ProductoDescripcion.CodigoPropiedad = CodigoPropiedad;
            ProductoDescripcion.ValorPropiedad = ValorPropiedad;
                               
            ProductosDescripcion.AddProductosDescripcionRow(ProductoDescripcion);

            int rowsAffected = Adapter.Update(ProductosDescripcion);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarProductoDescripcion(string CodigoProducto, int CodigoPropiedad, string ValorPropiedad)		
        {
            DSDoblones20GestionComercial.ProductosDescripcionDataTable ProductosDescripcion = Adapter.GetDataBy(CodigoProducto, CodigoPropiedad);
            if (ProductosDescripcion.Count == 0)
                return false;

            DSDoblones20GestionComercial.ProductosDescripcionRow ProductoDescripcion = ProductosDescripcion[0];

            ProductoDescripcion.CodigoProducto = CodigoProducto;
            ProductoDescripcion.CodigoPropiedad = CodigoPropiedad;
            ProductoDescripcion.ValorPropiedad = ValorPropiedad;

            int rowsAffected = Adapter.Update(ProductoDescripcion);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarProductoDescripcion(string CodigoProducto, int CodigoPropiedad)
        {
            int rowsAffected = Adapter.Delete(CodigoProducto, CodigoPropiedad);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosDescripcion()
        {
            return Adapter.GetData();
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerProductoDescripcion(string CodigoProducto, int CodigoPropiedad)
        {
            return Adapter.GetDataBy(CodigoProducto, CodigoPropiedad);
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosDescripcionPorCodigoProducto(string CodigoProducto)
        {
            return Adapter.GetDataByCodigoProducto(CodigoProducto);
        }
    }
}
