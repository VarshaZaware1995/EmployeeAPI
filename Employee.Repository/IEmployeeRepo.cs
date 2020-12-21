using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository
{
   public interface IEmployeeRepo
    {
        List<Model.Employee> GetEmployeeDetails();
        void CreateEmployeeDetails(Model.Employee employee);
        void UpdateEmployeeDetails(int id, Model.Employee employee);
        void DeleteEmployeeDetails(int id);
    }
}
