using CustomerFluentValidation.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerFluentValidation.Validation
{
    public class OrderValidation: AbstractValidator<Order>
    {
        public OrderValidation()
        {
            RuleFor(order=>order.Id).NotNull();
        }
    }
}
