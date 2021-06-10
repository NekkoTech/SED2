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
    public partial class EvaluarEncuadre : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Materias EM = new E_Materias();
        private string BackGroundHeader;
        private string BtnColor;
        E_Usuarios EU = new E_Usuarios();
        E_Usuarios SEU = new E_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        E_Encuadres EE = new E_Encuadres();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }
            else
            {
                EU = (E_Usuarios)Session["Usuario"];
                switch (EU.IdTipoUsuario)
                {
                    case 4:
                        Response.Redirect("InicioDocente.aspx");
                        break;
                    case 2:
                        Response.Redirect("InicioSubdirector.aspx");
                        break;
                }
            }
            string Msg = (string)Session["Mensaje"];
            EM =(E_Materias) Session["Materia"];
            if (EM != null)
            {
                EE = (E_Encuadres)Session["Encuadre"];
                if (EE != null)
                {
                    EP = NU.BuscaPlanCoordinador(EE.IdCoordinador);
                    Encuadre.Attributes["src"] = "..\\Encuadres\\" + EP.NombrePlan + "\\" + EE.NombreEncuadre;
                    Encuadre.DataBind();
                }
                else
                {
                    Response.Redirect("ListaEncuadres.aspx");
                }
            }
        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaEncuadres.aspx");
        }
        protected void BtnAceptado_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalObservaciones()", true);
        }
        protected void BtnRechazar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalAccept()", true);
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalCalif()", true);
        }
        protected void BtnEnviarRechazado_Click(object sender, EventArgs e)
        {
            EE.EstadoEncuadre = 3;
            EE.Calificacion = "0";
            EE.Observacion = tbObservaciones.Text;
            Master.ModalMsg(NU.ModificarEncuadre(EE));
        }
        protected void BtnEnviarAceptado_Click(object sender, EventArgs e)
        {
            EE.EstadoEncuadre = 4;
            EE.Calificacion = TbCalificacion.Text;
            EE.Observacion = "";
            Master.ModalMsg(NU.ModificarEncuadre(EE));
        }
    }
}