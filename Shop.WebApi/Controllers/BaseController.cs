﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Shop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator
        {
            get
            {
                return _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
            }
        }

        internal Guid UserId => !User.Identity.IsAuthenticated
             ? Guid.NewGuid()
             : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
