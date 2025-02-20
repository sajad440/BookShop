using BookShopDataAccess;
using bookShopModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;


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
        //create a  new object of MainViewModel and send to view
        //Books in MainViewModel cannot be empty so
            var model = new MainViewModel()
            {
                Book = new Book()
                ,
                Genres = _dbContext.genres.ToList()
            };

            return View(model);
        }
     
        [HttpPost]
        public IActionResult Add(MainViewModel book1)
        {
            Console.WriteLine($"Book Name: {book1.Book.Name}");
            Console.WriteLine($"GenreId: {book1.Book.GenreId}"); // مقدار GenreId را بررسی کن

            if (book1 == null)
            {
                TempData["Fail"] = "invalid input";
                return RedirectToAction("Add");
            }
            ModelState.Remove("Genres");
            ModelState.Remove("Book.Genre");
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.books.Add(book1.Book);
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

            return RedirectToAction("Add");
        }


        public IActionResult Show()
        {

           var Books = _dbContext.books.Include(x=>x.Genre).ToList();
            if(Books != null)
            {

                return View(Books  );
            }
            ViewData["Message"] = "There is nothing To Show";

            return View();
        }
    }
}
