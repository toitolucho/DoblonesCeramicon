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
    public class PlanCuentasCLN
    {
        private PlanCuentasTableAdapter _PlanCuentasTableAdapter = null;
        protected PlanCuentasTableAdapter Adapter
        {
            get
            {
                if (_PlanCuentasTableAdapter == null)
                    _PlanCuentasTableAdapter = new PlanCuentasTableAdapter();
                return _PlanCuentasTableAdapter;
            }
        }

        public PlanCuentasCLN()
        { }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarPlanCuentas(string NumCuenta, string NomCuenta, string NumCuentaPadre, byte Niv, string Desc)
        {
            DSDoblones20Contabilidad.PlanCuentasDataTable cuentas = new DSDoblones20Contabilidad.PlanCuentasDataTable();
            DSDoblones20Contabilidad.PlanCuentasRow cuenta = cuentas.NewPlanCuentasRow();

            cuenta.DescripcionCuenta = Desc;
            cuenta.NivelCuenta = Niv;
            cuenta.NombreCuenta = NomCuenta;
            cuenta.NumeroCuenta = NumCuenta;
            if (NumCuentaPadre == string.Empty)
            {
                cuenta.SetNumeroCuentaPadreNull();
            }
            else
                cuenta.NumeroCuentaPadre = NumCuentaPadre;

            cuentas.AddPlanCuentasRow(cuenta);

            int rowsAffected = Adapter.Update(cuenta);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarPlanCuentas(string NumCuenta, string NomCuenta, string NumCuentaPadre, byte Niv, string Desc)
        {
            DSDoblones20Contabilidad.PlanCuentasDataTable cuentas = Adapter.GetDataByNumeroCuenta(NumCuenta);
            DSDoblones20Contabilidad.PlanCuentasRow cuenta = cuentas[0];

            cuenta.DescripcionCuenta = Desc;
            cuenta.NivelCuenta = Niv;
            cuenta.NombreCuenta = NomCuenta;
            if (NumCuentaPadre == string.Empty)
            {
                cuenta.SetNumeroCuentaPadreNull();
            }
            else
                cuenta.NumeroCuentaPadre = NumCuentaPadre;

            int rowsAffected = Adapter.Update(cuenta);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarCuenta(string NumCuenta)
        {
            int rowsAffected = Adapter.Delete(NumCuenta);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPlanCuentas()
        {
            return Adapter.GetData();
        }

        /// <summary>
        /// Lista todas las cuentas de nivel 5
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPlanCuentasSimple()
        {
            ListarPlanCuentasSimpleTableAdapter ListarPlanCuentasTA = new ListarPlanCuentasSimpleTableAdapter();
            return ListarPlanCuentasTA.GetData();
        }

        /// <summary>
        /// Lista todas las cuentas Activo, Pasivo y Capital de nivel 5
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPlanCuentasSimpleAPC()
        {
            ListarPlanCuentasSimpleAPCTableAdapter ListarPlanCuentasTA = new ListarPlanCuentasSimpleAPCTableAdapter();
            return ListarPlanCuentasTA.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPlanCuentasActivo()
        {
            ListarPlanCuentasActivoTableAdapter miadapter = new ListarPlanCuentasActivoTableAdapter();
            return miadapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPlanCuentasPasivoCapital()
        {
            ListarPlanCuentasPasivoCapitalTableAdapter miadapter = new ListarPlanCuentasPasivoCapitalTableAdapter();
            return miadapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPlanCuentasIngreso()
        {
            ListarPlanCuentasIngresoTableAdapter miadapter = new ListarPlanCuentasIngresoTableAdapter();
            return miadapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPlanCuentasEgreso()
        {
            ListarPlanCuentasEgresoTableAdapter miadapter = new ListarPlanCuentasEgresoTableAdapter();
            return miadapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPlanCuentasNivel(byte nivel)
        {
            ListarPlanCuentasNivelTableAdapter miadapter = new ListarPlanCuentasNivelTableAdapter();
            return miadapter.GetData(nivel);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPlanCuentasPadre()
        {
            ListarPlanCuentasPadreTableAdapter miadapter = new ListarPlanCuentasPadreTableAdapter();
            return miadapter.GetData();
        }

    }
}
