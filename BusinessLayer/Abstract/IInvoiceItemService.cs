using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IInvoiceItemService
    {
        List<InvoiceItem> GetList();
        void InvoiceItemAdd(InvoiceItem invoice);
        void InvoiceItemDelete(InvoiceItem invoice);
        void InvoiceItemUpdate(InvoiceItem invoice);
        InvoiceItem GetByID(int id);
        List<InvoiceItem> GetByInvoice(int id);
    }
}
