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
   public class InvoiceManager : IInvoiceService
    {
        IInvoiceDal _invoiceDal;

        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }

        public Invoice GetByID(int id)
        {
            return _invoiceDal.Get(x => x.InvoiceID == id);
        }

        public List<Invoice> GetList()
        {
            return _invoiceDal.List();
        }

        public void InvoiceAdd(Invoice invoice)
        {
            _invoiceDal.Insert(invoice);
        }

        public void InvoiceDelete(Invoice invoice)
        {
            _invoiceDal.Delete(invoice);
        }

        public void InvoiceUpdate(Invoice invoice)
        {
            _invoiceDal.Update(invoice);
        }
    }
}
