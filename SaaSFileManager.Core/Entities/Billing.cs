namespace SaaSFileManager.Core.Entities
{
    public class Billing
    {
        public int Id { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime DueDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; } = new();
    }
}
