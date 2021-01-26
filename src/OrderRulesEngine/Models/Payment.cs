using OrderRulesEngine.Models;

namespace OrderRulesEngine
{
    public class Payment
    {
        public PaymentType Type { get; set; }
        public string Recipient { get; set; }

        public Payment(PaymentType type, string recipient)
        {
            Type = type;
            Recipient = recipient;
        }
    }
}