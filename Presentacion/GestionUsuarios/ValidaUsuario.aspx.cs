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
        E_Usuarios Eaux = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        int bloqueo;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EU = NU.ValidaUsuario(tbEmailUsuario.Text, tbPassWord.Text);
            if (EU != null)
            {
                Session["Usuario"] = EU;

                Eaux = NU.UsuarioBloqueado(EU.IdUsuario);
                if(Eaux == null)
               {
                    switch (EU.IdTipoUsuario)
                    {
                        case 1:

                            Response.Redirect("InicioMain.aspx");
                            break;
                        case 2:
                            Response.Redirect("InicioSubdirector.aspx");
                            break;
                        case 3:
                            Response.Redirect("InicioCoordinador.aspx");
                            break;
                        case 4:
                            Response.Redirect("InicioDocente.aspx");
                            break;
                    }
                }
                else
                {
                    lblMensaje.Text = "Usuario bloqueado";
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

        protected void LBAlumno_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccesoAlumnos.aspx");
        }
    }
}