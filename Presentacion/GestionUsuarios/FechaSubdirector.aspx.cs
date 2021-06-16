using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.GestionUsuarios
{
    public partial class FechaSubdirector : System.Web.UI.Page
    {
        DateTime myDateTime = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                CInicio.SelectedDate = myDateTime;
        }

        protected void IBInicio_Click(object sender, ImageClickEventArgs e)
        {
            if (CInicio.Visible==true)
            {
                CInicio.Visible = false;
            }
            else
            {
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
                    case -1:

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