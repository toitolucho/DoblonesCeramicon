using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;
using CLCAD.DSDoblones20ContabilidadTableAdapters;


namespace CLCLN.GestionComercial
{
    public class DepositosBancariosCLN
    {
        #region Atributos de la Clase
        private DepositosBancariosTableAdapter _DepositosBancariosAdapter = null;
        protected DepositosBancariosTableAdapter Adapter
        {
            get
            {
                if (_DepositosBancariosAdapter == null)
                    _DepositosBancariosAdapter = new DepositosBancariosTableAdapter();
                return _DepositosBancariosAdapter;
            }
        }
        #endregion

        #region Constructor
        public DepositosBancariosCLN()
        {
            //constructor
        }

        #endregion

        #region Insertar, Actualizar, Eliminar, Listar y Obtener un Deposito Bancario
        /// <summary>
        /// Ingresas un Deposito Bancario
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroCuentaBanco"></param>
        /// <param name="Depositante"></param>
        /// <param name="Monto"></param>
        /// <param name="Fecha"></param>
        /// <param name="CodigoMoneda"></param>
        /// <param name="Observaciones"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarDepositoBancario(int NumeroAgencia, string NumeroCuentaBanco, string Depositante, decimal Monto, DateTime Fecha, byte CodigoMoneda, string Observaciones)
        {
            DSDoblones20Sistema.DepositosBancariosDataTable DepositosBancarios = new DSDoblones20Sistema.DepositosBancariosDataTable();
            DSDoblones20Sistema.DepositosBancariosRow depositoBancario = DepositosBancarios.NewDepositosBancariosRow();

            depositoBancario.NumeroAgencia = NumeroAgencia;
            depositoBancario.NumeroCuentaBanco = NumeroCuentaBanco;
            depositoBancario.Depositante = Depositante;
            depositoBancario.Monto = Monto;
            depositoBancario.Fecha = Fecha;
            depositoBancario.CodigoMoneda = CodigoMoneda;
            if (Observaciones == null)
                depositoBancario.SetObservacionesNull();
            else
                depositoBancario.Observaciones = Observaciones;

            DepositosBancarios.AddDepositosBancariosRow(depositoBancario);

            int rowsAffected = Adapter.Update(DepositosBancarios);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool ActualizarDepositoBancario(int NumeroAgencia, int NumeroDepositoBancario, string NumeroCuentaBanco, string Depositante, decimal Monto, DateTime Fecha, byte CodigoMoneda, string Observaciones)
        {
            DSDoblones20Sistema.DepositosBancariosDataTable DepositosBancarios = Adapter.GetDataBy(NumeroAgencia, NumeroDepositoBancario);
            if (DepositosBancarios.Count == 0)
                return false;
            DSDoblones20Sistema.DepositosBancariosRow depositoBancario = DepositosBancarios[0];

            depositoBancario.NumeroAgencia = NumeroAgencia;

            //depositoBancario.NumeroDepositoBancario = NumeroDepositoBancario;
            depositoBancario.NumeroCuentaBanco = NumeroCuentaBanco;
            depositoBancario.Depositante = Depositante;
            depositoBancario.Monto = Monto;
            depositoBancario.Fecha = Fecha;
            depositoBancario.CodigoMoneda = CodigoMoneda;
            if (Observaciones == null)
                depositoBancario.SetObservacionesNull();
            else
                depositoBancario.Observaciones = Observaciones;


            DepositosBancarios.AddDepositosBancariosRow(depositoBancario);

            int rowsAffected = Adapter.Update(depositoBancario);
            return rowsAffected == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarDepositoBancario(int NumeroAgencia, int NumeroDepositoBancario)
        {
            QTAFuncionesSistema MiAdapter = new QTAFuncionesSistema();
              
            //int rowsAffedted = MiAdapter.Delete(NumeroAgencia, NumeroDepositoBancario);
            int rowsAffedted = MiAdapter.EliminarDepositoBancario(NumeroAgencia, NumeroDepositoBancario);
            return rowsAffedted == 1;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarDepositosBancarios()
        {
            return Adapter.GetData();
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarDepositosBancariosPorFecha(string Fecha)
        {
            DateTime? FechaDeposito = DateTime.Parse(Fecha);
            ListarDepositosBancariosPorFechaTableAdapter MiAdapter=new ListarDepositosBancariosPorFechaTableAdapter ();
            return MiAdapter.GetData(FechaDeposito);
        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerDepositoBancario(int NumeroAgencia, int NumeroDepositoBancario)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroDepositoBancario);

        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public int ObtenerUltimoDepositoBancario()
        {
            QTAFuncionesSistema UltimoDeposito = new QTAFuncionesSistema();
            decimal? resultado = 0;
            UltimoDeposito.ObtenerUltimoIndiceTabla("DepositosBancarios", ref resultado);
            return (int)resultado;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarFechasDepositosBancarios()
        {
            ListarFechasDepositosBancariosTableAdapter FechasDepositos = new ListarFechasDepositosBancariosTableAdapter();
            return FechasDepositos.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerDepositoBancarioDetalle(int NumeroDeposito, int NumeroAgencia)
        {
            ObtenerDepositosBancariosReporteTableAdapter Deposito = new ObtenerDepositosBancariosReporteTableAdapter();
            return Deposito.GetData(NumeroAgencia, NumeroDeposito);
        }

        #endregion
    }
}
