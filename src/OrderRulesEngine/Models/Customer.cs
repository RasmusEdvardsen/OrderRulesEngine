namespace OrderRulesEngine
{
    public class Customer
    {
        public string Email { get; set; }
        public Customer(string email)
        {
            // should check if valid email.
            Email = email;
        }

        // NOTE: out of scope: Id, Name, Address, etc.
    }
}