using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeserviceFaq.Models
{
    public class CategoryDataTransfer
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
