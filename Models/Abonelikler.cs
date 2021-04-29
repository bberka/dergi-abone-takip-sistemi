using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DergiAboneProje.Models
{
    public class Abonelikler
    {
        [Key]
        public int KayıtID { get; set; }

        [Required(ErrorMessage = "Kayıt tarihi boş bırakılamaz.")]
        [Display(Name = "Abonelik Başlangıç Tarihi")]
        public DateTime KayıtTarihi { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Kayıt süresi boş bırakılamaz.")]
        [Display(Name = "Kayıt Süresi(ay)")]
        public int KayıtSuresi { get; set; }

        [Required(ErrorMessage = "Üye ID boş bırakılamaz.")]
        public int? UyeID { get; set; }
        [ForeignKey("UyeID")]
        public virtual Uyeler Uye { get; set; }
        
        [Required(ErrorMessage = "Dergi ID boş bırakılamaz.")]
        public int? DergiID { get; set; }
        [ForeignKey("DergiID")]
        public virtual Dergiler Dergi { get; set; }
    }
}
