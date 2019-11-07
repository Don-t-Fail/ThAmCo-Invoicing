using System;

namespace AdminInvoices
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Invoiced { get; set; }
        public bool Dispatched { get; set; }
        public int CustomerId { get; set; }
    }
}
