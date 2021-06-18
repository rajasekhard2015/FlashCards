using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FlashCardsDemo.Data;
using FlashCardsDemo.Models;

namespace FlashCardsDemo.Pages.FlashCards
{
    public class DeleteModel : PageModel
    {
        private readonly FlashCardsDemo.Data.ApplicationDbContext _context;

        public DeleteModel(FlashCardsDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FlashCard FlashCard { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FlashCard = await _context.FlashCards.FirstOrDefaultAsync(m => m.Id == id);

            if (FlashCard == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FlashCard = await _context.FlashCards.FindAsync(id);

            if (FlashCard != null)
            {
                _context.FlashCards.Remove(FlashCard);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
