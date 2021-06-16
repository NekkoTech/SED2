using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesGestionUsuarios;

namespace Presentacion.PaginasMaestras
{
    public partial class MasterDocenteMenu : System.Web.UI.MasterPage
    {
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
                E_Usuarios EU = (E_Usuarios)Session["Usuario"];
                switch (EU.IdTipoUsuario)
                {
                    case 1:
                        Response.Redirect("InicioMain.aspx");
                        break;
                    case 3:
                        Response.Redirect("InicioCoordinador.aspx");
                        break;
                    case 2:
                        Response.Redirect("InicioSubdirector.aspx");
                        break;
                }
            }
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("ValidaUsuario.aspx");
        }
        public void ModalMsg(string pMsg)
        {
            String[] TipoMsg = pMsg.Split(':');
            AtributosModal(TipoMsg[0]);
            ModalHeader.Attributes.Clear();
            ModalHeader.Attributes.Add("class", BackGroundHeader);
            ModalTitulo.InnerHtml = string.Format("{0}", TipoMsg[0]);
            ModalBody.InnerHtml = string.Format("{0}", TipoMsg[1]);
            BtnEntendido.Attributes.Clear();
            BtnEntendido.Attributes.Add("class", BtnColor);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalMensaje()", true);
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