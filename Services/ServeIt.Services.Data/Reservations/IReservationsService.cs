namespace ServeIt.Services.Data.Reservations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ServeIt.Web.ViewModels.Reservations;

    public interface IReservationsService
    {
        Task<string> MakeReservation(ReservationInputModel model);

        Task<ReservationViewModel> TakeReservationInfo(string id);

        Task<ICollection<MyReservationsViewModel>> TakeAllMyReservation(string id);

    }
}
