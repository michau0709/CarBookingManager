using CarBookingManager.API.Dtos.Requests;
using CarBookingManager.API.Dtos.Responses;
using CarBookingManager.API.Services.ReservationService;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace CarBookingManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IValidator<ReservationRequest> _reservationValidator;
        public ReservationController(IReservationService reservationService,IValidator<ReservationRequest> reservationValidator)
        {
            _reservationService = reservationService;
            _reservationValidator = reservationValidator;
        }

        [HttpPost(nameof(Add))]
        public async Task<ActionResult> Add(ReservationRequest reservationRequest)
        {
            var result = await _reservationValidator.ValidateAsync(reservationRequest);
            if(result.IsValid)
            {
                await _reservationService.AddAsync(reservationRequest);
                return Ok();
            }
            return BadRequest();
        
        }

        [HttpGet(nameof(GetAll))]
        public async Task<ActionResult<IEnumerable<ReservationResponse>>> GetAll()
        {
                return Ok(await _reservationService.GetAllAsync());
        }


    }
}
