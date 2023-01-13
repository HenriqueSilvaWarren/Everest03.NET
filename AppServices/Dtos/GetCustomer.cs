namespace AppServices.Dtos
{
    public class GetCustomerDto
    {
        public GetCustomerDto(
           long id,
           string fullName,
           string email,
           string cellphone,
           string city,
           string postalCode
           )
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Cellphone = cellphone;
            City = city;
            PostalCode = postalCode;
        }
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
