using ServeIt.Web.ViewModels.Administration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Administration
{
    public interface IAdministrationService
    {
        Task<ICollection<AllUserViewModel>> GetAllUsers();

        Task  BlockUser(string userId);

        Task  UnblockUser(string userId);

    }
}
