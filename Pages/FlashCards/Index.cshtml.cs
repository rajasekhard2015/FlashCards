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
    public class IndexModel : PageModel
    {
        private readonly FlashCardsDemo.Data.ApplicationDbContext _context;

        public IndexModel(FlashCardsDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FlashCard> FlashCard { get;set; }

        public async Task OnGetAsync()
        {
            FlashCard = await _context.FlashCards.ToListAsync();
        }
    }
}
