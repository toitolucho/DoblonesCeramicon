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
    public class PCsConfiguracionesCLN
    {
        #region Atributos de la Clase
        private PCsConfiguracionesTableAdapter _PCsConfiguracionesAdapter = null;
        protected PCsConfiguracionesTableAdapter Adapter
        {
            get
            {
                if (_PCsConfiguracionesAdapter == null)
                    _PCsConfiguracionesAdapter = new PCsConfiguracionesTableAdapter();
                return _PCsConfiguracionesAdapter;
            }
        }
        #endregion

        #region Constructor
        public PCsConfiguracionesCLN()
        {
            //constructor
        }

        #endregion

         
        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarPCConfiguracion(string IDPC, string IPPC, int NumeroAgencia, byte CodigoMonedaSistema, byte CodigoMonedaRegion, decimal PorcentajeImpuesto, bool ContabilidadIntegrada, string RutaDirectorioImagenes)
        {
            DSDoblones20Sistema.PCsConfiguracionesDataTable PCsConfiguraciones = new DSDoblones20Sistema.PCsConfiguracionesDataTable();
            DSDoblones20Sistema.PCsConfiguracionesRow PCConfiguracionFila = PCsConfiguraciones.NewPCsConfiguracionesRow();

            PCConfiguracionFila.IDPC = IDPC;
            PCConfiguracionFila.IPPC = IPPC;
            PCConfiguracionFila.NumeroAgencia = NumeroAgencia;
            PCConfiguracionFila.CodigoMonedaSistema = CodigoMonedaSistema;
            PCConfiguracionFila.CodigoMonedaRegion = CodigoMonedaRegion;
            PCConfiguracionFila.PorcentajeImpuesto = PorcentajeImpuesto;
            PCConfiguracionFila.ContabilidadIntegrada = ContabilidadIntegrada;
            PCConfiguracionFila.RutaDirectorioImagenes = RutaDirectorioImagenes;
            PCsConfiguraciones.AddPCsConfiguracionesRow(PCConfiguracionFila);

            int rowsAffected = Adapter.Update(PCsConfiguraciones);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarPCConfiguracion(int NumeroPC, string IDPC, string IPPC, int NumeroAgencia, byte CodigoMonedaSistema, byte CodigoMonedaRegion, decimal PorcentajeImpuesto, bool ContabilidadIntegrada, string RutaDirectorioImagenes)
        {
            DSDoblones20Sistema.PCsConfiguracionesDataTable PCsConfiguraciones = Adapter.GetDataBy(NumeroPC);
            if (PCsConfiguraciones.Count == 0)
                return false;
            DSDoblones20Sistema.PCsConfiguracionesRow PCConfiguracionFila = PCsConfiguraciones[0];

            PCConfiguracionFila.IDPC = IDPC;
            PCConfiguracionFila.IPPC = IPPC;
            PCConfiguracionFila.NumeroAgencia = NumeroAgencia;
            PCConfiguracionFila.CodigoMonedaSistema = CodigoMonedaSistema;
            PCConfiguracionFila.CodigoMonedaRegion = CodigoMonedaRegion;
            PCConfiguracionFila.PorcentajeImpuesto = PorcentajeImpuesto;
            PCConfiguracionFila.ContabilidadIntegrada = ContabilidadIntegrada;
            PCConfiguracionFila.RutaDirectorioImagenes = RutaDirectorioImagenes;
            
            PCsConfiguraciones.AddPCsConfiguracionesRow(PCConfiguracionFila);

            int rowsAffected = Adapter.Update(PCsConfiguraciones);
            return rowsAffected == 1;
        }


        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarPCConfiguracion(int NumeroPC)
        {                    
            int rowsAffedted = Adapter.Delete(NumeroPC);
            return rowsAffedted == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPCsConfiguraciones()
        {
            return Adapter.GetData(); 
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerPCConfiguracion(int NumeroPC)
        {
            return Adapter.GetDataBy(NumeroPC);
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerPCConfiguracionIDPC(string IDPC)
        {
            return Adapter.GetDataByObtenerPCConfiguracionIDPC(IDPC);
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerPermisosInterface(int CodigoUsuario, int NumeroAgencia, string NombreInterface)
        {
            ObtenerPermisosInterfaceTableAdapter Adapter = new ObtenerPermisosInterfaceTableAdapter();
            return Adapter.GetData(CodigoUsuario, NumeroAgencia, NombreInterface);
        }

        public DataTable ObtenerConfiguracionSistemaParaTransaccionesGC(int NumeroPC)
        {
            VariablesConfiguracionGCTableAdapter VCGCTA = new VariablesConfiguracionGCTableAdapter();
            return VCGCTA.GetData(NumeroPC);
        }


    }
}
