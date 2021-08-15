namespace ServeIt.Web.Controllers
{
    using System.Threading.Tasks;
    using AspNetCore.ReCaptcha;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ServeIt.Services.Data.Reservations;
    using ServeIt.Web.ViewModels.Reservations;

    [Authorize]
    public class ReservationsController : BaseController
    {
        private readonly IReservationsService reservationsService;

        public ReservationsController(IReservationsService reservationsService)
        {
            this.reservationsService = reservationsService;
        }

        [ValidateReCaptcha]
        [HttpPost]
        public async Task<IActionResult> MakeReservation(ReservationInputModel model)
        {
            var reservationId = await this.reservationsService.MakeReservation(model);

            return this.Redirect($"/Reservations/Reservation/{reservationId}");
        }

   
        public async Task<IActionResult> Reservation(string id)
        {
            var model = await this.reservationsService.TakeReservationInfo(id);
            return this.View(model);
        }

        public async Task<IActionResult> MyReservations(string id)
        {
            var model = await this.reservationsService.TakeAllMyReservation(id);
            return this.View(model);
        }
    }
}
