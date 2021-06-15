using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;
using System.Net.Mail;

namespace Presentacion.GestionUsuarios
{
    public partial class AccesoAlumnos : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_CodAlumno EC = new E_CodAlumno();
        MailMessage Email = new MailMessage();
        protected void Page_Load(object sender, EventArgs e)
        {
            Email = (MailMessage)Session["Correo"];

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            EC = NU.BuscaCodAlumno(tbCodigo.Text.ToString());

            if (EC != null)
            {
                Session["Codigo"] = EC;
                
                Response.Redirect("FirmaAlumno.aspx");
            }
            else
            {
                LblMsg.Text = "El codigo de verificacion es incorrecto";
            }
           
        }
    }
}