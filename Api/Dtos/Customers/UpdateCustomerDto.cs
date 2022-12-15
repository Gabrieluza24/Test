namespace Api.Dtos.Customers
{
    public class UpdateCustomerDto
    {
        string Fullname { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        DateTime BirthDate { get; set; }
    }
}
