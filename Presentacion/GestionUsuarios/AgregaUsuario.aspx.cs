using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;

namespace Presentacion.GestionUsuarios
{
    
    public partial class AgregaUsuario : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["Usuario"]==null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }*/
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ChangeColorSubd(object sender, EventArgs e)
        {
            btnSubdirector.Style.Add("background-color", "#00723f");
            btnCoordinador.Style.Add("background-color", "#ffffff");
            btnDocente.Style.Add("background-color", "#ffffff");
            Session["TipoUsuario"] = 2;
        }
        protected void ChangeColorCoord(object sender, EventArgs e)
        {
            btnSubdirector.Style.Add("background-color", "#ffffff");
            btnCoordinador.Style.Add("background-color", "#00723f");
            btnDocente.Style.Add("background-color", "#ffffff");
            Session["TipoUsuario"] = 3;
        }
        protected void ChangeColorDoc(object sender, EventArgs e)
        {
            btnSubdirector.Style.Add("background-color", "#ffffff");
            btnCoordinador.Style.Add("background-color", "#ffffff");
            btnDocente.Style.Add("background-color", "#00723f");
            Session["TipoUsuario"] = 4;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            EU.NombreUsuario = tbNombre.Text;
            EU.APaternoUsuario = tbAPat.Text;
            EU.AMaternoUsuario = tbAMat.Text;
            EU.EmailUsuario = tbEmail.Text;
            EU.NumeroEmpleado = tbNumeroEmpleado.Text;
            EU.PassWordUsuario = tbPassWord.Text;
            EU.IdUsuario = 1;
            EU.IdTipoUsuario = (int)Session["TipoUsuario"];
            if(NU.InsertarUsuario(EU).Contains("Exito"))
            {
                Master.ModalMsg("Exito: El Usuario fue agregado exitosamente");
                //lblRespuesta.Text = "El usuario fue agregado exitosamente";
            }
            else
            {
                Master.ModalMsg("Error: El usuario no pudo ser agregado");
                //lblRespuesta.Text = "Error, los datos no pudieron ser ingresados";
            }
            

        }
    }
}