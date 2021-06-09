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
            if (Session["Usuario"] == null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }
            else
            {
                EU = (E_Usuarios)Session["Usuario"];
                switch (EU.IdTipoUsuario)
                {
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
            List<E_Usuarios> temp = new List<E_Usuarios>();
           
            
            GvUsuarios.DataSource = NU.LstUsuarios();
            GvUsuarios.DataBind();
            int IdUsuario;
            //foreach (GridViewRow E in GvUsuarios.Rows)
            //{

                for(int i=0;i<GvUsuarios.Rows.Count;i++)
                {
                    E_Usuarios AK= NU.UsuarioBloqueado(Convert.ToInt32(GvUsuarios.DataKeys[i].Value.ToString()));
                     if (AK != null)
                     {
                         LinkButton btnbloquear = (LinkButton)GvUsuarios.Rows[i].Cells[2].FindControl("btnBloquear");
                         btnbloquear.CssClass = "btn LinkButton4 btn-outline - Warning";
                         btnbloquear.CommandName = "desbloquear";
                         GvUsuarios.Rows[i].Cells[2].Controls.AddAt(2, btnbloquear);
                     }

                    IdUsuario = Convert.ToInt32(GvUsuarios.DataKeys[i].Value.ToString());
                }
                
                //LinkButton btnbloquear = (LinkButton)E.Cells[2].FindControl("btnBloquear");
            //}

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
            if(e.CommandName=="Bloquear")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdUsuario = Convert.ToInt32(GvUsuarios.DataKeys[index].Value.ToString());
                Master.ModalMsg(NU.InsertarBloqueo(IdUsuario));
                GvUsuarios.DataBind();
                Response.Redirect("ListaUsuarios.aspx");
            }
            if (e.CommandName == "desbloquear")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdUsuario = Convert.ToInt32(GvUsuarios.DataKeys[index].Value.ToString());
                Master.ModalMsg(NU.EliminarBloqueo(IdUsuario));
                GvUsuarios.DataBind();
                Response.Redirect("ListaUsuarios.aspx");
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
            if (ddlTest.Text.ToString() == "1")
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
            if (ddlTest.Text.ToString() == "1")
            {
                GvUsuarios.DataSource = NU.LstBuscaUsuarios(TextBox1.Text.ToString());
                GvUsuarios.DataBind();
            }
            else
            {
                GvUsuarios.DataSource = NU.LstBuscaUsuariosTipo(TextBox1.Text.ToString(), Convert.ToInt32(ddlTest.Text.ToString()));
                GvUsuarios.DataBind();
            }
        }
    }
}