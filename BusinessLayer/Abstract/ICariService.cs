using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ICariService
    {
        List<Cari> GetList();
        IEnumerable<ClassGroup> CityGroup();
        void CariAdd(Cari cari);
        void CariDelete(Cari cari);
        void CariUpdate(Cari cari);
        void PassiveUpdate(Cari cari);
        Cari GetByID(int id);
        Cari GetByMail(string mail);
    }
}
