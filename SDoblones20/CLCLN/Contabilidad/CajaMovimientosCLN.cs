using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD;
using CLCAD.DSDoblones20ContabilidadTableAdapters;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.Contabilidad
{
    public class CajaMovimientosCLN
    {
        
        private CajaMovimientosTableAdapter _CajaMovimientosTableAdapter = null;
        protected CajaMovimientosTableAdapter Adapter
        {
            get
            {
                if (_CajaMovimientosTableAdapter == null)
                    _CajaMovimientosTableAdapter = new CajaMovimientosTableAdapter();
                return _CajaMovimientosTableAdapter;
            }
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCajaMovimiento(byte CodigoMoneda, string Tipo, int CodigoUsuario, DateTime Fecha, string Descripcion, string Estado, decimal Debe, decimal Haber)
        {
            DSDoblones20Contabilidad.CajaMovimientosDataTable Movimientos = new DSDoblones20Contabilidad.CajaMovimientosDataTable();
            DSDoblones20Contabilidad.CajaMovimientosRow movimiento = Movimientos.NewCajaMovimientosRow();

            movimiento.CodigoMoneda = CodigoMoneda;
            movimiento.CodigoMedioPago = Tipo;
            movimiento.CodigoUsuario = CodigoUsuario;
            movimiento.FechaHora = Fecha;
            movimiento.Descripcion = Descripcion;
            movimiento.Estado = Estado;
            movimiento.Debe = Debe;
            movimiento.Haber = Haber;

            Movimientos.AddCajaMovimientosRow(movimiento);

            int rowsAffected = Adapter.Update(movimiento);

            

            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCajaMovimiento(byte CodigoMoneda, int NumMovimiento, string Tipo, int CodigoUsuario, DateTime Fecha, string Descripcion, string Estado, decimal Debe, decimal Haber)
        {

            int? numeromovimiento = NumMovimiento;
            DSDoblones20Contabilidad.CajaMovimientosDataTable Movimientos = Adapter.GetDataByNumero(numeromovimiento);

            DSDoblones20Contabilidad.CajaMovimientosRow movimiento = Movimientos[0];
            movimiento.CodigoMoneda = CodigoMoneda;
            movimiento.CodigoMedioPago = Tipo;
            movimiento.CodigoUsuario = CodigoUsuario;
            movimiento.FechaHora = Fecha;
            movimiento.Descripcion = Descripcion;
            movimiento.Estado = Estado;
            movimiento.Debe = Debe;
            movimiento.Haber = Haber;

            int rowsAffected = Adapter.Update(movimiento);
            return rowsAffected == 1;
        }        


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCajaMovimientoEstado(int NumMovimiento, string Estado)
        {

            int? numeromovimiento = NumMovimiento;
            DSDoblones20Contabilidad.CajaMovimientosDataTable Movimientos = Adapter.GetDataByNumero(numeromovimiento);

            DSDoblones20Contabilidad.CajaMovimientosRow movimiento = Movimientos[0];

            movimiento.Estado = Estado;

            int rowsAffected = Adapter.Update(movimiento);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarAsiento(int NumeroMovimiento)
        {
            int rowsAffected = Adapter.Delete(NumeroMovimiento);
            return rowsAffected == 1;
        }

        public DataTable Listar()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCajaMovimientosFecha(DateTime Fecha)
        {
            return Adapter.GetDataByFecha((DateTime?)Fecha);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCajaMovimientosFechaTipo(DateTime Fecha, string Tipo)
        {
            return Adapter.GetDataByMedioPago(Tipo, Fecha);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public decimal ObtenerUltimoSaldo()
        {
            QTAFuncionesContabilidad funciones = new QTAFuncionesContabilidad();
            decimal? respuesta = 0;

            funciones.ObtenerCajaMovimientoUltimoSaldo(ref respuesta);

            return (decimal)respuesta;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public int ObtenerUltimoNumeroMovimiento()
        {
            QTAFuncionesContabilidad funciones = new QTAFuncionesContabilidad();
            int? respuesta = 0;

            funciones.ObtenerUltimoNumeroCajaMovimiento(ref respuesta);

            return (int)respuesta;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public bool ExisteCajaMovimientosEstado(string Estado, string Fecha)
        {
            DateTime? dt = DateTime.Parse(Fecha);
            DSDoblones20Contabilidad.CajaMovimientosDataTable dd = Adapter.GetDataByEstado(Estado, dt);
            if (Adapter.GetDataByEstado(Estado, dt).Rows.Count > 0)
                return true;
            else
                return false;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public bool YaExisteFecha(DateTime Fecha)
        {
            bool respuesta = false;

            if (Adapter.GetDataByFecha((DateTime?)Fecha) == null)
                respuesta = false;
            else
                respuesta = true;

            return respuesta;
        }

        /*[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable Arqueo(int CodigoMoneda)
        {
            ListarMonedasFraccionesCodigoMonedaReporteTableAdapter miadapter = new ListarMonedasFraccionesCodigoMonedaReporteTableAdapter();
            return miadapter.GetData(CodigoMoneda);
        }*/

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCajaMovimientosReporte(int NumeroMovimiento)
        {
            ListarCajaMovimientosReporteNumeroTableAdapter miadapter = new ListarCajaMovimientosReporteNumeroTableAdapter();
            return miadapter.GetData(NumeroMovimiento);
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCajaMovimientosReporte(DateTime Fecha)
        {
            ListarCajaMovimientosReporteNumeroTableAdapter miadapter = new ListarCajaMovimientosReporteNumeroTableAdapter();
            return miadapter.GetDataByFecha((DateTime?)Fecha);
        }

        public void ActualizarMontoTotalDesdeDetalleFraccionado(int NumeroAgencia, int NumeroMovimiento)
        {
            QTAFuncionesContabilidad funciones = new QTAFuncionesContabilidad();
            funciones.ActualizarMontoTotalDesdeDetalleFraccionado(NumeroMovimiento, NumeroAgencia);
        }


        /// <summary>
        /// Realiza un listado de todos los movimientos de caja PARTICULARES
        /// incluida la Apertura y el cierre o arqueo
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <returns></returns>
        public DSDoblones20Contabilidad.ListarMovimientoCajaReporteDataTable ListarMovimientoCajaReporte(int NumeroAgencia,
            DateTime? FechaInicio, DateTime? FechaFin)
        {
            return new ListarMovimientoCajaReporteTableAdapter().GetData(NumeroAgencia, FechaInicio, FechaFin);
        }

        /// <summary>
        /// Lista el Detalle Fraccionado de Monedas, tanto para la apertura y el cierre de caja
        /// </summary>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <param name="TipoEstado"></param>
        /// <returns></returns>
        public DSDoblones20Contabilidad.ListarMovimientoCajaFraccionesReporteDataTable ListarMovimientoCajaFraccionesReporte(
            DateTime? FechaInicio, DateTime? FechaFin, string TipoEstado)
        {
            return new ListarMovimientoCajaFraccionesReporteTableAdapter().GetData(FechaInicio, FechaFin, TipoEstado);
        }

        /// <summary>
        /// Lista los campos resumidos de amlisis de un Arqueo de caja
        /// en una determinada Fecha
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <returns></returns>
        public DSDoblones20Contabilidad.ListarResumenCajaMovimientoReporteDataTable ListarResumenCajaMovimientoReporte(
            int NumeroAgencia, DateTime? FechaInicio, DateTime? FechaFin)
        {
            return new ListarResumenCajaMovimientoReporteTableAdapter().GetData(NumeroAgencia, FechaInicio, FechaFin);
        }
    }
}
