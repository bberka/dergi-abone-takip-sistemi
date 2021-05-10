using System;
using System.ComponentModel.DataAnnotations;

namespace DergiAboneProje.Models
{
    public class Uyeler
    {
        [Key]
        public int UyeID { get; set; }

        [Required(ErrorMessage = "Üye adı boş bırakılamaz")]
        [Display(Name = "Üye Adı Soyadı")]
        [RegularExpression(@"^[A-z^şŞıİçÇöÖüÜĞğ ]+$", ErrorMessage = "Üye adı sadece harf içerebilir.")]
        [MaxLength(50, ErrorMessage = "Üye adı soyadı en fazla 50 haneli olabilir")]
        public string UyeAD { get; set; }

        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Geçersiz email adresi girdiniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tel no boş bırakılamaz.")]
        [Display(Name = "Tel No")]
        public long TelNo { get; set; } 

        [Required(ErrorMessage = "Doğum Tarihi boş bırakılamaz.")]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime DogumTarihi { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        [DataType(DataType.Date)]
        public DateTime KayitTarihi { get; set; } = DateTime.Now;

    }
}
