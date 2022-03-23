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
   public class DetailManager : IDetailService
    {
        IDetailDal _detailDal;

        public DetailManager(IDetailDal detailDal)
        {
            _detailDal = detailDal;
        }

        public void DetailAdd(Detail detail)
        {
            throw new NotImplementedException();
        }

        public void DetailDelete(Detail detail)
        {
            throw new NotImplementedException();
        }

        public void DetailUpdate(Detail detail)
        {
            throw new NotImplementedException();
        }

        public Detail GetByID(int id)
        {
            return _detailDal.Get(x => x.DetailID == id);
        }

        public List<Detail> GetList()
        {
            return _detailDal.List(x => x.DetailID == 1);//bu şart şimdilik
        }
    }
}
