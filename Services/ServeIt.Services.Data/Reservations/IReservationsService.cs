using ServeIt.Web.ViewModels.Reservations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Reservations
{
    public interface IReservationsService
    {
        Task<string> MakeReservation(ReservationInputModel model);

        Task<ReservationViewModel> TakeReservationInfo(string id);
    }
}
