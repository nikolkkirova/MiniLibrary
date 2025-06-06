using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniLibrary.Models;

namespace MiniLibrary.Data
{
    public class MiniLibraryContext : IdentityDbContext<ApplicationUser>
    {
        public MiniLibraryContext(DbContextOptions<MiniLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
    }
}


/* Записки

MiniLibraryContext --> нашият клас, който описва връзката с базата и таблиците
: DbContext --> наследява EF класа, който свързва с базата данни
DbSet<Book> Book --> създава таблица Book в базата данни
default! --> уверяваме компилатора, че EF ще инициализира Book


*/