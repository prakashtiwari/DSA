using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsCol.DomailModels
{
    public class OperationResult
    {

        public OperationResult()
        {
        }

        public OperationResult(decimal Result, string message)
        {
            this.Result = Result;
            this.Message = Message;
        }
        public decimal Result { get; set; }
        public string Message { get; set; }

    }
}
