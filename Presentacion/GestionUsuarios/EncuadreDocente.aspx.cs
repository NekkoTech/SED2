using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegociosGestionUsuarios;
using EntidadesGestionUsuarios;
using System.Drawing;
using System.IO;
using System.Net;

namespace Presentacion.GestionUsuarios
{
    public partial class EncuadreDocente : System.Web.UI.Page
    {
        E_Usuarios EU = new E_Usuarios();
        N_Usuarios NU = new N_Usuarios();
        E_Materias EM = new E_Materias();
        E_Encuadres EE = new E_Encuadres();
        E_PlanEstudio EP = new E_PlanEstudio();
        List<E_Atributos> LEA = new List<E_Atributos>();
        List<string> ListAport = new List<string>();
        List<E_AtribMateria> ListEM = new List<E_AtribMateria>();
        List<DropDownList> ListDdl = new List<DropDownList>();
        List<Controles.wuc_Text_SR> ListTb = new List<Controles.wuc_Text_SR>();
        private string BackGroundHeader;
        private string BtnColor;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["Usuario"] == null)
                Response.Redirect("ValidaUsuario.aspx");
            else
            {
                EU = (E_Usuarios)Session["Usuario"];
                switch (EU.IdTipoUsuario)
                {
                    case 3:
                        Response.Redirect("InicioCoordinador.aspx");
                        break;
                    case 2:
                        Response.Redirect("InicioSubdirector.aspx");
                        break;
                }
            }
            EM = (E_Materias)Session["Materia"];
            if (EM!=null)
            {
                EE = (E_Encuadres)Session["Encuadre"];
                if (EE != null)
                {
                    EP = NU.BuscaPlanCoordinador(EE.IdCoordinador);
                    ListEM = NU.LstAtribMateria();
                    LEA = NU.BuscaAtributos(EP.IdPlan);
                    Encuadre.Attributes["src"] = "..\\Encuadres\\" + EP.NombrePlan + "\\" + EE.NombreEncuadre;
                    Encuadre.DataBind();
                    if (!IsPostBack)
                    {
                        switch (EE.EstadoEncuadre)
                        {
                            case 1:LblIntento.Text = "Aun no a sido enviado";
                                LblIntento.CssClass = "form-control bg-warning hover";
                                break;
                            case 2:
                                LblIntento.Text = "Encuadre Enviado";
                                LblIntento.CssClass = "form-control bg-info hover";
                                break;
                            case 3:
                                LblIntento.Text = "Encuadre Rechazado";
                                LblIntento.CssClass = "form-control  bg-danger hover";
                                break;
                            case 4:
                                LblIntento.Text = "Encuadre Aceptado";
                                LblIntento.CssClass = "form-control bg-success hover";
                                break;
                        }
                        LblCalificacion.Text = "Calificacion:" + EE.Calificacion;
                        tbObservaciones.Text = EE.Observaciones;
                        tbObservaciones.Enabled = false;
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
                        
                    }
                    
                }
                
            }
            

            
            

        }


        protected void BtnSubir_Click(object sender, EventArgs e)
        {
           
        }
        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            
        }
        public void ModalPeticiones(string pMsg)
        {
            String[] TipoMsg = pMsg.Split(':');
            AtributosModalPeticiones(TipoMsg[0]);
            EModalHeader.Attributes.Clear();
            EModalHeader.Attributes.Add("class", BackGroundHeader);
            EModalTitulo.InnerHtml = string.Format("{0}", TipoMsg[0]);
            EModalBody.InnerHtml = string.Format("{0}", TipoMsg[1]);
            BtnCancelar.Attributes.Add("class", BtnColor);
            BtnCancelar.Attributes.Add("class", Clr.BtnPeligro);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalPeticion()", true);


        }
        protected void AtributosModalPeticiones(string Tipo)
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


        protected void BtnVer_Click(object sender, EventArgs e)
        {
            
            string FilePath = Server.MapPath("..\\Encuadres\\"+EP.NombrePlan+"\\"+EE.NombreEncuadre);
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }
        protected void BtnDescargar_Click(object sender, EventArgs e)
        {

            string FilePath = Server.MapPath("..\\Encuadres\\" + EP.NombrePlan + "\\" + EE.NombreEncuadre);
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Encuadre.pdf");
                Response.TransmitFile(FilePath);
                Response.End();
            }
        }
        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaMateriasDocente.aspx");
        }

        protected void BtnSubirEncuadre_Click(object sender, EventArgs e)
        {
            EP = NU.BuscaPlanMateria(EM.IdMateria);
            E_Fecha EF = NU.BuscaFechaPlanEstudio(EP.IdPlan);
            int f = (int)(DateTime.Now - EF.FechaFinal).TotalDays;
            if (f < 0)
            {
                if (EE.EstadoEncuadre == 1 || EE.EstadoEncuadre == 3)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openMasterModalFU()", true);
                }
                else
                {
                    Master.ModalMsg("Informacion: Ya a enviado un encuadre espere la respuesta del coordinador");
                }
            }
            else
            {
                Master.ModalMsg("Error: La fecha para subir los archivos ya paso");
            }
            
        }

        protected void BtnGuardarModal_Click(object sender, EventArgs e)
        {
            if (EE.EstadoEncuadre == 1 || EE.EstadoEncuadre == 3)
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
                    string fileName = EE.NombreEncuadre;
                    string pathToCheck = folder + "\\" + fileName;
                    string tempfileName = "";
                    
                    savePath += "\\" + fileName;
                    FUModal.SaveAs(savePath);
                    EE.EstadoEncuadre = 2;
                    EE.Calificacion = "";
                    EE.Observaciones = "";
                    LblIntento.Text = "Encuadre Enviado";
                    LblIntento.CssClass = "form-control bg-info hover";
                    Master.ModalMsg(NU.ModificarEncuadre(EE));
                }
            }
            else
            {
                Master.ModalMsg("Informacion: Ya a enviado un encuadre espere la respuesta del coordinador");
            }
            
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
    }
}