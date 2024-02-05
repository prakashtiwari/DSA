namespace SplitwiseLLD.DataModel
{
    public class Expense
    {
        public string ExpenseDescription { get; set; }
        public User CreatedBY { get; set; }

        public List<User> Admin { get; set; }
     
    }
}
