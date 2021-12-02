using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace FleetManager.API
{
    // these classes are for trying out concepts here
    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0#default-configuration

    public class Index2Model : PageModel
    {
        private IConfigurationRoot ConfigRoot;

        public Index2Model(IConfiguration configRoot)
        {
            ConfigRoot = (IConfigurationRoot)configRoot;
        }

        public ContentResult OnGet()
        {           
            string str = "";
            foreach (var provider in ConfigRoot.Providers.ToList())
            {
                str += provider.ToString() + "\n";
            }

            return Content(str);
        }
    }

    public class Test22Model : PageModel
    {
        private readonly IConfiguration Configuration;

        public Test22Model(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult OnGet()
        {
            var securityOptions = new SecurityOptions();
            Configuration.GetSection(SecurityOptions.Security).Bind(securityOptions);

            return Content($"Password: {securityOptions.Password} \n" +
                           $"Port: {securityOptions.Port}");
        }
    }
}