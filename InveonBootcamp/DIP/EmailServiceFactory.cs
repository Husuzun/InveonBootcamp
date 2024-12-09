using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.DIP
{
    public class EmailServiceFactory
    {
        private static INotificationService _instance;

        public INotificationService CreateNotificationService()
        {
            if( _instance == null)
            {
                _instance = new EmailService();
            }
            return _instance;
        }
    }
}
