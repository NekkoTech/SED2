using EntidadesGestionUsuarios;
using NegociosGestionUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Presentacion.GestionUsuarios
{
    public partial class EvaluarRSA : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Materias EM = new E_Materias();
        private string BackGroundHeader;
        private string BtnColor;
        E_Usuarios EU = new E_Usuarios();
        E_Usuarios SEU = new E_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        E_RSA ER = new E_RSA();
        E_RSADocumento rsa = new E_RSADocumento();
        protected void Page_Load(object sender, EventArgs e)
        {
            EM = (E_Materias)Session["Materia"];
            if (EM != null)
            {
                ER = (E_RSA)Session["RSA"];
                if (ER != null)
                {
                    EP = NU.BuscaPlanCoordinador(ER.IdCoordinador);
                    rsa = NU.BuscaDocumentoRSA(ER.IdRSA);
                    if (rsa != null)
                    {
                        Documento.Attributes["src"] = "..\\RSA\\" + EP.NombrePlan + "\\" + rsa.NombreRSA;
                        Documento.DataBind();
                    }
                    
                }
                else
                {
                    Response.Redirect("ListaRSA.aspx");
                }
            }
        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaEncuadres.aspx");
        }
        protected void BtnAceptado_Click(object sender, EventArgs e)
        {
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalAccept()", true);
        }
        protected void BtnRechazar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalObservaciones()", true);
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalCalif()", true);
        }
        protected void BtnEnviarRechazado_Click(object sender, EventArgs e)
        {
            ER.Status = 3;
            rsa.Calificacion = "0";
            rsa.Observaciones = tbObservaciones.Text;
            E_Materias Mat = NU.BuscaMateria(ER.IdMateria);
            E_Usuarios aux = NU.BuscaUsuario(EM.IdDocente);
            try
            {

                MailMessage Email = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                Email.SubjectEncoding = Encoding.UTF8;
                Email.BodyEncoding = Encoding.UTF8;
                Email.From = new MailAddress("SedFiad@gmail.com", "Administrador del sistema");
                Email.Subject = "Notificaciones SED: Estado de Encuadre";
                Email.Body = "Hola, te notificamos que tu encuadre de la materia "+Mat.Materia.ToLowerInvariant()+" ha sigo rechazado, le recomendamos que revise las observaciones y que vuelva a subirlo";


                Email.To.Add(aux.EmailUsuario);
                SmtpServer.Port = 587; //SMTP de GMAIL
                SmtpServer.Credentials = new NetworkCredential("SedFiad@gmail.com", "SEDFIAD@");      //Hay que crear las credenciales del correo emisor
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(Email);
                Master.ModalMsg(NU.ModificarRSA(ER));
                
            }
            catch (SmtpException ex)
            {
                Master.ModalMsg("Error: No se pudo enviar el correo");
            }

        }
        protected void BtnEnviarAceptado_Click(object sender, EventArgs e)
        {
            ER.Status = 4;
            rsa.Calificacion = TbCalificacion.Text;
            rsa.Observaciones = "";
            if (NU.ModificarRSA(ER).Contains("Exito") && NU.ModificarRSAPDF(rsa).Contains("Exito"))
            {
                //Master.ModalMsg("Exito: RSA evaluado con exito");
                Session["Notificacion"] = "Exito: RSA evaluado con exito";
                Response.Redirect("ListaRSA.aspx");
            }
        }
    }
}