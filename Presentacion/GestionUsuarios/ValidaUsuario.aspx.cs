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
    public partial class ValidaUsuario : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EU = NU.ValidaUsuario(tbEmailUsuario.Text, tbPassWord.Text);
            if (EU != null)
            {
                Session["Usuario"] = EU;
                switch (EU.IdTipoUsuario)
                {
                    case 1:
                        
                        Response.Redirect("InicioMain.aspx");
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        Response.Redirect("InicioDocente.aspx");
                        break;
                }
            }
            else
            {
                lblMensaje.Text = "Credenciales incorrectas";
            }
        }

        protected void LBForgot_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forgot.aspx");
        }
    }
}