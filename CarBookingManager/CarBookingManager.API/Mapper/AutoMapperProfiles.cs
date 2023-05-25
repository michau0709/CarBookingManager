using AutoMapper;
using CarBookingManager.API.Dtos.Requests;
using CarBookingManager.API.Dtos.Responses;
using CarBookingManager.API.Models;

namespace CarBookingManager.API.Mapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CarRequest, Car>();
            CreateMap<CustomerRequest, Customer>();
            CreateMap<Customer, CustomerResponse>();
            CreateMap<ReservationRequest, Reservation>()
                .ForMember(dest => dest.PersonalNo, opt => opt.MapFrom(src => src.CustomerPersonalNo));
            CreateMap<Reservation, ReservationResponse>();
            CreateMap<Reservation, ReservationCustomerResponse>()
        .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.Car.Model));
            CreateMap<Reservation, CarReservationResponse>();
           
        }
    }
}
