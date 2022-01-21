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
    public class AsientosCLN
    {
        private AsientosTableAdapter _AsientosTableAdapter = null;
        protected AsientosTableAdapter Adapter
        {
            get
            {
                if (_AsientosTableAdapter == null)
                    _AsientosTableAdapter = new AsientosTableAdapter();
                return _AsientosTableAdapter;
            }
        }

        public AsientosCLN()
        { }

        /// <summary>
        /// Registra un nuevo asiento contable
        /// </summary>
        /// <param name="CodigoUsuario"></param>
        /// <param name="Fecha"></param>
        /// <param name="Glosa"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarAsientos(int CodigoUsuario, string Fecha, string Hora, string Glosa, string Estado)
        {
            DSDoblones20Contabilidad.AsientosDataTable asientos = new DSDoblones20Contabilidad.AsientosDataTable();
            DSDoblones20Contabilidad.AsientosRow asiento = asientos.NewAsientosRow();

            asiento.CodigoUsuario = CodigoUsuario;

            /*DateTime fechaAux = DateTime.Parse(Fecha);
            asiento.Fecha = DateTime.Parse(fechaAux.ToShortDateString());
            DateTime horaAux = DateTime.Parse(Hora);
            asiento.Hora = TimeSpan.Parse(horaAux.ToLongTimeString());*/

            asiento.Fecha = DateTime.Parse(Fecha);
            asiento.Hora = DateTime.Parse(Hora);

            asiento.Glosa = Glosa;
            asiento.Estado = Estado;

            asientos.AddAsientosRow(asiento);

            int rowsAffected = Adapter.Update(asientos);
            return rowsAffected == 1;
        }

        /// <summary>
        /// Actualiza un asiento contable
        /// </summary>
        /// <param name="NumeroDeAsiento"></param>
        /// <param name="CodigoUsuario"></param>
        /// <param name="Fecha"></param>
        /// <param name="Glosa"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarAsientos(int NumeroDeAsiento, int CodigoUsuario, string Fecha, string Hora, string Glosa, string Estado)
        {

            int? numeroasiento = NumeroDeAsiento;
            DSDoblones20Contabilidad.AsientosDataTable asientos = Adapter.GetDataBy(numeroasiento);

            DSDoblones20Contabilidad.AsientosRow asiento = asientos[0];

            asiento.CodigoUsuario = CodigoUsuario;
            DateTime fechaAux = DateTime.Parse(Fecha);
            asiento.Fecha = DateTime.Parse(fechaAux.ToShortDateString());
            DateTime horaAux = DateTime.Parse(Hora);
            asiento.Hora = DateTime.Parse(horaAux.ToLongTimeString());
            asiento.Glosa = Glosa;
            asiento.Estado = Estado;

            int rowsAffected = Adapter.Update(asiento);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarAsiento(int NumeroAsiento)
        {
            int rowsAffected = Adapter.Delete(NumeroAsiento);
            return rowsAffected == 1;
        }

        /// <summary>
        /// Lista todos los asientos
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarAsientos()
        {
            return Adapter.GetData();
        }

        /// <summary>
        /// Lista todos los asientos de una fecha y estado definidos
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarAsientosFechaEstado(DateTime Fecha, string Estado)
        {
            ListarAsientosFechaEstadoTableAdapter ListarAsientosTA = new ListarAsientosFechaEstadoTableAdapter();
            return ListarAsientosTA.GetData(Fecha,Estado);
        }

        /// <summary>
        /// Lista todos los asientos de una fecha definida
        /// </summary>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarAsientosFecha(DateTime Fecha)
        {
            ListarAsientosFechaTableAdapter ListarAsientosTA = new ListarAsientosFechaTableAdapter();
            return ListarAsientosTA.GetData((DateTime?)Fecha);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarAsientosNumero(int NumeroAsiento)
        {
            return Adapter.GetDataBy((int?)NumeroAsiento);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarAsientosBusqueda(string Criterio, DateTime Fecha1, DateTime Fecha2, string Estado)
        {
            return Adapter.GetDataByBusqueda(Criterio, (DateTime?)Fecha1, (DateTime?)Fecha2, Estado);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarAsientosBusqueda(string Criterio, DateTime Fecha1, DateTime Fecha2)
        {
            return Adapter.GetDataByBusquedaTodos(Criterio, (DateTime?)Fecha1, (DateTime?)Fecha2);
        }

        /// <summary>
        /// Obtiene el ultimo asiento registrado
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public int ObtenerUltimoNumeroAsiento()
        {
            QTAFuncionesContabilidad UltimoNumero = new QTAFuncionesContabilidad();
            int? respuesta = 0;
            UltimoNumero.ObtenerUltimoNumeroAsiento(ref respuesta);

            if (respuesta == null)
                respuesta = 0;

            return (int)respuesta;
        }

        /// <summary>
        /// Determina si una fecha dada existe en el Detalle
        /// </summary>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool ExisteFecha(string Fecha)
        {
            QTAFuncionesContabilidad consulta = new QTAFuncionesContabilidad();
            DateTime? FechaHora = DateTime.Parse(Fecha);
            
            int? NumeroAsiento = 0;

            consulta.ObtenerFecha(FechaHora, ref NumeroAsiento);

            if (NumeroAsiento == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Determina si una fecha y estado dados existe en el Detalle
        /// </summary>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool ExisteFecha(string Fecha, string Estado)
        {
            QTAFuncionesContabilidad consulta = new QTAFuncionesContabilidad();
            DateTime? FechaHora = DateTime.Parse(Fecha);

            int? NumeroAsiento = 0;

            if (Estado != "Todos")
            {
                consulta.ObtenerFechaEstado(FechaHora, Estado, ref NumeroAsiento);

                if (NumeroAsiento == null)
                    return false;
                else
                    return true;
            }
            else
                return ExisteFecha(Fecha);            
        }


        public bool InsertarAsientoPorNumeroConfiguracion(int CodigoUsuario, int NumeroConfiguracion, string Glosa, List<decimal> Montos)
        {
            DSDoblones20Contabilidad.AsientosDataTable asientos = new DSDoblones20Contabilidad.AsientosDataTable();
            DSDoblones20Contabilidad.AsientosRow asiento = asientos.NewAsientosRow();

            asiento.CodigoUsuario = CodigoUsuario;
            asiento.Estado = "Pendiente";
            DateTime fecha = DateTime.Parse(new FuncionesContabilidad().FechaHora());
            asiento.Fecha = DateTime.Parse(fecha.ToShortDateString());
            asiento.Hora = DateTime.Parse(fecha.ToLongTimeString());
            asiento.Glosa = Glosa;

            asientos.AddAsientosRow(asiento);
            int rowsAffected = Adapter.Update(asientos);

            int numeroAsiento = ObtenerUltimoNumeroAsiento();

            CuentasConfiguracionCLN cc = new CuentasConfiguracionCLN();
            DataTable dtaux = cc.ListarPorNumero(NumeroConfiguracion);

            AsientosDetalleCLN asientoDetalle;

            int n = dtaux.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                asientoDetalle = new AsientosDetalleCLN();

                if (dtaux.Rows[i]["TipoCuentaDebeHaber"].ToString() == "D")
                    asientoDetalle.InsertarDetalleAsiento(numeroAsiento, dtaux.Rows[i]["NumeroCuentaConfiguracion"].ToString(), Montos[i], 0);
                else
                    asientoDetalle.InsertarDetalleAsiento(numeroAsiento, dtaux.Rows[i]["NumeroCuentaConfiguracion"].ToString(), 0, Montos[i]);
            }

            return rowsAffected == 1;
        }

    }
}

