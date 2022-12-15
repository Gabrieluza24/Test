using Api.Dtos.Customers;
using Api.Services.Interface;
using Domain.Entities;
using Domain.Interfaces;

namespace Api.Services.Services
{
    public class GetCustomersService : IGetCustomersService
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<List<CustomerDto>> GetAll()
        {
            try
            {
                List<Customer> Customerlist = _customerRepository.GetAll().ToList();
                List<CustomerDto> response = new List<CustomerDto>();

                foreach (Customer customer in Customerlist)
                {
                    CustomerDto obj = new CustomerDto();
                    obj.Id = customer.Id;
                    obj.Email = customer.Email;
                    obj.Phone = customer.Phone;
                    obj.Address = customer.Address;
                    obj.Fullname = customer.Fullname;
                    obj.BirthDate = customer.BirthDate;
                    response.Add(obj);
                }
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
