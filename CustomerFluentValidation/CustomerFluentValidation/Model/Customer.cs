using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerFluentValidation.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; } = "Channel 11";
        public decimal Discount { get; set; }
        public string Address { get; set; }
        public bool isPrefered { get; set; }
        public List<Order> Orders { get; set; }

    }
}
