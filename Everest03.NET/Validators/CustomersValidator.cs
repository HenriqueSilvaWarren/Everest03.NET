using FluentValidation;

namespace Everest03.NET.Validators
{
    public class CustomersValidator : AbstractValidator<Customer>
    {
        public CustomersValidator()
        {
            RuleFor(customer => customer.FullName).NotNull();
            RuleFor(customer => customer.Email).NotNull().EmailAddress();
            RuleFor(customer => customer.EmailConfirmation).NotNull().EmailAddress().Equal(customer => customer.Email);
            RuleFor(customer => customer.Cpf).NotNull().IsValidCPF();
            RuleFor(customer => customer.Cellphone).NotNull();
            RuleFor(customer => customer.DateOfBirth).NotNull();
            RuleFor(customer => customer.EmailSms).NotNull();
            RuleFor(customer => customer.Whatsapp).NotNull();
            RuleFor(customer => customer.Country).NotNull();
            RuleFor(customer => customer.City).NotNull();
            RuleFor(customer => customer.PostalCode).NotNull();
            RuleFor(customer => customer.Address).NotNull();
            RuleFor(customer => customer.Number).NotNull();
        }
    }
}
