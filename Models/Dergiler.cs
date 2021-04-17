using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime DergiTARIH { get; set; }

        public int KategoriID { get; set; }
        public Kategoriler Kategoriler { get; set; }

    }
}
