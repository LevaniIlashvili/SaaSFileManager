﻿using MediatR;

namespace SaaSFileManager.Application.Features.Companies.Commands.RegisterCompany
{
    public class RegisterCompanyCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
    }
}
