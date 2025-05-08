using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaaSFileManager.Application.Features.SubscriptionPlans.Queries.GetSubscriptionPlanDetails;
using SaaSFileManager.Application.Features.SubscriptionPlans.Queries.GetSubscriptionPlans;

namespace SaaSFileManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPlanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionPlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubscriptionPlanVm>>> GetPlans()
        {
            var query = new GetSubscriptionPlansQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionPlanDetailsVm>> GetPlanDetails([FromRoute] string id)
        {
            var query = new GetSubscriptionPlanDetailsQuery(id);
            return await _mediator.Send(query);
        }
    }
}
