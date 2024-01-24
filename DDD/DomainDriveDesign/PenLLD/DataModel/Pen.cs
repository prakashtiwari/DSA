using PenLLD.Interface;

namespace PenLLD.DataModel
{
    public abstract class Pen
    {
        private string _name;
        private string _brand;
        private int _price;
        private PenType _penType;
        IWriteBehaviour writeBehaviour;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {

                _name = value;
            }
        }
        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {

                _brand = value;
            }
        }
        public int Price { get { return _price; } set { _price = value; } }

        public Pen(PenType type, IWriteBehaviour writeBehaviour)
        {
            Type = type;
            this.writeBehaviour = writeBehaviour;
        }

        public PenType Type { get; set; }
        public abstract Color GetColor();
        public  void Write()
        {
            writeBehaviour.Write();
        }
    }
}
