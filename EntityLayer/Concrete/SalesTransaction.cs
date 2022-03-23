using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SalesTransaction
    {
        [Key]
        public int SalesTransactionID { get; set; }
        public int Amount { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
       
        public int CariID { get; set; }
        public virtual Cari Cari { get; set; }

        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
