using Microsoft.AspNetCore.Mvc;
using bookShopModel;
using System.Runtime.CompilerServices;
using BookShopDataAccess;
using Microsoft.EntityFrameworkCore;
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
                    ViewData["Success"] = "genre add successful";
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
        public IActionResult Showbook(int id)
        {
            var books = _dbContext.books.Where(x=>x.GenreId==id).ToList();
            if (books != null)
            {

                return View(books);

            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var DeletedGenre = _dbContext.genres.FirstOrDefault(x => x.Id == id);

            if (DeletedGenre != null)
            {
                var palang = _dbContext.books
                    .Where(x => x.GenreId == id)
                    .ToList();
                
                _dbContext.RemoveRange(palang);
                _dbContext.Remove(DeletedGenre);
                _dbContext.SaveChanges();
                return RedirectToAction("Show");
            }
            return RedirectToAction("Show");
        }
    }
}
