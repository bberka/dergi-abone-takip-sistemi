
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace DergiAboneProje.Models
{
    public class Kategoriler
    {
        

        [Key]
        public int KategoriID { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        [DataType(DataType.Text)]
        [Display(Name ="Kategori Adı")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Kategori adı sayı içeremez.")]       
        [MaxLength(16, ErrorMessage = "Kategori adı en az 3 en fazla 16 haneli olabilir.")]        
        public string KategoriAD { get; set; }
        

        public IList<Dergiler> Dergilers { get; set; }
    }
}
