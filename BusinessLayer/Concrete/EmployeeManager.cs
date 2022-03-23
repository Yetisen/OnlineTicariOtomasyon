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
   public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void EmployeeAdd(Employee employee)
        {
            _employeeDal.Insert(employee);
        }

        public void EmployeeDelete(Employee employee)
        {
            _employeeDal.Delete(employee);
        }

        public void EmployeeUpdate(Employee employee)
        {
            _employeeDal.Update(employee);
        }

        public List<Employee> GetByDepartment(int id)
        {
            return _employeeDal.List(x => x.DepartmentID == id);
        }

        public Employee GetByID(int id)
        {
            return _employeeDal.Get(x => x.EmployeeID == id);
        }

        public List<Employee> GetList()
        {
            return _employeeDal.List();
        }
        public IEnumerable<ClassGroupEmployee> DepartmentGroup()
        {
            var sorgu = from x in GetList()
                        group x by x.Department.DepartmentName into g
                        select new ClassGroupEmployee
                        {
                            Department = g.Key,
                            Total = g.Count()
                        };
            return sorgu;

        }
    }
}
