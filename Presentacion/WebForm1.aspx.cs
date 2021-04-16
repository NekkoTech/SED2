using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesGestionUsuarios;
using NegociosGestionUsuarios;

namespace Presentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        E_Usuarios EU= new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            GrvUsuarios.DataSource = NU.LstUsuarios();
            GrvUsuarios.DataBind();
        }

        protected void GrvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}