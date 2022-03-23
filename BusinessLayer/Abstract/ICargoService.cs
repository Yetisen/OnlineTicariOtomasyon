using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ICargoService
    {
        List<CargoDetail> GetList();
        void CargoAdd(CargoDetail cargo);
        void CargoDelete(CargoDetail cargo);
        void CargoUpdate(CargoDetail cargo);
        void PassiveUpdate(CargoDetail cargo);
        CargoDetail GetByID(int id);
    }
}
