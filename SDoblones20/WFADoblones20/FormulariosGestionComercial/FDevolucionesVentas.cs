using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FDevolucionesVentas : Form
    {
        private string NombreUsuario;
        private int Codigousuario;
        private int NumeroAgencia;

        public FDevolucionesVentas(int NumeroAgencia, int CodigoUsuario, string NombreUsuario)
        {
            this.NumeroAgencia = NumeroAgencia;
            this.Codigousuario = CodigoUsuario;
            this.NombreUsuario = NombreUsuario;
            InitializeComponent();
        }
    }

    public class TipoReemDevolucón
    {
        private string _DescripcionTipo;
        private char _Tipo;
        public TipoReemDevolucón( string descipcion, char tipo)
        {
            this._DescripcionTipo = descipcion;
            this._Tipo = tipo;
        }

        public string DescripcionTipo
        {
            get
            {
                return this._DescripcionTipo;
            }
            set
            {
                this._DescripcionTipo = value;
            }
        }


        public char TipoDevolucion
        {
            get
            {
                return this._Tipo;
            }
            set
            {
                this._Tipo = value;
            }
        }
    }
}
