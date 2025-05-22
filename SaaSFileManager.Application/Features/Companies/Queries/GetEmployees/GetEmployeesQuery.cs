using MediatR;

namespace SaaSFileManager.Application.Features.Companies.Queries.GetEmployees
{
    public class GetEmployeesQuery : IRequest<List<EmployeeVm>>
    {
    }
}
