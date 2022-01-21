using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20SistemaTableAdapters;
using CLCAD;
using System.Data;

using System.Data.SqlClient;

namespace CLCLN.Sistema
{
    [System.ComponentModel.DataObject]
    public class PersonasCLN
    {
        private PersonasTableAdapter _PersonasAdapter = null;
        protected PersonasTableAdapter Adapter
        {
            get
            {
                if (_PersonasAdapter == null)
                    _PersonasAdapter = new PersonasTableAdapter();
                return _PersonasAdapter;
            }
        }

        public PersonasCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarPersona(string DIPersona, string Paterno, string Materno, string Nombres, DateTime FechaNacimiento, string Sexo, string Celular, string Email, string CodigoPaisD, string CodigoDepartamentoD, string CodigoProvinciaD, string CodigoLugarD, string DireccionD, string TelefonoD, string RutaArchivoHuellaDactilar, string RutaArchivoFotografia, string RutaArchivoFirma, string Observaciones)		
        {
            DSDoblones20Sistema.PersonasDataTable Personas = new DSDoblones20Sistema.PersonasDataTable();
            DSDoblones20Sistema.PersonasRow Persona = Personas.NewPersonasRow();

            Persona.DIPersona = DIPersona;
            if (Paterno == null) Persona.SetPaternoNull();
            else Persona.Paterno = Paterno;
            if (Materno == null) Persona.SetMaternoNull();
            else Persona.Materno = Materno;
            Persona.Nombres = Nombres;
            if (FechaNacimiento == null) Persona.SetFechaNacimientoNull();
            else Persona.FechaNacimiento = FechaNacimiento;
            Persona.Sexo = Sexo;
            if (Celular == null) Persona.SetCelularNull();
            else Persona.Celular = Celular;
            if (Email == null) Persona.SetEmailNull();
            else Persona.Email = Email;
            if (CodigoPaisD == null) Persona.SetCodigoPaisDNull();
            else Persona.CodigoPaisD = CodigoPaisD;
            if (CodigoDepartamentoD == null) Persona.SetCodigoDepartamentoDNull();
            else Persona.CodigoDepartamentoD = CodigoDepartamentoD;
            if (CodigoProvinciaD == null) Persona.SetCodigoProvinciaDNull();
            else Persona.CodigoProvinciaD = CodigoProvinciaD;
            if (CodigoLugarD == null) Persona.SetCodigoLugarDNull();
            else Persona.CodigoLugarD = CodigoLugarD;
            if (DireccionD == null) Persona.SetDireccionDNull();
            else Persona.DireccionD = DireccionD;
            if (TelefonoD == null) Persona.SetTelefonoDNull();
            else Persona.TelefonoD = TelefonoD;
            if (RutaArchivoHuellaDactilar == null) Persona.SetRutaArchivoHuellaDactilarNull();
            else Persona.RutaArchivoHuellaDactilar = RutaArchivoHuellaDactilar;
            if (RutaArchivoFotografia == null) Persona.SetRutaArchivoFotografiaNull();
            else Persona.RutaArchivoFotografia = RutaArchivoFotografia;
            if (RutaArchivoFirma == null) Persona.SetRutaArchivoFirmaNull();
            else Persona.RutaArchivoFirma = RutaArchivoFirma;
            if (Observaciones == null) Persona.SetObservacionesNull();
            else Persona.Observaciones = Observaciones;
                                          
            Personas.AddPersonasRow(Persona);

            int rowsAffected = Adapter.Update(Personas);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarPersona(string DIPersona, string Paterno, string Materno, string Nombres, DateTime FechaNacimiento, string Sexo, string Celular, string Email, string CodigoPaisD, string CodigoDepartamentoD, string CodigoProvinciaD, string CodigoLugarD, string DireccionD, string TelefonoD, string RutaArchivoHuellaDactilar, string RutaArchivoFotografia, string RutaArchivoFirma, string Observaciones)		
        {
            DSDoblones20Sistema.PersonasDataTable Personas = Adapter.GetDataBy(DIPersona);
            if (Personas.Count == 0)
                return false;

            DSDoblones20Sistema.PersonasRow Persona = Personas[0];

            Persona.DIPersona = DIPersona;
            if (Paterno == null) Persona.SetPaternoNull();
            else Persona.Paterno = Paterno;
            if (Materno == null) Persona.SetMaternoNull();
            else Persona.Materno = Materno;
            Persona.Nombres = Nombres;
            if (FechaNacimiento == null) Persona.SetFechaNacimientoNull();
            else Persona.FechaNacimiento = FechaNacimiento;
            Persona.Sexo = Sexo;
            if (Celular == null) Persona.SetCelularNull();
            else Persona.Celular = Celular;
            if (Email == null) Persona.SetEmailNull();
            else Persona.Email = Email;
            if (CodigoPaisD == null) Persona.SetCodigoPaisDNull();
            else Persona.CodigoPaisD = CodigoPaisD;
            if (CodigoDepartamentoD == null) Persona.SetCodigoDepartamentoDNull();
            else Persona.CodigoDepartamentoD = CodigoDepartamentoD;
            if (CodigoProvinciaD == null) Persona.SetCodigoProvinciaDNull();
            else Persona.CodigoProvinciaD = CodigoProvinciaD;
            if (CodigoLugarD == null) Persona.SetCodigoLugarDNull();
            else Persona.CodigoLugarD = CodigoLugarD;
            if (DireccionD == null) Persona.SetDireccionDNull();
            else Persona.DireccionD = DireccionD;
            if (TelefonoD == null) Persona.SetTelefonoDNull();
            else Persona.TelefonoD = TelefonoD;
            if (RutaArchivoHuellaDactilar == null) Persona.SetRutaArchivoHuellaDactilarNull();
            else Persona.RutaArchivoHuellaDactilar = RutaArchivoHuellaDactilar;
            if (RutaArchivoFotografia == null) Persona.SetRutaArchivoFotografiaNull();
            else Persona.RutaArchivoFotografia = RutaArchivoFotografia;
            if (RutaArchivoFirma == null) Persona.SetRutaArchivoFirmaNull();
            else Persona.RutaArchivoFirma = RutaArchivoFirma;
            if (Observaciones == null) Persona.SetObservacionesNull();
            else Persona.Observaciones = Observaciones;

            int rowsAffected = Adapter.Update(Persona);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarPersona(string DIPersona)                           	                   	     
        {
            int rowsAffected = Adapter.Delete(DIPersona);
            return rowsAffected == 1;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPersonas()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerPersona(string DIPersona)
        {
            return Adapter.GetDataBy(DIPersona);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable BuscarPersonas(string CodigoAmbitoBusqueda, string TextoABuscar, bool ExactamenteIgual)
        {
            return Adapter.GetDataByBuscarPersonas(CodigoAmbitoBusqueda, TextoABuscar, ExactamenteIgual);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public string ObtenerNombreCompleto(string DIPersona)
        {
            QTAFuncionesSistema foncp = new QTAFuncionesSistema();
            return foncp.ObtenerNombreCompletoPersona(DIPersona);
        }
    }
}
