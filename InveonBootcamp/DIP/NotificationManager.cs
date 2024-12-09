using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.DIP
{
    public class NotificationManager
    {
        private INotificationService _notificationService;

        public NotificationManager(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void Notify(string message)
        {   
            _notificationService.SendEmail(message);
        }
    }
}
