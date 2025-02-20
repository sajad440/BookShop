using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public DbSet<Genre> genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasOne(x => x.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(x => x.GenreId);
        }


    }
}
