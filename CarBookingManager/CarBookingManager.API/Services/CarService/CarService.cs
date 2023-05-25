using AutoMapper;
using CarBookingManager.API.Dtos.Requests;
using CarBookingManager.API.Dtos.Responses;
using CarBookingManager.API.Exceptions;
using CarBookingManager.API.Models;
using CarBookingManager.API.Repositories.CarRepository;
using CarBookingManager.API.Repositories.ReservationRepository;
using System.Web.Http;

namespace CarBookingManager.API.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public CarService(ICarRepository carRepository, IMapper mapper,IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task AddAsync(CarRequest car)
        {
            if (await _carRepository.GetAsync(car.RegistrationNo) != null)
            {
                throw new DomainAlreadyExistException($"Car with registration number: {car.RegistrationNo} already exists.");
            }
            var carObject = _mapper.Map<Car>(car);
            await _carRepository.AddAsync(carObject);
        }

        public async Task<IEnumerable<CarReservationResponse>> GetAllAssignedAsync()
        {
            var reservation=await _reservationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarReservationResponse>>(reservation);  
        }
    }
}
