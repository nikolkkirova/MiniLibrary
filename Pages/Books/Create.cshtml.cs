using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniLibrary.Data;
using MiniLibrary.Models;
using System.Linq;
namespace MiniLibrary.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly MiniLibraryContext _context;

        public CreateModel(MiniLibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("POST handler called.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine("User ID: " + userId);

            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError(string.Empty, "Не сте влезли.");
                Console.WriteLine("User not logged in.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid.");
                foreach (var modelError in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("Model Error: " + modelError.ErrorMessage);
                }
                return Page();
            }

            Book.UserId = userId;

            try
            {
                _context.Book.Add(Book);
                await _context.SaveChangesAsync();
                Console.WriteLine("Book saved successfully.");
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while saving: " + ex.Message);
                ModelState.AddModelError(string.Empty, $"Грешка при запис: {ex.Message}");
                return Page();
            }
        }
    }
}