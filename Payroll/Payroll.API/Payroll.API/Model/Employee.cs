using Payroll.API.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.API.Model
{
    interface IPaycheck
    {
        public void Accept(IPaycheckVisitor visitor);
    }

    public class Employee : IPaycheck
    {
        public string Name { set; get; }
        public List<Dependent> Dependents { set; get; }
        public double PaycheckBeforeDeduction { set; get; }
        public double EmployeeDeduction { set; get; }
        public double TotalDeduction { set; get; }
        public double PerPayCheckDeduction { set; get; }
        public double PerPayCheckDiscount { set; get; }
        public double TotalDiscount { set; get; }
        public double PaycheckAfterDeduction { set; get; }
        public int PaychecksInYear { set; get; }

        public Employee()
        {
            //todo: Constats can move to constans file
            this.EmployeeDeduction = 1000;
            this.PaycheckBeforeDeduction = 2000;
            this.PaychecksInYear = 26;
        }

        public void Accept(IPaycheckVisitor Visitor)
        {
            Visitor.Visit(this);
        }
    }
}
