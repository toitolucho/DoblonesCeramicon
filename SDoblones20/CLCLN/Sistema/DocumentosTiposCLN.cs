using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;


namespace CLCLN.Sistema
{
    public class DocumentosTiposCLN
    {
        #region Atributos de la Clase
        private DocumentosTiposTableAdapter _DocumentosTiposAdapter = null;
        protected DocumentosTiposTableAdapter Adapter
        {
            get
            {
                if (_DocumentosTiposAdapter == null)
                    _DocumentosTiposAdapter = new DocumentosTiposTableAdapter();
                return _DocumentosTiposAdapter;
            }
        }
        #endregion

        #region Constructor
        public DocumentosTiposCLN()
        {
            //constructor
        }

        #endregion

        #region Insertar,Actualizar, Eliminar, Listar y Obtener un Tipo de Documento
        /// <summary>
        /// Insertar un Tipo de Documento
        /// </summary>
        /// <param name="NombreTipoDocumento">Nombre del Tipo de Documento o Descripcion del Tipo</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarDocumentoTipo(string NombreTipoDocumento)
        {
            DSDoblones20Sistema.DocumentosTiposDataTable DocumentosTipos = new DSDoblones20Sistema.DocumentosTiposDataTable();
            DSDoblones20Sistema.DocumentosTiposRow documentoTipo = DocumentosTipos.NewDocumentosTiposRow();
                        
            documentoTipo.NombreTipoDocumento = NombreTipoDocumento;


            DocumentosTipos.AddDocumentosTiposRow(documentoTipo);

            int rowsAffected = Adapter.Update(DocumentosTipos);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarDocumentoTipo(byte CodigoTipoDocumento, string NombreTipoDocumento)
        {
            DSDoblones20Sistema.DocumentosTiposDataTable DocumentosTipos = Adapter.GetDataBy(CodigoTipoDocumento);
            if (DocumentosTipos.Count == 0)
                return false;
            DSDoblones20Sistema.DocumentosTiposRow documentoTipo = DocumentosTipos[0];

            documentoTipo.CodigoTipoDocumento = CodigoTipoDocumento;
            documentoTipo.NombreTipoDocumento = NombreTipoDocumento;
            


            DocumentosTipos.AddDocumentosTiposRow(documentoTipo);

            int rowsAffected = Adapter.Update(documentoTipo);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarDocumentoTipo(byte CodigoTipoDocumento)
        {
            int rowsAffedted = Adapter.Delete(CodigoTipoDocumento);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarDocumentosTipos()
        {
            return Adapter.GetData(); 
        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerDocumentoTipo(byte CodigoTipoDocumento)
        {
            return Adapter.GetDataBy(CodigoTipoDocumento);
        }
        #endregion
    }
}
