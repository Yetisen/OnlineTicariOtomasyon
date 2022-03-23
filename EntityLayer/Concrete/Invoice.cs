using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string InvoiceSerialNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceOrderNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAdministration { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Submitter { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; }
        public DateTime InvoiceDate { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string InvoiceHour { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
