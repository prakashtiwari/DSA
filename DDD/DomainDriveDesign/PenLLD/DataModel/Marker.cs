using PenLLD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenLLD.DataModel
{
    public class Marker : Pen
    {
        public Marker(IWriteBehaviour writeBehaviour) : base(PenType.Marker,writeBehaviour)
        { 
        }
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
