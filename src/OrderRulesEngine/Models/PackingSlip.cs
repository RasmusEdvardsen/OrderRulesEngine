using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Models
{
    public class PackingSlip
    {
        public Guid Id { get; set; }
        public string Recipient { get; set; } // NOTE: Out of scope. Should be an object.

        public PackingSlip(string recipient)
        {
            Id = Guid.NewGuid();
            Recipient = recipient;
        }

        public PackingSlip(Guid guid, string recipient)
        {
            Id = guid;
            Recipient = recipient;
        }
    }
}
