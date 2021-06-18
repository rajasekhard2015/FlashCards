using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FlashCardsDemo.Data;
using FlashCardsDemo.Models;

namespace FlashCardsDemo.Pages.FlashCards
{
    public class CreateModel : PageModel
    {
        private readonly FlashCardsDemo.Data.ApplicationDbContext _context;

        public CreateModel(FlashCardsDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FlashCard FlashCard { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            FlashCard.CreatonTime = DateTime.UtcNow;
            FlashCard.CourseId = "1";
            _context.FlashCards.Add(FlashCard);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
