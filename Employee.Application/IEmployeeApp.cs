using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee.Application
{
   public interface IEmployeeApp
    {
        List<Model.Employee> GetEmployeeDetail();
        void CreateEmployeeDetail(Model.Employee employee);
        void UpdateEmployeeDetail(int id, Model.Employee employee);
        void DeleteEmployeeDetail(int id);
    }
}
