using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bookShopModel;
using Microsoft.EntityFrameworkCore;


namespace BookShopDataAccess
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> books{ get; set; }

    }
}
