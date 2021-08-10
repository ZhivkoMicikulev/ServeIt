using Microsoft.AspNetCore.Mvc;
using ServeIt.Data.Models;
using ServeIt.Services.Data.Reservations;
using ServeIt.Web.ViewModels.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeIt.Web.Controllers
{
    public class ReservationsController : BaseController
    {
        private readonly IReservationsService reservationsService;

        public ReservationsController(IReservationsService reservationsService)
        {
            this.reservationsService = reservationsService;
        }

        [HttpPost]
        public async Task<IActionResult> MakeReservation(ReservationInputModel model)
        {
            var reservationId =await reservationsService.MakeReservation(model);

            return this.Redirect($"/Reservations/Reservation/{reservationId}");
           

        }

        public async Task<IActionResult> Reservation(string id)
        {
            var model =await reservationsService.TakeReservationInfo(id);
            return this.View(model);
        }
    }
}
