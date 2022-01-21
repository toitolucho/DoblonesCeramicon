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
    public class ConfiguracionesTransaccionesCuentasCLN
    {
        private ConfiguracionesCuentasTableAdapter _ConfiguracionesCuentasTableAdapter = null;
        protected ConfiguracionesCuentasTableAdapter Adapter
        {
            get
            {
                if (_ConfiguracionesCuentasTableAdapter == null)
                    _ConfiguracionesCuentasTableAdapter = new ConfiguracionesCuentasTableAdapter();
                return _ConfiguracionesCuentasTableAdapter;
            }
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarConfiguracionesTransaccionesCuentas(string Nombre, string CodigoTipoTransaccion, string CodigoTipoMovimiento, string Descripcion)
        {
            DSDoblones20Contabilidad.ConfiguracionesCuentasDataTable cuentas = new DSDoblones20Contabilidad.ConfiguracionesCuentasDataTable();
            DSDoblones20Contabilidad.ConfiguracionesCuentasRow cuenta = cuentas.NewConfiguracionesCuentasRow();

            cuenta.NombreConfiguracion = Nombre;
            cuenta.DescripcionConfiguracion = Descripcion;
            cuenta.CodigoTipoMovimiento = CodigoTipoMovimiento;
            cuenta.CodigoTipoTransaccion = CodigoTipoTransaccion;
            

            cuentas.AddConfiguracionesCuentasRow(cuenta);
            return Adapter.Update(cuentas) == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarConfiguracionesTransaccionesCuentas(int Numero, string Nombre, string CodigoTipoTransaccion, string CodigoTipoMovimiento, string Descripcion)
        {
            return Adapter.Update((int?)Numero, Nombre, CodigoTipoTransaccion, CodigoTipoMovimiento, Descripcion) == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarConfiguracionesTransaccionesCuentas(int Numero)
        {
            return Adapter.Delete((int?)Numero) == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarConfiguracionesTransaccionesCuentas()
        {
            return Adapter.GetData();
        }

    }
}
