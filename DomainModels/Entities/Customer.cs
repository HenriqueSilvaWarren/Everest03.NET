using System;

namespace DomainModels.Entities
{
    public class Customer
    {
        public Customer(
            string fullName,
            string email,
            string cpf,
            string cellphone,
            DateTime dateOfBirth,
            string country,
            string city,
            string postalCode,
            string address,
            int number
            )
        {
            FullName = fullName;
            Email = email;
            Cpf = cpf;
            Cellphone = cellphone;
            DateOfBirth = dateOfBirth;
            Country = country;
            City = city;
            PostalCode = postalCode;
            Address = address;
            Number = number;
        }
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
    }
}