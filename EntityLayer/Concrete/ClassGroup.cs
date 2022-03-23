using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ClassGroup
    {
        public string City { get; set; }
        public int Total { get; set; }
    }
    public class ClassGroupEmployee
    {
        public string Department { get; set; }
        public int Total { get; set; }
    }
    public class ClassGroupBrand
    {
        public string Brand { get; set; }
        public int Total { get; set; }
    }
}
