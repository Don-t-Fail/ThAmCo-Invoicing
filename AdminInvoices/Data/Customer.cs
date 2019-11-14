using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AdminInvoices
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public List<Order> Orders { get; set; }

    }
}
