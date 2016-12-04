using DesignPatternsLibrary.DIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.DIP
{
    public partial class DependencyInversion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            INotification sms = new SMS();
            sms.SendNotification();
        }
    }
}