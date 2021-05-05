using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Controles
{
    public partial class wuc_CrearUsuarioPassWord : System.Web.UI.UserControl
    {
        public string Text
        {
            get { return tbPassWord.Text.Trim(); }
            set { tbPassWord.Text = value; }
        }
        public bool Enabled
        {
            set { tbPassWord.Enabled = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                this.tbPassWord.Attributes.Add("value", this.tbPassWord.Text);
            }
        }
    }
}