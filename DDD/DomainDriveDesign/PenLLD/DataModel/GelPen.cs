using PenLLD.Common;
using PenLLD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenLLD.DataModel
{
    public class GelPen : Pen, IRefillPen
    {
        public Refill refil;
        public bool canChangeRefil = false;
        private GelPen(IWriteBehaviour writeBehaviour) : base(PenType.GelPen,writeBehaviour)
        { }

        public bool ChangeRefill(Refill refill)
        {
           return  this.canChangeRefil;
        }

        public override Color GetColor()
        {
            throw new NotImplementedException();
        }

        public Refill GetRefill()
        {
            throw new NotImplementedException();
        }

        public bool IsRefillable()
        {
            throw new NotImplementedException();
        }

        

        void IRefillPen.ChangeRefill(Refill refill)
        {
            throw new NotImplementedException();
        }

        public class Builder
        {

            internal static Refill refill;
            internal static bool canChangeRefil = false;
            internal static Builder builder;
            public  Builder SetRefil(Refill refl)
            {
                builder=new Builder();
                refill = refl;
                return builder;
            }
            public  Builder CanChangeRefil(bool val)
            {
                canChangeRefil = val;
                return builder;
            }
            public  GelPen Build()
            {
                GelPen gelPen = new GelPen(new SmoothWriteBehaviour());
                gelPen.refil = Builder.refill;
                gelPen.canChangeRefil = Builder.canChangeRefil;
                return gelPen;
            }
        }
    }
}
