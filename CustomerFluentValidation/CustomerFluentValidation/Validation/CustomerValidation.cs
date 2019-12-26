using CustomerFluentValidation.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerFluentValidation.Validation
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            
            //customer
            RuleFor(customer => customer.Surname).NotNull();

            // foreach and re-use of order validation.
            RuleForEach(x => x.Orders).Where(x => x.Amount != 0).SetValidator(new OrderValidation());

            // with name
            RuleFor(x => x.Surname).NotEmpty().WithName("Last Name");

            // with parameters
            RuleFor(x => x.Surname).NotEmpty().WithMessage(cust => $"Last Name must not be empty :{cust.Forename}");

            // condition
            RuleFor(x => x.Discount).GreaterThan(10).When(x => x.isPrefered).WithMessage("Discount must not be greaterthan");

            // must
            RuleFor(x => x.Orders).Must(BeOver18).WithMessage("No more than 10 orders are allowed.")
                .ForEach(orderRule =>
                {
                    orderRule.Must(Order => Order.Total > 0).WithMessage("Orders must have a total of more than 0");
                });

            //When & Otherwise
            When(x => x.isPrefered, () =>
              {
                  RuleFor(x => x.Discount).GreaterThan(0);
              }).Otherwise(() =>
              {
                  RuleFor(cust => cust.Address != null);
              });

            //CascadeMode
            RuleFor(x => x.Address).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEqual("");
        }

        protected bool BeOver18(List<Order> date)
        {
            return true;
        }
    }
}
