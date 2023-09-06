using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDDesignPrinciple.SRP
{
    public class Policy
    {
        public PolicyType PolType { get; set; }
        public string PolicyName { get; set; }
        public string Validity { get; set; }        
    }
}
