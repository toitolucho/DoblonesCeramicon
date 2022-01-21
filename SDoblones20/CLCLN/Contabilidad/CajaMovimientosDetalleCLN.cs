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
    public class CajaMovimientosDetalleCLN
    {
        private CajaMovimientosDetalleTableAdapter _CajaMovimientosDetalleTableAdapter = null;
        protected CajaMovimientosDetalleTableAdapter Adapter
        {
            get
            {
                if (_CajaMovimientosDetalleTableAdapter == null)
                    _CajaMovimientosDetalleTableAdapter = new CajaMovimientosDetalleTableAdapter();
                return _CajaMovimientosDetalleTableAdapter;
            }
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool Insertar(int NumeroMovimiento, string NumeroCuenta, int Cantidad, string NumeroSerie)
        {
            DSDoblones20Contabilidad.CajaMovimientosDetalleDataTable Movimientos = new DSDoblones20Contabilidad.CajaMovimientosDetalleDataTable();
            DSDoblones20Contabilidad.CajaMovimientosDetalleRow movimiento = Movimientos.NewCajaMovimientosDetalleRow();

            movimiento.NumeroMovimiento = NumeroMovimiento;
            movimiento.Cantidad = Cantidad;
            movimiento.NumeroCuentaDeposito = NumeroCuenta;
            movimiento.NumeroSerie = NumeroSerie;

            Movimientos.AddCajaMovimientosDetalleRow(movimiento);

            int rowsAffected = Adapter.Update(movimiento);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool Eliminar(int NumeroMovimiento)
        {
            int rowsAffected = Adapter.Delete(NumeroMovimiento);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable Listar(int NumeroMovimiento)
        {
            return Adapter.GetDataByNumero(NumeroMovimiento);
        }
    }

}
