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
    public class ComprasProductosDocuImagCLN
    {
        #region Atributos de la Clase
        
        private ComprasProductosDocuImagTableAdapter _ComprasProductosDocuImagAdapter = null;
        protected ComprasProductosDocuImagTableAdapter Adapter
        {
            get
            {
                if (_ComprasProductosDocuImagAdapter == null)
                    _ComprasProductosDocuImagAdapter = new ComprasProductosDocuImagTableAdapter();
                return _ComprasProductosDocuImagAdapter;
            }
        }
        #endregion

        #region Constructor
        public ComprasProductosDocuImagCLN()
        {
            //constructor
        }

        #endregion


        /// <summary>
        /// Insertar un Documento de Imagen para una Compra (la Imagen Escaneada de una Factura)
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroCompraProducto"></param>
        /// <param name="CodigoTipoDocumento"></param>
        /// <param name="NumeroTipoDocumento"></param>
        /// <param name="RutaArchivoImagenDocumento"></param>
        /// <param name="Descripcion"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCompraProductoDocuImag(int NumeroAgencia,int NumeroCompraProducto, byte CodigoTipoDocumento,byte NumeroTipoDocumento, string RutaArchivoImagenDocumento, string Descripcion)
        {
            DSDoblones20GestionComercial.ComprasProductosDocuImagDataTable ComprasProductosDocuImag = new DSDoblones20GestionComercial.ComprasProductosDocuImagDataTable();
            DSDoblones20GestionComercial.ComprasProductosDocuImagRow compraProductoDocuImag = ComprasProductosDocuImag.NewComprasProductosDocuImagRow();

            compraProductoDocuImag.NumeroAgencia = NumeroAgencia;
            compraProductoDocuImag.NumeroCompraProducto  = NumeroCompraProducto;
            compraProductoDocuImag.CodigoTipoDocumento = CodigoTipoDocumento;
            compraProductoDocuImag.NumeroTipoDocumento = NumeroTipoDocumento;
            if (RutaArchivoImagenDocumento == null)
                compraProductoDocuImag.SetRutaArchivoImagenDocumentoNull();
            else
                compraProductoDocuImag.RutaArchivoImagenDocumento = RutaArchivoImagenDocumento;
            if (Descripcion == null)
                compraProductoDocuImag.SetDescripcionNull();
            else
                compraProductoDocuImag.Descripcion = Descripcion;
           


            ComprasProductosDocuImag.AddComprasProductosDocuImagRow(compraProductoDocuImag);

            int rowsAffected = Adapter.Update(ComprasProductosDocuImag);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarCompraProductoDocuImag(int NumeroAgencia, int NumeroCompraProducto, byte CodigoTipoDocumento, byte NumeroTipoDocumento, string RutaArchivoImagenDocumento, string Descripcion)
        {
            DSDoblones20GestionComercial.ComprasProductosDocuImagDataTable ComprasProductosDocuImag = Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, CodigoTipoDocumento);
            if (ComprasProductosDocuImag.Count == 0)
                return false;
            DSDoblones20GestionComercial.ComprasProductosDocuImagRow compraProductoDocuImag = ComprasProductosDocuImag[0];

            compraProductoDocuImag.NumeroAgencia = NumeroAgencia;
            compraProductoDocuImag.NumeroCompraProducto = NumeroCompraProducto;
            compraProductoDocuImag.CodigoTipoDocumento = CodigoTipoDocumento;
            compraProductoDocuImag.NumeroTipoDocumento = NumeroTipoDocumento;
            if (RutaArchivoImagenDocumento == null)
                compraProductoDocuImag.SetRutaArchivoImagenDocumentoNull();
            else
                compraProductoDocuImag.RutaArchivoImagenDocumento = RutaArchivoImagenDocumento;
            if (Descripcion == null)
                compraProductoDocuImag.SetDescripcionNull();
            else
                compraProductoDocuImag.Descripcion = Descripcion;
            


            ComprasProductosDocuImag.AddComprasProductosDocuImagRow(compraProductoDocuImag);

            int rowsAffected = Adapter.Update(compraProductoDocuImag);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCompraProductoDocuImag(int NumeroAgencia, int NumeroCompraProducto, byte CodigoTipoDocumento)
        {
            int rowsAffedted = Adapter.Delete(NumeroAgencia,NumeroCompraProducto,CodigoTipoDocumento);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarComprasProductosDocuImag(int NumeroAgencia)
        {
            return Adapter.GetData(NumeroAgencia); 
        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerCompraProductoDocuImag(int NumeroAgencia, int NumeroCompraProducto, byte CodigoTipoDocumento)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroCompraProducto, CodigoTipoDocumento);
        }
    }
}
