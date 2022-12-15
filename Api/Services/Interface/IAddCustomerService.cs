using Api.Dtos.Customers;

namespace Api.Services.Interface
{
    public interface IAddCustomerService
    {
        Task<long> Create(AddCustomerDto request);
    }
}
