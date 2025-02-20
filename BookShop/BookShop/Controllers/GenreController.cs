using Microsoft.AspNetCore.Mvc;
using bookShopModel;
using System.Runtime.CompilerServices;
using BookShopDataAccess;
namespace BookShop.Controllers
{
    public class GenreController : Controller
    {
       private readonly BookDbContext _dbContext;

        public GenreController(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genre genre1)
        {
            ModelState.Remove("Books");
            if(genre1==null)
            {
                ViewData["Fail"]= "invalid inputs !!!";
                return View();
            }
            if (ModelState.IsValid)
            {
              
                    _dbContext.genres.Add(genre1);
                    _dbContext.SaveChanges();
                     ModelState.Clear();
                    ViewData["Success"] = "genre add successfl";
                    return View();
               
            }
            ViewData["Fail"] = "invalid inputs !!!";
            return View();
        }

        public IActionResult Show()
        {
            var genres = _dbContext.genres.ToList();
            if (genres != null)
            {
                return View(genres);
            }
            ViewData["Fail"] = "there is not any genre here";
            return View();
        }
        public IActionResult Showbook()
        {

            return View();
        }

    }
}
