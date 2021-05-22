using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;

namespace Presentacion.GestionUsuarios
{
    public partial class EliminarUsuario : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        private string BackGroundHeader;
        private string BtnColor;
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
            if (Session["UsuarioSeleccionado"] != null)
            {
                EU = (E_Usuarios)Session["UsuarioSeleccionado"];
                tbNombre.Text = EU.NombreUsuario;
                tbAPat.Text = EU.APaternoUsuario;
                tbAMat.Text = EU.AMaternoUsuario;
                tbEmail.Text = EU.EmailUsuario;
                tbNumeroEmpleado.Text = EU.NumeroEmpleado;
                tbPassWord.Text = EU.PassWordUsuario;
                switch (EU.IdTipoUsuario)
                {
                    case 2:
                        btnSubdirector.Style.Add("background-color", "#00723f");
                        break;
                    case 3:
                        btnCoordinador.Style.Add("background-color", "#00723f");
                        break;
                    case 4:
                        btnDocente.Style.Add("background-color", "#00723f");
                        break;
                }
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaUsuarios.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            ModalConfirmationMsg("Precaucion: ¿Seguro que desea eliminar al usuario?");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Session["UsuarioSeleccionado"] != null)
            {
                EU = (E_Usuarios)Session["UsuarioSeleccionado"];
                if (NU.BorraUsuario(EU.IdUsuario).Contains("Exito"))
                {
                    ModalRedireccionMsg("Exito: El usuario fue eliminado Exitosamente");
                }
                else
                {
                    Master.ModalMsg("Error: El usuario no pude ser eliminado");
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaUsuarios.aspx");
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