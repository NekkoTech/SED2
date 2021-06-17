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
    public partial class InfoCuenta : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        private string BackGroundHeader;
        private string BtnColor;
        protected void Page_Load(object sender, EventArgs e)
        {
            EU = (E_Usuarios)Session["Usuario"];
            if (EU == null)
                Response.Redirect("ValidaUsuario.aspx");
            if (!IsPostBack)
            {
                TbRepPassWord.Text = String.Empty;
                TbRepPassWord.Visible = false;
                BtnCambio.Visible = true;
                tbNombre.Text = EU.NombreUsuario;
                tbAPat.Text = EU.APaternoUsuario;
                tbAMat.Text = EU.AMaternoUsuario;
                tbEmail.Text = EU.EmailUsuario;
                tbNumeroEmpleado.Text = EU.NumeroEmpleado;
                tbNombre.Enabled = false;
                tbAPat.Enabled = false;
                tbAMat.Enabled = false;
                tbEmail.Enabled = false;
                tbNumeroEmpleado.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Pass"] = TbRepPassWord.Text;
            ModalPeticiones("Informacion: ¿Seguro que desea cambiar la contraseña?");
        }
        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (TbRepPassWord.Visible == true)
            {
                TbRepPassWord.Text = (string)Session["Pass"];
                if (TbRepPassWord.Text.Length > 8 && TbRepPassWord.Text.Length <= 20)
                {
                    EU.PassWordUsuario = TbRepPassWord.Text;
                    if (NU.ModificarUsuario(EU).Contains("Exito"))
                    {
                        TbRepPassWord.Visible = false;
                        Master.ModalMsg("Exito: La contraseña fue cambiada exitosamente");
                    }
                    else
                    {
                        Master.ModalMsg("Contraseña Muy Corta o Muy Larga");
                    }
                }
            }
        }
        public void ModalPeticiones(string pMsg)
        {
            String[] TipoMsg = pMsg.Split(':');
            AtributosModalPeticiones(TipoMsg[0]);
            EModalHeader.Attributes.Clear();
            EModalHeader.Attributes.Add("class", BackGroundHeader);
            EModalTitulo.InnerHtml = string.Format("{0}", TipoMsg[0]);
            EModalBody.InnerHtml = string.Format("{0}", TipoMsg[1]);
            BtnCancelar.Attributes.Add("class", BtnColor);
            BtnCancelar.Attributes.Add("class", Clr.BtnPeligro);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalPeticion()", true);


        }
        protected void AtributosModalPeticiones(string Tipo)
        {
            switch (Tipo)
            {
                case "Agregar":
                    BackGroundHeader = Clr.ClrExito; BtnColor = Clr.BtnExito;
                    break;
                case "Eliminar":
                    BackGroundHeader = Clr.ClrPeligro; BtnColor = Clr.BtnPeligro;
                    break;
                case "Informacion": BackGroundHeader = Clr.ClrInformacion; BtnColor = Clr.BtnInformacion; break;
                case "Precaucion": BackGroundHeader = Clr.ClrPrecaucion; BtnColor = Clr.BtnPrecaucion; break;
                default: BackGroundHeader = Clr.ClrGeneral; BtnColor = Clr.BtnGeneral; break;
            }
        }
        protected void BtnCambio_Click(object sender, EventArgs e)
        {
            TbRepPassWord.Visible = true;
            BtnGuardar.CausesValidation = true;
            BtnCambio.Visible = false;
        }

    }
}