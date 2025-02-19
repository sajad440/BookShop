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
                    ViewData["Success"] = "genre add successfl";
                    return View();
               
            }
            ViewData["Fail"] = "invalid inputs !!!";
            return View();
        }
    }
}
