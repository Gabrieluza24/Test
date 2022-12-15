namespace Api.Dtos.Customers
{
    public class AddCustomerResponseDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
