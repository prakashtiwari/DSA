namespace BuilderPattern.ImmutableBuilder
{
    public class Person
    {
        public string FisrtName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public IEnumerable<string> Childrens { get; private set; }
        public Person(string firstName, string lastName, string middleName, IEnumerable<string> children = null)
        {
            this.FisrtName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            Childrens = children;
        }
        public Person(Builder builder)
        {
            this.FisrtName = builder.FisrtName;
            this.LastName = builder.LastName;
            this.MiddleName = builder.MiddleName;
            this.Childrens = builder.childrens;
        }
        public void Show()
        {
            Console.WriteLine($"Name is {this.FisrtName + " " + " " + this.MiddleName+ " " + this.LastName}");
        }
        public class Builder
        {
            internal string FisrtName { get; private set; }
            internal string LastName { get; private set; }
            internal string MiddleName { get; private set; }
            internal IEnumerable<string> childrens
            {
                get; private set;
            }
            public Builder(string fName, string lName)
            {
                this.FisrtName = fName;
                this.LastName = lName;
            }
            public Builder AddMiddleName(string name)
            {
                MiddleName = name;
                return this;
            }
            public Builder AddChildren(IEnumerable<string> children)
            {
                childrens = children;
                return this;
            }
            public Person Build()
            {
                return new Person(this);
            }

        }
    }
}
