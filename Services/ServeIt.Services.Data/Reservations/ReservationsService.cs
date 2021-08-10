using Microsoft.EntityFrameworkCore;
using ServeIt.Data.Common.Repositories;
using ServeIt.Data.Models;
using ServeIt.Web.ViewModels.Orders;
using ServeIt.Web.ViewModels.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Reservations
{
    public class ReservationsService : IReservationsService
    {
        private readonly IDeletableEntityRepository<Reservation> reservationsRepository;

        public ReservationsService(IDeletableEntityRepository<Reservation> reservationsRepository)
        {
            this.reservationsRepository = reservationsRepository;
        }

        public async Task<string> MakeReservation(ReservationInputModel model)
        {
            var reservation = new Reservation
            {
                Date = DateTime.ParseExact(model.Date, "yyyy-MM-dd", null),
                Time = DateTime.ParseExact(model.Time, "HH:mm", null),
                SeatNumber = model.People,
                RestaurantId = model.RestaurantId,
                UserId = model.UserId,
                Description = model.Message,
            };

            await this.reservationsRepository.AddAsync(reservation);
            await this.reservationsRepository.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task<ICollection<MyReservationsViewModel>> TakeAllMyReservation(string id)
        {
            var myReservations =await this.reservationsRepository.All().Where(x => x.UserId == id)
                .Include(x => x.Restaurant)
                .OrderByDescending(x=>x.Date)            
                .Select(x => new MyReservationsViewModel
                {
                    ReservationId = x.Id,
                    RestaurantName = x.Restaurant.Name,
                    Date = x.Date.ToString("dd/MM/yyyy")


                }).ToListAsync();

            return myReservations;
        }

        public async Task<ReservationViewModel> TakeReservationInfo(string id)
        {
            var reservation = reservationsRepository.All().Where(x => x.Id == id)
                 .Include(x => x.User)
                 .Include(x => x.Restaurant)
                .Select(x => new ReservationViewModel
                {
                    ReservationId=x.Id,
                    FullName = x.User.FirstName + " " + x.User.LastName,
                    Phone = x.User.PhoneNumber,
                    Email = x.User.Email,
                    Date = x.Date.ToString("dd/MM/yyyy"),
                    Time = x.Time.ToString("HH:mm"),
                    People = x.SeatNumber,
                    RestaurantName = x.Restaurant.Name,
                    Description = string.IsNullOrEmpty(x.Description) ? " " : x.Description,
                })
                .FirstOrDefault();

            return reservation;

        }
    }
}
