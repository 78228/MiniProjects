using Payroll.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.API.DTO
{
    public class EmployeeDTO
    {
        public string Name { set; get; }
        public List<Dependent> Dependents { set; get; }
    }
}
