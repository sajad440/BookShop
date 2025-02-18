using BookShopDataAccess;
using bookShopModel;
using Microsoft.AspNetCore.Mvc;


namespace BookShop.Controllers
{
    public class BookManagmentController : Controller
    {
        private BookDbContext _dbContext;

        public BookManagmentController(BookDbContext dbContext)
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
        public IActionResult Add(Book book1)
        {
            if (book1 == null)
            {
                TempData["Fail"] = "invalid input";
                return RedirectToAction("Add");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.books.Add(book1);
                    _dbContext.SaveChanges();
                    TempData["Success"] = "Book add successful";
                    return RedirectToAction("Add");
                }
                catch (Exception ex)
                {
                    TempData["Fail"] = "Book cannot  add";
                    Console.WriteLine(ex.Message); 
                }
            }
            else
            {
                TempData["Fail"] = "Book not valid ";
            }

            return RedirectToAction("Add");
        }

    }
}
