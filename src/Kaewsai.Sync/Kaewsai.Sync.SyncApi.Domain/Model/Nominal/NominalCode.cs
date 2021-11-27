namespace Kaewsai.Sync.SyncApi.Domain.Model.Nominal
{
    public class NominalCode
    {
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public string? CompanyId { get; set; }
        public string? CostCentre { get; set; }
        public string? CostCentreCode { get; set; }
        public string? Department { get; set; }
        public string? DepartmentCode { get; set; }
        public NominalAccountType? Type { get; set; }
        public decimal? Balance { get; set; }
    }
}