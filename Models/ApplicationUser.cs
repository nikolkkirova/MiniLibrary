using Microsoft.AspNetCore.Identity;

namespace MiniLibrary.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Добавям тук Books, за да виждам кои книги притежава потребителят
        public ICollection<Book>? Books { get; set; }
    }
}