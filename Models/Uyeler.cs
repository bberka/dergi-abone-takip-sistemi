using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DergiAboneProje.Models
{
    public class Uyeler
    {
        [Key]
        public int UyeID { get; set; }
        [Required(ErrorMessage = "Üye adı boş bırakılamaz")]
        [Display(Name = "Üye Adı")]
        public string UyeAD { get; set; }
        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Tel no bırakılamaz")]
        [Display(Name = "Tel No")]
        public long TelNo { get; set; }
        public DateTime Tarih { get; set; }
       
    }
}
