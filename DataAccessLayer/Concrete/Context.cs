using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   public class Context : DbContext
        //enable-migrations diyip truedan sonra update-database
    {
        //Bu sınıf manuel olarak oluşturulur
        //öncelikle dataaccess layerına entity paketi kurulmalı
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<SalesTransaction> SalesTransactions { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoTracking> CargoTracking { get; set; }
    }
}
