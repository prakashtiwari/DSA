﻿using System;
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
            //Resp2: Loading data
            string policyData = File.ReadAllText("SRP/PolicyData.json");
            //Resp3: Deserialize data.
            var data = JsonSerializer.Deserialize<Policy>(policyData);
            switch (data.PolicyType)
            {
                //Resp4: Business rules based on policy.
                case PolicyType.Auto:
                    Console.WriteLine($"Evaluating the Auto polict");
                    Console.WriteLine($"Validating policy");
                    if (string.IsNullOrEmpty(data.Make))
                    {
                        Console.WriteLine($"Make should be provided.");
                        return 1;
                    }
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
