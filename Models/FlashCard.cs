using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCardsDemo.Models
{
    public class FlashCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set;}

        public string Question { get; set;}

        public string Answer { get; set;}

        public string CourseId { get; set;}

        public DateTime CreatonTime { get; set;}
    }
}
