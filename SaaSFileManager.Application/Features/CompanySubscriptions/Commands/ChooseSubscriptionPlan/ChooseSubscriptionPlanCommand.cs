using MediatR;

namespace SaaSFileManager.Application.Features.CompanySubscriptions.Commands.ChooseSubscriptionPlan
{
    public class ChooseSubscriptionPlanCommand : IRequest
    {
        public string SubscriptionPlanId { get; set; }
    }
}
