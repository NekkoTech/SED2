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

namespace Presentacion.GestionUsuarios
{
    public partial class ListaRSA: System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Materias EM = new E_Materias();
        private string BackGroundHeader;
        private string BtnColor;
        E_Usuarios EU = new E_Usuarios();
        E_Usuarios SEU = new E_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        E_Encuadres EE = new E_Encuadres();
        E_RSA ER = new E_RSA();
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
            if (Session["Notificacion"] != null)
                Master.ModalMsg((string)Session["Notificacion"]);
            //GvMaterias.DataSource = NU.LstBuscaMaterias(NU.BuscaPlanCoordinador(EU.IdUsuario).IdPlan);
            GvMaterias.DataSource = NU.LstMateriasInnerJoinRSA(EU.IdUsuario);
            if(!IsPostBack)
                GvMaterias.DataBind();
           //if (GvMaterias.Rows.Count == 0)
               // Master.ModalMsg("Error:No hay Materias Registradas");

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
            /*if (e.CommandName == "Consultar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdMateria = Convert.ToInt32(GvMaterias.DataKeys[index].Value.ToString());
                EM = new N_Usuarios().BuscaMateria(IdMateria);
                EM.IdMateria = IdMateria;
                Session["Materia"] = EM;
                Session["Mensaje"] = "Consultar";
                //Response.Redirect("EvaluarRSA.aspx");
            }*/
            if (e.CommandName == "Evaluar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdMateria = Convert.ToInt32(GvMaterias.DataKeys[index].Value.ToString());
                EM = new N_Usuarios().BuscaMateria(IdMateria);
                //EM.IdMateria = IdMateria;
                Session["Materia"] = EM;
                Session["Mensaje"] = "Evaluar";
                ER = NU.BuscaRSA(EM.IdMateria);
                if (ER != null)
                {
                    if (ER.Status == 2)
                    {
                        Session["RSA"] = ER;
                        Response.Redirect("EvaluarRSA.aspx");
                    }
                    else
                    {
                        Master.ModalMsg("Informacion: El encuadre ya fue evaluado");
                    }
                    if(ER.Status==1 || ER.Status == 0)
                    {
                        Master.ModalMsg("Error: El docente aun no a enviado el Documento RSA");
                    }
                    
                }
                
            }
            if (e.CommandName == "Descargar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdMateria = Convert.ToInt32(GvMaterias.DataKeys[index].Value.ToString());
                EM = new N_Usuarios().BuscaMateria(IdMateria);
                ER = NU.BuscaRSA(EM.IdMateria);
                if (ER != null)
                {
                    if (ER.Status == 5)
                    {
                        E_RSADocumento ED = NU.BuscaDocumentoRSA(ER.IdRSA);
                        string FilePath = Server.MapPath(ED.RSAUrl);
                        WebClient User = new WebClient();
                        Byte[] FileBuffer = User.DownloadData(FilePath);
                        if (FileBuffer != null)
                        {
                            Response.ContentType = "application/pdf";
                            Response.AppendHeader("Content-Disposition", "attachment; filename=RSA.pdf");
                            Response.TransmitFile(FilePath);
                            Response.End();
                        }
                    }
                    else
                    {
                        Master.ModalMsg("Error: Solo se puede realizar la descarga cuando el RSA se encuentra firmado");
                    }
                }
                else
                {
                    Master.ModalMsg("Error: Aun no se encuentra con registro Activo de RSA");
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