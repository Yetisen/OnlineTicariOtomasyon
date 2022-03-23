using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Class1
    {
        //IEnumurable koleksiyon yapısı olarak tutan interface
        //bu sayfada ürünü listeleyeceğim
       public IEnumerable<Product> Deger1 { get; set; }
       public IEnumerable<Detail> Deger2 { get; set; }
        // böylece bu proplar 2 değeride collection olarak tutacak
    }
}
