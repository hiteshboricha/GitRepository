using DesignPatternsLibrary.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Factory
{
    public partial class FactoryPattern : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VehicleFactory factory = new ConcreteVehicleFactory();

            IFactory scooter = factory.GetVehicle(typeof(Scooter));
            scooter.Drive(5);
        }
    }
}