﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public void DepartmentAdd(Department department)
        {
            _departmentDal.Insert(department);
        }

        public void DepartmentDelete(Department department)
        {
            _departmentDal.Delete(department);
            
        }

        public void DepartmentUpdate(Department department)
        {
            _departmentDal.Update(department);
        }
        public void PassiveUpdate(Department department)
        {
            department.Status = false;
            _departmentDal.Update(department);
        }

        public Department GetByID(int id)
        {
            return _departmentDal.Get(x => x.DepartmentID == id);
        }

        public List<Department> GetList()
        {
            return _departmentDal.List(x => x.Status == true);
        }
    }
}
