using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IProductService
    {
        List<Product> GetList();
        IEnumerable<ClassGroupBrand> BrandGroup();
        void ProductAdd(Product product);
        void ProductDelete(Product product);
        void ProductUpdate(Product product);
        Product GetByID(int id);
    }
}
