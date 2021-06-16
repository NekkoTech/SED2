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
    public partial class InfoCuenta : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"]==null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }
            EU = (E_Usuarios)Session["Usuario"];
            if (!IsPostBack)
            {
                tbNombre.Text = EU.NombreUsuario;
                tbAPat.Text = EU.APaternoUsuario;
                tbAMat.Text = EU.AMaternoUsuario;
                tbEmail.Text = EU.EmailUsuario;
                tbNumeroEmpleado.Text = EU.NumeroEmpleado;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EU.PassWordUsuario = tbPassWord.Text.Trim();
            if (NU.ModificarUsuario(EU).Contains("Exito"))
            {
                lblRespuesta.Text = "Su contraseña ha sido modificada";
            }
            else
            {
                lblRespuesta.Text = "Error: los la contraseña no pudo ser modificada";
            }
        }
    }
}