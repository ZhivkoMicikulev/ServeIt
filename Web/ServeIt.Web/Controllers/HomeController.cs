namespace ServeIt.Web.Controllers
{
    using System.Diagnostics;

    using ServeIt.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class HomeController : BaseController
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
          
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View();
        }


    }
}
