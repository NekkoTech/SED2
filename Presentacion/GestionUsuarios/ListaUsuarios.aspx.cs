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
        N_Usuarios NU = new N_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            GvUsuarios.DataSource=NU.LstUsuarios();
            GvUsuarios.DataBind();
        }

        protected void GvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Modificar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdUsuario = Convert.ToInt32(GvUsuarios.DataKeys[index].Value.ToString());
                EU = new N_Usuarios().BuscaUsuario(IdUsuario);
                Session["UsuarioSeleccionado"] = EU;
                Session["Mensaje"] = "Modificar";
                Response.Redirect("ModificarUsuario.aspx");
            }
            if(e.CommandName=="Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdUsuario = Convert.ToInt32(GvUsuarios.DataKeys[index].Value.ToString());
                EU = new N_Usuarios().BuscaUsuario(IdUsuario);
                Session["UsuarioSeleccionado"] = EU;
                Session["Mensaje"] = "Borrar";
                Response.Redirect("EliminarUsuario.aspx");
            }
        }

        protected void GvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregaUsuario.aspx");
        }

        protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTest.Text.ToString()=="1")
            {
                GvUsuarios.DataSource = NU.LstUsuarios();
                GvUsuarios.DataBind();
            }
            else
            {
                GvUsuarios.DataSource = NU.BuscaUsuarioTipo(Convert.ToInt32(ddlTest.Text.ToString()));
                GvUsuarios.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ddlTest.Text.ToString()=="1")
            {
                GvUsuarios.DataSource = NU.LstBuscaUsuarios(TextBox2.Text.ToString());
                GvUsuarios.DataBind();
            }
            else
            {
                GvUsuarios.DataSource = NU.LstBuscaUsuariosTipo(TextBox2.Text.ToString(), Convert.ToInt32(ddlTest.Text.ToString()));
                GvUsuarios.DataBind();
            }
        }
    }
}