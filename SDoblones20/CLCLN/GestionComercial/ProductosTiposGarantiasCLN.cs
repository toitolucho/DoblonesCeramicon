using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD;
using System.Data;
using System.Data.SqlClient;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;

namespace CLCLN.GestionComercial
{
    [System.ComponentModel.DataObject]
    public class ProductosTiposGarantiasCLN
    {
        private ProductosTiposGarantiasTableAdapter _ProductosTiposGarantiasAdapter = null;
        protected ProductosTiposGarantiasTableAdapter Adapter
        {
            get
            {
                if (_ProductosTiposGarantiasAdapter == null)
                    _ProductosTiposGarantiasAdapter = new ProductosTiposGarantiasTableAdapter();
                return _ProductosTiposGarantiasAdapter;
            }
        }

        public ProductosTiposGarantiasCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarProductoTipoGarantia(string NombreTipoGarantia, string Descripcion)
        {
            DSDoblones20GestionComercial2.ProductosTiposGarantiasDataTable ProductosTiposGarantias = new DSDoblones20GestionComercial2.ProductosTiposGarantiasDataTable();
            DSDoblones20GestionComercial2.ProductosTiposGarantiasRow ProductoTipoGarantia = ProductosTiposGarantias.NewProductosTiposGarantiasRow();

            ProductoTipoGarantia.CodigoTipoGarantia = 1;
            ProductoTipoGarantia.NombreTipoGarantia = NombreTipoGarantia;
            ProductoTipoGarantia.Descripcion = Descripcion;
            ProductosTiposGarantias.AddProductosTiposGarantiasRow(ProductoTipoGarantia);

            int rowsAffected = Adapter.Update(ProductosTiposGarantias);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarProductoTipoGarantia(int CodigoTipoGarantia, string NombreTipoGarantia, string Descripcion)
        {
            DSDoblones20GestionComercial2.ProductosTiposGarantiasDataTable ProductosTiposGarantias = Adapter.GetDataBy(CodigoTipoGarantia);
            if (ProductosTiposGarantias.Count == 0)
                return false;

            DSDoblones20GestionComercial2.ProductosTiposGarantiasRow ProductoTipoGarantia = ProductosTiposGarantias[0];

            ProductoTipoGarantia.NombreTipoGarantia = NombreTipoGarantia;
            ProductoTipoGarantia.Descripcion = Descripcion;

            int rowsAffected = Adapter.Update(ProductoTipoGarantia);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarProductoTipoGarantia(int CodigoMarcaProducto)
        {
            int rowsAffected = Adapter.Delete(CodigoMarcaProducto);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.ProductosTiposGarantiasDataTable ListarProductosTiposGarantias()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.ProductosTiposGarantiasDataTable ObtenerProductoTipoGarantia(int CodigoMarcaProducto)
        {
            return Adapter.GetDataBy(CodigoMarcaProducto);
        }
    }
}
