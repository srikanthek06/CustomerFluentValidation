using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerFluentValidation.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Total { get; set; }

    }
}
