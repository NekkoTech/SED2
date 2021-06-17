using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;
using Presentacion.Controles;
using System.IO;

namespace Presentacion.GestionUsuarios
{

    public partial class EncuadreCoordinador : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Usuarios SEU = new E_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        List<E_Atributos> LEA = new List<E_Atributos>();
        E_Materias EM = new E_Materias();
        List<string> ListAport = new List<string>();
        List<E_AtribMateria> ListEM = new List<E_AtribMateria>();
        List<DropDownList> ListDdl = new List<DropDownList>();
        List<wuc_Text_SR> ListTb = new List<wuc_Text_SR>();
        private string BackGroundHeader;
        private string BtnColor;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("ValidaUsuario.aspx");
            SEU = (E_Usuarios)Session["Usuario"];
            switch (SEU.IdTipoUsuario)
            {
                case 1:
                    Response.Redirect("InicioMain.aspx");
                    break;
                case 4:
                    Response.Redirect("InicioDocente.aspx");
                    break;
                case 2:
                    Response.Redirect("InicioSubdirector.aspx");
                    break;
            }
            EP = NU.BuscaPlanCoordinador(SEU.IdUsuario);
            LEA = NU.BuscaAtributos(EP.IdPlan);
            EM = (E_Materias)Session["Materia"];
            if (!IsPostBack)
            {
                if (Session["Materia"] != null)
                {
                    NU.LlenaDropDown(DdlDocentes, "Docente");
                    if (Session["Mensaje"].ToString() == "Consultar")
                    {
                        LlenaAtributos(LEA);
                        tbNombre.Text = EM.Materia;
                        tbNombre.Enabled = false;
                        tbClave.Text = EM.Clave;
                        tbClave.Enabled = false;
                        DdlSemestre.SelectedValue = EM.Semestre.ToString();
                        DdlSemestre.Enabled = false;
                        DdlDocentes.SelectedValue = EM.IdDocente.ToString();
                        DdlDocentes.Enabled = false;
                        ListEM = NU.LstAtribMateria();
                        LlenaDdlList();
                        if (ListEM != null)
                        {
                            int i = 0;
                            foreach (E_AtribMateria AM in ListEM)
                            {
                                if (AM.IdMateria == EM.IdMateria)
                                {
                                    ListDdl[i].SelectedValue = AM.Aportacion;
                                    ListDdl[i].Enabled = false;
                                    i++;
                                }
                            }
                        }
                    }
                    if (Session["Mensaje"].ToString() == "Evaluar")
                    {

                    }
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
        protected void BtnGuardarModal_Click(object sender, EventArgs e)
        {
            HttpPostedFile HpfFirma = FUModal.PostedFile;
            if (FUModal.HasFile)
            {
                string savePath = "..\\Encuadres\\";
                var folder = Server.MapPath(savePath + "\\" + EP.NombrePlan);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);

                }
                savePath = folder;
                string fileName = EM.Clave + "-" + EM.Materia.Trim() + ".pdf";
                string pathToCheck = folder + "\\" + fileName;
                string tempfileName = "";
                if (System.IO.File.Exists(pathToCheck))
                {
                    int counter = 2;
                    while (System.IO.File.Exists(pathToCheck))
                    {
                        tempfileName = counter.ToString() + fileName;
                        pathToCheck = savePath + tempfileName;
                        counter++;
                    }

                    fileName = tempfileName;
                    Master.ModalMsg("Error: Existe un Archivo con el Mismo Nombre");
                }
                else
                {
                    Master.ModalMsg("Exito: El Archivo fue agregado con exito");
                }
                savePath += "\\" + fileName;
                FUModal.SaveAs(savePath);
                E_Encuadres EE = NU.BuscaEncuadre(EM.IdMateria);
                if (EE != null)
                {
                    EE.NombreEncuadre = fileName;
                    EE.UrlEncuadre = savePath;
                    EE.EstadoEncuadre = 2;
                    if (EE.EstadoEncuadre == 3 || EE.EstadoEncuadre == 3)
                    {
                        Master.ModalMsg(NU.ModificarEncuadre(EE));
                    }

                }
                else
                {
                    Master.ModalMsg(NU.InsertaEncuadre(fileName, savePath, EM.IdMateria, SEU.IdUsuario));
                }
                
                
            }

        }
        protected void BtnSubirEncuadre_Click(object sender, EventArgs e)
        {
            E_Fecha EF = NU.BuscaFechaPlanEstudio(EP.IdPlan);
            if (EF != null)
            {
                int f = (int)(DateTime.Now - EF.FechaFinal).TotalDays;
                if (f < 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalFU()", true);
                }
                else
                {

                    Master.ModalMsg("Error:La fecha para entrega de encuadres ya expiro");
                }
            }
            else
            {
                Master.ModalMsg("Error:No ha ingresado la fecha de entrega");
            }

        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
           
            
        }

