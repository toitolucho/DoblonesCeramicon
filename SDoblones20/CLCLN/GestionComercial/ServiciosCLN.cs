using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD;
using System.Data;
using System.Data.SqlClient;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;

namespace CLCLN.GestionComercial
{
    public class ServiciosCLN
    {
        private ServiciosTableAdapter _ServiciosAdapter = null;
        protected ServiciosTableAdapter Adapter
        {
            get
            {
                if (_ServiciosAdapter == null)
                    _ServiciosAdapter = new ServiciosTableAdapter();
                return _ServiciosAdapter;
            }
        }

        public ServiciosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarServicio(string NombreServicio, string CodigoTipoServicio, decimal PrecioUnitario, string Descripcion)
        {
            DSDoblones20GestionComercial2.ServiciosDataTable Servicios = new DSDoblones20GestionComercial2.ServiciosDataTable();
            DSDoblones20GestionComercial2.ServiciosRow Servicio = Servicios.NewServiciosRow();

            Servicio.NombreServicio = NombreServicio;
            Servicio.CodigoTipoServicio = CodigoTipoServicio;
            Servicio.PrecioUnitario = PrecioUnitario;
            if (Descripcion == null) Servicio.SetDescripcionNull();
            else Servicio.Descripcion = Descripcion;            
            
            Servicios.AddServiciosRow(Servicio);

            int rowsAffected = Adapter.Update(Servicios);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarServicio(int CodigoServicio, string NombreServicio, string CodigoTipoServicio, decimal PrecioUnitario, string Descripcion)
        {
            DSDoblones20GestionComercial2.ServiciosDataTable Servicios = Adapter.GetDataBy(CodigoServicio);
            if (Servicios.Count == 0)
                return false;

            DSDoblones20GestionComercial2.ServiciosRow Servicio = Servicios[0];

            Servicio.NombreServicio = NombreServicio;
            Servicio.CodigoTipoServicio = CodigoTipoServicio;
            Servicio.PrecioUnitario = PrecioUnitario;
            if (Descripcion == null) Servicio.SetDescripcionNull();
            else Servicio.Descripcion = Descripcion;

            int rowsAffected = Adapter.Update(Servicio);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarServicio(int CodigoServicio)
        {
            int rowsAffected = Adapter.Delete(CodigoServicio);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.ServiciosDataTable ListarServicios()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.ServiciosDataTable ObtenerServicio(int CodigoServicio)
        {
            return Adapter.GetDataBy(CodigoServicio);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.ServiciosDataTable BuscarServicios(string CodigoAmbitoBusqueda, string TextoABuscar, bool ExactamenteIgual)
        {
            //return Adapter.GetDataByBuscarServicios(CodigoAmbitoBusqueda, TextoABuscar, ExactamenteIgual);
            return null;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DSDoblones20GestionComercial2.ServiciosDataTable ListarServiciosReporte()
        {
            return Adapter.GetDataByReporte();
        }        
    }
}
