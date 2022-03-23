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
   public class SalesTransactionManager : ISalesTransactionService
    {
        ISalesTransactionDal _salesTransactionDal;

        public SalesTransactionManager(ISalesTransactionDal salesTransactionDal)
        {
            _salesTransactionDal = salesTransactionDal;
        }

        public List<SalesTransaction> GetByEmployeeID(int id)
        {
            return _salesTransactionDal.List(x => x.EmployeeID == id);
        }
        public List<SalesTransaction> GetByCariID(int id)
        {
            return _salesTransactionDal.List(x => x.CariID == id);
        }

        public SalesTransaction GetByID(int id)
        {
            return _salesTransactionDal.Get(x => x.SalesTransactionID == id);
        }

        public List<SalesTransaction> GetList()
        {
           return _salesTransactionDal.List(x => x.Status == true);
        }

        public void SalesTransactionAdd(SalesTransaction salesTransaction)
        {
            _salesTransactionDal.Insert(salesTransaction);
        }

        public void SalesTransactionDelete(SalesTransaction salesTransaction)
        {
            throw new NotImplementedException();
        }

        public void SalesTransactionUpdate(SalesTransaction salesTransaction)
        {
            _salesTransactionDal.Update(salesTransaction);
        }
        public void PassiveUpdate(SalesTransaction salesTransaction)
        {
            salesTransaction.Status = false;
            _salesTransactionDal.Update(salesTransaction);
        }
    }
}
