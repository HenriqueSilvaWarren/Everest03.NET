namespace Everest03.NET.Validators
{
    using FluentValidation;
    public class CustomersValidator : AbstractValidator<Customers>
    {
        public CustomersValidator()
        {
            RuleFor(customer => customer.FullName).NotNull();
            RuleFor(customer => customer.Email).NotNull();
            RuleFor(customer => customer.EmailConfirmation).NotNull().Equal(customer => customer.Email);
            RuleFor(customer => customer.Cpf).NotNull();
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
