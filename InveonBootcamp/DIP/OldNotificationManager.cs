using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.DIP
{
    public class OldNotificationManager
    {
        private OldEmailService _oldEmailService = new OldEmailService();
        public void Notify(string message)
        {
            _oldEmailService.SendEmail(message);
        }
    }
} 