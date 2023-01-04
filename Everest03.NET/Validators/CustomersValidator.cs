﻿using FluentValidation;
using System;

namespace Everest03.NET.Validators
{
   

    public class CustomersValidator : AbstractValidator<Customer>
    {
        public CustomersValidator()
        {
            RuleFor(customer => customer.FullName).NotEmpty().MinimumLength(8);
            RuleFor(customer => customer.Email).NotEmpty().EmailAddress();
            RuleFor(customer => customer).Must(customer => customer.Email == customer.EmailConfirmation).WithMessage("Email e EmailConfirmation precisam ser iguais");
            RuleFor(customer => customer.Cpf).NotEmpty().IsValidCPF();
            RuleFor(customer => customer.Cellphone).NotEmpty().Matches(@"\([0-9]{2}\)[0-9]{5}-[0-9]{4}");
            RuleFor(customer => customer.DateOfBirth).NotEmpty().LessThanOrEqualTo(DateTime.Now.AddYears(-18));
            RuleFor(customer => customer.EmailSms).NotEmpty();
            RuleFor(customer => customer.Whatsapp).NotEmpty();
            RuleFor(customer => customer.Country).NotEmpty().MinimumLength(4);
            RuleFor(customer => customer.City).NotEmpty();
            RuleFor(customer => customer.PostalCode).NotEmpty().Matches(@"[0-9]{5}-[0-9]{3}");
            RuleFor(customer => customer.Address).NotEmpty().MinimumLength(10);
            RuleFor(customer => customer.Number).NotNull();
        }
    }
}
