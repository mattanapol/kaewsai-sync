namespace Kaewsai.Sync.SyncApi.Domain.Model.Nominal
{
    public enum NominalAccountType: long
    {
        Unknown = -1,
        NominalAccountTypePosting = 0,
        NominalAccountTypeGroup = 1,
        NominalAccountTypeMemo = 2,
    }
}