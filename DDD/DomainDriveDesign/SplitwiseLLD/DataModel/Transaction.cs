using SplitwiseLLD.DTO;

namespace SplitwiseLLD.DataModel
{
    public class Transaction
    {
        public UserDTO From { get; set; }
        public UserDTO To { get; set; }

        public int Amount { get; set; }

        public Transaction(UserDTO from, UserDTO to, int amount)
        {
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }
    }
}
