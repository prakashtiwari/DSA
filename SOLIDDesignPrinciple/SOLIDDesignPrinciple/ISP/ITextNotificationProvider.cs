﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDDesignPrinciple.ISP
{
    public interface ITextNotificationProvider
    {
        void SendTextMessage();
    }
}