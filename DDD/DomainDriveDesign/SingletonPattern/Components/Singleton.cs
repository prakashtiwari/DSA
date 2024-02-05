using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern.Components
{
    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object padlock = new object();

        private Singleton()
        {
            Console.WriteLine("Construction");
        }

        /// <summary>
        /// Naive
        /// </summary>
        //public static Singleton Instance
        //{
        //    get
        //    {
        //        return _instance ??= new Singleton();
        //    }
        //}

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {

                            _instance = new Singleton();
                        }
                    }
                }

                Console.WriteLine("Resue");
                return _instance;


            }
        }
    }
}
