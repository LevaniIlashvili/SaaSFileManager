using AutoMapper;
using MediatR;
using SaaSFileManager.Application.Contracts.Persistence;

namespace SaaSFileManager.Application.Features.Companies.Queries.GetEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeVm>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeVm>> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.ListAllAsync();

            return _mapper.Map<List<EmployeeVm>>(employees);
        }
    }
}
