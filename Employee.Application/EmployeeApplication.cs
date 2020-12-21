using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Repository;

namespace Employee.Application
{
    public class EmployeeApplication : IEmployeeRepo
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeApplication(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public void CreateEmployeeDetails(Model.Employee employee)
        {
            _employeeRepo.CreateEmployeeDetails(employee);
        }

        public void DeleteEmployeeDetails(int id)
        {
            _employeeRepo.DeleteEmployeeDetails(id);
        }

        public List<Model.Employee> GetEmployeeDetails()
        {
            return _employeeRepo.GetEmployeeDetails().ToList();
        }

        public void UpdateEmployeeDetails(int id, Model.Employee employee)
        {
            _employeeRepo.UpdateEmployeeDetails(id, employee);
        }
    }
}
