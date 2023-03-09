using CQRSMediatR.Dto;
using CQRSMediatR.MediatR.Employee.Command;
using CQRSMediatR.MediatR.Employee.Query;
using CQRSMediatR.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> New(EmployeeVm vm)
        {
            var dto = new EmployeeDto(vm.FirstName, vm.LastName, vm.Address, vm.Phone, vm.Salary);
            await _mediator.Send(new NewEmployeeCommand(dto));
            return Ok();
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(long id)
        {
            var employee = await _mediator.Send(new GetSingleEmployeeQuery(id));

            var vm = new EmployeeUpdateVm()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address = employee.Address,
                Phone = employee.Phone,
                Salary = employee.Salary,
                Employee = employee
            };

            return Ok(vm);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                var employee = await _mediator.Send(new GetSingleEmployeeQuery(id));
                await _mediator.Send(new DeleteEmployeeCommand(employee));
                return Ok();
            }
            catch (Exception e)
            {
                return Ok();
            }
        }
    }
}
