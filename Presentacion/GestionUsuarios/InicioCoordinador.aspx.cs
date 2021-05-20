using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesGestionUsuarios;

namespace Presentacion.GestionUsuarios
{
    public partial class InicioCoordinador : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            EU = (E_Usuarios)Session["Usuario"];
            if (EU != null)
            {
                LblMensajeInicio.Text = "Bienvenido Coordinador";
                LblNombre.Text = EU.NombreUsuario + " " + EU.APaternoUsuario + " " + EU.AMaternoUsuario;
            }
        }
    }
}