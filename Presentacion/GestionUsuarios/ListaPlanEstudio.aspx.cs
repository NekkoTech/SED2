using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;

namespace Presentacion.GestionUsuarios
{
    public partial class ListaPlanEstudio : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
               
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IbmPlanEstudio.aspx");
        }

        
    }
}