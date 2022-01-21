using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD.DSDoblones20ContabilidadTableAdapters;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    public class ProductosEmpresasListaCLN
    {
        private ProductosEmpresasListaTableAdapter   _ProductosEmpresasListaAdapter = null;
        protected ProductosEmpresasListaTableAdapter Adapter
        {
            get
            {
                if (_ProductosEmpresasListaAdapter == null)
                    _ProductosEmpresasListaAdapter = new ProductosEmpresasListaTableAdapter();
                return _ProductosEmpresasListaAdapter;
            }
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarProductosEmpresasLista(int CodEmpresa, string Descripcion, DateTime Fecha)
        {
            DSDoblones20GestionComercial.ProductosEmpresasListaDataTable listas = new DSDoblones20GestionComercial.ProductosEmpresasListaDataTable();
            DSDoblones20GestionComercial.ProductosEmpresasListaRow lista = listas.NewProductosEmpresasListaRow();

            lista.CodigoEmpresa = CodEmpresa;
            lista.Descripcion = Descripcion;
            lista.Fecha = Fecha;

            listas.AddProductosEmpresasListaRow(lista);

            int rowsaffected = Adapter.Update(listas);
            return rowsaffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarProductosEmpresasLista(int NumeroLista)
        {
            int rowsaffected = Adapter.Delete(NumeroLista);
            return rowsaffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosEmpresasListaProveedor(int CodProveedor)
        {
            return Adapter.GetDataByProveedor(CodProveedor);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProveedores()
        {
            ListarProveedoresProductosEmpresasListaTableAdapter proveedores = new ListarProveedoresProductosEmpresasListaTableAdapter();
            return proveedores.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public int UltimoNumeroLista()
        {
            QTAFuncionesContabilidad indice = new QTAFuncionesContabilidad();
            int? respuesta = 0;

            indice.ObtenerUlitmoIndiceLista(ref respuesta);

            return (int)respuesta;
        }
    }
}
