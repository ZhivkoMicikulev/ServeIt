using ServeIt.Data.Common.Repositories;
using ServeIt.Data.Models;
using ServeIt.Web.ViewModels.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Administration
{
    public class AdministrationService : IAdministrationService
    {
        private readonly IDeletableEntityRepository<User> usersRepository;

        public AdministrationService(IDeletableEntityRepository<User> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task BlockUser(string userId)
        {
            var user = this.usersRepository.All().Where(x => x.Id == userId).FirstOrDefault();

            user.IsDeleted = true;
            await this.usersRepository.SaveChangesAsync();
        }

        public async Task<ICollection<AllUserViewModel>> GetAllUsers()
        {
            var users = this.usersRepository.All().Where(x=>x.UserName!="Admin")
                .Select(x => new AllUserViewModel
                {
                    UserId = x.Id,
                    Username = x.UserName,
                    Phone = x.PhoneNumber,
                    Email = x.Email,
                    FullName = x.FirstName + " " + x.LastName,
                    RegisterDate = x.CreatedOn.ToString("dd/MM/yyyy"),
                    IsDeleted = x.IsDeleted,
                    IsOwner = x.IsItOwnerOfRestaurant ? "YES" : "NO",

                }).ToList();

            return users;
        }

        public async Task UnblockUser(string userId)
        {
            var user = this.usersRepository.All().Where(x => x.Id == userId).FirstOrDefault();

            user.IsDeleted = false;
            await this.usersRepository.SaveChangesAsync();
        }
    }
}
