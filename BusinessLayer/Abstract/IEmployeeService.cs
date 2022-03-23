using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IEmployeeService
    {
        List<Employee> GetList();
        IEnumerable<ClassGroupEmployee> DepartmentGroup();
        void EmployeeAdd(Employee employee);
        void EmployeeDelete(Employee employee);
        void EmployeeUpdate(Employee employee);
        Employee GetByID(int id);
        List<Employee> GetByDepartment(int id);
    }
}
