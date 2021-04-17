using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DergiAboneProje.Models
{
    public class Abonelikler
    {
        [Key]
        public int KayıtID { get; set; }
        [Required]
        public DateTime KayıtTarihi { get; set; }

        public int KayıtSuresi { get; set; }

        public int UyeID { get; set; }
        public Uyeler Uye { get; set; }

        public int DergiID { get; set; }
        public Dergiler Dergi { get; set; }
    }
}
