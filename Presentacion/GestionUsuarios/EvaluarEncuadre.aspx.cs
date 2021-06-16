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
    public partial class EvaluarEncuadre : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Materias EM = new E_Materias();
        private string BackGroundHeader;
        private string BtnColor;
        E_Usuarios EU = new E_Usuarios();
        E_Usuarios SEU = new E_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        E_Encuadres EE = new E_Encuadres();
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
                    case 4:
                        Response.Redirect("InicioDocente.aspx");
                        break;
                    case 2:
                        Response.Redirect("InicioSubdirector.aspx");
                        break;
                }
            }
            string Msg = (string)Session["Mensaje"];
            EM =(E_Materias) Session["Materia"];
            if (EM != null)
            {
                EE = (E_Encuadres)Session["Encuadre"];
                if (EE != null)
                {
                    EP = NU.BuscaPlanCoordinador(EE.IdCoordinador);
                    Encuadre.Attributes["src"] = "..\\Encuadres\\" + EP.NombrePlan + "\\" + EE.NombreEncuadre;
                    Encuadre.DataBind();
                }
                else
                {
                    Response.Redirect("ListaEncuadres.aspx");
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
            EE.EstadoEncuadre = 3;
            EE.Calificacion = "0";
            EE.Observaciones = tbObservaciones.Text;
            E_Materias Mat = NU.BuscaMateria(EE.IdMateria);
            E_Usuarios aux = NU.BuscaUsuario(EM.IdDocente);
            try
            {
                if (EE.Observaciones != string.Empty)
                {
                    MailMessage Email = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    Email.SubjectEncoding = Encoding.UTF8;
                    Email.BodyEncoding = Encoding.UTF8;
                    Email.From = new MailAddress("SedFiad@gmail.com", "Administrador del sistema");
                    Email.Subject = "Notificaciones SED: Estado de Encuadre";
                    Email.Body = "Hola, te notificamos que tu encuadre de la materia " + Mat.Materia.ToLowerInvariant() + " ha sigo rechazado, le recomendamos que revise las observaciones y que vuelva a subirlo";


                    Email.To.Add(aux.EmailUsuario);
                    SmtpServer.Port = 587; //SMTP de GMAIL
                    SmtpServer.Credentials = new NetworkCredential("SedFiad@gmail.com", "SEDFIAD@");      //Hay que crear las credenciales del correo emisor
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(Email);
                    Master.ModalMsg(NU.ModificarEncuadre(EE));

                }
                else
                {
                    Master.ModalMsg("Llene el campo de observaciones para darle retroalimentacion al Docente");
                }

            }
            catch (SmtpException ex)
            {
                Master.ModalMsg("Error: No se pudo enviar el correo");
            }

        }
        protected void BtnEnviarAceptado_Click(object sender, EventArgs e)
        {
            EE.EstadoEncuadre = 4;
            EE.Calificacion = TbCalificacion.Text;
            EE.Observaciones = "";
            Master.ModalMsg(NU.ModificarEncuadre(EE));
        }
    }
}