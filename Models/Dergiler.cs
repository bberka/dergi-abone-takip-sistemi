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
        [Display(Name = "Dergi Adı")]
        [Required(ErrorMessage = "Dergi adı boş bırakılamaz.")]
        public string DergiAD { get; set; }
        [Display(Name = "Dergi Eklenme Tarihi")]
        [Required(ErrorMessage = "Dergi tarihi boş bırakılamaz.")]
        public DateTime DergiTARIH { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Kategori seçiniz.")]
        public int? KategoriID { get; set; }
        [ForeignKey("KategoriID")]
        public virtual Kategoriler Kategoriler { get; set; }

        public virtual Uyeler Uyeler { get; set; }

    }
}
