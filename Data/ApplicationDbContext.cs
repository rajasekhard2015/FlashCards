using FlashCardsDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<FlashCard> FlashCards { get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
