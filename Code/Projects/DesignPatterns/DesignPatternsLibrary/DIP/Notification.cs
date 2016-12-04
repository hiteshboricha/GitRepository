using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLibrary.DIP
{
    public class Notification
    {
        private INotification _messages;

        public Notification()
        {

        }

        public Notification(INotification Message)
        {
            this._messages = Message;
        }

        public void SendNotification()
        {
            _messages.SendNotification();
        }
            
    }
}
