using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IExpenseService
    {
        List<Expense> GetList();
        void ProductAdd(Expense expense);
        void ProductDelete(Expense expense);
        void ProductUpdate(Expense expense);
        Expense GetByID(int id);
    }
}
