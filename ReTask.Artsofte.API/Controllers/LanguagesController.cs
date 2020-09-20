using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReTask.Artsofte.API.Controllers;
using ReTask.Artsofte.Application.CQRS.Languages.Commands.Add;
using ReTask.Artsofte.Application.CQRS.Languages.Commands.Delete;
using ReTask.Artsofte.Application.CQRS.Languages.Commands.Edit;
using ReTask.Artsofte.Application.CQRS.Languages.Queries.GetAll;
using ReTask.Artsofte.Application.CQRS.Languages.Queries.GetById;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Controllers
{
    /// <summary>
    /// Basic languages controller.
    /// </summary>
    public class LanguagesController : ArtsofteController
    {
        /// <summary>
        /// Gets all languages.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new LanguagesGetAllQuery { }));
        }

        /// <summary>
        /// Gets a certain language.
        /// </summary>
        /// <param name="id"> Language's ID. </param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new LanguageGetByIdQuery { Id = id }));
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
        public async Task<IActionResult> Add([FromBody] LanguageAddCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Edits a certain language.
        /// </summary>
        /// <param name="id"> Language's ID. </param>
        /// <param name="command"> Request body. </param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] LanguageEditCommand command)
        {
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Removes a certain language from the database.
        /// </summary>
        /// <param name="id"> Department's ID. </param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await Mediator.Send(new LanguageDeleteCommand { Id = id });
            return NoContent();
        }
    }
}
