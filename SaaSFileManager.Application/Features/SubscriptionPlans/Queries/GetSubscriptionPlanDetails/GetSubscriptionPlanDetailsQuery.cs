using MediatR;

namespace SaaSFileManager.Application.Features.SubscriptionPlans.Queries.GetSubscriptionPlanDetails
{
    public class GetSubscriptionPlanDetailsQuery : IRequest<SubscriptionPlanDetailsVm>
    {
        public string Id { get; set; }

        public GetSubscriptionPlanDetailsQuery(string id)
        {
            this.Id = id;
        }
    }
}
