using System;
using System.Collections.Generic;
using System.Text;

namespace ServeIt.Web.ViewModels.Reservations
{
 public  class ReservationViewModel
    {
        public string ReservationId { get; set; }
        public string  FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string RestaurantName { get; set; }

        public int People { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Description { get; set; }
    }
}
