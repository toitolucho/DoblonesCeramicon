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
    public class ProductosEmpresasListaDetalleCLN
    {
        private ProductosEmpresasListaDetalleTableAdapter _ProductosEmpresasListaDetalleAdapter = null;
        protected ProductosEmpresasListaDetalleTableAdapter Adapter
        {
            get
            {
                if (_ProductosEmpresasListaDetalleAdapter == null)
                    _ProductosEmpresasListaDetalleAdapter = new ProductosEmpresasListaDetalleTableAdapter();
                return _ProductosEmpresasListaDetalleAdapter;
            }
        }

        public ProductosEmpresasListaDetalleCLN()
        { }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarProductosEmpresasListaDetalle(int NumLista, string Codigo, string Nombre, string Descripcion, decimal Precio)
        {
            DSDoblones20GestionComercial.ProductosEmpresasListaDetalleDataTable ListasDetalle = new DSDoblones20GestionComercial.ProductosEmpresasListaDetalleDataTable();
            DSDoblones20GestionComercial.ProductosEmpresasListaDetalleRow listadetalle = ListasDetalle.NewProductosEmpresasListaDetalleRow();

            listadetalle.NumeroLista = NumLista;
            listadetalle.CodigoProducto = Codigo;
            listadetalle.NombreProducto = Nombre;
            listadetalle.DescripcionProducto = Descripcion;
            listadetalle.PrecioProducto = Precio;

            ListasDetalle.AddProductosEmpresasListaDetalleRow(listadetalle);

            int rowsaffected = Adapter.Update(listadetalle);

            return rowsaffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool ElminarProductosEmpresasListaDetalle(int NumLista)
        {
            int rowsaffected = Adapter.Delete(NumLista);
            return rowsaffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosEmpresasListaDetalle()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosEmpresasListaDetalleNumeroLista(int NumLista)
        {
            return Adapter.GetDataByNumeroLista(NumLista);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosEmpresasListaDetalleNumeroListaReporte(int NumLista)
        {
            ListarProductosEmpresasListaDetalleReporteTableAdapter listadetalle = new ListarProductosEmpresasListaDetalleReporteTableAdapter();
            return listadetalle.GetData(NumLista);
        }
    }
}
