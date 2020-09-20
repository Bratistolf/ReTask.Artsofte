using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReTask.Artsofte.Application.CQRS.Employees.Commands.Add;
using ReTask.Artsofte.Application.CQRS.Employees.Commands.Delete;
using ReTask.Artsofte.Application.CQRS.Employees.Commands.Edit;
using ReTask.Artsofte.Application.CQRS.Employees.Queries.GetAll;
using ReTask.Artsofte.Application.CQRS.Employees.Queries.GetById;
using System.Threading.Tasks;

namespace ReTask.Artsofte.API.Controllers
{
    /// <summary>
    /// Basic employees controller.
    /// </summary>
    public class EmployeesController : ArtsofteController
    {
        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new EmployeesGetAllQuery()));
        }

        /// <summary>
        /// Gets a certain employee.
        /// </summary>
        /// <param name="id"> Employee's ID. </param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new EmployeeGetByIdQuery { Id = id }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"> Request body. </param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] EmployeeAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Edits a certain employee.
        /// </summary>
        /// <param name="id"> Employee's ID. </param>
        /// <param name="command"> Request body. </param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EmployeeEditCommand command)
        {
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Removes a certain employee from the database.
        /// </summary>
        /// <param name="id"> Employee's ID. </param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            await Mediator.Send(new EmployeeDeleteCommand { Id = id });
            return NoContent();
        }
    }
}
