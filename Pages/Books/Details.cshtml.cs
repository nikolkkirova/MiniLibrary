using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniLibrary.Data;
using MiniLibrary.Models;

namespace MiniLibrary.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly MiniLibrary.Data.MiniLibraryContext _context;

        public DetailsModel(MiniLibrary.Data.MiniLibraryContext context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (book is not null)
            {
                Book = book;

                return Page();
            }

            return NotFound();
        }
    }
}
