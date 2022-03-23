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
   public class ExpenseManager : IExpenseService
    {
        IExpenseDal _expenseDal;

        public ExpenseManager(IExpenseDal expenseDal)
        {
            _expenseDal = expenseDal;
        }

        public Expense GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Expense> GetList()
        {
            throw new NotImplementedException();
        }

        public void ProductAdd(Expense expense)
        {
            throw new NotImplementedException();
        }

        public void ProductDelete(Expense expense)
        {
            throw new NotImplementedException();
        }

        public void ProductUpdate(Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}
