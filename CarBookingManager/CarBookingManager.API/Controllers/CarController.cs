using CarBookingManager.API.Dtos.Requests;
using CarBookingManager.API.Services.CarService;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace CarBookingManager.API.Controllers
{
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IValidator<CarRequest> _carRequestValidator;

        public CarController(ICarService carService, IValidator<CarRequest> carRequestValidator)
        {
            _carService = carService;
            _carRequestValidator = carRequestValidator;
        }

        [HttpPost(nameof(Add))]
        public async Task<ActionResult> Add(CarRequest carRequest)
        {
            var result=await _carRequestValidator.ValidateAsync(carRequest);
            if(result.IsValid)
            {
                await _carService.AddAsync(carRequest);
                return Ok();
            }
            return BadRequest();
         
        }
        [HttpGet(nameof(GetAllAssigned))]
        public async Task<ActionResult> GetAllAssigned()
        {

            return Ok(await _carService.GetAllAssignedAsync());

        }



    }
}
