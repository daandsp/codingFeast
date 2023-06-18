using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<ActionResult> MediatorActionAsync<TAction>(TAction action)
        {
            if (action == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(action);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        protected async Task<ActionResult<TResult>> MediatorActionAsync<TResult, TAction>(TAction action)
        {
            if (action == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(action);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        protected async Task PublishNotificationAsync<TNotification>(TNotification notification)
            where TNotification : INotification
        {
            if (notification == null)
            {
                return;
            }

            await _mediator.Publish(notification);
        }

        protected string GetRequestUserId()
        {
            return User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
        }

        protected string GetRefreshToken()
        {
            return User.Claims.SingleOrDefault(claim => claim.Type == "RefreshToken")?.Value;
        }
    }
}
