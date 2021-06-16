using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;

namespace Presentacion.GestionUsuarios
{
    public partial class ListaEncuadres : System.Web.UI.Page
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
            GvMaterias.DataSource = NU.LstMateriasInnerJoinEncuadre(EU.IdUsuario);
            GvMaterias.DataBind();
            //if (GvMaterias.Rows.Count == 0)
                //Master.ModalMsg("Error:No hay Materias Registradas");

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

        protected void GvMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvMaterias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Consultar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdMateria = Convert.ToInt32(GvMaterias.DataKeys[index].Value.ToString());
                EM = new N_Usuarios().BuscaMateria(IdMateria);
                EM.IdMateria = IdMateria;
                Session["Materia"] = EM;
                Session["Mensaje"] = "Consultar";
                Response.Redirect("EncuadreCoordinador.aspx");
            }
            if (e.CommandName == "Evaluar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdMateria = Convert.ToInt32(GvMaterias.DataKeys[index].Value.ToString());
                EM = new N_Usuarios().BuscaMateria(IdMateria);
                //EM.IdMateria = IdMateria;
                Session["Materia"] = EM;
                Session["Mensaje"] = "Evaluar";
                EE = NU.BuscaEncuadre(EM.IdMateria);
                if (EE != null)
                {
                    if (EE.EstadoEncuadre == 2)
                    {
                        Session["Encuadre"] = EE;
                        Response.Redirect("EvaluarEncuadre.aspx");
                    }
                    if (EE.EstadoEncuadre ==1)
                    {
                        Master.ModalMsg("Informacion: El docente no ha enviado el encuadre");
                    }
                    else
                    {
                        Master.ModalMsg("Informacion: El encuadre ya fue evaluado");
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
        /*protected void btnBuscar_Click(object sender, EventArgs e)
        {
            GvPlanes.DataSource = NU.LstBuscaPlan(TbSearch.Text.ToString());
            GvPlanes.DataBind();
        }*/

    }
}