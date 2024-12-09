using InveonBootcamp.DIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp
{
    public class DIPTest
    {
        public static void Run()
        {
            Console.WriteLine("\nDIP\n");
            
            OldNotificationManager oldNotificationManager = new OldNotificationManager();
            string test = "test";
            oldNotificationManager.Notify(test);

            string test2 = "test2";
            var emailServiceFactory = new EmailServiceFactory();
            var notificationManager = new NotificationManager(emailServiceFactory.CreateNotificationService());
            notificationManager.Notify(test2);
        }
    }
}
