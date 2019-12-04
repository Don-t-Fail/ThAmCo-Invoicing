using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminInvoices
{
    public class Order
    {
        public int Id { get; set; }

        public bool Invoiced { get; set; }

        public bool Dispatched { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int? InvoiceId { get; set; }

        

        //array of products in order??

        //total cost?
    }
}
