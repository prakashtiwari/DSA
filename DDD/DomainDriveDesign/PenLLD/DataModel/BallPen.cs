using PenLLD.Interface;

namespace PenLLD.DataModel
{
    public class BallPen :  Pen, IRefillPen
    {
        public BallPen(IWriteBehaviour writeBehaviour) : base(PenType.BallPen,writeBehaviour)
        { }

        public void ChangeRefill(Refill refill)
        {
            throw new NotImplementedException();
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

        public  void Write()
        {
            throw new NotImplementedException();
        }
    }
}
