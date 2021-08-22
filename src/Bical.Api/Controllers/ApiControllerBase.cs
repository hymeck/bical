using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Bical.Api.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private ISender _sender;

        protected ISender Mediator => _sender ??= HttpContext.RequestServices.GetService<ISender>();
    }
}