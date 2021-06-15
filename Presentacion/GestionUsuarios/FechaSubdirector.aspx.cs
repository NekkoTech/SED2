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
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}