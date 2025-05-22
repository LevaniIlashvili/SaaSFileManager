using AutoMapper;
using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;

namespace SaaSFileManager.Application.Features.Companies.Queries.GetEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeVm>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper, ILoggedInUserService loggedInUserService)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<List<EmployeeVm>> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
        {
            var companyId = Guid.Parse(_loggedInUserService.UserId);

            var employees = await _employeeRepository.ListByCompanyId(companyId);

            return _mapper.Map<List<EmployeeVm>>(employees);
        }
    }
}
