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
   public class CariManager: ICariService
    {
        ICariDal _cariDal;

        public CariManager(ICariDal cariDal)
        {
            _cariDal = cariDal;
        }

        public void CariAdd(Cari cari)
        {
            _cariDal.Insert(cari);
        }

        public void CariDelete(Cari cari)
        {
            _cariDal.Delete(cari);
        }

        public void CariUpdate(Cari cari)
        {
            _cariDal.Update(cari);
        }

        public Cari GetByID(int id)
        {
            return _cariDal.Get(x => x.CariID == id);
        }
        public Cari GetByMail(string mail)
        {
            return _cariDal.Get(x => x.CariMail== mail);
        }

        public List<Cari> GetList()
        {
            return _cariDal.List(x => x.State == true);
        }
        public void PassiveUpdate(Cari cari)
        {
            cari.State = false;
            _cariDal.Update(cari);
        }
        public IEnumerable<ClassGroup> CityGroup()
        {
            var sorgu = from x in GetList()
                        group x by x.CariCity into g
                        select new ClassGroup
                        {
                            City = g.Key,
                            Total = g.Count()
                        };
            return sorgu;

        }
    }
}
