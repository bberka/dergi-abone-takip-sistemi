
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
        private const string V = "asd";

        [Key]
        public int KategoriID { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        [DataType(DataType.Text)]
        [Display(Name ="Kategori Adı")]
        public string KategoriAD { get; set; }
        

        public IList<Dergiler> Dergilers { get; set; }
    }
}
