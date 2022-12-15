using Api.Dtos.Customers;

namespace Api.Services.Interface
{
    public interface IGetCustomersService
    {
        Task<List<CustomerDto>> GetAll();
    }
}
