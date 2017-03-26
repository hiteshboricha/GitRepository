using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLibrary.Factory
{
    public class Scooter : IFactory
    {
        public string Drive(int miles)
        {
            return "Drive the Scooter : " + miles.ToString() + "km";
        }
    }
}
