using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DergiAboneProje.Models
{
    public class Dergiler
    {
        [Key]
        public int DergiID { get; set; }
        [Required]
        public string DergiAD { get; set; }
        [Display(Name = "Date")]
        public DateTime DergiTARIH { get; set; } = DateTime.Now;

        [Required]
        public int? KategoriID { get; set; }
        [ForeignKey("KategoriID")]
        public virtual Kategoriler Kategoriler { get; set; }

    }
}
