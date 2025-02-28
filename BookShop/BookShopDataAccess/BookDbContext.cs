using Microsoft.EntityFrameworkCore;
using bookShopModel;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace BookShopDataAccess
{
    public class BookDbContext :IdentityDbContext<IdentityUser>

    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
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
