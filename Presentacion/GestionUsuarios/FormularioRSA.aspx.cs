using EntidadesGestionUsuarios;
using NegociosGestionUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.GestionUsuarios
{
    public partial class FormularioRSA : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Materias EM = new E_Materias();
        private string BackGroundHeader;
        private string BtnColor;
        E_Usuarios EU = new E_Usuarios();
        E_Usuarios SEU = new E_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        List<E_Atributos> LEA = new List<E_Atributos>();
        List<TextBox> Lista1 = new List<TextBox>();
        List<TextBox> Lista2 = new List<TextBox>();
        List<TextBox> Lista3 = new List<TextBox>();
        List<TextBox> Lista4 = new List<TextBox>();
        List<TextBox> Lista5 = new List<TextBox>();
        List<TextBox> Lista6 = new List<TextBox>();

        E_RSA ER = new E_RSA();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }
            else
            {
                E_Usuarios EU = (E_Usuarios)Session["Usuario"];
                switch (EU.IdTipoUsuario)
                {
                    case 1:
                        Response.Redirect("InicioMain.aspx");
                        break;
                    case 3:
                        Response.Redirect("InicioCoordinador.aspx");
                        break;
                    case 2:
                        Response.Redirect("InicioSubdirector.aspx");
                        break;
                }
            }
            ER = (E_RSA)Session["RSA"];
            EU = (E_Usuarios)Session["Usuario"];
            if (ER != null)
            {
                
                EM = (E_Materias)Session["Materia"];
                EP = NU.BuscaPlanCoordinador(ER.IdCoordinador);
                 
                if (!IsPostBack)
                {
                    if (ER.Status == 3)
                    {
                        E_RSADocumento ERD = NU.BuscaDocumentoRSA(ER.IdRSA);
                        tbObservaciones.Text = ERD.Observaciones;
                        tbObservaciones.Enabled = false;
                        btnModal.Visible = true;
                    }
                    TbCarrera.Text = EP.NombrePlan.ToLowerInvariant();
                    TbSemestre.Text = EM.Semestre.ToString();
                    TbNumEmpleado.Text = EU.NumeroEmpleado;
                    TbNombreDocente.Text = EU.NombreUsuario + " " + EU.APaternoUsuario + " " + EU.AMaternoUsuario;
                    TbAsignatura.Text = EM.Materia.ToLowerInvariant();
                    TbClaveAsig.Text = EM.Clave;
                    TbFecha.Text = ER.FechaAD;
                    DdlAD.SelectedValue = ER.CopiaAD.ToString();
                    TbFecha2.Text = ER.FechaMP;
                    DdlMP.SelectedValue = ER.CopiaMP.ToString();
                    tbSemestresImp.Text = ER.Semestres.ToString();
                }
            }
            else
            {
                ER = new E_RSA();
                EM = (E_Materias)Session["Materia"];
                EP = NU.BuscaPlanMateria(EM.IdMateria);
                if (!IsPostBack)
                {
                    TbCarrera.Text = EP.NombrePlan.ToLowerInvariant();
                    TbSemestre.Text = EM.Semestre.ToString();
                    TbNumEmpleado.Text = EU.NumeroEmpleado;
                    TbNombreDocente.Text = EU.NombreUsuario + " " + EU.APaternoUsuario + " " + EU.AMaternoUsuario;
                    TbAsignatura.Text = EM.Materia.ToLowerInvariant();
                    TbClaveAsig.Text = EM.Clave;
                }

            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            ER.FechaAD = TbFecha.Text.ToString();
            ER.CopiaAD = Convert.ToInt32(DdlAD.SelectedValue);
            ER.FechaMP = TbFecha2.Text.ToString();
            ER.CopiaMP = Convert.ToInt32(DdlMP.SelectedValue);
            ER.Semestres = Convert.ToInt32(tbSemestresImp.Text.ToString());
            //ER.Status = 1;
            ER.IdCoordinador = EP.IdCoordinador;
            ER.IdMateria = EM.IdMateria;
            Session["RSA"] = ER;
            Response.Redirect("FormularioRSA2.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            ER.FechaAD = TbFecha.Text.ToString();
            ER.CopiaAD = Convert.ToInt32(DdlAD.SelectedValue);
            ER.FechaMP = TbFecha2.Text.ToString()+" ";
            ER.CopiaMP = Convert.ToInt32(DdlMP.SelectedValue);
            ER.Semestres = Convert.ToInt32(tbSemestresImp.Text.ToString());
            //ER.Status = 1;
            ER.IdCoordinador = EP.IdCoordinador;
            ER.IdMateria = EM.IdMateria;
            if (ER.Status == 1)
            {
                if (NU.ModificarRSA(ER).Contains("Exito"))
                {
                    Console.WriteLine("Rsa Modificado");
                }
            }
            if (ER.Status == 0)
            {
                ER.Status = 1;
                if (NU.InsertarRSA(ER).Contains("Exito"))
                {

                    Console.WriteLine("Rsa Ingresado");
                    
                }
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalPeticion()", true);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaRSADocente.aspx");
        }

        protected void btnObservaciones_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalObservaciones()", true);
        }
    }
}