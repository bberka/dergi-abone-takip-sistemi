using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAboneTakip.Models
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar(16)")]
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
        [MaxLength(16, ErrorMessage = "Kullanıcı adı en fazla 16 haneli olabilir.")]
        public string KullaniciAD { get; set; }

        [Column(TypeName = "Varchar(16)")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        [MinLength(3, ErrorMessage = "Şifre en az 3 en fazla 16 haneli olabilir.")]
        [MaxLength(16, ErrorMessage = "Şifre en az 3 en fazla 16 haneli olabilir.")]
        public string Sifre { get; set; }

        [Column(TypeName = "Varchar(10)")]
        [Display(Name = "Rol")]
        [StringLength(1)]
        public string Rol { get; set; } = "U"; //U = User ** A = Admin ** O = Owner
    }
}
