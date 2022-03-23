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
   public class CargoTrackingManager : ICargoTrackingService
    {
        ICargoTrackingDal _cargoTrackingDal;

        public CargoTrackingManager(ICargoTrackingDal cargoTrackingDal)
        {
            _cargoTrackingDal = cargoTrackingDal;
        }

        public void CargoTrackingAdd(CargoTracking cargoT)
        {
            _cargoTrackingDal.Insert(cargoT);
        }

        public void CargoTrackingDelete(CargoTracking cargoT)
        {
            _cargoTrackingDal.Delete(cargoT);
        }

        public void CargoTrackingUpdate(CargoTracking cargoT)
        {
            _cargoTrackingDal.Update(cargoT);
        }

        public CargoTracking GetByID(int id)
        {
            return _cargoTrackingDal.Get(x => x.CargoTrackingID == id);
        }

        public List<CargoTracking> GetList()
        {
            return _cargoTrackingDal.List();
        }

        public void PassiveUpdate(CargoTracking cargoT)
        {
            //daha sonra aktif pasif eklemek istersem
            throw new NotImplementedException();
        }
    }
}
