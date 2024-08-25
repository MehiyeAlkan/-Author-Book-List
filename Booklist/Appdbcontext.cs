using LibraryService.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryService
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-OD0I8PV\\SQLEXPRESS;Database=test;Trusted_Connection=True; user=sa;password=12345678; TrustServerCertificate = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().Property(i=>i.Namesurname).HasColumnName("name");

        }




    }
}
