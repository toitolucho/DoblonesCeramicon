using System;
using System.Collections.Generic;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.Sistema
{
    [System.ComponentModel.DataObject]
    public class MonedasCotizacionesCLN
    {
        private MonedasCotizacionesTableAdapter _MonedasCotizacionesAdapter = null;
        protected MonedasCotizacionesTableAdapter Adapter
        {
            get
            {
                if (_MonedasCotizacionesAdapter == null)
                    _MonedasCotizacionesAdapter = new MonedasCotizacionesTableAdapter();
                return _MonedasCotizacionesAdapter;
            }
        }

        public MonedasCotizacionesCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarMonedaCotizacion(byte CodigoMoneda, DateTime FechaHoraCotizacion, byte CodigoMonedaCotizacion, decimal CambioOficial, decimal CambioParalelo)		
        {
            DSDoblones20Sistema.MonedasCotizacionesDataTable MonedasCotizaciones = new DSDoblones20Sistema.MonedasCotizacionesDataTable();
            DSDoblones20Sistema.MonedasCotizacionesRow MonedaCotizacion = MonedasCotizaciones.NewMonedasCotizacionesRow();
            
            MonedaCotizacion.CodigoMoneda = CodigoMoneda;
            MonedaCotizacion.FechaHoraCotizacion = FechaHoraCotizacion;
            MonedaCotizacion.CodigoMonedaCotizacion = CodigoMonedaCotizacion;
            MonedaCotizacion.CambioOficial = CambioOficial;
            MonedaCotizacion.CambioParalelo = CambioParalelo;
            
            MonedasCotizaciones.AddMonedasCotizacionesRow(MonedaCotizacion);

            int rowsAffected = Adapter.Update(MonedasCotizaciones);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarMonedaCotizacion(byte CodigoMoneda, DateTime FechaHoraCotizacion, byte CodigoMonedaCotizacion, decimal CambioOficial, decimal CambioParalelo)		
        {
            DSDoblones20Sistema.MonedasCotizacionesDataTable MonedasCotizaciones = Adapter.GetDataBy(CodigoMoneda, FechaHoraCotizacion, CodigoMonedaCotizacion);
            if (MonedasCotizaciones.Count == 0)
                return false;

            DSDoblones20Sistema.MonedasCotizacionesRow MonedaCotizacion = MonedasCotizaciones[0];

            MonedaCotizacion.CodigoMoneda = CodigoMoneda;
            MonedaCotizacion.FechaHoraCotizacion = FechaHoraCotizacion;
            MonedaCotizacion.CodigoMonedaCotizacion = CodigoMonedaCotizacion;
            MonedaCotizacion.CambioOficial = CambioOficial;
            MonedaCotizacion.CambioParalelo = CambioParalelo;

            int rowsAffected = Adapter.Update(MonedaCotizacion);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarMonedaCotizacion(byte CodigoMoneda, DateTime FechaHoraCotizacion, byte CodigoMonedaCotizacion)			
        {
            int rowsAffected = Adapter.Delete(CodigoMoneda, FechaHoraCotizacion, CodigoMonedaCotizacion);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarMonedasCotizaciones()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerMonedaCotizacion(byte CodigoMoneda, DateTime FechaHoraCotizacion, byte CodigoMonedaCotizacion)
        {
            return Adapter.GetDataBy(CodigoMoneda, FechaHoraCotizacion, CodigoMonedaCotizacion);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarMonedasCotizacionesPorMoneda(byte CodigoMoneda, byte CodigoMonedaCotizacion, DateTime FechaHoraCotizacionInicio, DateTime FechaHoraCotizacionFin)
        {
            MonedasCotizacionesPorMonedaTableAdapter AdaptadorTemporal = new MonedasCotizacionesPorMonedaTableAdapter();
            return AdaptadorTemporal.GetData(CodigoMoneda, CodigoMonedaCotizacion, FechaHoraCotizacionInicio, FechaHoraCotizacionFin);
        }

        public CLCAD.DSDoblones20Sistema.MonedasCotizacionesDataTable ObtenerUltimaMonedaCotizacionFecha(byte CodigoMonedaSistema, byte CodigoMonedaCotizacion)
        {
            return Adapter.GetDataByUltimaMonedaCotizacion(CodigoMonedaSistema, CodigoMonedaCotizacion);
        }
    }
}
