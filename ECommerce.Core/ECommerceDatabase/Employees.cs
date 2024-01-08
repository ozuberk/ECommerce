using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Employees : BaseEntity
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public string Gender { get; set; }
        public decimal EmployeeSalary { get; set; }
        public DateTime SalaryPayDate { get; set; }
        public bool MaritalStatus { get; set; }
        public string CompanyName { get; set; }
        public string AboutTheEmployee { get; set; }
        public string LivesInACity { get; set; }
        public int EmployeeUserInfoId { get; set; }
        public Users Users { get; set; }
        public Users EmployeeUserInfo { get; set; }
    }
}
