﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfExpenseDal : GenericRepository<Expense>, IExpenseDal
    {
        //generic repository nin t parametresi verilmiş oldu
        //böylece napıyorum:katmanlarımı ve ordak sınıfları birbiriyle haberleştirerek böylece herkes kendine ait işlemleri gerçekleştrsin
    }
}
