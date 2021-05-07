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
    public partial class EliminarUsuario : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["Usuario"]==null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }*/
            if (Session["UsuarioSeleccionado"] != null)
            {
                EU = (E_Usuarios)Session["UsuarioSeleccionado"];
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

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaUsuarios.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if (Session["UsuarioSeleccionado"] != null)
            {
                EU = (E_Usuarios)Session["UsuarioSeleccionado"];
                
            
                if (NU.BorraUsuario(EU.IdUsuario).Contains("Exito"))
                {
                    Master.ModalMsg("Exito: El usuario fue eliminado Exitosamente"); 
                    //Response.Redirect("ListaUsuarios.aspx");
                
                }
                else
                {
                    Master.ModalMsg("Error: El usuario no pude ser eliminado");
                    //lblRespuesta.Text = "El usuario no pudo ser eliminado";
                }
            }
        }
    }
}