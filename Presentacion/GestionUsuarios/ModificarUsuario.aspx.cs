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
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        private string BackGroundHeader;
        private string BtnColor;
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
            if (IsPostBack)
            {
                this.tbPassWord.Attributes.Add("value", this.tbPassWord.Text);
            }
            else
            {
                if (Session["UsuarioSeleccionado"] != null)
                {
                    EU = (E_Usuarios)Session["UsuarioSeleccionado"];
                    Session["TipoUsuario"] = EU.IdTipoUsuario;

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
        }

        protected void ChangeColorSubd(object sender, EventArgs e)
        {
            btnSubdirector.Style.Add("background-color", "#00723f");
            btnCoordinador.Style.Add("background-color", "#ffffff");
            btnDocente.Style.Add("background-color", "#ffffff");
            Session["TipoUsuario"] = 2;
        }
        protected void ChangeColorCoord(object sender, EventArgs e)
        {
            btnSubdirector.Style.Add("background-color", "#ffffff");
            btnCoordinador.Style.Add("background-color", "#00723f");
            btnDocente.Style.Add("background-color", "#ffffff");
            Session["TipoUsuario"] = 3;
        }
        protected void ChangeColorDoc(object sender, EventArgs e)
        {
            btnSubdirector.Style.Add("background-color", "#ffffff");
            btnCoordinador.Style.Add("background-color", "#ffffff");
            btnDocente.Style.Add("background-color", "#00723f");
            Session["TipoUsuario"] = 4;
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaUsuarios.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ModalConfirmationMsg("Precaución : ¿Seguro que desea modificar al usuario?");


        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            EU = new E_Usuarios();
            E_Usuarios aux = (E_Usuarios)Session["UsuarioSeleccionado"];
            EU.NombreUsuario = tbNombre.Text;
            EU.APaternoUsuario = tbAPat.Text;
            EU.AMaternoUsuario = tbAMat.Text;
            EU.NumeroEmpleado = tbNumeroEmpleado.Text;
            EU.EmailUsuario = tbEmail.Text;
            EU.PassWordUsuario = tbPassWord.Text;
            EU.IdTipoUsuario = (int)Session["TipoUsuario"];
            EU.IdUsuario = aux.IdUsuario;

            if (NU.ModificarUsuario(EU).Contains("Exito"))
            {
                //Response.Redirect("ListaUsuarios.aspx");
                Master.ModalMsg("Exito: Los Datos Fueron Modificados exitosamente");

            }
            else
            {
                Master.ModalMsg("Error: El Usuario No Pudo Ser Modificado, Revise Su Informacion");
                //lblRespuesta.Text = "Error, los datos no pudieron ser ingresados";
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