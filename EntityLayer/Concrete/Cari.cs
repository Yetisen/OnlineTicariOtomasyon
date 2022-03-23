using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter olmalı")]
        public string CariName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı doldurmalısınız!")]
        public string CariSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        public bool State { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariPassword { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }

        //mployee yi oluştur ve bu kısımları düzenle
    }
}
