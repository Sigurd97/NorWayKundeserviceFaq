using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeserviceFaq.Models
{
    public class UserQuestonDataTransfer
    {
        public int id { get; set; }
        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ.\\-]{1,}$")]
        public string firstname { get; set; }
        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ.\\-]{1,}$")]
        public string lastname { get; set; }
        [Required]
        [RegularExpression("^[0-9a-zA-ZøæåØÆÅ./-?\' !#%&,_<>\"@$()=]{1,}$")]
        public string question { get; set; }
        [Required]
        [RegularExpression("^[0-9]$")]
        public int categoryId { get; set; }
    }
}
