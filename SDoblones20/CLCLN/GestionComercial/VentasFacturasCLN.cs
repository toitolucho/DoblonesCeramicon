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
    [System.ComponentModel.DataObject]
    public class VentasFacturasCLN
    {
        private VentasFacturasTableAdapter _VentasFacturasAdapter = null;
        protected VentasFacturasTableAdapter Adapter
        {
            get
            {
                if (_VentasFacturasAdapter == null)
                    _VentasFacturasAdapter = new VentasFacturasTableAdapter();
                return _VentasFacturasAdapter;
            }
        }

        public VentasFacturasCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        //public bool InsertarVentaFactura(int NumeroAgencia, int NumeroFactura, string NombreFactura, DateTime FechaHoraFactura)
        //{
        //    DSDoblones20GestionComercial.VentasFacturasDataTable VentasFacturas = new DSDoblones20GestionComercial.VentasFacturasDataTable();
        //    DSDoblones20GestionComercial.VentasFacturasRow VentaFactura = VentasFacturas.NewVentasFacturasRow();

        //    VentaFactura.NumeroAgencia = NumeroAgencia;
        //    VentaFactura.NumeroFactura = NumeroFactura;
        //    VentaFactura.NombreFactura = NombreFactura;
        //    VentaFactura.FechaHoraFactura = FechaHoraFactura;

        //    VentasFacturas.AddVentasFacturasRow(VentaFactura);

        //    int rowsAffected = Adapter.Update(VentasFacturas);
        //    return rowsAffected == 1;
        //}


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarVentaFactura(int NumeroAgencia, int NumeroFactura, string NombreFactura, string NITFactura, DateTime FechaHoraFactura)
        {
            DSDoblones20GestionComercial.VentasFacturasDataTable VentasFacturas = new DSDoblones20GestionComercial.VentasFacturasDataTable();
            DSDoblones20GestionComercial.VentasFacturasRow VentaFactura = VentasFacturas.NewVentasFacturasRow();

            VentaFactura.NumeroAgencia = NumeroAgencia;
            VentaFactura.NumeroFactura = NumeroFactura;
            VentaFactura.NombreFactura = NombreFactura;
            VentaFactura.FechaHoraFactura = FechaHoraFactura;
            VentaFactura.NITFactura = NITFactura;

            VentasFacturas.AddVentasFacturasRow(VentaFactura);

            int rowsAffected = Adapter.Update(VentasFacturas);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarVentaFactura(int NumeroAgencia, int NumeroFactura, string NombreFactura, DateTime FechaHoraFactura)
        {
            DSDoblones20GestionComercial.VentasFacturasDataTable VentasFacturas = Adapter.GetDataBy(NumeroAgencia, NumeroFactura);
            if (VentasFacturas.Count == 0)
                return false;

            DSDoblones20GestionComercial.VentasFacturasRow VentaFactura = VentasFacturas[0];

                VentaFactura.NumeroAgencia = NumeroAgencia;
            VentaFactura.NumeroFactura = NumeroFactura;
            VentaFactura.NombreFactura = NombreFactura;
            VentaFactura.FechaHoraFactura = FechaHoraFactura;          

            int rowsAffected = Adapter.Update(VentaFactura);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarVentaFactura(int NumeroAgencia, int NumeroFactura)
        {
            int rowsAffected = Adapter.Delete(NumeroAgencia, NumeroFactura);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarVentasFacturas()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerVentaFactura(int NumeroAgencia, int NumeroFactura)
        {
            return Adapter.GetDataBy(NumeroAgencia, NumeroFactura);
        }
    }
}
