﻿using System;
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
    public partial class ListaPlanEstudio : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        private string BackGroundHeader;
        private string BtnColor;
        private List<E_Atributos> ListAtrib= new List<E_Atributos>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Eliminar"] != null)
            {
                string msg = Session["Eliminar"].ToString();
                if (msg == "Exito: Los Atributos y los Planes fueron exitosamente Eliminados")
                {
                    Master.ModalMsg("Exito: Los Atributos y los Planes fueron exitosamente Eliminados");
                    Session["Eliminar"] = null;
                }
            }
            if (GvPlanes.Rows.Count == 0)
            {
                ModalPeticiones("Agregar:No hay Planes de Estudio Registrados",Agregar_Click);
            }
            
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Session["Mensaje"] = "Agregar";
            Response.Redirect("IbmPlanEstudio.aspx");
        }
        protected void Agregar_Click(object sender, EventArgs e)
        {
            Response.Write(((Button)sender).Parent.ID);
            Session["Mensaje"] = "Agregar";
            Response.Redirect("IbmPlanEstudio.aspx");
        }
        protected void Eliminar_Click(object sender, EventArgs e)
        {
            EP =(E_PlanEstudio) Session["Plan"];
            ListAtrib = NU.BuscaAtributos(EP.IdPlan);
            int i = 0;
            foreach(E_Atributos a in ListAtrib)
            {
                string msg= NU.EliminarAtributo(a);
                i++;
                if(msg== "Error: No se pudo eliminado el atributo.")
                {
                    Master.ModalMsg("Error: No se pudo eliminar el atributo");
                    break;
                }
                else
                {
                    if (i >= ListAtrib.Count)
                    {
                        msg=NU.EliminarPlan(EP);
                        Session["Eliminar"] = "Exito: Los Atributos y los Planes fueron exitosamente Eliminados";
                        Response.Redirect("ListaPlanEstudio.aspx");
                    }
                }
            }
        }

        protected void GvPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvPlanes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdPlan = Convert.ToInt32(GvPlanes.DataKeys[index].Value.ToString());
                EP = new N_Usuarios().BuscaPlanes(IdPlan);
                EP.IdPlan = IdPlan;
                Session["Plan"] = EP;
                Session["Mensaje"] = "Modificar";
                Response.Redirect("IbmPlanEstudio.aspx");
            }
            if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdPlan = Convert.ToInt32(GvPlanes.DataKeys[index].Value.ToString());
                EP = new N_Usuarios().BuscaPlanes(IdPlan);
                Session["Plan"] = EP;
                ModalPeticiones("Eliminar:Seguro que Desea Eliminar el Plan " + EP.NombrePlan,Agregar_Click);
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

    }
}