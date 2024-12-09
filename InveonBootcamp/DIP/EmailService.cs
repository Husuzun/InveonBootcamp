using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.DIP
{
    public class EmailService : INotificationService
    {
        public void SendEmail(string message)
        {
            Console.WriteLine("Email gönderildi: " + message);
        }
    }
}
