using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Presentacion.GestionUsuarios
{
    public partial class ListaRSAD : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Materias EM = new E_Materias();
        private string BackGroundHeader;
        private string BtnColor;
        E_Usuarios EU = new E_Usuarios();
        E_Usuarios SEU = new E_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        protected void Page_Load(object sender, EventArgs e)
        {

            EU = (E_Usuarios)Session["Usuario"];
            GvMaterias.DataSource = NU.BuscaMateriasDocente(EU.IdUsuario);
            GvMaterias.DataBind();
            if (GvMaterias.Rows.Count == 0)
                Master.ModalMsg("Error:No hay Materias Registradas");

        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {

        }
        protected void Agregar_Click(object sender, EventArgs e)
        {

        }
        protected void Eliminar_Click(object sender, EventArgs e)
        {


        }



        protected void ComprobarContra_Click(object sender, EventArgs e)
        {
            if (wuc_RepPassWord.Text == EU.PassWordUsuario)
            {
                E_Materias mat = (E_Materias)Session["MatFirmar"];
                E_RSA RSA = (E_RSA)Session["RSAFirmar"];
                E_Firma EF = NU.BuscaFirma(EU.IdUsuario);
                if (RSA.Status == 4)
                {
                    if (EF != null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalCorreo()", true);
                    }
                    else
                    {
                        Master.ModalMsg("Error: Usted no a subido una firma al sistema, favor de subir una en su perfil");
                    }
                }
                if (RSA.Status == 2)
                {
                    Master.ModalMsg("Error: Su coordinador aun no aprueba su RSA, no tiene permitido firmarlo");
                }

            }
            else
            {
                Master.ModalMsg("Error: Contraseña Incorrecta");
            }


        }
        protected void CorreoAlumno_Click(object sender, EventArgs e)
        {
            E_CodAlumno ECD = new E_CodAlumno();
            string Codigo = GenerarCodigo();
            try
            {

                MailMessage Email = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                Email.SubjectEncoding = Encoding.UTF8;
                Email.BodyEncoding = Encoding.UTF8;
                Email.From = new MailAddress("SedFiad@gmail.com", "Administrador del sistema");
                Email.Subject = "Codigo de Recuperacion de contraseña";
                Email.Body = "Hola nos solicitaste recuperar tu contraseña. EL codigo de verificacion es : " + Codigo;


                Email.To.Add(wuc_Email.Text);
                SmtpServer.Port = 587; //SMTP de GMAIL
                SmtpServer.Credentials = new NetworkCredential("SedFiad@gmail.com", "SEDFIAD@");      //Hay que crear las credenciales del correo emisor
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(Email);
                Session["Correo"] = Email;
                //lblMensaje.Text = "Mensaje Enviado";
            }
            catch (SmtpException ex)
            {
                //throw new Exception(lblMensaje.Text + ex);
            }
            E_RSA rsa = (E_RSA)Session["RSAFirma"];
            ECD.Codigo = Codigo.ToString();
            ECD.IdRSA = rsa.IdRSA;
            if (NU.InsertarCodAlumno(ECD).Contains("Exito"))
            {

            }
            Response.Redirect("Verificacion.aspx");

        }

        public string GenerarCodigo()
        {
            string Codigo = string.Empty;
            int i;

            Random rnd = new Random();
            for (i = 0; i < 5; i++)
                Codigo += Convert.ToChar(rnd.Next(65, 90)).ToString();

            return Codigo;
        }
        protected void GvMaterias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Llenar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdMateria = Convert.ToInt32(GvMaterias.DataKeys[index].Value.ToString());
                EM = new N_Usuarios().BuscaMateria(IdMateria);
                E_RSA ER = NU.BuscaRSA(EM.IdMateria);
                if (ER != null)
                {
                    switch (ER.Status)
                    {
                        case 1:
                            Session["Materia"] = EM;
                            Session["RSA"] = ER;
                            Session["Mensaje"] = "Llenar";
                            Response.Redirect("FormularioRSA.aspx");
                            break;
                        case 2:
                            Master.ModalMsg("Error: El RSA ya fue enviado, espere a la respuesta de su Coordinador");
                            break;
                        case 3:
                            if (ER != null)
                            {
                                Session["Materia"] = EM;
                                Session["RSA"] = ER;
                                Session["Mensaje"] = "Llenar";
                                Response.Redirect("FormularioRSA.aspx");
                            }
                            else
                            {
                                Master.ModalMsg("Error: La materia no tiene RSA registrado");
                            }

                            break;
                    }
                }
                else
                {
                    Session["Materia"] = EM;
                    Session["RSA"] = ER;
                    Session["Mensaje"] = "Llenar";
                    Response.Redirect("FormularioRSA.aspx");
                }



            }
            if (e.CommandName == "Firmar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdMateria = Convert.ToInt32(GvMaterias.DataKeys[index].Value.ToString());
                EM = new N_Usuarios().BuscaMateria(IdMateria);
                E_RSA ER = NU.BuscaRSA(EM.IdMateria);
                if (ER != null)
                {
                    if (ER.Status == 4)
                    {
                        Session["MatFirmar"] = EM;
                        Session["RSAFirmar"] = ER;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalContra()", true);
                    }
                }
            }

        }


        public void ModalPeticiones(string pMsg, EventHandler handler)
        {
            String[] TipoMsg = pMsg.Split(':');
            AtributosModalPeticiones(TipoMsg[0], handler);
            if (TipoMsg[0] == "Agregar")
            {
                AModalHeader.Attributes.Clear();
                AModalHeader.Attributes.Add("class", BackGroundHeader);
                AModalTitulo.InnerHtml = string.Format("{0}", TipoMsg[0]);
                AModalBody.InnerHtml = string.Format("{0}", TipoMsg[1]);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalAgregar()", true);
            }
            else
            {
                EModalHeader.Attributes.Clear();
                EModalHeader.Attributes.Add("class", BackGroundHeader);
                EModalTitulo.InnerHtml = string.Format("{0}", TipoMsg[0]);
                EModalBody.InnerHtml = string.Format("{0}", TipoMsg[1]);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalPeticion()", true);
            }


        }
        protected void AtributosModalPeticiones(string Tipo, EventHandler handler)
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

        protected void GvMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}