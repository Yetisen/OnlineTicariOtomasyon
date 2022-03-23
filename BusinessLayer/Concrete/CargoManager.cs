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
   public class CargoManager: ICargoService
    {
        ICargoDal _cargoDal;

        public CargoManager(ICargoDal cargoDal)
        {
            _cargoDal = cargoDal;
        }

        public void CargoAdd(CargoDetail cargo)
        {
            _cargoDal.Insert(cargo);
        }

        public void CargoDelete(CargoDetail cargo)
        {
            _cargoDal.Delete(cargo);
        }

        public void CargoUpdate(CargoDetail cargo)
        {
            _cargoDal.Update(cargo);
        }

        public CargoDetail GetByID(int id)
        {
            return _cargoDal.Get(x => x.CargoDetailID == id);
        }

        public List<CargoDetail> GetList()
        {
            return _cargoDal.List();
        }

        public void PassiveUpdate(CargoDetail cargo)
        {
            //daha sonra status eklendiğinde pasif hale getirilebilir
            throw new NotImplementedException();
        }
    }
}