        protected void LlenaAtributos(List<E_Atributos> ListAtrib)
        {
            LlenaTbList();
            for (int i = 0; i < ListAtrib.Count; i++)
            {
                ListTb[i].Enabled = false;
                ListTb[i].Text = ListAtrib[i].Atributo;
            }
        }
        protected List<string> ListaAportaciones()
        {
            List<string> ListAport = new List<string>();
            LEA = NU.BuscaAtributos((int)Session["IdPlan"]);
            switch (LEA.Count)
            {
                case 1:
                    ListAport.Add(DdlAtrib1.SelectedValue);

                    break;
                case 2:
                    ListAport.Add(DdlAtrib1.SelectedValue);
                    ListAport.Add(DdlAtrib2.SelectedValue);
                    break;
                case 3:
                    ListAport.Add(DdlAtrib1.SelectedValue);
                    ListAport.Add(DdlAtrib2.SelectedValue);
                    ListAport.Add(DdlAtrib3.SelectedValue);

                    break;
                case 4:
                    ListAport.Add(DdlAtrib1.SelectedValue);
                    ListAport.Add(DdlAtrib2.SelectedValue);
                    ListAport.Add(DdlAtrib3.SelectedValue);
                    ListAport.Add(DdlAtrib4.SelectedValue);
                    break;
                case 5:
                    ListAport.Add(DdlAtrib1.SelectedValue);
                    ListAport.Add(DdlAtrib2.SelectedValue);
                    ListAport.Add(DdlAtrib3.SelectedValue);
                    ListAport.Add(DdlAtrib4.SelectedValue);
                    ListAport.Add(DdlAtrib5.SelectedValue);
                    break;
                case 6:
                    ListAport.Add(DdlAtrib1.SelectedValue);
                    ListAport.Add(DdlAtrib2.SelectedValue);
                    ListAport.Add(DdlAtrib3.SelectedValue);
                    ListAport.Add(DdlAtrib4.SelectedValue);
                    ListAport.Add(DdlAtrib5.SelectedValue);
                    ListAport.Add(DdlAtrib6.SelectedValue);
                    break;
                case 7:
                    ListAport.Add(DdlAtrib1.SelectedValue);
                    ListAport.Add(DdlAtrib2.SelectedValue);
                    ListAport.Add(DdlAtrib3.SelectedValue);
                    ListAport.Add(DdlAtrib4.SelectedValue);
                    ListAport.Add(DdlAtrib5.SelectedValue);
                    ListAport.Add(DdlAtrib6.SelectedValue);
                    ListAport.Add(DdlAtrib7.SelectedValue);
                    break;
            }
            return ListAport;
        }
        protected void LlenaDdlList()
        {
            ListDdl.Clear();
            ListDdl.Add(DdlAtrib1);
            ListDdl.Add(DdlAtrib2);
            ListDdl.Add(DdlAtrib3);
            ListDdl.Add(DdlAtrib4);
            ListDdl.Add(DdlAtrib5);
            ListDdl.Add(DdlAtrib6);
            ListDdl.Add(DdlAtrib7);
        }
        protected void LlenaTbList()
        {
            ListTb.Clear();
            ListTb.Add(wuc_Text1);
            ListTb.Add(wuc_Text2);
            ListTb.Add(wuc_Text3);
            ListTb.Add(wuc_Text4);
            ListTb.Add(wuc_Text5);
            ListTb.Add(wuc_Text6);
            ListTb.Add(wuc_Text7);
        }
        public void ModalPeticiones(string pMsg)
        {
            String[] TipoMsg = pMsg.Split(':');
            AtributosModalPeticiones(TipoMsg[0]);
            EModalHeader.Attributes.Clear();
            EModalHeader.Attributes.Add("class", BackGroundHeader);
            EModalTitulo.InnerHtml = string.Format("{0}", TipoMsg[0]);
            EModalBody.InnerHtml = string.Format("{0}", TipoMsg[1]);
            BtnRegresarModal.Attributes.Add("class", BtnColor);
            BtnGuardarModal.Attributes.Add("class", BtnColor);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalPeticion()", true);
        }
        protected void AtributosModalPeticiones(string Tipo)
        {
            switch (Tipo)
            {
                case "Modificar":
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