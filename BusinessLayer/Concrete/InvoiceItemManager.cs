using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class InvoiceItemManager : IInvoiceItemService
    {
        IInvoiceItemDal _invoiceItemDal;

        public InvoiceItemManager(IInvoiceItemDal invoiceItemDal)
        {
            _invoiceItemDal = invoiceItemDal;
        }

        public InvoiceItem GetByID(int id)
        {
            return _invoiceItemDal.Get(x => x.InvoiceItemID==id);
        }
        public List<InvoiceItem> GetByInvoice(int id)
        {
            return _invoiceItemDal.List(x => x.InvoiceID == id);
        }

        public List<InvoiceItem> GetList()
        {
            return _invoiceItemDal.List();
        }

        public void InvoiceItemAdd(InvoiceItem invoice)
        {
            _invoiceItemDal.Insert(invoice);
        }

        public void InvoiceItemDelete(InvoiceItem invoice)
        {
            _invoiceItemDal.Delete(invoice);
        }

        public void InvoiceItemUpdate(InvoiceItem invoice)
        {
            _invoiceItemDal.Update(invoice);
        }
    }
}
