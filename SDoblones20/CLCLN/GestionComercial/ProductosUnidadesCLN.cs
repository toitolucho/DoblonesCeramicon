using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    [System.ComponentModel.DataObject]
    public class ProductosUnidadesCLN
    {
        private ProductosUnidadesTableAdapter _ProductosUnidadesAdapter = null;
        protected ProductosUnidadesTableAdapter Adapter
        {
            get
            {
                if (_ProductosUnidadesAdapter == null)
                    _ProductosUnidadesAdapter = new ProductosUnidadesTableAdapter();
                return _ProductosUnidadesAdapter;
            }
        }

        public ProductosUnidadesCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public bool InsertarProductoUnidad(string NombreUnidad, ref decimal? CodigoUnidadAsignado)
        {
            DSDoblones20GestionComercial.ProductosUnidadesDataTable ProductosUnidades = new DSDoblones20GestionComercial.ProductosUnidadesDataTable();
            DSDoblones20GestionComercial.ProductosUnidadesRow ProductoUnidad = ProductosUnidades.NewProductosUnidadesRow();


            ProductoUnidad.NombreUnidad = NombreUnidad;

            ProductosUnidades.AddProductosUnidadesRow(ProductoUnidad);

            int rowsAffected = Adapter.Update(ProductosUnidades);

            QTAFuncionesSistema fs = new QTAFuncionesSistema();
            fs.ObtenerUltimoIndiceTabla("ProductosUnidades", ref CodigoUnidadAsignado);


            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarProductoUnidad(int CodigoUnidad, string NombreUnidad)		
        {
            DSDoblones20GestionComercial.ProductosUnidadesDataTable ProductosUnidades = Adapter.GetDataBy(CodigoUnidad);
            if (ProductosUnidades.Count == 0)
                return false;

            DSDoblones20GestionComercial.ProductosUnidadesRow ProductoUnidad = ProductosUnidades[0];

            ProductoUnidad.CodigoUnidad = CodigoUnidad;
            ProductoUnidad.NombreUnidad = NombreUnidad;

         
            int rowsAffected = Adapter.Update(ProductoUnidad);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarProductoUnidad(int CodigoUnidad)
        {
            int rowsAffected = Adapter.Delete(CodigoUnidad);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosUnidades()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerProductoUnidad(int CodigoUnidad)
        {
            return Adapter.GetDataBy(CodigoUnidad);
        }
    }
}
