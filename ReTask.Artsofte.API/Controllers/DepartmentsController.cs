using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReTask.Artsofte.Application.CQRS.Departments.Commands.Add;
using ReTask.Artsofte.Application.CQRS.Departments.Commands.Delete;
using ReTask.Artsofte.Application.CQRS.Departments.Commands.Edit;
using ReTask.Artsofte.Application.CQRS.Departments.Queries.GetAll;
using ReTask.Artsofte.Application.CQRS.Departments.Queries.GetById;
using System.Threading.Tasks;

namespace ReTask.Artsofte.API.Controllers
{
    /// <summary>
    /// Basic department controller.
    /// </summary>
    public class DepartmentsController : ArtsofteController
    {
        /// <summary>
        /// Gets all departments.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new DepartmentsGetAllQuery()));
        }

        /// <summary>
        /// Gets a certain department.
        /// </summary>
        /// <param name="id"> Department's ID. </param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DepartmentGetByIdQuery { Id = id }));
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
        public async Task<IActionResult> Add([FromBody] DepartmentAddCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Edits a certain department.
        /// </summary>
        /// <param name="id"> Department's ID. </param>
        /// <param name="command"> Request body. </param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] DepartmentEditCommand command)
        {
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Removes a certain department from the database.
        /// </summary>
        /// <param name="id"> Department's ID. </param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            await Mediator.Send(new DepartmentDeleteCommand { Id = id });
            return NoContent();
        }
    }
}
