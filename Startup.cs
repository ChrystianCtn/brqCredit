using Microsoft.Extensions.Configuration;

namespace brqCredit
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = config.Build();
        }
    }
}
