using Api.Dtos.Customers;

namespace Api.Services.Interface
{
    public interface IUpdateCustomerService
    {
        Task<CustomerDto> update(int id, UpdateCustomerDto request);
    }
}
