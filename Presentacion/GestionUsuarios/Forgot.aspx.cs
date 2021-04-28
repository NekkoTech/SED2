using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;

namespace Presentacion.GestionUsuarios
{
    public partial class Forgot : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Codigo EC= new E_Codigo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void EnviaEmail(string pEmailDestino)
        {
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


                Email.To.Add(pEmailDestino);
                SmtpServer.Port = 587; //SMTP de GMAIL
                SmtpServer.Credentials = new NetworkCredential("SedFiad@gmail.com", "SEDFIAD@");      //Hay que crear las credenciales del correo emisor
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(Email);
                Session["Correo"] = Email;
                lblMensaje.Text = "Mensaje Enviado";
            }
            catch (SmtpException ex)
            {
                throw new Exception(lblMensaje.Text + ex);
            }
            
            EC.Codigo = Codigo.ToString();
            EC.EmailUsuario = pEmailDestino.ToString();
            NU.InsertarCodigo(EC);
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

        protected void BtnSolicitar_Click(object sender, EventArgs e)
        {
            E_Usuarios EU = NU.BuscaUsuario(tbEmailUsuario.Text.Trim());
            if (EU!=null)
            {
                EnviaEmail(tbEmailUsuario.Text);
            }
            else
            {
                lblMensaje.Text = "El correo electronico no esta registrado";
            }
        }
    }
}