using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;


namespace CLCLN.GestionComercial
{
    public class ComprasProductosEspecificosReemDevoCambiosCLN
    {
        //#region Atributos de la Clase
        //private ComprasProductosEspecificosReemDevoCambiosTableAdapter _ComprasProductosEspecificosReemDevoCambiosAdapter = null;
        //protected ComprasProductosEspecificosReemDevoCambiosTableAdapter Adapter
        //{
        //    get
        //    {
        //        if (_ComprasProductosEspecificosReemDevoCambiosAdapter == null)
        //            _ComprasProductosEspecificosReemDevoCambiosAdapter = new ComprasProductosEspecificosReemDevoCambiosTableAdapter();
        //        return _ComprasProductosEspecificosReemDevoCambiosAdapter;
        //    }
        //}
        //#endregion

        //#region Constructor
        //public ComprasProductosEspecificosReemDevoCambiosCLN()
        //{
        //    //constructor
        //}

        //#endregion


        ///// <summary>
        ///// Insertar una BancoCuenta dentro del Sistema
        ///// </summary>
        ///// <param name="NombreBancoCuenta"> Nombre de la BancoCuenta</param>
        ///// <param name="CodigoPais">Codigo del Pais donde se encuentra</param>
        ///// <param name="CodigoDepartamento"> Codigo del Departamento donde se encuentra</param>
        ///// <param name="CodigoProvincia">Codigo de Provincia</param>
        ///// <param name="CodigoLugar">Código del SistemaInteraz</param>
        ///// <param name="DIResponsable">Persona Responsable de la BancoCuenta</param>
        ///// <returns>Retorna True si se realizo correctamente la transacción de Insertado</returns>
        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        //public bool InsertarCompraProductoEspecificoReemDevoCambio(int NumeroAgencia,int NumeroReemDevo, int CodigoMotivoReemDevo, string CodigoProducto, string CodigoProductoEspeDevo, string CodigoProductoEspeCambio,int TiempoGarantiaPE, DateTime FechaHoraVencimientoPE, decimal PrecioUnitarioPECambio, decimal MontoDevolucion, string CodigoTipoReemDevo,DateTime FechaHoraReemDevoCambio, string ObservacionesReemDevoCambio)
        //{
        //    DSDoblones20.ComprasProductosEspecificosReemDevoCambiosDataTable ComprasProductosEspecificosReemDevoCambios = new DSDoblones20.ComprasProductosEspecificosReemDevoCambiosDataTable();
        //    DSDoblones20.ComprasProductosEspecificosReemDevoCambiosRow compraProductoEspecificoReemDevoCambio = ComprasProductosEspecificosReemDevoCambios.NewComprasProductosEspecificosReemDevoCambiosRow();

        //    compraProductoEspecificoReemDevoCambio.NumeroAgencia = NumeroAgencia;
        //    compraProductoEspecificoReemDevoCambio.NumeroReemDevo = NumeroReemDevo;
        //    compraProductoEspecificoReemDevoCambio.CodigoMotivoReemDevo = CodigoMotivoReemDevo;
        //    compraProductoEspecificoReemDevoCambio.CodigoProducto = CodigoProducto;
        //    compraProductoEspecificoReemDevoCambio.CodigoProductoEspeDevo = CodigoProductoEspeDevo;
        //    compraProductoEspecificoReemDevoCambio.CodigoProductoEspeCambio = CodigoProductoEspeCambio;
        //    if (TiempoGarantiaPE == null)
        //        compraProductoEspecificoReemDevoCambio.SetTiempoGarantiaPENull();
        //    else
        //        compraProductoEspecificoReemDevoCambio.TiempoGarantiaPE = TiempoGarantiaPE;
        //    if (FechaHoraVencimientoPE == null)
        //        compraProductoEspecificoReemDevoCambio.SetFechaHoraVencimientoPENull();
        //    else
        //        compraProductoEspecificoReemDevoCambio.FechaHoraVencimientoPE = FechaHoraVencimientoPE;
        //    if (PrecioUnitarioPECambio == null)
        //        compraProductoEspecificoReemDevoCambio.SetPrecioUnitarioPECambioNull();
        //    else
        //        compraProductoEspecificoReemDevoCambio.PrecioUnitarioPECambio = PrecioUnitarioPECambio;
        //    compraProductoEspecificoReemDevoCambio.MontoDevolucion = MontoDevolucion;
        //    compraProductoEspecificoReemDevoCambio.CodigoTipoReemDevo = CodigoTipoReemDevo;
        //    compraProductoEspecificoReemDevoCambio.FechaHoraReemDevoCambio = FechaHoraReemDevoCambio;
        //    compraProductoEspecificoReemDevoCambio.ObservacionesReemDevoCambio = ObservacionesReemDevoCambio;


        //    ComprasProductosEspecificosReemDevoCambios.AddComprasProductosEspecificosReemDevoCambiosRow(compraProductoEspecificoReemDevoCambio);

