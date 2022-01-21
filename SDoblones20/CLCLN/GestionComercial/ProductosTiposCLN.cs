using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    //[System.ComponentModel.DataObject]
    public class ProductosTiposCLN
    {
        private ProductosTiposTableAdapter _ProductosTiposAdapter = null;
        protected ProductosTiposTableAdapter Adapter
        {
            get
            {
                if (_ProductosTiposAdapter == null)
                    _ProductosTiposAdapter = new ProductosTiposTableAdapter();
                return _ProductosTiposAdapter;
            }
        }

        public ProductosTiposCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarProductoTipo(int? CodigoTipoProductoPadre, string NombreTipoProducto, string NombreCortoTipoProducto, string DescripcionTipoProducto, int Nivel, ref int? CodigoTipoProducto)		
        {
            DSDoblones20GestionComercial.ProductosTiposDataTable ProductosTipos = new DSDoblones20GestionComercial.ProductosTiposDataTable();
            DSDoblones20GestionComercial.ProductosTiposRow ProductoTipo = ProductosTipos.NewProductosTiposRow();

            if (CodigoTipoProductoPadre == null) ProductoTipo.SetCodigoTipoProductoPadreNull();
            else ProductoTipo.CodigoTipoProductoPadre = CodigoTipoProductoPadre.Value;
            ProductoTipo.NombreTipoProducto = NombreTipoProducto;
            ProductoTipo.NombreCortoTipoProducto = NombreCortoTipoProducto;
            ProductoTipo.DescripcionTipoProducto = DescripcionTipoProducto;
            ProductoTipo.Nivel = Nivel;
                   
            ProductosTipos.AddProductosTiposRow(ProductoTipo);
            int rowsAffected = Adapter.Update(ProductosTipos);

            if (rowsAffected > 0)
            {
                TransaccionesUtilidadesCLN TransaccionesUtilidades = new TransaccionesUtilidadesCLN();
                CodigoTipoProducto = TransaccionesUtilidades.ObtenerUltimoIndiceTabla("ProductosTipos");
                return true;
            }
            else
                return false;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarProductoTipo(int CodigoTipoProducto, int? CodigoTipoProductoPadre, string NombreTipoProducto, string NombreCortoTipoProducto, string DescripcionTipoProducto, int Nivel)		
        {
            DSDoblones20GestionComercial.ProductosTiposDataTable ProductosTipos = Adapter.GetDataBy(CodigoTipoProducto);
            if (ProductosTipos.Count == 0)
                return false;

            DSDoblones20GestionComercial.ProductosTiposRow ProductoTipo = ProductosTipos[0];

            //ProductoTipo.CodigoTipoProducto = CodigoTipoProducto;
            if (CodigoTipoProductoPadre == null) ProductoTipo.SetCodigoTipoProductoPadreNull();
            else ProductoTipo.CodigoTipoProductoPadre = CodigoTipoProductoPadre.Value;
            ProductoTipo.NombreTipoProducto = NombreTipoProducto;
            ProductoTipo.NombreCortoTipoProducto = NombreCortoTipoProducto;
            ProductoTipo.DescripcionTipoProducto = DescripcionTipoProducto;
            ProductoTipo.Nivel = Nivel;

            int rowsAffected = Adapter.Update(ProductoTipo);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarProductoTipo(int CodigoTipoProducto)
        {
            int rowsAffected = Adapter.Delete(CodigoTipoProducto);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosTipos()
        {
            return Adapter.GetData();
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerProductoTipo(int CodigoTipoProducto)
        {
            return Adapter.GetDataBy(CodigoTipoProducto);
        }

        public DataTable ListarProductosTiposPadres()
        {
            return Adapter.GetDataByListarProductosTiposPadres();
        }

        public DataTable ListarProductosTiposProductoTipoPadre(int? CodigoTipoProductoPadre)
        {
            return Adapter.GetDataByListarProductosTiposProductoTipoPadre(CodigoTipoProductoPadre);
        }

        public DataTable ObtenerProductoTipoNombre(string NombreTipoProducto)
        {
            return Adapter.GetDataByObtenerProductoTipoNombre(NombreTipoProducto);
        }

    }
}
