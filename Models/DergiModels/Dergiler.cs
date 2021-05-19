using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DergiAboneProje.Models
{
    public class Dergiler
    {
        [Key]
        public int DergiID { get; set; }
        [Display(Name = "Dergi Adı")]
        [Required(ErrorMessage = "Dergi adı boş bırakılamaz.")]
        [MaxLength(50, ErrorMessage = "Dergi adı en fazla 50 haneli olabilir")]
        public string DergiAD { get; set; }

        [Required(ErrorMessage = "Aylık ücret boş bırakılamaz.")]
        [Display(Name = "Aylık Ücret")]
        public int AylikUcret { get; set; }

        [Display(Name = "Dergi Eklenme Tarihi")]
        [Required(ErrorMessage = "Dergi tarihi boş bırakılamaz.")]
        public DateTime DergiTARIH { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Kategori seçiniz.")]
        public int? KategoriID { get; set; }
        [ForeignKey("KategoriID")]
        public virtual Kategoriler Kategoriler { get; set; }

        
        public IList<Uyeler> Uyeler { get; set; }

    }
}
