using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payroll.API.DTO;
using Payroll.API.Model;
using Payroll.API.Visitor;

namespace Payroll.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaycheckController : ControllerBase
    {
        private readonly ILogger<PaycheckController> _logger;

        public PaycheckController(ILogger<PaycheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Paycheck Deduction Calculator.";
        }

        [HttpPost]
        public Employee Post(EmployeeDTO employeeDto)
        {
            //todo: DI can remove all visitor from here  
            var deductionVisitor = new DeductionVisitor();
            var discountVisitor = new DiscountVisitor();


            var employee = new Employee
            {
                Name = employeeDto.Name,
                Dependents = employeeDto.Dependents
            }; 

            employee.Accept(deductionVisitor);
            employee.Accept(discountVisitor);

            return employee;
        }
    }
}
