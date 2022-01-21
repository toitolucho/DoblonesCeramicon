﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Sistema;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FGeografico : Form
    {
        private PaisesCLN Paises = new PaisesCLN();
        private DepartamentosCLN Departamentos = new DepartamentosCLN();
        private ProvinciasCLN Provincias = new ProvinciasCLN();
        private LugaresCLN Lugares = new LugaresCLN();
        private string TipoOperacion = "";
        public string vRegion = "";

        public FGeografico()
        {
            InitializeComponent();
        }

        private void CargarPaises()
        {
            DataTable DTPaises = new DataTable();
            DTPaises = Paises.ListarPaises();
            cBNombrePais.DataSource = DTPaises.DefaultView;
            cBNombrePais.DisplayMember = "NombrePais";
            cBNombrePais.ValueMember = "CodigoPais";

        }

        private void CargarPaisesP()
        {
            DataTable DTPaisesP = new DataTable();
            DTPaisesP = Paises.ListarPaises();
            cBNombrePaisP.DataSource = DTPaisesP.DefaultView;
            cBNombrePaisP.DisplayMember = "NombrePais";
            cBNombrePaisP.ValueMember = "CodigoPais";

        }

        private void CargarPaisesL()
        {
            DataTable DTPaisesL = new DataTable();
            DTPaisesL = Paises.ListarPaises();
            cBNombrePaisL.DataSource = DTPaisesL.DefaultView;
            cBNombrePaisL.DisplayMember = "NombrePais";
            cBNombrePaisL.ValueMember = "CodigoPais";
        }

        private void CargarDepartamentos(string CodigoPais)
        {
            DataTable DTDepartamentos = new DataTable();
            DTDepartamentos = Departamentos.ObtenerDepartamentosPorPais(CodigoPais);
            cBDepartamentoN.DataSource = DTDepartamentos.DefaultView;
            cBDepartamentoN.DisplayMember = "NombreDepartamento";
            cBDepartamentoN.ValueMember = "CodigoDepartamento";

        }

        private void CargarDepartamentosL(string CodigoPais)
        {
            DataTable DTDepartamentosL = new DataTable();
            DTDepartamentosL = Departamentos.ObtenerDepartamentosPorPais(CodigoPais);
            cBNombreDepartamentoL.DataSource = DTDepartamentosL.DefaultView;
            cBNombreDepartamentoL.DisplayMember = "NombreDepartamento";
            cBNombreDepartamentoL.ValueMember = "CodigoDepartamento";
        }

        private void CargarProvincias(string CodigoPais, string CodigoDepartamento)
        {
            DataTable DTProvincias = new DataTable();
            DTProvincias = Provincias.ObtenerProvinciasPorDepartamento(CodigoPais, CodigoDepartamento);
            cBNombreProvinciaL.DataSource = DTProvincias.DefaultView;
            cBNombreProvinciaL.DisplayMember = "NombreProvincia";
            cBNombreProvinciaL.ValueMember = "CodigoProvincia";
        }

        private void FGeografico_Load(object sender, EventArgs e)
        {
            CargarPaises();
            CargarPaisesP();
            CargarPaisesL();
        }

        private void cBNombrePaisP_SelectedValueChanged(object sender, EventArgs e)
        {

            CargarDepartamentos(cBNombrePaisP.SelectedValue.ToString());

        }

        private void cBNombrePaisL_SelectedValueChanged(object sender, EventArgs e)
        {

            CargarDepartamentosL(cBNombrePaisL.SelectedValue.ToString());
        }

        private void cBNombreDepartamentoL_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((cBNombrePaisL.SelectedValue != null) && (cBNombreDepartamentoL.SelectedValue != null))
                CargarProvincias(cBNombrePaisL.SelectedValue.ToString(), cBNombreDepartamentoL.SelectedValue.ToString());
        }


        //botones para paises     
        private void bNuevo_Click(object sender, EventArgs e)
        {
            bCancelar.Enabled = true;
            bAceptar.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            TipoOperacion = "I";

            tBCodigoPais.ReadOnly = false;
            tBNombrePais.ReadOnly = false;
            tBNacionalidad.ReadOnly = false;
            
            tBCodigoPais.Text = "";
            tBNombrePais.Text = "";
            tBNacionalidad.Text = "";
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            bCancelar.Enabled = true;
            bAceptar.Enabled = true;
            TipoOperacion = "A";

            tBCodigoPais.ReadOnly = true;
            tBNombrePais.ReadOnly = false;
            tBNacionalidad.ReadOnly = false;
        }


        private void bEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = "Esta seguro de eliminar" + tBNombrePais.Text;
            string caption = "Eliminar";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult Resultado;
            Resultado = MessageBox.Show(mensaje, caption, botones);
            if (Resultado == DialogResult.OK)
            {
                Paises.EliminarPais(tBCodigoPais.Text);
                tBCodigoPais.ReadOnly = true;
                tBNombrePais.ReadOnly = true;
                tBNacionalidad.ReadOnly = true;
                
                tBCodigoPais.Text = "";
                tBNombrePais.Text = "";
                tBNacionalidad.Text = "";
            }
            else
                tPPaises.Show();

        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
            {
                if (tBCodigoPais.Text == "")
                {
                    MessageBox.Show("Debe ingresar el codigo de pais");
                }
                if (tBNombrePais.Text == "")
                {
                    MessageBox.Show("Debe ingresar un nombre de pais");
                }
                if (tBNacionalidad.Text == "")
                {
                    MessageBox.Show("Debe ingresar la nacionalidad");
                }
                else
                {
                    try
                    {
                        Paises.InsertarPais(tBCodigoPais.Text, tBNombrePais.Text, tBNacionalidad.Text);
                        MessageBox.Show("Ingreso satisfactorio");
                    }

                    catch (FormatException)
                    {
                        MessageBox.Show("Datos incorrectos");
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Ya existe un pais con el codigo:  " + tBCodigoPais.Text + " No se pudo insertar el pais!!!");
                    }
                }
                tBCodigoPais.ReadOnly = true;
                tBNombrePais.ReadOnly = true;
                tBNacionalidad.ReadOnly = true;
                bCancelar.Enabled = false;
            }

            else
            {
                if (TipoOperacion == "A")
                {
                    if (tBNombrePais.Text == "")
                    {
                        MessageBox.Show("Debe ingresar un nombre de pais");
                    }
                    if (tBNacionalidad.Text == "")
                    {
                        MessageBox.Show("Debe ingresar la nacionalidad");
                    }
                    else
                    {

                        try
                        {
                            Paises.ActualizarPais(tBCodigoPais.Text, tBNombrePais.Text, tBNacionalidad.Text);
                            MessageBox.Show("Actualizacion satisfactoria");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo realizar la actualizacion");

                        }
                    }
                    tBCodigoPais.ReadOnly = true;
                    tBNombrePais.ReadOnly = true;
                    tBNacionalidad.ReadOnly = true;
                }

            }
            bCancelar.Enabled = false;
            bAceptar.Enabled = true;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            tPPaises.Show();
            tBCodigoPais.ReadOnly = true;
            tBNombrePais.ReadOnly = true;
            tBNacionalidad.ReadOnly = true;
            bCancelar.Enabled = false;
            bAceptar.Enabled = false;
        }


        private void Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //botones papa departamentos
        private void bNuevoD_Click(object sender, EventArgs e)
        {
            cBNombrePais.Enabled = true;
            bCancelarD.Enabled = true;
            bAceptarD.Enabled = true;
            bEliminarD.Enabled = true;
            bEditarD.Enabled = true;
            TipoOperacion = "I";

            tBCodigoDepartamento.ReadOnly = false;
            tBNombreDepartamento.ReadOnly = false;

            cBNombrePais.Text = "";
            tBCodigoDepartamento.Text = "";
            tBNombreDepartamento.Text = "";
        }

        private void bEditarD_Click(object sender, EventArgs e)
        {
            bCancelarD.Enabled = true;
            bAceptarD.Enabled = true;
            TipoOperacion = "A";

            tBCodigoDepartamento.ReadOnly = true;
            tBNombreDepartamento.ReadOnly = false;
        }

        private void bEliminarD_Click(object sender, EventArgs e)
        {
            string mensaje = "Esta seguro de eliminar" + tBNombreDepartamento.Text;
            string caption = "Eliminar";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult Resultado;
            Resultado = MessageBox.Show(mensaje, caption, botones);
            if (Resultado == DialogResult.OK)
            {
                Departamentos.EliminarDepartamento(cBNombrePais.SelectedValue.ToString(), tBCodigoDepartamento.Text);

                tBCodigoDepartamento.Text = "";
                tBNombreDepartamento.Text = "";

            }
            else
                tPPaises.Show();

        }


        private void bAceptarD_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
            {
                if (cBNombrePais.SelectedValue.ToString() == "00")
                {
                    MessageBox.Show("Debe seleccionar un pais");
                }
                if (tBCodigoDepartamento.Text == "")
                {
                    MessageBox.Show("Debe ingresar el codigo del departamento");
                }
                if (tBNombreDepartamento.Text == "")
                {
                    MessageBox.Show("Debe ingresar un nombre de departamento");
                }
                else
                {
                    try
                    {
                        Departamentos.InsertarDepartamento(cBNombrePais.SelectedValue.ToString(), tBCodigoDepartamento.Text, tBNombreDepartamento.Text);
                        MessageBox.Show("Ingreso satisfactorio");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Datos incorrectos");
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Ya existe un Departamento con el codigo:  " + tBCodigoDepartamento.Text +
                            " No se pudo insertar el departamento!!!");
                    }
                }
                cBNombrePais.Enabled = false;
                tBCodigoDepartamento.ReadOnly = true;
                tBNombreDepartamento.ReadOnly = true;
            }
            else
            {
                if (TipoOperacion == "A")
                {
                    if (tBNombreDepartamento.Text == "")
                    {
                        MessageBox.Show("Debe ingresar un nombre para el departamento");
                    }
                    else
                    {
                        try
                        {
                            Departamentos.ActualizarDepartamento(cBNombrePais.SelectedValue.ToString(), tBCodigoDepartamento.Text, tBNombreDepartamento.Text);
                            MessageBox.Show("Actualizacion satisfactoria");
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("No se pudo actualizar los datos");
                        }
                    }

                    tBCodigoDepartamento.ReadOnly = true;
                    tBNombreDepartamento.ReadOnly = true;
                }
            }
            bCancelarD.Enabled = false;
            bAceptarD.Enabled = false;
        }

        private void bCancelarD_Click(object sender, EventArgs e)
        {
            tPDepartamentos.Show();
            tBCodigoDepartamento.ReadOnly = true;
            tBNombreDepartamento.ReadOnly = true;
            bCancelarD.Enabled = false;
            bAceptarD.Enabled = false;
            cBNombrePais.Enabled = false;
        }

        private void SalirD_Click(object sender, EventArgs e)
        {
            Close();
        }


        //botones para provincias
        private void bNuevoP_Click(object sender, EventArgs e)
        {
            cBNombrePaisP.Enabled = true;
            cBDepartamentoN.Enabled = true;
            bCancelarP.Enabled = true;
            bAceptarP.Enabled = true;
            bEditarP.Enabled = true;
            bEliminarP.Enabled = true;
            TipoOperacion = "I";

            CargarDepartamentos(cBNombrePaisP.SelectedValue.ToString());
            tBCodigoProvincia.ReadOnly = false;
            tBNombreProvincia.ReadOnly = false;

            cBNombrePaisP.Text = "";
            cBDepartamentoN.Text = "";
            tBCodigoProvincia.Text = "";
            tBNombreProvincia.Text = "";
        }

        private void bEditarP_Click(object sender, EventArgs e)
        {
            bCancelarP.Enabled = true;
            bAceptarP.Enabled = true;
            TipoOperacion = "A";

            tBCodigoProvincia.ReadOnly = true;
            tBNombreProvincia.ReadOnly = false;
        }

        private void bEliminarP_Click(object sender, EventArgs e)
        {
            string mensaje = "Esta seguro de eliminar" + tBNombreProvincia.Text;
            string caption = "Eliminar";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult Resultado;
            Resultado = MessageBox.Show(mensaje, caption, botones);
            if (Resultado == DialogResult.OK)
            {
                Provincias.EliminarProvincia(cBNombrePaisP.SelectedValue.ToString(), cBDepartamentoN.SelectedValue.ToString(), tBCodigoProvincia.Text);
                tBCodigoProvincia.ReadOnly = true;
                tBNombreProvincia.ReadOnly = true;

                tBCodigoProvincia.Text = "";
                tBNombreProvincia.Text = "";
            }
            else
                tPProvincias.Show();

        }

        private void bAceptarP_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
            {
                if (cBNombrePaisP.SelectedValue.ToString() == "00")
                {
                    MessageBox.Show("Debe seleccionar un pais");
                }
                if (tBCodigoProvincia.Text == "")
                {
                    MessageBox.Show("Debe ingrear el codigo de la provincia");
                }
                if (tBNombreProvincia.Text == "")
                {
                    MessageBox.Show("Debe ingresar un nombre para la provincia");
                }

                else
                {
                    try
                    {
                        Provincias.InsertarProvincia(cBNombrePaisP.SelectedValue.ToString(), cBDepartamentoN.SelectedValue.ToString(), tBCodigoProvincia.Text, tBNombreProvincia.Text);
                        MessageBox.Show("Ingreso satisfactorio");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Datos incorrectos");
                    }

                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Debe seleccionar un departamento");
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Ya existe la provincia" + tBNombreProvincia.Text + " No se pudo insertar la provincia");
                    }
                }

                tBCodigoProvincia.ReadOnly = true;
                tBNombreProvincia.ReadOnly = true;
            }
            else
            {
                if (TipoOperacion == "A")
                {
                    if (tBNombreProvincia.Text == "")
                    {
                        MessageBox.Show("Debe ingresar un nombre para la provincia");
                    }
                    else
                    {
                        try
                        {
                            Provincias.ActualizarProvincia(cBNombrePaisP.SelectedValue.ToString(), cBDepartamentoN.SelectedValue.ToString(), tBCodigoProvincia.Text, tBNombreProvincia.Text);
                            MessageBox.Show("Actualizacion satisfactoria");
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo actualizar");
                        }
                    }

                    tBCodigoProvincia.ReadOnly = true;
                    tBNombreProvincia.ReadOnly = true;
                }
            }
            bCancelarP.Enabled = false;
            bAceptarP.Enabled = false;
        }

        private void bCancelarP_Click(object sender, EventArgs e)
        {
            tPProvincias.Show();
            tBCodigoProvincia.ReadOnly = true;
            tBNombreProvincia.ReadOnly = true;
            bCancelarP.Enabled = false;
            bAceptarP.Enabled = false;
            cBNombrePaisP.Enabled = false;
            cBDepartamentoN.Enabled = false;
        }

        private void SalirP_Click(object sender, EventArgs e)
        {
            Close();
        }

        // botones de lugares
        private void bNuevoL_Click(object sender, EventArgs e)
        {
            cBNombrePaisL.Enabled = true;
            cBNombreDepartamentoL.Enabled = true;
            cBNombreProvinciaL.Enabled = true;
            bCancelarL.Enabled = true;
            bAceptarL.Enabled = true;
            bEliminarL.Enabled = true;
            bEliminarL.Enabled = true;
            TipoOperacion = "I";

            CargarDepartamentosL(cBNombrePaisL.SelectedValue.ToString());
            CargarProvincias(cBNombrePaisL.SelectedValue.ToString(), cBNombreDepartamentoL.SelectedValue.ToString());
            tBCodigoLugar.ReadOnly = false;
            tBNombreLugar.ReadOnly = false;

            cBNombrePaisL.Text = "";
            cBNombreDepartamentoL.Text = "";
            cBNombreProvinciaL.Text = "";
            tBCodigoLugar.Text = "";
            tBNombreLugar.Text = "";
        }

        private void bEditarL_Click(object sender, EventArgs e)
        {
            bCancelarL.Enabled = true;
            bAceptarL.Enabled = true;
            TipoOperacion = "A";

            tBCodigoLugar.ReadOnly = true;
            tBNombreLugar.ReadOnly = false;
        }

        private void bEliminarL_Click(object sender, EventArgs e)
        {
            string mensaje = "Esta seguro de eliminar" + tBNombreLugar.Text;
            string caption = "Eliminar";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult Resultado;
            Resultado = MessageBox.Show(mensaje, caption, botones);
            if (Resultado == DialogResult.OK)
            {
                Lugares.EliminarLugar(cBNombrePaisL.SelectedValue.ToString(), cBNombreDepartamentoL.SelectedValue.ToString(), cBNombreProvinciaL.SelectedValue.ToString(), tBCodigoLugar.Text);
                tBCodigoLugar.ReadOnly = true;
                tBNombreLugar.ReadOnly = true;

                tBCodigoLugar.Text = "";
                tBNombreLugar.Text = "";

            }
            else
                tPLugares.Show();

        }

        private void bAceptarL_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
            {
                if (cBNombrePaisL.SelectedValue.ToString() == "00")
                {
                    MessageBox.Show("Debe seleccionar un pais");
                }
                if (tBCodigoLugar.Text == "")
                {
                    MessageBox.Show("Debe ingresar el codigo del lugar");
                }
                if (tBNombreLugar.Text == "")
                {
                    MessageBox.Show("Debe ingresar un nombre para la provincia");
                }
                else
                {
                    try
                    {
                        Lugares.InsertarLugar(cBNombrePaisL.SelectedValue.ToString(), cBNombreDepartamentoL.SelectedValue.ToString(), cBNombreProvinciaL.SelectedValue.ToString(), tBCodigoLugar.Text, tBNombreLugar.Text);
                        MessageBox.Show("Ingreso satisfactorio");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Datos erroneos");
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Debe selecionar un departamento y una provincia");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ya existe el lugar" + tBNombreProvincia.Text + " No se pudo insertar el lugar!!!");
                    }
                }

                tBCodigoLugar.ReadOnly = true;
                tBNombreLugar.ReadOnly = true;
            }
            else
            {
                if (TipoOperacion == "A")
                {
                    if (tBNombreLugar.Text == "")
                    {
                        MessageBox.Show("Debe ingresar un nombre para el lugar");
                    }
                    else
                    {
                        try
                        {
                            Lugares.ActualizarLugar(cBNombrePaisL.SelectedValue.ToString(), cBNombreDepartamentoL.SelectedValue.ToString(), cBNombreProvinciaL.SelectedValue.ToString(), tBCodigoLugar.Text, tBNombreLugar.Text);
                            MessageBox.Show("Actualizacion satisfactoria");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo actualizar");
                        }
                    }

                    tBCodigoLugar.ReadOnly = true;
                    tBNombreLugar.ReadOnly = true;
                }

            }
            bCancelarL.Enabled = false;
            bAceptarL.Enabled = false;
        }

        private void bCancelarL_Click(object sender, EventArgs e)
        {
            tPLugares.Show();
            tBCodigoLugar.ReadOnly = true;
            tBNombreLugar.ReadOnly = true;
            bCancelarL.Enabled = false;
            bAceptarL.Enabled = false;
            cBNombrePaisL.Enabled = false;
            cBNombreDepartamentoL.Enabled = false;
            cBNombreProvinciaL.Enabled = false;
        }

        private void SalirL_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tBCodigoPais_TextChanged(object sender, EventArgs e)
        {
            tBCodigoPais.MaxLength = 2;
        }

        private void tBCodigoDepartamento_TextChanged(object sender, EventArgs e)
        {
            tBCodigoDepartamento.MaxLength = 2;
        }

        private void tBCodigoProvincia_TextChanged(object sender, EventArgs e)
        {
            tBCodigoProvincia.MaxLength = 2;
        }

        private void tBCodigoLugar_TextChanged(object sender, EventArgs e)
        {
            tBCodigoLugar.MaxLength = 2;
        }

        private void bBuscarPais_Click(object sender, EventArgs e)
        {
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            string CP = "";
            FBuscarRegion fBuscarRegion = new FBuscarRegion();
            fBuscarRegion.vRegion = "P";
            fBuscarRegion.ShowDialog(this);
            CP = fBuscarRegion.CodigoPais;
            if ((CP != null) && (CP != ""))
            {
                DataTable DTPais = new DataTable();
                DTPais = Paises.ObtenerPais(CP);

                tBCodigoPais.Text = DTPais.Rows[0][0].ToString();
                tBNombrePais.Text = DTPais.Rows[0][3].ToString();
                tBNacionalidad.Text = DTPais.Rows[0][5].ToString();
            }


        }

        private void bBuscarDep_Click(object sender, EventArgs e)
        {
            bEditarD.Enabled = true;
            bEliminarD.Enabled = true;
            string CP = "";
            string CD = "";
            FBuscarRegion fBuscarRegion = new FBuscarRegion();
            fBuscarRegion.vRegion = "D";
            fBuscarRegion.ShowDialog();
            CD = fBuscarRegion.CodigoDepartamento;
            CP = fBuscarRegion.CodigoPais;
            if ((CP != null) && (CP != ""))
            {
                DataTable DTDepartamento = new DataTable();
                DTDepartamento = Departamentos.ObtenerDepartamento(CP, CD);

                if ((DTDepartamento.Rows[0][0].ToString() != null) && (DTDepartamento.Rows[0][0].ToString() != ""))
                    cBNombrePais.SelectedValue = DTDepartamento.Rows[0][0].ToString();
                else
                    cBNombrePais.SelectedIndex = -1;

                tBCodigoDepartamento.Text = DTDepartamento.Rows[0][1].ToString();
                tBNombreDepartamento.Text = DTDepartamento.Rows[0][3].ToString();

            }
        }

        private void bBuscarProv_Click(object sender, EventArgs e)
        {
            bEditarP.Enabled = true;
            bEliminarP.Enabled = true;
            string CP = "";
            string CD = "";
            string CR = "";
            FBuscarRegion fBuscarRegion = new FBuscarRegion();
            fBuscarRegion.vRegion = "R";
            fBuscarRegion.ShowDialog();
            CD = fBuscarRegion.CodigoDepartamento;
            CP = fBuscarRegion.CodigoPais;
            CR = fBuscarRegion.CodigoProvincia;
            if ((CP != null) && (CP != ""))
            {
                DataTable DTProvincia = new DataTable();
                DTProvincia = Provincias.ObtenerProvincia(CP, CD, CR);

                if ((DTProvincia.Rows[0][0].ToString() != null) && (DTProvincia.Rows[0][0].ToString() != ""))
                    cBNombrePaisP.SelectedValue = DTProvincia.Rows[0][0].ToString();
                else
                    cBNombrePaisP.SelectedIndex = -1;

                if ((DTProvincia.Rows[0][1].ToString() != null) && (DTProvincia.Rows[0][1].ToString() != ""))
                    cBDepartamentoN.SelectedValue = DTProvincia.Rows[0][1].ToString();
                else
                    cBDepartamentoN.SelectedIndex = -1;

                tBCodigoProvincia.Text = DTProvincia.Rows[0][2].ToString();
                tBNombreProvincia.Text = DTProvincia.Rows[0][4].ToString();
            }
        }

        private void bBuscarLugar_Click(object sender, EventArgs e)
        {
            bEditarL.Enabled = true;
            bEliminarL.Enabled = true;
            string CP = "";
            string CD = "";
            string CR = "";
            string CL = "";
            FBuscarRegion fBuscarRegion = new FBuscarRegion();
            fBuscarRegion.vRegion = "L";
            fBuscarRegion.ShowDialog();
            CD = fBuscarRegion.CodigoDepartamento;
            CP = fBuscarRegion.CodigoPais;
            CR = fBuscarRegion.CodigoProvincia;
            CL = fBuscarRegion.CodigoLugar;
            if ((CP != null) && (CP != ""))
            {
                DataTable DTLugar = new DataTable();
                DTLugar = Lugares.ObtenerLugar(CP, CD, CR, CL);

                if ((DTLugar.Rows[0][0].ToString() != null) && (DTLugar.Rows[0][0].ToString() != ""))
                    cBNombrePaisL.SelectedValue = DTLugar.Rows[0][0].ToString();
                else
                    cBNombrePaisL.SelectedIndex = -1;

                if ((DTLugar.Rows[0][1].ToString() != null) && (DTLugar.Rows[0][1].ToString() != ""))
                    cBNombreDepartamentoL.SelectedValue = DTLugar.Rows[0][1].ToString();
                else
                    cBNombreDepartamentoL.SelectedIndex = -1;

                if ((DTLugar.Rows[0][2].ToString() != null) && (DTLugar.Rows[0][2].ToString() != ""))
                    cBNombreProvinciaL.SelectedValue = DTLugar.Rows[0][2].ToString();
                else
                    cBNombreProvinciaL.SelectedIndex = -1;

                tBCodigoLugar.Text = DTLugar.Rows[0][3].ToString();
                tBNombreLugar.Text = DTLugar.Rows[0][5].ToString();
            }
        }

        public void seleccionarPestaniaPais()
        {
            tabControl1.SelectedTab = tPPaises;
        }

        public void seleccionarPestaniaDepartamento()
        {
            tabControl1.SelectedTab = tPDepartamentos;
        }

        public void seleccionarPestaniaProvincia()
        {
            tabControl1.SelectedTab = tPProvincias;
        }

        public void seleccionarPestaniaLugar()
        {
            tabControl1.SelectedTab = tPLugares;
        }
    }
}
