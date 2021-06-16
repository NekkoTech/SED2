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
        private string BackGroundHeader;
        private string BtnColor;
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

            for (int i = 0; i < GvUsuarios.Rows.Count; i++)
            {
                E_Usuarios AK = NU.UsuarioBloqueado(Convert.ToInt32(GvUsuarios.DataKeys[i].Value.ToString()));
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
            if (e.CommandName == "Modificar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdUsuario = Convert.ToInt32(GvUsuarios.DataKeys[index].Value.ToString());
                EU = new N_Usuarios().BuscaUsuario(IdUsuario);
                Session["UsuarioSeleccionado"] = EU;
                Session["Mensaje"] = "Modificar";
                Response.Redirect("ModificarUsuario.aspx");
            }
            if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdUsuario = Convert.ToInt32(GvUsuarios.DataKeys[index].Value.ToString());
                EU = new N_Usuarios().BuscaUsuario(IdUsuario);
                Session["UsuarioSeleccionado"] = EU;
                Session["Mensaje"] = "Borrar";
                Response.Redirect("EliminarUsuario.aspx");
            }
            if (e.CommandName == "Bloquear")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdUsuario = Convert.ToInt32(GvUsuarios.DataKeys[index].Value.ToString());
                EU = new N_Usuarios().BuscaUsuario(IdUsuario);
                Session["Bloqueo"] = EU;
                ModalConfirmationMsg("Precaucion: ¿Seguro que desea bloquear al usuario?");

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
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            E_Usuarios bloqueo = (E_Usuarios)Session["Bloqueo"];
            Master.ModalMsg(NU.InsertarBloqueo(bloqueo.IdUsuario));
            GvUsuarios.DataBind();

        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregaUsuario.aspx");
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaUsuarios.aspx");
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
        public void ModalConfirmationMsg(string pMsg)
        {
            String[] TipoMsg = pMsg.Split(':');
            AtributosModal(TipoMsg[0]);
            ModalHeader.Attributes.Clear();
            ModalHeader.Attributes.Add("class", BackGroundHeader);
            ModalTitulo.InnerHtml = string.Format("{0}", TipoMsg[0]);
            ModalBody.InnerHtml = string.Format("{0}", TipoMsg[1]);
            btnConfirmar.Attributes.Clear();
            btnConfirmar.Attributes.Add("class", BtnColor);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openconfirmationModalMensaje()", true);
        }
        public void ModalRedireccionMsg(string pMsg)
        {
            String[] TipoMsg = pMsg.Split(':');
            AtributosModal(TipoMsg[0]);
            Encabezado.Attributes.Clear();
            Encabezado.Attributes.Add("class", BackGroundHeader);
            TituloModalRedireccion.InnerHtml = string.Format("{0}", TipoMsg[0]);
            CuerpoModalRedireccion.InnerHtml = string.Format("{0}", TipoMsg[1]);
            btnAceptarRedireccion.Attributes.Clear();
            btnAceptarRedireccion.Attributes.Add("class", BtnColor);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openRedireccionModalMensaje()", true);
        }
        protected void AtributosModal(string Tipo)
        {
            switch (Tipo)
            {
                case "Exito": BackGroundHeader = Clr.ClrExito; BtnColor = Clr.BtnExito; break;
                case "Error": BackGroundHeader = Clr.ClrPeligro; BtnColor = Clr.BtnPeligro; break;
                case "Informacion": BackGroundHeader = Clr.ClrInformacion; BtnColor = Clr.BtnInformacion; break;
                case "Precaucion": BackGroundHeader = Clr.ClrPrecaucion; BtnColor = Clr.BtnPrecaucion; break;
                default: BackGroundHeader = Clr.ClrGeneral; BtnColor = Clr.BtnGeneral; break;
            }
        }
    }
}