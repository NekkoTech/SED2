using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesGestionUsuarios;

namespace Presentacion.GestionUsuarios
{
    public partial class InicioSubdirector: System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }
            EU = (E_Usuarios)Session["Usuario"];
            switch (EU.IdTipoUsuario)
            {
                case 1:
                    Response.Redirect("InicioMain.aspx");
                    break;
                case 4:
                    Response.Redirect("InicioDocente.aspx");
                    break;
                case 3:
                    Response.Redirect("InicioCoordinador.aspx");
                    break;
            }
            LblMensajeInicio.Text = "Bienvenido Subdirector";
            LblNombre.Text = EU.NombreUsuario + " " + EU.APaternoUsuario + " " + EU.AMaternoUsuario;
        }
    }
}