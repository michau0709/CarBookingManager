
using AutoMapper;
using CarBookingManager.API.Dtos.Requests;
using CarBookingManager.API.Dtos.Responses;
using CarBookingManager.API.Models;
using CarBookingManager.API.Repositories.CarRepository;
using CarBookingManager.API.Repositories.CustomerRepository;
using CarBookingManager.API.Repositories.ReservationRepository;

namespace CarBookingManager.API.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository,ICarRepository carRepository,ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository= customerRepository;
            _carRepository = carRepository;
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ReservationRequest reservationRequest)
        {
           var customer=await _customerRepository.GetAsync(reservationRequest.CustomerPersonalNo);
            if(customer==null)
            {
                throw new DomainNotFoundException("Customer not found.");
            }

            var car = await _carRepository.GetAsync(reservationRequest.RegistrationNo);
            if (car == null)
            {
                throw new DomainNotFoundException("Car not found.");
            }

            var reservation = _mapper.Map<Reservation>(reservationRequest);
    
            await _reservationRepository.AddAsync(reservation);
        }

        public async Task<IEnumerable<ReservationResponse>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ReservationResponse>>(await _reservationRepository.GetAllAsync());
        
        }
    }
}
