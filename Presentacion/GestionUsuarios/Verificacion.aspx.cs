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
    public partial class Verificacion : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Codigo EC = new E_Codigo();
        MailMessage Email = new MailMessage();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Email = (MailMessage)Session["Correo"];

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            EC=NU.BuscaCodigo(Email.To.ToString());
            if (tbCodigo.Text.ToString() == EC.Codigo)
            {
                Session["Codigo"] = EC;
                Session["Correo"] = EC.EmailUsuario.ToString();
                Response.Redirect("NuevaContraseña.aspx");
            }
            else
            {
                LblMsg.Text = "El codigo de verificacion es incorrecto";
            }
        }
    }
}