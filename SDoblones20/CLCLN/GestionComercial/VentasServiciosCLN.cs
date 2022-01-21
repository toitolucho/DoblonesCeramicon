using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    public class VentasServiciosCLN
    {
        private VentasServiciosTableAdapter _VentasServiciosAdapter = null;
        protected VentasServiciosTableAdapter Adapter
        {
            get
            {
                if (_VentasServiciosAdapter == null)
                    _VentasServiciosAdapter = new VentasServiciosTableAdapter();
                return _VentasServiciosAdapter;
            }
        }

        public VentasServiciosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaServicio(int NumeroAgencia, int CodigoUsuario, string DIPersonaResponsable1, string DIPersonaResponsable2, string DIPersonaResponsable3, int CodigoCliente, DateTime? FechaHoraVentaServicio, DateTime? FechaHoraEntregaServicio, string CodigoEstadoServicio, string CodigoTipoServicio, decimal MontoTotal, int? NumeroFactura, int? NumeroCredito, byte CodigoMoneda, string Observaciones)
        {
            DSDoblones20GestionComercial2.VentasServiciosDataTable VentasServicios = new DSDoblones20GestionComercial2.VentasServiciosDataTable();
            DSDoblones20GestionComercial2.VentasServiciosRow VentaServicio = VentasServicios.NewVentasServiciosRow();

            VentaServicio.NumeroAgencia = NumeroAgencia;
            VentaServicio.CodigoUsuario = CodigoUsuario;
            VentaServicio.DIPersonaResponsable1 = DIPersonaResponsable1;
            if (String.IsNullOrEmpty(DIPersonaResponsable2)) VentaServicio.SetDIPersonaResponsable2Null();
            else VentaServicio.DIPersonaResponsable2 = DIPersonaResponsable2;
            if (String.IsNullOrEmpty(DIPersonaResponsable3)) VentaServicio.SetDIPersonaResponsable3Null();
            else VentaServicio.DIPersonaResponsable3 = DIPersonaResponsable3;
            VentaServicio.CodigoCliente = CodigoCliente;
            if (FechaHoraEntregaServicio == null) VentaServicio.SetFechaHoraEntregaServicioNull();
            else VentaServicio.FechaHoraEntregaServicio = FechaHoraEntregaServicio.Value;
            if (FechaHoraVentaServicio == null) VentaServicio.SetFechaHoraVentaServicioNull();
            else VentaServicio.FechaHoraVentaServicio = FechaHoraVentaServicio.Value;
            VentaServicio.CodigoEstadoServicio = CodigoEstadoServicio;
            VentaServicio.CodigoTipoServicio = CodigoTipoServicio;
            VentaServicio.MontoTotal = MontoTotal;
            if (NumeroFactura == null) VentaServicio.SetNumeroFacturaNull();
            else VentaServicio.NumeroFactura = NumeroFactura.Value;
            if (NumeroCredito == null) VentaServicio.SetNumeroCreditoNull();
            else VentaServicio.NumeroCredito = NumeroCredito.Value;
            VentaServicio.CodigoMoneda = CodigoMoneda;
            if (Observaciones == null) VentaServicio.SetObservacionesNull();
            VentaServicio.Observaciones = Observaciones;


            VentasServicios.AddVentasServiciosRow(VentaServicio);

            int rowsAffected = Adapter.Update(VentasServicios);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaServicio(int NumeroAgencia, int NumeroVentaServicio, int CodigoUsuario, string DIPersonaResponsable1, string DIPersonaResponsable2, string DIPersonaResponsable3, int CodigoCliente, DateTime? FechaHoraVentaServicio, DateTime? FechaHoraEntregaServicio, string CodigoEstadoServicio, string CodigoTipoServicio, decimal MontoTotal, int? NumeroFactura, int? NumeroCredito, byte CodigoMoneda, string Observaciones)
        {
            DSDoblones20GestionComercial2.VentasServiciosDataTable VentasServicios = Adapter.GetDataBy1(NumeroAgencia, NumeroVentaServicio);
            if (VentasServicios.Count == 0)
                return false;

            DSDoblones20GestionComercial2.VentasServiciosRow VentaServicio = VentasServicios[0];

            VentaServicio.NumeroAgencia = NumeroAgencia;
            VentaServicio.CodigoUsuario = CodigoUsuario;
            VentaServicio.DIPersonaResponsable1 = DIPersonaResponsable1;
            if (String.IsNullOrEmpty(DIPersonaResponsable2)) VentaServicio.SetDIPersonaResponsable2Null();
            else VentaServicio.DIPersonaResponsable2 = DIPersonaResponsable2;
            if (String.IsNullOrEmpty(DIPersonaResponsable3)) VentaServicio.SetDIPersonaResponsable3Null();
            else VentaServicio.DIPersonaResponsable3 = DIPersonaResponsable3;
            VentaServicio.CodigoCliente = CodigoCliente;
            if (FechaHoraEntregaServicio == null) VentaServicio.SetFechaHoraEntregaServicioNull();
            else VentaServicio.FechaHoraEntregaServicio = FechaHoraEntregaServicio.Value;
            if (FechaHoraVentaServicio == null) VentaServicio.SetFechaHoraVentaServicioNull();
            else VentaServicio.FechaHoraVentaServicio = FechaHoraVentaServicio.Value;
            VentaServicio.CodigoEstadoServicio = CodigoEstadoServicio;
            VentaServicio.CodigoTipoServicio = CodigoTipoServicio;
            VentaServicio.MontoTotal = MontoTotal;
            if (NumeroFactura == null) VentaServicio.SetNumeroFacturaNull();
            else VentaServicio.NumeroFactura = NumeroFactura.Value;
            if (NumeroCredito == null) VentaServicio.SetNumeroCreditoNull();
            else VentaServicio.NumeroCredito = NumeroCredito.Value;
            VentaServicio.CodigoMoneda = CodigoMoneda;
            if (Observaciones == null) VentaServicio.SetObservacionesNull();
            VentaServicio.Observaciones = Observaciones;
        
            int rowsAffected = Adapter.Update(VentaServicio);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaServicio(int NumeroAgencia, int NumeroVentaServicio)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroVentaServicio);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.VentasServiciosDataTable ListarVentasServicios()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.VentasServiciosDataTable ObtenerVentaServicio(int NumeroAgencia, int NumeroVentaServicio)
        {
            return Adapter.GetDataBy1(NumeroAgencia, NumeroVentaServicio);
        }

        public void ActualizarCodigoEstadoVentaServicio(int NumeroAgencia, int NumeroVentaServicio, string CodigoEstadoServicio)
        {
            QTAFuncionesGestionComercial AdapterFunciones = new QTAFuncionesGestionComercial();
            AdapterFunciones.ActualizarCodigoEstadoServicio(NumeroAgencia, NumeroVentaServicio, CodigoEstadoServicio);
        }

        public void InsertarVentaServicio(int NumeroAgencia, int CodigoUsuario, string DIPersonaResponsable1, string DIPersonaResponsable2, string DIPersonaResponsable3, int CodigoCliente, DateTime? FechaHoraVentaServicio, DateTime? FechaHoraEntregaServicio, string CodigoEstadoServicio, string CodigoTipoServicio, decimal MontoTotal, int? NumeroFactura, int? NumeroCredito, byte CodigoMoneda, string Observaciones, string ServiciosDetalle)
        {
            Adapter.InsertarVentaServicioXMLDetalle(NumeroAgencia, CodigoUsuario, DIPersonaResponsable1, DIPersonaResponsable2,
                DIPersonaResponsable3, CodigoCliente, FechaHoraVentaServicio, FechaHoraEntregaServicio,
                CodigoEstadoServicio, CodigoTipoServicio, MontoTotal,
                NumeroFactura, NumeroCredito, CodigoMoneda, Observaciones, ServiciosDetalle);
        }

        public void ActualizarVentaServicio(int NumeroAgencia, int NumeroVentaServicio, int CodigoUsuario, string DIPersonaResponsable1, string DIPersonaResponsable2, string DIPersonaResponsable3, int CodigoCliente, DateTime? FechaHoraVentaServicio, DateTime? FechaHoraEntregaServicio, string CodigoEstadoServicio, string CodigoTipoServicio, decimal MontoTotal, int? NumeroFactura, int? NumeroCredito, byte CodigoMoneda, string Observaciones, string ServiciosDetalle)
        {
            Adapter.ActualizarVentaServicioXMLDetalle(NumeroAgencia, NumeroVentaServicio, CodigoUsuario, DIPersonaResponsable1,
                DIPersonaResponsable2, DIPersonaResponsable3, CodigoCliente, FechaHoraVentaServicio,
                FechaHoraEntregaServicio, CodigoEstadoServicio, CodigoTipoServicio,
                MontoTotal, NumeroFactura, NumeroCredito,
                CodigoMoneda, Observaciones, ServiciosDetalle);
        }

        public DSDoblones20GestionComercial2.BuscarVentaServicioDataTable BuscarVentaServicio(string CodigoAmbitoBusqueda, string TextoABuscar, int? NumeroAgencia, int? NumeroTransaccion, string CodigoEstadoVentaServicio, DateTime FechaInicio, DateTime FechaFin, bool ExactamenteIgual)
        {
            int? numVentaServicio = null;
            if (NumeroTransaccion != -1)
            {
                numVentaServicio = NumeroTransaccion;
            }
            return new BuscarVentaServicioTableAdapter().GetData(CodigoAmbitoBusqueda, TextoABuscar, NumeroAgencia, numVentaServicio, CodigoEstadoVentaServicio, FechaInicio, FechaFin, ExactamenteIgual);
        }

    }
}
