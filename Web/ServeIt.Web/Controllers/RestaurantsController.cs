using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeIt.Web.Controllers
{
    public class RestaurantsController : BaseController
    {


        public async Task<IActionResult> All()
        {
            return this.View();
        }

    }
}
