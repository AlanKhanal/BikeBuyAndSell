using Microsoft.AspNetCore.Mvc;
using MashWebApplication.Models;
using MashWebApplication.AppDbContext;
namespace MashWebApplication.Controllers
{
    public class MakeController : Controller
    {
        /*[Route("make")]
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
        }*/

        private readonly MashDbContext _db;

        public MakeController(MashDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Makes.ToList());
        }

        //HTTP GET METHOD
        public IActionResult Create()
        {
            return View();
        }

        //HTTP POST METHOD
        [HttpPost]
        public IActionResult Create(Make make)
        {
            if (ModelState.IsValid)
            {
                _db.Add(make);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var make = _db.Makes.Find(id);
            if (make==null)
            {
                return NotFound();
            }
            _db.Makes.Remove(make);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var make = _db.Makes.Find(id);
            if (make == null)
            {
                return NotFound();
            }
            
            return View(make);
        }

        [HttpPost]
        public IActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                _db.Update(make);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }
    }
}
