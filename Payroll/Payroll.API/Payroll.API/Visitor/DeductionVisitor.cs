using Payroll.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.API.Visitor
{  
    public interface IPaycheckVisitor
    {
        void Visit(Employee employee);
    }

    public class DeductionVisitor : IPaycheckVisitor
    {
        public void Visit(Employee employee)
        {
            employee.TotalDeduction = employee.EmployeeDeduction;

            foreach (var dependent in employee.Dependents)
            {
                if (dependent != null && !string.IsNullOrEmpty(dependent.Name))
                    employee.TotalDeduction += dependent.Deduction;
            }

            employee.PerPayCheckDeduction = employee.TotalDeduction / employee.PaychecksInYear;

            employee.PaycheckAfterDeduction = employee.PaycheckBeforeDeduction - employee.PerPayCheckDeduction;
        }
    } 
}
