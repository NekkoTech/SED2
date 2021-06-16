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
    public partial class FechaSubdirector : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        E_Fecha EF = new E_Fecha();
        DateTime myDateTime = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {
            EF = NU.BuscaGlobal();
            if (EF != null)
            {
                if (!IsPostBack)
                {
                    CInicio.SelectedDate = EF.FechaInicial;
                    tbInicio.Text = CInicio.SelectedDate.ToShortDateString();
                    CFinal.SelectedDate = EF.FechaFinal;
                    tbFinal.Text = CFinal.SelectedDate.ToShortDateString();
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    CInicio.SelectedDate = myDateTime;
                    tbInicio.Text = CInicio.SelectedDate.ToShortDateString();
                }
            }
            
                
        }

        protected void IBInicio_Click(object sender, ImageClickEventArgs e)
        {
            if (CInicio.Visible==true)
            {
                CInicio.Visible = false;
            }
            else
            {
                //CInicio.SelectedDate = myDateTime;
                CInicio.Visible = true;
            }
        }
        protected void IBFinal_Click(object sender, ImageClickEventArgs e)
        {
            if (CFinal.Visible == true)
            {
                CFinal.Visible = false;
            }
            else
            {
                CFinal.Visible = true;
            }
        }
        protected void CInicio_SelectionChanged(object sender,EventArgs e)
        {
            tbInicio.Text = CInicio.SelectedDate.ToShortDateString();
            CInicio.Visible = false;
        }
        protected void CFinal_SelectionChanged(object sender, EventArgs e)
        {
            tbFinal.Text = CFinal.SelectedDate.ToShortDateString();
            CFinal.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime date1, date2;
        
            if(tbInicio.Text!="" && tbFinal.Text != "")
            {
                date1 = Convert.ToDateTime(tbInicio.Text).Date;
                date2 = Convert.ToDateTime(tbFinal.Text).Date;
                int i = DateTime.Compare(date1, date2);
                switch (i)
                {
                    case -1:EF = NU.BuscaGlobal();
                        if (EF == null)
                        {
                            EF = new E_Fecha();
                            EF.FechaInicial = new DateTime(date1.Year,date1.Month,date1.Day);
                            EF.FechaFinal = new DateTime(date2.Year, date2.Month, date2.Day);
                            EF.isGlobal = 1;
                            if (NU.InsertarFecha(EF).Contains("Exito"))
                                Master.ModalMsg("Exito: Fecha Ingresada");
                        }
                        else
                        {
                            EF.FechaInicial = date1;
                            EF.FechaFinal = date2;
                            //EF.Global = 1;
                            if (NU.ModificarFecha(EF).Contains("Exito"))
                                Master.ModalMsg("Exito: Fecha Ingresada");
                        }
                        
                        break;
                    case 0:
                        Master.ModalMsg("Error: Las fechas son iguales");
                        break;
                    case 1:
                        Master.ModalMsg("Error: La fecha Iniciar es mayor que la Fecha final");
                        break;
                }
                
            }
            else
            {
                Master.ModalMsg("Error: Selecciona Las fechas de inicio y final");
            }
            
        }
    }
}