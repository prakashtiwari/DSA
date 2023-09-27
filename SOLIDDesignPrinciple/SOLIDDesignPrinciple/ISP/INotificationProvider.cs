using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDDesignPrinciple.ISP
{
    public interface INotificationProvider
    {
        void SendTextMessage();
        void SendMail();
    }
    //public interface INotificationProvider : ITextNotificationProvider, IEmailNotificationProvider
    //{


    //}
}
