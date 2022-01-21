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
    public class ProductosImagenesCLN
    {
        private ProductosImagenesTableAdapter _ProductosImagenesAdapter = null;
        protected ProductosImagenesTableAdapter Adapter
        {
            get
            {
                if (_ProductosImagenesAdapter == null)
                    _ProductosImagenesAdapter = new ProductosImagenesTableAdapter();
                return _ProductosImagenesAdapter;
            }
        }

        public ProductosImagenesCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarProductoImagen(string CodigoProducto, byte NumeroImagen, string RutaArchivoImagen, string NombreImagen)		
        {
            DSDoblones20GestionComercial.ProductosImagenesDataTable ProductosImagenes = new DSDoblones20GestionComercial.ProductosImagenesDataTable();
            DSDoblones20GestionComercial.ProductosImagenesRow ProductoImagen = ProductosImagenes.NewProductosImagenesRow();

            ProductoImagen.CodigoProducto = CodigoProducto;
            ProductoImagen.NumeroImagen = NumeroImagen;
            ProductoImagen.RutaArchivoImagen = RutaArchivoImagen;
            ProductoImagen.NombreImagen = NombreImagen;
                   
            ProductosImagenes.AddProductosImagenesRow(ProductoImagen);

            int rowsAffected = Adapter.Update(ProductosImagenes);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarProductoImagen(string CodigoProducto, byte NumeroImagen, string RutaArchivoImagen, string NombreImagen)		
        {
            DSDoblones20GestionComercial.ProductosImagenesDataTable ProductosImagenes = Adapter.GetDataBy(CodigoProducto, NumeroImagen);
            if (ProductosImagenes.Count == 0)
                return false;

            DSDoblones20GestionComercial.ProductosImagenesRow ProductoImagen = ProductosImagenes[0];

            ProductoImagen.CodigoProducto = CodigoProducto;
            ProductoImagen.NumeroImagen = NumeroImagen;
            ProductoImagen.RutaArchivoImagen = RutaArchivoImagen;
            ProductoImagen.NombreImagen = NombreImagen;

            //ProductosImagenes.AddProductosImagenesRow(ProductoImagen);

            int rowsAffected = Adapter.Update(ProductoImagen);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarProductoImagen(string CodigoProducto, int NumeroImagen)
        {
            int rowsAffected = Adapter.Delete(CodigoProducto, NumeroImagen);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosImagenes()
        {
            return Adapter.GetData();
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerProductoImagen(string CodigoProducto, int NumeroImagen)
        {
            return Adapter.GetDataBy(CodigoProducto, NumeroImagen);
        }

        public DataTable ListarProductosImagenesPorProducto(string CodigoProducto)
        {
            return Adapter.GetDataByListarProductosImagenesPorProducto(CodigoProducto);
        }

        public int ObtenerSiguienteNumeroProductoImagen(string CodigoProducto)
        {
            FuncionesGestionComercial fgcaux1 = new FuncionesGestionComercial();
            return int.Parse(fgcaux1.ObtenerSiguienteNumeroProductoImagen(CodigoProducto.TrimEnd()).ToString());
        }
    }
}
