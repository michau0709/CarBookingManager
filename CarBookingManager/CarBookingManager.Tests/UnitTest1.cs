using CarBookingManager.API.Controllers;
using CarBookingManager.API.Dtos.Requests;
using CarBookingManager.API.Repositories.CarRepository;
using CarBookingManager.API.Services.CarService;
using CarBookingManager.API.Services.CustomerService;
using CarBookingManager.API.Services.ReservationService;
using CarBookingManager.API.Validators;
using FakeItEasy;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CarBookingManager.Tests
{
    public class Tests
    {
        private ICustomerService _customerService;
        private ICarService _carService;
        private IReservationService _reservationService;

        private IValidator<CarRequest> _carValidator;
        private IValidator<CustomerRequest> _customerValidator;
        private IValidator<ReservationRequest> _reservationValidator;

        [SetUp]
        public void Setup()
        {
            _carService = A.Fake<ICarService>();
            _reservationService = A.Fake<IReservationService>();
            _customerService= A.Fake<ICustomerService>();

            _carValidator = new CarRequestValidator();
            _customerValidator = new CustomerRequestValidator();
            _reservationValidator = new ReservationRequestValidator();
        }

        [Test]
        public async Task Cars_Year_Cannot_Be_Feature_Year()
        {
            //Arange  

            var controller = new CarController(_carService, _carValidator);
            var car = new API.Dtos.Requests.CarRequest()
            {
                Fuel = API.Models.Enums.FuelType.Petrol,
                Model = "BMW",
                Power = 204,
                Price = 200,
                RegistrationNo = "ZS 101010",
                Year = 2030
            };
            //Act
            var actionResult = await controller.Add(car);
            var result = actionResult as IStatusCodeActionResult;

            //Assert
            Assert.That(result!.StatusCode,Is.EqualTo(400));
        }

        [Test]
        public async Task Customer_FirstName_And_LastName_CannotBeEmpty()
        {
            //Arrange
            var controller = new CustomerController(_customerService, _customerValidator);
            var customer = new API.Dtos.Requests.CustomerRequest()
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                PersonalNo = string.Empty
            };
            //Act
            var actionResult = await controller.Add(customer);
            var result = actionResult as IStatusCodeActionResult;

            //Assert
            Assert.That( result!.StatusCode,Is.EqualTo(400));

        }

        [Test]
        public async Task Reservation_StartDate_Cant_Be_Higher_Than_EndDate()
        {
            //Arrange
            var controller = new ReservationController(_reservationService, _reservationValidator);
            var reservation = new API.Dtos.Requests.ReservationRequest()
            {
                DateFrom = DateTime.UtcNow.AddYears(1),
                DateTo = DateTime.UtcNow,
                CustomerPersonalNo = "990203040134",
                RegistrationNo = "ZS 923021"
            };
            //Act
            var actionResult = await controller.Add(reservation);
            var result = actionResult as IStatusCodeActionResult;

            //Assert
            Assert.That(result!.StatusCode,Is.EqualTo(400));
        }

        [Test]
        public async Task Add_ValidCar_ReturnsTrue()
        {
            //Arrange
            var controller = new CarController(_carService, _carValidator);
            var car = new CarRequest() 
            { 
                Fuel=API.Models.Enums.FuelType.LPG,
                Model="BMW",
                Power=204,
                Price=1000,
                RegistrationNo="ZS 93420",
                Year=2020
               
            };

            //Act
            var actionResult = await controller.Add(car);
            var result = actionResult as IStatusCodeActionResult;
            
            //Assert
            Assert.That(result!.StatusCode,Is.EqualTo(200));
        }

        [Test]
        public async Task Add_Valid_Customer_Returns_True()
        {
            //Arrange
            var controller= new CustomerController(_customerService, _customerValidator);
            var customer = new CustomerRequest()
            {
                FirstName = "Robert",
                LastName = "Kowalski",
                PersonalNo = "78902031423"
            };

            //Act
            var actionResult = await controller.Add(customer);
            var result = actionResult as IStatusCodeActionResult;

            //Assert
            Assert.That(result!.StatusCode, Is.EqualTo(200));
        }
    }
}