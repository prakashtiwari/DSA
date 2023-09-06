using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SOLIDDesignPrinciple.SRP
{
    public class RatingEngine
    {
        public decimal Rating;
        public int Rate()
        {
            //Resp1: Logging
            Console.WriteLine($"Rating started.");
            Console.WriteLine($"Rating loading.");
            string policyData = File.ReadAllText("SRP/PolicyData.json");
            var data = JsonSerializer.Deserialize<Policy>(policyData);

            switch (data.PolType)
            {

                case PolicyType.Auto:
                    //Do the extensive validation
                    break;
                case PolicyType.Environment:
                    //Do the extensive validation
                    break;
                case PolicyType.Health:
                    //Do the extensive validation
                    break;
                default:
                    break;
            }
            return 1;
        }
    }
}
