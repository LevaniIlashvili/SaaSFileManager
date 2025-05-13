using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaaSFileManager.Application.Features.CompanySubscriptions.Commands.ChooseSubscriptionPlan;
using SaaSFileManager.Application.Features.CompanySubscriptions.Queries.GetCompanyCurrentSubscription;

namespace SaaSFileManager.Api.Controllers
{
    [Route("api/company-subscription")]
    [ApiController]
    public class CompanySubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanySubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("select/{SubscriptionPlanId}")]
        public async Task<IActionResult> ChooseSubscription([FromRoute] ChooseSubscriptionPlanCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<CompanySubscriptionVM>> GetCurrentSubscription()
        {
            var query = new GetCompanyCurrentSubscriptionQuery();
            return await _mediator.Send(query);
        }
        
    }
}
