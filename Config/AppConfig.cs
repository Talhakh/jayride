using Microsoft.Extensions.Configuration;

namespace JayRideTest.Helpers
{
    public class AppConfig
    {
        public const string IpStackApiAccessKeyString = nameof(IpStackApiAccessKey);
        public const string IpStockApiUrlString = nameof(IpStockApiBaseUrl);
        public const string JayRideBaseUrlString = nameof(JayRideBaseUrl);

        public string IpStackApiAccessKey { get; }
        public string IpStockApiBaseUrl { get; }
        public string JayRideBaseUrl { get; }
        public AppConfig(IConfiguration configuration)
        {
            IpStackApiAccessKey = configuration[IpStackApiAccessKeyString] ?? string.Empty;
            IpStockApiBaseUrl = configuration[IpStockApiUrlString] ?? string.Empty;
            JayRideBaseUrl = configuration[JayRideBaseUrlString] ?? string.Empty;
        }
    }
}
