using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeserviceFaq.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string Message { get; set; }
        public string Answer { get; set; }
        public int CategoryId { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public Category Category { get; set; }
    }
}
