using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;
using SaaSFileManager.Application.Models.Application;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Features.Auth.Commands.CreateCompany
{
    public class RegisterCompanyCommandHandler : IRequestHandler<RegisterCompanyCommand, Guid>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ApplicationSettings _appSettings;

        public RegisterCompanyCommandHandler(
            ICompanyRepository companyRepository,
            IMapper mapper,
            IEmailService emailService,
            IPasswordHasher passwordHasher,
            IOptions<ApplicationSettings> appSettings)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _emailService = emailService;
            _passwordHasher = passwordHasher;
            _appSettings = appSettings.Value;
        }

        public async Task<Guid> Handle(RegisterCompanyCommand request, CancellationToken cancellationToken)
        {
            var validator = new RegisterCompanyCommandValidator(_companyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var company = _mapper.Map<Company>(request);

            company.PasswordHash = _passwordHasher.Hash(request.Password);

            var token = Guid.NewGuid().ToString();
            company.ActivationToken = token;

            company = await _companyRepository.AddAsync(company);

            var activationLink = $"{_appSettings.BaseUrl}/api/auth/company/activate/{token}";
            await _emailService.SendActivationEmailAsync(company.Email, activationLink);

            return company.Id;
        }
    }
}