        //    int rowsAffected = Adapter.Update(ComprasProductosEspecificosReemDevoCambios);
        //    return rowsAffected == 1;
        //}

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        //public bool ActualizarCompraProductoEspecificoReemDevoCambio(int NumeroAgencia, int NumeroReemDevo, int CodigoMotivoReemDevo, string CodigoProducto, string CodigoProductoEspeDevo, string CodigoProductoEspeCambio, int TiempoGarantiaPE, DateTime FechaHoraVencimientoPE, decimal PrecioUnitarioPECambio, decimal MontoDevolucion, string CodigoTipoReemDevo, DateTime FechaHoraReemDevoCambio, string ObservacionesReemDevoCambio)
        //{
        //    DSDoblones20.ComprasProductosEspecificosReemDevoCambiosDataTable ComprasProductosEspecificosReemDevoCambios = Adapter.GetlObtenerCompraProductoEspecificoReemDevoCambio(NumeroAgencia, NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo, CodigoProductoEspeCambio);
        //    if (ComprasProductosEspecificosReemDevoCambios.Count == 0)
        //        return false;
        //    DSDoblones20.ComprasProductosEspecificosReemDevoCambiosRow compraProductoEspecificoReemDevoCambio = ComprasProductosEspecificosReemDevoCambios[0];

        //    compraProductoEspecificoReemDevoCambio.NumeroAgencia = NumeroAgencia;
        //    compraProductoEspecificoReemDevoCambio.NumeroReemDevo = NumeroReemDevo;
        //    compraProductoEspecificoReemDevoCambio.CodigoMotivoReemDevo = CodigoMotivoReemDevo;
        //    compraProductoEspecificoReemDevoCambio.CodigoProducto = CodigoProducto;
        //    compraProductoEspecificoReemDevoCambio.CodigoProductoEspeDevo = CodigoProductoEspeDevo;
        //    compraProductoEspecificoReemDevoCambio.CodigoProductoEspeCambio = CodigoProductoEspeCambio;
        //    if (TiempoGarantiaPE == null)
        //        compraProductoEspecificoReemDevoCambio.SetTiempoGarantiaPENull();
        //    else
        //        compraProductoEspecificoReemDevoCambio.TiempoGarantiaPE = TiempoGarantiaPE;
        //    if (FechaHoraVencimientoPE == null)
        //        compraProductoEspecificoReemDevoCambio.SetFechaHoraVencimientoPENull();
        //    else
        //        compraProductoEspecificoReemDevoCambio.FechaHoraVencimientoPE = FechaHoraVencimientoPE;
        //    if (PrecioUnitarioPECambio == null)
        //        compraProductoEspecificoReemDevoCambio.SetPrecioUnitarioPECambioNull();
        //    else
        //        compraProductoEspecificoReemDevoCambio.PrecioUnitarioPECambio = PrecioUnitarioPECambio;
        //    compraProductoEspecificoReemDevoCambio.MontoDevolucion = MontoDevolucion;
        //    compraProductoEspecificoReemDevoCambio.CodigoTipoReemDevo = CodigoTipoReemDevo;
        //    compraProductoEspecificoReemDevoCambio.FechaHoraReemDevoCambio = FechaHoraReemDevoCambio;
        //    compraProductoEspecificoReemDevoCambio.ObservacionesReemDevoCambio = ObservacionesReemDevoCambio;
            


        //    ComprasProductosEspecificosReemDevoCambios.AddComprasProductosEspecificosReemDevoCambiosRow(compraProductoEspecificoReemDevoCambio);

        //    int rowsAffected = Adapter.Update(compraProductoEspecificoReemDevoCambio);
        //    return rowsAffected == 1;
        //}


        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        //public bool EliminarCompraProductoEspecificoReemDevoCambio(int NumeroAgencia, int NumeroReemDevo, int CodigoMotivoReemDevo, string CodigoProducto, string CodigoProductoEspeDevo, string CodigoProductoEspeCambio)
        //{
        //    int rowsAffedted = Adapter.Delete(NumeroAgencia, NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto,CodigoProductoEspeDevo, CodigoProductoEspeCambio);
        //    return rowsAffedted == 1;
        //}


        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DataTable ListarComprasProductosEspecificosReemDevoCambios()
        //{
        //    return Adapter.GetData(); 
        //}



        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DataTable ObtenerCompraProductoEspecificoReemDevoCambio(int NumeroAgencia, int NumeroReemDevo, int CodigoMotivoReemDevo, string CodigoProducto, string CodigoProductoEspeDevo, string CodigoProductoEspeCambio)
        //{
        //    return Adapter.GetlObtenerCompraProductoEspecificoReemDevoCambio(NumeroAgencia, NumeroReemDevo, CodigoMotivoReemDevo, CodigoProducto, CodigoProductoEspeDevo, CodigoProductoEspeCambio);
            
        //}


        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public DataTable ObtenerComprasProductosEspecificosReemDevoCambios()
        //{
        //    return Adapter.GetObtenerComprasProductosEspecificosReemDevoCambios();
        //} 
    }
}
