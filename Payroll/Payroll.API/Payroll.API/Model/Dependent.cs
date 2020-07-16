using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.API.Model
{
    public class Dependent
    {
        public string Name { set; get; }

        public double Deduction { set; get; }

        public Dependent()
        {
            // todo: Constats can move to constans file
            this.Deduction = 500;
        }

    }
}
