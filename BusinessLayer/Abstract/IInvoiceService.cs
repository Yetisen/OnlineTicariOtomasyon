using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IInvoiceService
    {
        List<Invoice> GetList();
        void InvoiceAdd(Invoice invoice);
        void InvoiceDelete(Invoice invoice);
        void InvoiceUpdate(Invoice invoice);
        Invoice GetByID(int id);
    }
}
