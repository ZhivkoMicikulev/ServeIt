using System;
using System.Collections.Generic;
using System.Text;

namespace ServeIt.Web.ViewModels.Reservations
{
 public   class ReservationInputModel
    {
        public string UserId { get; set; }

        public string RestaurantId { get; set; }
        public string Message { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int People { get; set; }
    }
}
