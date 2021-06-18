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
    public class DetailsModel : PageModel
    {
        private readonly FlashCardsDemo.Data.ApplicationDbContext _context;

        public DetailsModel(FlashCardsDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
