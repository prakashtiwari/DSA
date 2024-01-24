using PenLLD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenLLD.DataModel
{
    public class FountainPen : Pen
    {
        public FountainPen(IWriteBehaviour writeBehaviour   ) : base(PenType.FountainPen,writeBehaviour)
        { }
        public override Color GetColor()
        {
            throw new NotImplementedException();
        }

        public  void Write()
        {
            throw new NotImplementedException();
        }
    }
}
