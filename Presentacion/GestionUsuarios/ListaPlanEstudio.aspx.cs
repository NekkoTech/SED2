using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;

namespace Presentacion.GestionUsuarios
{
    public partial class ListaPlanEstudio : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        protected void Page_Load(object sender, EventArgs e)
        {
               
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Session["Opcion"] = "Agregar";
            Response.Redirect("IbmPlanEstudio.aspx");
        }

        protected void GvPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvPlanes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdPlan = Convert.ToInt32(GvPlanes.DataKeys[index].Value.ToString());
                EP = new N_Usuarios().BuscaPlanes(IdPlan);
                Session["Plan"] = EP;
                Session["Mensaje"] = "Modificar";
                Response.Redirect("IbmPlanEstudio.aspx");
            }
            if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdPlan = Convert.ToInt32(GvPlanes.DataKeys[index].Value.ToString());
                EP = new N_Usuarios().BuscaPlanes(IdPlan);
                Session["Plan"] = EP;
                //Session["Mensaje"] = "Borrar";
                //Response.Redirect("EliminarUsuario.aspx");
            }
        }
    }
}