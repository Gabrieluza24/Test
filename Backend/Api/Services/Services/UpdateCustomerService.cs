using Api.Dtos.Customers;
using Api.Services.Interface;
using Domain.Entities;
using Domain.Interfaces;

namespace Api.Services.Services
{
    public class UpdateCustomerService : IUpdateCustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Task<CustomerDto> update(int id, UpdateCustomerDto request)
        {
            try
            {
                Customer customer = _customerRepository.GetById(id);
                customer.Email = request.Email;
                customer.Phone = request.Phone;
                customer.Address = request.Address;
                customer.Fullname = request.Fullname;
                customer.BirthDate = request.BirthDate;
                customer.UpdatedAt = DateTime.Now;

                _customerRepository.Update(customer);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
