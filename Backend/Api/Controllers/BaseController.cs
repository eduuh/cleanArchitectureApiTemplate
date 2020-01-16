using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Controllers
{
   [Produces("application/json")]
   [ApiController]
   [Route("api/[Controller]")]
    public class BaseController : ControllerBase
    {
     
     private  IMediator _mediator;
     protected IMediator Mediator => _mediator ??
     (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    
        
    }
}