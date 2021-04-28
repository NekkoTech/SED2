using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Controles
{
    public partial class wuc_Text : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Text
        {
            get { return tbTexto.Text.ToUpper().Trim(); }
            set { tbTexto.Text = value; }
        }
        public bool Enabled
        {
            set { tbTexto.Enabled = value; }
        }
    }
}