using System;

namespace AdminInvoices
{
    public class Invoice
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public bool Sent { get; set; }
        
    }
}
