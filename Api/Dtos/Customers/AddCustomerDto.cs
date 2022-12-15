namespace Api.Dtos.Customers
{
    public class AddCustomerDto
    {
        string Fullname { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        DateTime BirthDate { get; set; }
    }
}
