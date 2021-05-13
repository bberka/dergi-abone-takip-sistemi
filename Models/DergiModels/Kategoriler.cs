using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DergiAboneProje.Models
{
    public class Kategoriler
    {


        [Key]
        public int KategoriID { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        [DataType(DataType.Text)]
        [Display(Name = "Kategori Adı")]
        [RegularExpression(@"^[A-z^şŞıİçÇöÖüÜĞğ ]+$", ErrorMessage = "Kategori adı sadece harf içerebilir.")]
        [MaxLength(50, ErrorMessage = "Kategori adı en az 3 en fazla 50 haneli olabilir.")]
        
        public string KategoriAD { get; set; }


        public IList<Dergiler> Dergilers { get; set; }
    }
}
