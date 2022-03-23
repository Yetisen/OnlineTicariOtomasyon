using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ICargoTrackingService
    {
        List<CargoTracking> GetList();
        void CargoTrackingAdd(CargoTracking cargoT);
        void CargoTrackingDelete(CargoTracking cargoT);
        void CargoTrackingUpdate(CargoTracking cargoT);
        void PassiveUpdate(CargoTracking cargoT);
        CargoTracking GetByID(int id);
    }
}
