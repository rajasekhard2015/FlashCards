using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlashCardsDemo.Data;
using FlashCardsDemo.Models;

namespace FlashCardsDemo.Pages.FlashCards
{
    public class EditModel : PageModel
    {
        private readonly FlashCardsDemo.Data.ApplicationDbContext _context;

        public EditModel(FlashCardsDemo.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            FlashCard.CreatonTime = DateTime.UtcNow;
            FlashCard.CourseId = "1";
            _context.Attach(FlashCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlashCardExists(FlashCard.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FlashCardExists(long id)
        {
            return _context.FlashCards.Any(e => e.Id == id);
        }
    }
}
