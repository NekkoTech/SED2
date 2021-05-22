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
    public partial class CuentaDocente : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        Byte[] ByteFirma;
        E_Firma EF = new E_Firma();
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
                LblMensaje.Text = "";
                LblMensaje.Attributes.Add("class", "text-danger");
                EF=NU.BuscaFirma(EU.IdUsuario);
                if (EF != null)
                {
                    string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(EF.Firma);
                    ImgFirma.ImageUrl = ImagenDataURL64;
              
                }
            }

            
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Pass"] = TbRepPassWord.Text;
            ModalPeticiones("Informacion: ¿Seguro que desea guardar los cambios a la firma?");
        }


        protected void BtnSubir_Click(object sender, EventArgs e)
        {
            HttpPostedFile HpfFirma = FuFirma.PostedFile;
            if (FuFirma.HasFile)
            {
                
                string msg = HpfFirma.ContentType;
                if (msg == "image/jpg" || msg=="image/png" || msg == "image/jpeg")
                {
                    int TamFirma = FuFirma.PostedFile.ContentLength;
                    if (TamFirma <= 1250000)
                    {
                        ByteFirma = new Byte[TamFirma];
                        HpfFirma.InputStream.Read(ByteFirma, 0, TamFirma);
                        Session["Firma"] = ByteFirma;
                        Bitmap ImagenOriginalBinaria = new Bitmap(HpfFirma.InputStream);

                        string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ByteFirma);
                        ImgFirma.ImageUrl = ImagenDataURL64;
                    }
                    else
                    {
                        
                        LblMensaje.Text = "Archivo Menor a 10 MB";
                    }   
                }
                else
                {
                    
                    LblMensaje.Text = "Ingrese un Arhivo con formato PNG, JPG o JPEG";
                }
            }
            else
            {
                
                LblMensaje.Text = "Seleccione una firma primero";
            }
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
                        ByteFirma = (Byte[])Session["Firma"];
                        if (ByteFirma != null)
                        {
                            if (NU.InsertarFirma(ByteFirma, EU.IdUsuario).Contains("Exito"))
                            {
                                Master.ModalMsg("Exito: La contraseña fue cambiada con exito y la firma ingresada");
                            }
                            else
                            {
                                Master.ModalMsg("Peligro: Se registro la contraseña, pero la firma no se pudo ingresar");
                            }
                        }
                        else
                        {
                            TbRepPassWord.Visible = false;
                            BtnCambio.Visible = true;
                            Master.ModalMsg("Exito: La contraseña fue cambiada exitosamente");
                        }
                            

                    }
                    else
                    {
                        Master.ModalMsg("Error: La contraseña, ni la firma pudo ser cambiada");
                    }
                }
                else
                {
                    Master.ModalMsg("Contraseña Muy Corta o Muy Larga");
                }
            }
            else
            {
                ByteFirma = (Byte[])Session["Firma"];
                if (ByteFirma != null)
                {
                    if (NU.InsertarFirma(ByteFirma, EU.IdUsuario).Contains("Exito"))
                    {
                        Master.ModalMsg("Exito: La Firme Fue ingresada Con Exito");
                    }
                    else
                    {
                        Master.ModalMsg("Error: La firma no pudo ser ingresada");
                    }
                }
                else
                {
                    Master.ModalMsg("Error: No a hecho ninguna modificacion");
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