using Api.Dtos.Customers;
using Api.Services.Interface;
using Domain.Entities;
using Domain.Interfaces;

namespace Api.Services.Services
{
    public class DeleteCustomerService : IDeleteCustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<CustomerDto> remove(int id)
        {
            try
            {
                Customer customer = _customerRepository.GetById(id);

                CustomerDto response = new CustomerDto();
                response.Id = customer.Id;
                response.Fullname = customer.Fullname;
                response.Email = customer.Email;
                response.Address = customer.Address;
                response.Phone = customer.Phone;
                response.BirthDate = customer.BirthDate;

                _customerRepository.Remove(id);
                _customerRepository.SaveChanges();

                return Task.FromResult(response);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
