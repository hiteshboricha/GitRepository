using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLibrary.Factory
{
    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IFactory GetVehicle(Type t)
        {
            if(t.GetType() == typeof(Scooter))
            {
                return new Scooter();
            }
            else if (t.GetType() == typeof(Bike))
            {
                return new Bike();
            }
            else
            {
                throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", t.ToString()));
            }
        }
    }
}
