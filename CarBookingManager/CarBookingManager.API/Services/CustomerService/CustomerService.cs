using AutoMapper;
using CarBookingManager.API.Dtos.Requests;
using CarBookingManager.API.Dtos.Responses;
using CarBookingManager.API.Exceptions;
using CarBookingManager.API.Models;
using CarBookingManager.API.Repositories.CustomerRepository;
using System.Web.Http;

namespace CarBookingManager.API.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(CustomerRequest customerRequest)
        {
            if (await _customerRepository.GetAsync(customerRequest.PersonalNo) != null)
            {
                throw new DomainAlreadyExistException($"Customer with personal no:{customerRequest.PersonalNo} already exists.");           
            }

            var customerObject = _mapper.Map<Customer>(customerRequest);
            await _customerRepository.AddAsync(customerObject);
        }

        public async Task DeleteAsync(string personalNo)
        {
            var customer = await _customerRepository.GetAsync(personalNo);
            if (customer == null)
            {
                throw new DomainNotFoundException($"Customer with personal no:{personalNo} not exists.");
            }
            await _customerRepository.DeleteAsync(customer);
        }

        public async Task<IEnumerable<CustomerResponse>> GetAllAsync()
        {
            var customers= await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerResponse>>(customers);
        }

        public async Task UpdateAsync(CustomerRequest customerRequest)
        {
            var customer = await _customerRepository.GetAsync(customerRequest.PersonalNo);
            if (customer == null)
            {        
                     throw new DomainNotFoundException($"Customer with personal no:{customerRequest.PersonalNo} not exists.");
            }

            var customerObject=_mapper.Map<Customer>(customerRequest);

            await _customerRepository.UpdateAsync(customerObject);
        }
    }
}
