using CustomerOrderServiceAPI.Services;

namespace CustomerOrderServiceAPI.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITenantProvider tenantProvider)
        {
            if (context.Request.RouteValues.TryGetValue("tenantId", out var tenantIdObj))
            {
                tenantProvider.TenantId = tenantIdObj?.ToString() ?? "";
            }
            else
            {
                throw new Exception("Tenant ID is missing in route.");
            }

            await _next(context);
        }
    }
}
