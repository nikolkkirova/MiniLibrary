using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniLibrary.Data;
using MiniLibrary.Models;

namespace MiniLibrary.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly MiniLibraryContext _context;

        public IndexModel(MiniLibraryContext context)
        {
            _context = context;
        }

        public IList<Book> Books { get; set; } = new List<Book>();

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                // Зарежда само книгите на логнатия потребител
                Books = await _context.Book
                    .Where(b => b.UserId == userId)
                    .ToListAsync();


                if (!string.IsNullOrEmpty(SearchString))
                {
                    Books = Books
                        .Where(b =>
                            (b.Title != null && b.Title.Contains(SearchString, StringComparison.OrdinalIgnoreCase)) ||
                            (b.Author != null && b.Author.Contains(SearchString, StringComparison.OrdinalIgnoreCase)) ||
                            (b.Genre != null && b.Genre.Contains(SearchString, StringComparison.OrdinalIgnoreCase)))
                        .ToList();



                }
            }
        }
    }
}