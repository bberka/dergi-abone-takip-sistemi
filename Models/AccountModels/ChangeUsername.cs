using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAboneTakip.Models.AccountModels
{
    public class ChangeUsername
    {

        [Column(TypeName = "Varchar(16)")]
        [Display(Name = "Yeni Kullanıcı Adı")]
        [Required(ErrorMessage = "Yeni kullanıcı adı boş bırakılamaz.")]
        [MaxLength(16, ErrorMessage = "Yeni kullanıcı adı en fazla 16 haneli olabilir.")]
        public string NewUsername { get; set; }
        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        [Column(TypeName = "Varchar(16)")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [MinLength(3), MaxLength(16, ErrorMessage = "Şifre en az 3 en fazla 16 haneli olabilir.")]
        public string Password { get; set; }
    }
}
