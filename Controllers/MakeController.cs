using Microsoft.AspNetCore.Mvc;
using MashWebApplication.Models;
namespace MashWebApplication.Controllers
{
    public class MakeController : Controller
    {
        [Route("make")]
        [Route("make/bike")]

        public IActionResult Bikes()
        {
            Make make= new Make { Name="Harley Davidson"};
            //return View(make);

            ContentResult CR = new ContentResult { Content = "Hello World" };
            return CR;
        }
        [Route("make/bikes/{year:int:length(4)}/{month:int:range(1,12)}")]
        public IActionResult ByYearMonth(int year,int month)
        {
            return Content(year+";"+month);
        }
    }
}
