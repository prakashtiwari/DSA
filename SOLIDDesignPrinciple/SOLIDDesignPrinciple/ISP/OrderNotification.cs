using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDDesignPrinciple.ISP
{
    public class OrderNotification : INotificationProvider
    {
        public void SendMail()
        {
            Console.WriteLine("Sending e-Mail!");
        }

        public void SendTextMessage()
        {
            Console.WriteLine("Sending text message!");
        }
    }
}
