using MediatR;

namespace SaaSFileManager.Application.Features.SubscriptionPlans.Queries.GetSubscriptionPlans
{
    public class GetSubscriptionPlansQuery : IRequest<List<SubscriptionPlanVm>>
    {
    }
}
