using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLibrary.DIP
{
    public class SMS : INotification
    {
        public string MobileNumber { get; set; }

        public void SendNotification()
        {
            //Send SMS
        }
    }
}
