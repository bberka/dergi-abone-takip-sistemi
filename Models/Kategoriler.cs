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

        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string KategoriAD { get; set; }
        

        public IList<Dergiler> Dergilers { get; set; }
    }
}
