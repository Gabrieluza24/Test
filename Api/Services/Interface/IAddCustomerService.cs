using Api.Dtos.Customers;

namespace Api.Services.Interface
{
    public interface IAddCustomerService
    {
        Task<AddCustomerResponseDto> Create(AddCustomerDto request);
    }
}
