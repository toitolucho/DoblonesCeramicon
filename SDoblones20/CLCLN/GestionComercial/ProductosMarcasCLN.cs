using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD;
using CLCAD.DSDoblones20SistemaTableAdapters;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    //[System.ComponentModel.DataObject]
    public class ProductosMarcasCLN
    {
        private ProductosMarcasTableAdapter _ProductosMarcasAdapter = null;
        protected ProductosMarcasTableAdapter Adapter
        {
            get
            {
                if (_ProductosMarcasAdapter == null)
                    _ProductosMarcasAdapter = new ProductosMarcasTableAdapter();
                return _ProductosMarcasAdapter;
            }
        }

        public ProductosMarcasCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public bool InsertarProductoMarca(string NombreMarcaProducto, ref decimal? CodigoMarcaAsignado)
        {
            DSDoblones20GestionComercial.ProductosMarcasDataTable ProductosMarcas = new DSDoblones20GestionComercial.ProductosMarcasDataTable();
            DSDoblones20GestionComercial.ProductosMarcasRow ProductoMarca = ProductosMarcas.NewProductosMarcasRow();

            ProductoMarca.NombreMarcaProducto = NombreMarcaProducto;

            ProductosMarcas.AddProductosMarcasRow(ProductoMarca);

            int rowsAffected = Adapter.Update(ProductosMarcas);

            QTAFuncionesSistema fs = new QTAFuncionesSistema();
            fs.ObtenerUltimoIndiceTabla("ProductosMarcas", ref CodigoMarcaAsignado);

            return rowsAffected == 1;
        }



        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarProductoMarca(int CodigoMarcaProducto, string NombreMarcaProducto)		
        {
            DSDoblones20GestionComercial.ProductosMarcasDataTable ProductosMarcas = Adapter.GetDataBy(CodigoMarcaProducto);
            if (ProductosMarcas.Count == 0)
                return false;

            DSDoblones20GestionComercial.ProductosMarcasRow ProductoMarca = ProductosMarcas[0];

            ProductoMarca.CodigoMarcaProducto = CodigoMarcaProducto;
            ProductoMarca.NombreMarcaProducto = NombreMarcaProducto;

            int rowsAffected = Adapter.Update(ProductoMarca);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarProductoMarca(int CodigoMarcaProducto)
        {
            int rowsAffected = Adapter.Delete(CodigoMarcaProducto);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosMarcas()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerProductoMarca(int CodigoMarcaProducto)
        {
            return Adapter.GetDataBy(CodigoMarcaProducto);
        }
    }
}
