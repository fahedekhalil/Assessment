namespace CustomerOrderServiceAPI.Services
{
    public interface ITenantProvider
    {
        string TenantId { get; set; }
    }

    public class TenantProvider : ITenantProvider
    {
        public string TenantId { get; set; } = string.Empty;
    }
}
