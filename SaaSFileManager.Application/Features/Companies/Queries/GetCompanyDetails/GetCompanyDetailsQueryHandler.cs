using AutoMapper;
using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSFileManager.Application.Features.Companies.Queries.GetCompanyDetails
{
    public class GetCompanyDetailsQueryHandler : IRequestHandler<GetCompanyDetailsQuery, CompanyDetailsVm>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;

        public GetCompanyDetailsQueryHandler(ICompanyRepository companyRepository, ILoggedInUserService loggedInUserService, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
        }

        public async Task<CompanyDetailsVm> Handle(GetCompanyDetailsQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(Guid.Parse(_loggedInUserService.UserId));

            return _mapper.Map<CompanyDetailsVm>(company);
        }
    }
}
