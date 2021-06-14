using EntidadesGestionUsuarios;
using NegociosGestionUsuarios;
using Presentacion.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.GestionUsuarios
{
    public partial class FormularioRSA2 : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Materias EM = new E_Materias();
        private string BackGroundHeader;
        private string BtnColor;
        E_Usuarios EU = new E_Usuarios();
        E_Usuarios SEU = new E_Usuarios();
        E_PlanEstudio EP = new E_PlanEstudio();
        List<E_Atributos> LEA = new List<E_Atributos>();
        E_RSA ER = new E_RSA();
        List<wuc_Text_SR> ListTb = new List<wuc_Text_SR>();
        List<E_Porcentajes> ListEPO = new List<E_Porcentajes>();
        E_Porcentajes EPO = new E_Porcentajes();

        protected void Page_Load(object sender, EventArgs e)
        {
            ER = (E_RSA)Session["RSA"];
            EU = (E_Usuarios)Session["Usuario"];
            EM = (E_Materias)Session["Materia"];
            EP = NU.BuscaPlanCoordinador(ER.IdCoordinador);
            if (ER != null)
            {
                LEA = NU.BuscaAtributos(EP.IdPlan);
                LlenaAtributos(LEA);
                if (ER.Status == 1)
                {
                    ListEPO = NU.BuscaPorcentajes(ER.IdRSA);
                    if (ListEPO.Count > 0)
                    {
                        if (!IsPostBack)
                            LlenaCampos();
                    }
                    
                }
                
            }
        }
        protected void LlenaAtributos(List<E_Atributos> ListAtrib)
        {
            LlenaTbList();
            for (int i = 0; i < ListAtrib.Count; i++)
            {
                ListTb[i].Text = ListAtrib[i].Atributo;
            }
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

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            LlenaPorcentajes();
            Session["ListaEPO"] = ListEPO;
            Response.Redirect("FormularioRSA3.aspx");
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            LlenaPorcentajes();
            
            if (ER.Status == 1)
            {
                if (NU.ModificarRSA(ER).Contains("Exito"))
                {
                    List<E_Porcentajes> LEP = NU.BuscaPorcentajes(ER.IdRSA);
                    foreach (E_Porcentajes P in ListEPO)
                    {
                        string[] tect = P.Tecnica.Split('-');
                        if (tect[0] != "")
                        {
                            if (LEP.Count!=0)
                            {
                                string msg=NU.ModificarPorcentajes(P);
                            }
                            else
                            {
                                string msg=NU.InsertarPorcentajes(P);
                            }
                            
                        }
                    }
                }
            }
            if (ER.Status == 0)
            {
                ER.Status = 1;
                if (NU.InsertarRSA(ER).Contains("Exito"))
                {
                    foreach ( E_Porcentajes P in ListEPO)
                    {
                        string[] tect = P.Tecnica.Split('-');
                        if (tect[0] != "")
                        {
                            NU.InsertarPorcentajes(P);
                        }
                    }
                }
            }
            
            
        }

        private void LlenaPorcentajes()
        {
            ListEPO.Clear();
            EPO = new E_Porcentajes();
            EPO.IdAtributo = LEA[0].IdAtributo;
            EPO.Tecnica = TbTecnica1.Text+"-1";
            EPO.Porcentaje = Tb11.Text + "-" + Tb12.Text + "-" + Tb13.Text + "-" + Tb14.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

            EPO = new E_Porcentajes();
            EPO.IdAtributo = LEA[1].IdAtributo;
            EPO.Tecnica = TbTecnica2.Text + "-2";
            EPO.Porcentaje = Tb21.Text + "-" + Tb22.Text + "-" + Tb23.Text + "-" + Tb24.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

            EPO = new E_Porcentajes();
            EPO.IdAtributo = LEA[2].IdAtributo;
            EPO.Tecnica = TbTecnica3.Text + "-3";
            EPO.Porcentaje = Tb31.Text + "-" + Tb32.Text + "-" + Tb33.Text + "-" + Tb34.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

            EPO = new E_Porcentajes();
            EPO.IdAtributo = LEA[3].IdAtributo;
            EPO.Tecnica = TbTecnica4.Text + "-4";
            EPO.Porcentaje = Tb41.Text + "-" + Tb42.Text + "-" + Tb43.Text + "-" + Tb44.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

            EPO = new E_Porcentajes();
            EPO.IdAtributo = LEA[4].IdAtributo;
            EPO.Tecnica = TbTecnica5.Text + "-5";
            EPO.Porcentaje = Tb51.Text + "-" + Tb52.Text + "-" + Tb53.Text + "-" + Tb54.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

            EPO = new E_Porcentajes();
            EPO.IdAtributo = LEA[5].IdAtributo;
            EPO.Tecnica = TbTecnica6.Text + "-6";
            EPO.Porcentaje = Tb61.Text + "-" + Tb62.Text + "-" + Tb63.Text + "-" + Tb64.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);

            EPO = new E_Porcentajes();
            EPO.IdAtributo = LEA[6].IdAtributo;
            EPO.Tecnica = TbTecnica7.Text + "-7";
            EPO.Porcentaje = Tb71.Text + "-" + Tb72.Text + "-" + Tb73.Text + "-" + Tb74.Text;
            EPO.IdRSA = ER.IdRSA;
            ListEPO.Add(EPO);
            
        }
        
        private void LlenaCampos()
        {
            foreach(E_Porcentajes p in ListEPO)
            {
                string[] tect = p.Tecnica.Split('-');
                string[] port; 
                switch (tect[1])
                {
                    case "1":
                        port= p.Porcentaje.Split('-');
                        TbTecnica1.Text = tect[0];
                        Tb11.Text = port[0];
                        Tb12.Text = port[1];
                        Tb13.Text = port[2];
                        Tb14.Text = port[3];
                        break;
                    case "2":
                        port = p.Porcentaje.Split('-');
                        TbTecnica2.Text = tect[0];
                        Tb21.Text = port[0];
                        Tb22.Text = port[1];
                        Tb23.Text = port[2];
                        Tb24.Text = port[3];
                        break;
                    case "3":
                        port = p.Porcentaje.Split('-');
                        TbTecnica3.Text = tect[0];
                        Tb31.Text = port[0];
                        Tb32.Text = port[1];
                        Tb33.Text = port[2];
                        Tb34.Text = port[3];
                        break;
                    case "4":
                        port = p.Porcentaje.Split('-');
                        TbTecnica4.Text = tect[0];
                        Tb41.Text = port[0];
                        Tb42.Text = port[1];
                        Tb43.Text = port[2];
                        Tb44.Text = port[3];
                        break;
                    case "5":
                        port = p.Porcentaje.Split('-');
                        TbTecnica5.Text = tect[0];
                        Tb51.Text = port[0];
                        Tb52.Text = port[1];
                        Tb53.Text = port[2];
                        Tb54.Text = port[3];
                        break;
                    case "6":
                        port = p.Porcentaje.Split('-');
                        TbTecnica6.Text = tect[0];
                        Tb61.Text = port[0];
                        Tb62.Text = port[1];
                        Tb63.Text = port[2];
                        Tb64.Text = port[3];
                        break;
                    case "7":
                        port = p.Porcentaje.Split('-');
                        TbTecnica7.Text = tect[0];
                        Tb71.Text = port[0];
                        Tb72.Text = port[1];
                        Tb73.Text = port[2];
                        Tb74.Text = port[3];
                        break;
                }
            }
        }

    }
}