namespace SaaSFileManager.Application.Features.Companies.Queries.GetCompanyDetails
{
    public class CompanyDetailsVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
    }
}
