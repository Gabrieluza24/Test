using Api.Dtos.Customers;
using Api.Services.Interface;
using Domain.Interfaces;

namespace Api.Services.Services
{
    public class AddCustomerService : IAddCustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public AddCustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<long> Create(AddCustomerDto request)
        {
            throw new NotImplementedException();
        }
    }
}
