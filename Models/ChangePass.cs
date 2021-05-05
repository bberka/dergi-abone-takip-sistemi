using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAboneTakip.Models
{
    public class ChangePass
    {
        [Column(TypeName = "Varchar(16)")]
        [Display(Name = "Geçerli Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Geçerli şifre boş bırakılamaz.")]
        public string OldPass { get; set; }

        [Column(TypeName = "Varchar(16)")]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        [MinLength(3, ErrorMessage = "Yeni şifre en az 3 en fazla 16 haneli olabilir.")]
        [MaxLength(16, ErrorMessage = "Yeni şifre en az 3 en fazla 16 haneli olabilir.")]
        public string NewPass { get; set; }

        [Column(TypeName = "Varchar(16)")]
        [Display(Name = "Yeni Şifre Tekrar")]
        [DataType(DataType.Password)]
        public string NewPass2 { get; set; }
    }
}
