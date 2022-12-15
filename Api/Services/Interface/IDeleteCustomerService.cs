using Api.Dtos.Customers;

namespace Api.Services.Interface
{
    public interface IDeleteCustomerService
    {
        Task<CustomerDto> remove(int id);
    }
}
