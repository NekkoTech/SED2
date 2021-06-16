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
    public partial class ListaMaterias : System.Web.UI.Page
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
            if (Session["Usuario"] == null)
            {
                Response.Redirect("ValidaUsuario.aspx");
            }
            else
            {
                SEU = (E_Usuarios)Session["Usuario"];
                if (SEU.IdTipoUsuario == 3)
                {
                    EP = NU.BuscaPlanCoordinador(SEU.IdUsuario);
                    if (EP == null)
                    {
                        Response.Redirect("InicioCoordinador.aspx");
                        Session["NoPlan"] = "No existe plan";
                    }
                    if (EP != null)
                        Session["IdPlan"] = EP.IdPlan;

                }
                
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

            if (Session["Eliminar"] != null)
            {
                string msg = Session["Eliminar"].ToString();
                if (msg == "Exito: Los Atributos y los Planes fueron exitosamente Eliminados")
                {
                    Master.ModalMsg("Exito: La Materia fue eliminada");
                    Session["Eliminar"] = null;
                }
            }
            EP = NU.BuscaPlanCoordinador(EU.IdUsuario);
            if (EP != null)
            {
                GvMaterias.DataSource = NU.LstBuscaMaterias(NU.BuscaPlanCoordinador(EU.IdUsuario).IdPlan);
                GvMaterias.DataBind();
                if (GvMaterias.Rows.Count == 0)
                {
                    ModalPeticiones("Agregar:No hay Materias Registradas", Agregar_Click);
                }
            }
            else
            {
                Master.ModalMsg("Error: Aun no esta registrado en un Plan de Estudio");
            }
            
            
        }

        

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Session["Mensaje"] = "Agregar";
            Response.Redirect("IbmMateria.aspx");
        }
        protected void Agregar_Click(object sender, EventArgs e)
        {
            Response.Write(((Button)sender).Parent.ID);
            Session["Mensaje"] = "Agregar";
            Response.Redirect("IbmMateria.aspx");
        }


        protected void Eliminar_Click(object sender, EventArgs e)
        {
            EM =(E_Materias) Session["Materia"];
            List<E_Atributos> LEA = NU.BuscaAtributos((int)Session["IdPlan"]);
            List<E_Encuadres> LEE = NU.BuscaEncuadreMateria(EM.IdMateria);
            E_RSA ER = NU.BuscaRSA(EM.IdMateria);
            if (ER != null)
            {
                NU.EliminarRSA(ER);
                E_RSADocumento ERD = NU.BuscaDocumentoRSA(ER.IdRSA);
                List<E_Porcentajes> LEP = NU.BuscaPorcentajes(ER.IdRSA);
                foreach (E_Porcentajes c in LEP)
                {
                    NU.EliminarPorcentajes(c);
                }
                NU.EliminarRSAPDF(ERD.IdRSADocumento);
            }

            int i = 0;
            foreach (E_Atributos a in LEA)
            {
                if (NU.EliminarAtributoMateria(EM.IdMateria, a.IdAtributo).Contains("Exito"))
                {
                    i++;
                }
                else
                {
                    Master.ModalMsg("Error: Las Aportaciones no pudieron ser eliminadas");
                }
            }
            foreach (E_Encuadres b in LEE)
            {
                NU.EliminarEncuadre(b.IdEncuadre);
            }
            if (NU.EliminarMateria(EM).Contains("Exito"))
            {
                Master.ModalMsg("Exito: La Materia fue eliminada");
            }
            else
            {
                Master.ModalMsg("Error: La materia no pudo ser eliminada");
            }
        }



















        protected void GvMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvMaterias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdMateria = Convert.ToInt32(GvMaterias.DataKeys[index].Value.ToString());
                EM = new N_Usuarios().BuscaMateria(IdMateria);
                EM.IdMateria = IdMateria;
                Session["Materia"] = EM;
                Session["Mensaje"] = "Modificar";
                Response.Redirect("IbmMateria.aspx");
            }
            if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdMateria = Convert.ToInt32(GvMaterias.DataKeys[index].Value.ToString());
                EM = new N_Usuarios().BuscaMateria(IdMateria);
                EM.IdMateria = IdMateria;
                Session["Materia"] = EM;
                ModalPeticiones("Eliminar:Seguro que Desea Eliminar la Materia " + EM.Materia,Agregar_Click);
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