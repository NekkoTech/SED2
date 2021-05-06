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
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Modificar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdUsuario = Convert.ToInt32(GvUsuarios.DataKeys[index].Value.ToString());
                EU = new N_Usuarios().BuscaUsuario(IdUsuario);
                Session["ModUs"] = EU;
                Session["Mensaje"] = "Modificar";
                Response.Redirect("");

            }
        }

        protected void GvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}