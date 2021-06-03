using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;
using System.Drawing;
using System.IO;

namespace Presentacion.GestionUsuarios
{
    public partial class EncuadreDocente : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        E_Firma EF = new E_Firma();
        private string BackGroundHeader;
        private string BtnColor;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["Usuario"] == null)
                Response.Redirect("ValidaUsuario.aspx");

            if (!IsPostBack)
            {
               
            }

            
            

        }


        protected void BtnSubir_Click(object sender, EventArgs e)
        {
           
        }
        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            
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


        protected void BtnVer_Click(object sender, EventArgs e)
        {

        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSubirEncuadre_Click(object sender, EventArgs e)
        {

        }

        protected void BtnDescargar_Click(object sender, EventArgs e)
        {

        }
    }
}