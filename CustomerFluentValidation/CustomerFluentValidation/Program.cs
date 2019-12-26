using CustomerFluentValidation.Model;
using CustomerFluentValidation.Validation;
using System;

namespace CustomerFluentValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            CustomerValidation validator = new CustomerValidation();

            var results = validator.Validate(customer);
            if(!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    Console.WriteLine($"Property: {error.PropertyName} faliled validation. Error was: {error.ErrorMessage}");
                }
            }
            Console.ReadLine();
        }
    }
}
