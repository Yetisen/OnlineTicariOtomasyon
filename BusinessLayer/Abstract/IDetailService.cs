using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IDetailService
    {
        List<Detail> GetList();
        void DetailAdd(Detail detail);
        void DetailDelete(Detail detail);
        void DetailUpdate(Detail detail);
        Detail GetByID(int id);
    }
}
