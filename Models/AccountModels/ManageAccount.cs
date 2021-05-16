using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAboneTakip.Models.AccountModels
{
    public class ManageAccount
    {
        [Column(TypeName = "Varchar(16)")]
        [Display(Name = "Yeni Kullanıcı Adı")]
        [Required(ErrorMessage = "Yeni kullanıcı adı boş bırakılamaz.")]
        [MaxLength(16, ErrorMessage = "Yeni kullanıcı adı en fazla 16 haneli olabilir.")]
        public string Username { get; set; }

        [Column(TypeName = "Varchar(16)")]
        [Display(Name = "Geçerli Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Geçerli şifre boş bırakılamaz.")]
        public string GecerliSifre { get; set; }

        [Column(TypeName = "Varchar(16)")]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Yeni şifre en az 3 en fazla 16 haneli olabilir.")]
        [MaxLength(16, ErrorMessage = "Yeni şifre en az 3 en fazla 16 haneli olabilir.")]
        public string YeniSifre { get; set; }

        [Column(TypeName = "Varchar(16)")]
        [Display(Name = "Yeni Şifre Tekrar")]
        [DataType(DataType.Password)]
        public string YeniSifreT { get; set; }
    }
}
