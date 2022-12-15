using Api.Dtos.Customers;
using Api.Services.Interface;
using Domain.Entities;
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

        public Task<CustomerDto> Create(AddCustomerDto request)
        {
            Customer customer = new Customer();

            customer.Fullname = request.Fullname;
            customer.Email = request.Email;
            customer.Address = request.Address;
            customer.Phone = request.Phone;
            customer.BirthDate = request.BirthDate;
            customer.CreatedAt = DateTime.Now;

            _customerRepository.Add(customer);
            _customerRepository.SaveChanges();

            CustomerDto response = new CustomerDto();
            response.Id = customer.Id;
            response.Fullname = customer.Fullname;
            response.Email = customer.Email;
            response.Address = customer.Address;
            response.Phone = customer.Phone;
            response.BirthDate = customer.BirthDate;
            return Task.FromResult(response);
        }
    }
}
