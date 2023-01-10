using DomainModels;
using FluentValidation;
using System;

namespace AppServices.Validators
{
    public class CustomersValidator : AbstractValidator<Customer>
    {
        public CustomersValidator()
        {
            RuleFor(customer => customer.FullName)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(customer => customer.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email inválido, formato esperado: xxxxx@xxxxx.xxx");
            
            RuleFor(customer => customer)
                .Must(customer => customer.Email == customer.EmailConfirmation)
                .WithMessage("Email e EmailConfirmation precisam ser iguais");
            
            RuleFor(customer => customer.Cpf)
                .NotEmpty()
                .IsValidCPF()
                .WithMessage("CPF inválido, formato esperado: 000.000.000-00");
            
            RuleFor(customer => customer.Cellphone)
                .NotEmpty()
                .Matches(@"\([0-9]{2}\)9[0-9]{4}-[0-9]{4}")
                .WithMessage("Número de Telefone inválido, formato esperado: (00)90000-0000");

            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now.AddYears(-18));
            
            RuleFor(customer => customer.EmailSms)
                .NotEmpty();
            
            RuleFor(customer => customer.Whatsapp)
                .NotEmpty();
            
            RuleFor(customer => customer.Country)
                .NotEmpty()
                .MinimumLength(3);
            
            RuleFor(customer => customer.City)
                .NotEmpty();
            
            RuleFor(customer => customer.PostalCode)
                .NotEmpty()
                .Matches(@"[0-9]{5}-[0-9]{3}")
                .WithMessage("CEP inválido, formato esperado: 00000-000");
            
            RuleFor(customer => customer.Address)
                .NotEmpty()
                .MinimumLength(3);
            
            RuleFor(customer => customer.Number)
                .NotNull();
        }
    }
}
