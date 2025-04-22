using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ApplicationSettings _appSettings;

        public CreateCompanyCommandHandler(
            ICompanyRepository companyRepository,
            IMapper mapper,
            IEmailService emailService,
            IOptions<ApplicationSettings> appSettings )
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _emailService = emailService;
            _appSettings = appSettings.Value;
        }

        public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCompanyCommandValidator(_companyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var company = _mapper.Map<Company>(request);

            company.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var token = Guid.NewGuid().ToString();
            company.ActivationToken = token;

            company = await _companyRepository.AddAsync(company);

            var activationLink = $"{_appSettings.BaseUrl}/api/company/activate?token={token}";
            await _emailService.SendActivationEmailAsync(company.Email, activationLink);

            return company.Id;
        }
    }
}
