using Moq;
using ServeIt.Data.Common.Repositories;
using ServeIt.Data.Models;
using ServeIt.Services.Data.Reservations;
using ServeIt.Web.ViewModels.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServeIt.Services.Data.Tests
{
  public class ReservationsServiceTests
    {

        public static ICollection<Reservation> ReservationsList;
        

        public static Mock<IDeletableEntityRepository<Reservation>> mockReservationsRepo;


        public static ReservationsService service;



        public ReservationsServiceTests()
        {
            ReservationsList = new List<Reservation>();


            mockReservationsRepo = new Mock<IDeletableEntityRepository<Reservation>>();
            mockReservationsRepo.Setup(x => x.All()).Returns(ReservationsList.AsQueryable());
            mockReservationsRepo.Setup(x => x.AddAsync(It.IsAny<Reservation>()))
                .Callback((Reservation r) => ReservationsList.Add(r));


       

            service = new ReservationsService(
        mockReservationsRepo.Object
              );
        }

        [Fact]
        public async void TestMakeReservationShouldReturnCorrectExpectedResultsAfterMakingReservation()
        {
            var model = new ReservationInputModel
            {
                Date = "2021-08-23",
                Time = "10:20",
                Message = "",
                People = 2,
                RestaurantId = "b",
                UserId = "a"
            };
            var model2 = new ReservationInputModel
            {
                Date = "2021-08-24",
                Time = "10:21",
                Message = "Outside",
                People = 4,
                RestaurantId = "c",
                UserId = "b"
            };

            var expectedCountResult = 2;
            //msg=""
            var expectedMessage = true;
            //people=2
            var expectetPeople = true;
            //userId="a"
            var expectedUserId = true;
            //restaurantId="b"
            var expectedRestaurantId = true;

            await service.MakeReservation(model);
            await service.MakeReservation(model2);


            var resultCount = ReservationsList.Count();
            var resultMsg = ReservationsList.Any(x => x.Description == "");
            var resultPeople = ReservationsList.Any(x => x.SeatNumber == 2);
            var resultUserId = ReservationsList.Any(x => x.UserId == "a");
            var resultRestaurantId= ReservationsList.Any(x => x.RestaurantId == "b");

            Assert.Equal(expectedCountResult, resultCount);
            Assert.Equal(expectedMessage, resultMsg);
            Assert.Equal(expectetPeople, resultPeople);
            Assert.Equal(expectedUserId, resultUserId);
            Assert.Equal(expectedRestaurantId, resultRestaurantId);
        }
      
        [Fact]
        public async void TestTakeAllMyReServationShouldReturnTheCorrectCountOfReservations()
        {
            var restaurant1 = new Restaurant
            {
                Id = "b",
                Name = "Happy"
            };

            var restaurant2 = new Restaurant
            {
                Id = "c",
                Name = "Torro"
            };

            var model = new Reservation
            {
                Date = DateTime.Parse("23/08/2021"),
                Restaurant=restaurant1,
                RestaurantId = "b",
                UserId = "a"
            };
            var model2 = new Reservation
            {
                Date = DateTime.Parse("24/08/2021"),
                Restaurant = restaurant1,
                RestaurantId = "b",
                UserId = "a"
            };
            var model3 = new Reservation
            {
                Date = DateTime.Parse("23/08/2021"),
                Restaurant = restaurant2,
                RestaurantId = "c",
                UserId = "b"
            };
            ReservationsList.Add(model);
            ReservationsList.Add(model2);
            ReservationsList.Add(model3);



            var expectedCountResult = 2;
            var expectedBoolResult = false;
    


            var resultCount = (await service.TakeAllMyReservation("a")).Count;
            var boolResult = (await service.TakeAllMyReservation("a")).Any(x=>x.ReservationId=="c");





            Assert.Equal(expectedCountResult, resultCount);
            Assert.Equal(expectedBoolResult, boolResult);


        }

        [Fact]
        public async void TestTakeReservationInfoShouldReturnTheCorrectValuesForTheGivenReservation()
        {
            var restaurant1 = new Restaurant
            {
                Id = "b",
                Name = "Happy"
            };

            var restaurant2 = new Restaurant
            {
                Id = "c",
                Name = "Torro"
            };

            var user = new User
            {
                Id="a",
                FirstName = "Pesho",
                LastName = "Goshoko",
                PhoneNumber = "00000",
                Email = "a@abv.bg",
            };

            var user2 = new User
            {
                Id = "b",
                FirstName = "Gosho",
                LastName = "Pesho",
                PhoneNumber = "00000",
                Email = "a@abv.bg",
            };

            var model = new Reservation
            {
                Id="a",
                Date = DateTime.Parse("23/08/2021"),
                Restaurant = restaurant1,
                RestaurantId = "b",
                UserId = "a",
                 User=user,
                  SeatNumber=2,
                  Time=DateTime.Parse("20:00"),
                  Description=""
            };
            var model2 = new Reservation
            {
                Id="b",
                Date = DateTime.Parse("24/08/2021"),
                Restaurant = restaurant1,
                RestaurantId = "b",
                UserId = "a",
                User=user,
                SeatNumber = 3,
                Time = DateTime.Parse("21:00"),
                Description = "outside"
            };
            var model3 = new Reservation
            {
                Id="c",
                Date = DateTime.Parse("23/08/2021"),
                Restaurant = restaurant2,
                RestaurantId = "c",
                UserId = "b",
                User=user2,
                SeatNumber = 4,
                Time = DateTime.Parse("22:00"),
                Description = "inside"


            };
            ReservationsList.Add(model);
            ReservationsList.Add(model2);
            ReservationsList.Add(model3);

    
            var expectedFullName ="Pesho Goshoko";
            var expectedPeople = 3;
            var expectedReservationId = "b";
            var expectedPhone = "00000";
            var expectedEmail = "a@abv.bg";
            var expectedDate = "24.08.2021";
            var expectedTime = "21:00";
            var expectedDescription = "outside";

            var reservation = await service.TakeReservationInfo("b");

            var resultFullName = reservation.FullName;        
            var resultPeople = reservation.People;
            var resultReservationId = reservation.ReservationId;
            var resultPhone = reservation.Phone;
            var resultEmail = reservation.Email;
            var resultDate = reservation.Date;
            var resultTime = reservation.Time;
            var resultDescription = reservation.Description;

            Assert.Equal(expectedFullName, resultFullName);
            Assert.Equal(expectedPeople, resultPeople);
            Assert.Equal(expectedPhone, resultPhone);
            Assert.Equal(expectedEmail, resultEmail);
            Assert.Equal(expectedDate, resultDate);
            Assert.Equal(expectedTime, resultTime);
            Assert.Equal(expectedDescription, resultDescription);
            Assert.Equal(expectedReservationId, resultReservationId);
        }
    }
}
