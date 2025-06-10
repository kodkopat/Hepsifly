using Hepsifly.Domain;
using Hepsifly.Domain.Models;
using Hepsifly.Domain.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hepsifly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationBusiness reservationBusiness;
        public ReservationController(ReservationBusiness reservationBusiness)
        {
            this.reservationBusiness = reservationBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Ok(reservationBusiness.Get(id, null));
            else
                return Ok(reservationBusiness.Get<ReservationGetViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reservation model)
        {
            var Id = reservationBusiness.Add(model);
            return Created("Get", new { Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Reservation model)
        {
            var Id = reservationBusiness.Update(model);
            return Created("Get", new { Id });
        }

        [HttpDelete]
        public async Task<bool> Delete(string id)
            => reservationBusiness.Delete(id);
    }
}
