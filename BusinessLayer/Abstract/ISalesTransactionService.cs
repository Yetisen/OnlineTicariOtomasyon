using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ISalesTransactionService
    {
        List<SalesTransaction> GetList();
        void SalesTransactionAdd(SalesTransaction salesTransaction);
        void SalesTransactionDelete(SalesTransaction salesTransaction);
        void SalesTransactionUpdate(SalesTransaction salesTransaction);
        void PassiveUpdate(SalesTransaction salesTransaction);
        SalesTransaction GetByID(int id);
        List<SalesTransaction> GetByEmployeeID(int id);
        List<SalesTransaction> GetByCariID(int id);
    }
}
