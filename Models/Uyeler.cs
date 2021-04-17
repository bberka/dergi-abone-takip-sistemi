using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DergiAboneProje.Models
{
    public class Uyeler
    {
        [Key]
        public int UyeID { get; set; }
        [Required]
        public string UyeAD { get; set; }
        [Required]
        public string Email { get; set; }
        public long TelNo { get; set; }
        public DateTime Tarih { get; set; }
       
    }
}
