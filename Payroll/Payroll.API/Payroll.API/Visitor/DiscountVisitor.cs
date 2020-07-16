using Payroll.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.API.Visitor
{  
    public class DiscountVisitor : IPaycheckVisitor
    {
        public void Visit(Employee employee)
        {
            double employeeDiscount = 0.0;

            if (!string.IsNullOrEmpty(employee.Name) && (employee.Name.StartsWith('a') || employee.Name.StartsWith('A')))
            {
                employeeDiscount += employee.EmployeeDeduction * 0.1; //Calculating 10% discount on deduction
            }

            foreach(var dependent in employee.Dependents)
            {
                if (!string.IsNullOrEmpty(dependent?.Name) && (dependent.Name.StartsWith('a') || dependent.Name.StartsWith('A')))
                {
                    employeeDiscount += dependent.Deduction * 0.1; //Calculating 10% discount on deduction
                }
            }

            employee.TotalDiscount = employeeDiscount;

            employee.PerPayCheckDiscount = employee.TotalDiscount / employee.PaychecksInYear;

            employee.PerPayCheckDeduction -= employee.PerPayCheckDiscount;

            employee.PaycheckAfterDeduction = employee.PaycheckBeforeDeduction - employee.PerPayCheckDeduction;
        }
    } 
}
