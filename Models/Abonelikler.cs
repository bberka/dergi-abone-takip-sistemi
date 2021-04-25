using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DergiAboneProje.Models
{
    public class Abonelikler
    {
        [Key]
        public int KayıtID { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime KayıtTarihi { get; set; } = DateTime.Now;
        [Required]
        public int KayıtSuresi { get; set; }

        public int? UyeID { get; set; }
        [ForeignKey("UyeID")]
        public virtual Uyeler Uye { get; set; }

        public int? DergiID { get; set; }
        [ForeignKey("DergiID")]
        public virtual Dergiler Dergi { get; set; }
    }
}
