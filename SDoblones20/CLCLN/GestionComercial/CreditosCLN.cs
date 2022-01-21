using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms; 
namespace CLCLN.GestionComercial
{
    [System.ComponentModel.DataObject]
    public class CreditosCLN
    {
        private CreditosTableAdapter _CreditosAdapter = null;
        protected CreditosTableAdapter Adapter
        {
            get
            {
                if (_CreditosAdapter == null)
                    _CreditosAdapter = new CreditosTableAdapter();
                return _CreditosAdapter;
            }
        }

        public CreditosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarCredito(string DIDeudor, string DIGarante1, string DIGarante2, string DIGarante3, string DIGarante4, string DIGarante5,
                                    string CodigoTipoCredito, int? NumeroAgenciaCotizacion, int? NumeroCotizacion,
                                    string CodigoSistemaAmortizacion, decimal MontoDeuda, byte CodigoMoneda, int CodigoFrecuenciaPago, int NumeroPeriodos,
                                    decimal InteresAnual, decimal? InteresAnualMora, DateTime FechaPrimerPago, DateTime FechaUltimoPago, decimal MontoDisponible, string Observaciones,
                                    bool RegistrarContabilidad,
                                    int NumeroAgenciaSolicitud, int CodigoUsuarioSolicitud, DateTime FechaHoraSolicitud,
                                    int? NumeroAgenciaAutorizacion, int? CodigoUsuarioAutorizacion, DateTime? FechaHoraAutorizacion,
                                    string CodigoAutorizacion, string CodigoEstadoCredito, ref int NumeroCredito)
        {
            DSDoblones20GestionComercial.CreditosDataTable Creditos = new DSDoblones20GestionComercial.CreditosDataTable();
            DSDoblones20GestionComercial.CreditosRow Credito = Creditos.NewCreditosRow();

            Credito.DIDeudor = DIDeudor;
            Credito.DIGarante1 = DIGarante1;
            if (DIGarante2 == null) Credito.SetDIGarante2Null();
            else Credito.DIGarante2 = DIGarante2;
            if (DIGarante3 == null) Credito.SetDIGarante3Null();
            else Credito.DIGarante3 = DIGarante3;
            if (DIGarante4 == null) Credito.SetDIGarante4Null();
            else Credito.DIGarante4 = DIGarante4;
            if (DIGarante5 == null) Credito.SetDIGarante5Null();
            else Credito.DIGarante5 = DIGarante5;
            Credito.CodigoTipoCredito = CodigoTipoCredito;
            if (NumeroAgenciaCotizacion == null) Credito.SetNumeroAgenciaCotizacionNull();
            else Credito.NumeroAgenciaCotizacion = NumeroAgenciaCotizacion.Value;
            if (NumeroCotizacion == null) Credito.SetNumeroCotizacionNull();
            else Credito.NumeroCotizacion = NumeroCotizacion.Value;
            Credito.CodigoSistemaAmortizacion = CodigoSistemaAmortizacion;
            Credito.MontoDeuda = MontoDeuda;
            Credito.CodigoMoneda = CodigoMoneda;
            Credito.CodigoFrecuenciaPago = CodigoFrecuenciaPago;
            Credito.NumeroPeriodos = NumeroPeriodos;
            Credito.InteresAnual = InteresAnual;
            if (InteresAnualMora == null) Credito.SetInteresAnualMoraNull();
            else Credito.InteresAnualMora = InteresAnualMora.Value;
            Credito.FechaPrimerPago = FechaPrimerPago;
            Credito.FechaUltimoPago = FechaUltimoPago;
            Credito.MontoDisponible = MontoDisponible;
            if (Observaciones == null) Credito.SetObservacionesNull();
            else Credito.Observaciones = Observaciones;
            Credito.RegistrarContabilidad = RegistrarContabilidad;
            Credito.NumeroAgenciaSolicitud = NumeroAgenciaSolicitud;
            Credito.CodigoUsuarioSolicitud = CodigoUsuarioSolicitud;
            Credito.FechaHoraSolicitud = FechaHoraSolicitud;
            if (NumeroAgenciaAutorizacion == null) Credito.SetNumeroAgenciaAutorizacionNull();
            else Credito.NumeroAgenciaAutorizacion = NumeroAgenciaAutorizacion.Value;
            if (CodigoUsuarioAutorizacion == null) Credito.SetCodigoUsuarioAutorizacionNull();
            else Credito.CodigoUsuarioAutorizacion = CodigoUsuarioAutorizacion.Value;
            if (FechaHoraAutorizacion == null) Credito.SetFechaHoraAutorizacionNull();
            else Credito.FechaHoraAutorizacion = FechaHoraAutorizacion.Value;
            if (CodigoAutorizacion == null) Credito.SetCodigoAutorizacionNull();
            else Credito.CodigoAutorizacion = CodigoAutorizacion;
            Credito.CodigoEstadoCredito = CodigoEstadoCredito;

            Creditos.AddCreditosRow(Credito);

            int rowsAffected = Adapter.Update(Creditos);
            //return rowsAffected == 1;

            if (rowsAffected > 0)
            {
                TransaccionesUtilidadesCLN TransaccionesUtilidades = new TransaccionesUtilidadesCLN();
                NumeroCredito = TransaccionesUtilidades.ObtenerUltimoIndiceTabla("Creditos");

                CreditosCuotasCLN cc = new CreditosCuotasCLN();
                cc.GenerarTablaAmortizaciones(NumeroCredito, CodigoSistemaAmortizacion, MontoDeuda, NumeroPeriodos, CodigoFrecuenciaPago, InteresAnual, FechaPrimerPago);
                
                return true;
            }
            else
                return false;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarCredito(int NumeroCredito, string DIDeudor, string DIGarante1, string DIGarante2, string DIGarante3, string DIGarante4, string DIGarante5,
                                    string CodigoTipoCredito, int? NumeroAgenciaCotizacion, int? NumeroCotizacion,
                                    string CodigoSistemaAmortizacion, decimal MontoDeuda, byte CodigoMoneda, int CodigoFrecuenciaPago, int NumeroPeriodos,
                                    decimal InteresAnual, decimal? InteresAnualMora, DateTime FechaPrimerPago, DateTime FechaUltimoPago, decimal MontoDisponible, string Observaciones,
                                    bool RegistrarContabilidad,
                                    int NumeroAgenciaSolicitud, int CodigoUsuarioSolicitud, DateTime FechaHoraSolicitud,
                                    int? NumeroAgenciaAutorizacion, int? CodigoUsuarioAutorizacion, DateTime? FechaHoraAutorizacion,
                                    string CodigoAutorizacion, string CodigoEstadoCredito)
        {
            DSDoblones20GestionComercial.CreditosDataTable Creditos = Adapter.GetDataBy(NumeroCredito);
            if (Creditos.Count == 0)
                return false;

            DSDoblones20GestionComercial.CreditosRow Credito = Creditos[0];

            Credito.DIDeudor = DIDeudor;
            Credito.DIGarante1 = DIGarante1;
            if (DIGarante2 == null) Credito.SetDIGarante2Null();
            else Credito.DIGarante2 = DIGarante2;
            if (DIGarante3 == null) Credito.SetDIGarante3Null();
            else Credito.DIGarante3 = DIGarante3;
            if (DIGarante4 == null) Credito.SetDIGarante4Null();
            else Credito.DIGarante4 = DIGarante4;
            if (DIGarante5 == null) Credito.SetDIGarante5Null();
            else Credito.DIGarante5 = DIGarante5;
            Credito.CodigoTipoCredito = CodigoTipoCredito;
            if (NumeroAgenciaCotizacion == null) Credito.SetNumeroAgenciaCotizacionNull();
            else Credito.NumeroAgenciaCotizacion = NumeroAgenciaCotizacion.Value;
            if (NumeroCotizacion == null) Credito.SetNumeroCotizacionNull();
            else Credito.NumeroCotizacion = NumeroCotizacion.Value;
            Credito.CodigoSistemaAmortizacion = CodigoSistemaAmortizacion;
            Credito.MontoDeuda = MontoDeuda;
            Credito.CodigoMoneda = CodigoMoneda;
            Credito.CodigoFrecuenciaPago = CodigoFrecuenciaPago;
            Credito.NumeroPeriodos = NumeroPeriodos;
            Credito.InteresAnual = InteresAnual;
            if (InteresAnualMora == null) Credito.SetInteresAnualMoraNull();
            else Credito.InteresAnualMora = InteresAnualMora.Value;
            Credito.FechaPrimerPago = FechaPrimerPago;
            Credito.FechaUltimoPago = FechaUltimoPago;
            Credito.MontoDisponible = MontoDisponible;
            if (Observaciones == null) Credito.SetObservacionesNull();
            else Credito.Observaciones = Observaciones;
            Credito.RegistrarContabilidad = RegistrarContabilidad;
            Credito.NumeroAgenciaSolicitud = NumeroAgenciaSolicitud;
            Credito.CodigoUsuarioSolicitud = CodigoUsuarioSolicitud;
            Credito.FechaHoraSolicitud = FechaHoraSolicitud;
            if (NumeroAgenciaAutorizacion == null) Credito.SetNumeroAgenciaAutorizacionNull();
            else Credito.NumeroAgenciaAutorizacion = NumeroAgenciaAutorizacion.Value;
            if (CodigoUsuarioAutorizacion == null) Credito.SetCodigoUsuarioAutorizacionNull();
            else Credito.CodigoUsuarioAutorizacion = CodigoUsuarioAutorizacion.Value;
            if (FechaHoraAutorizacion == null) Credito.SetFechaHoraAutorizacionNull();
            else Credito.FechaHoraAutorizacion = FechaHoraAutorizacion.Value;
            if (CodigoAutorizacion == null) Credito.SetCodigoAutorizacionNull();
            else Credito.CodigoAutorizacion = CodigoAutorizacion;
            Credito.CodigoEstadoCredito = CodigoEstadoCredito;

            int rowsAffected = Adapter.Update(Credito);
            CreditosCuotasCLN cc = new CreditosCuotasCLN();
            cc.GenerarTablaAmortizaciones(NumeroCredito, CodigoSistemaAmortizacion, MontoDeuda, NumeroPeriodos, CodigoFrecuenciaPago, InteresAnual, FechaPrimerPago);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCredito(int NumeroCredito)                           	                   	     
        {
            int rowsAffected = Adapter.Delete(NumeroCredito);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarCreditos()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerCredito(int NumeroCredito)
        {
            return Adapter.GetDataBy(NumeroCredito);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable BuscarCreditos(string CodigoAmbitoBusqueda, string TextoABuscar, bool ExactamenteIgual)
        {
            BuscarCreditosTableAdapter bcta = new BuscarCreditosTableAdapter();
            return bcta.GetDataBuscarCredito(CodigoAmbitoBusqueda, TextoABuscar, ExactamenteIgual);
        }
    }
}
