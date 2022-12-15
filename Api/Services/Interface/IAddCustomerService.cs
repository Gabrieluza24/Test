using Api.Dtos.Customers;

namespace Api.Services.Interface
{
    public interface IAddCustomerService
    {
        Task<CustomerDto> Create(AddCustomerDto request);
    }
}
