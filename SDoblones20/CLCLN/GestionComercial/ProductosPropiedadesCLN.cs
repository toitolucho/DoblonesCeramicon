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
    public class ProductosPropiedadesCLN
    {
        private ProductosPropiedadesTableAdapter _ProductosPropiedadesAdapter = null;
        protected ProductosPropiedadesTableAdapter Adapter
        {
            get
            {
                if (_ProductosPropiedadesAdapter == null)
                    _ProductosPropiedadesAdapter = new ProductosPropiedadesTableAdapter();
                return _ProductosPropiedadesAdapter;
            }
        }

        public ProductosPropiedadesCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarProductoPropiedad(string NombrePropiedad, string Mascara)		
        {
            DSDoblones20GestionComercial.ProductosPropiedadesDataTable ProductosPropiedades = new DSDoblones20GestionComercial.ProductosPropiedadesDataTable();
            DSDoblones20GestionComercial.ProductosPropiedadesRow ProductoPropiedad = ProductosPropiedades.NewProductosPropiedadesRow();

            ProductoPropiedad.NombrePropiedad = NombrePropiedad;
            ProductoPropiedad.Mascara = Mascara;
                   
            ProductosPropiedades.AddProductosPropiedadesRow(ProductoPropiedad);

            int rowsAffected = Adapter.Update(ProductosPropiedades);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarProductoPropiedad(int CodigoPropiedad, string NombrePropiedad, string Mascara)		
        {
            DSDoblones20GestionComercial.ProductosPropiedadesDataTable ProductosPropiedades = Adapter.GetDataBy(CodigoPropiedad);
            if (ProductosPropiedades.Count == 0)
                return false;

            DSDoblones20GestionComercial.ProductosPropiedadesRow ProductoPropiedad = ProductosPropiedades[0];

            ProductoPropiedad.CodigoPropiedad = CodigoPropiedad;
            ProductoPropiedad.NombrePropiedad = NombrePropiedad;
            ProductoPropiedad.Mascara = Mascara;

          
            int rowsAffected = Adapter.Update(ProductoPropiedad);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarProductoPropiedad(int CodigoPropiedad)
        {
            int rowsAffected = Adapter.Delete(CodigoPropiedad);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosPropiedades()
        {
            return Adapter.GetData();
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerProductoPropiedad(int CodigoPropiedad)
        {
            return Adapter.GetDataBy(CodigoPropiedad);
        }

        public DataTable ListarPropiedadesDisponiblesPorCodigoProducto(string CodigoProducto)
        {
            return Adapter.GetDataByListarPropiedadesDisponiblesPorCodigoProducto(CodigoProducto);
        }

        public DataTable ListarProductosDescripcionPorCodigoProducto(string CodigoProducto)
        {
            return Adapter.GetDataByListarProductosDescripcionPorCodigoProducto(CodigoProducto);
        }
    }
}
