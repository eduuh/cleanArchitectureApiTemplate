using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Api.Controllers
{

    [Produces("application/json")]
    public class UserController : BaseController
    {
        /// <summary>
        /// Logins in a User to the Api
        ///</summary>
        /// <remarks>
        /// Sample Request
        /// POST User/login
        /// {
        ///     "email": "josh@icropal.com",
        ///      "password": "Pa$$w0rd"
        /// }
        /// </remarks>
        /// <param name="query"></param>
        /// <returns>Some records of logged In user and Token</returns>
        /// <response code="200">Return some record of logged in user and a Token</response>
        /// <response code="401">Returns an authorised</response>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<User>> Login(Login.Query query)
        {
            return await Mediator.Send(query);
        }
    }
}