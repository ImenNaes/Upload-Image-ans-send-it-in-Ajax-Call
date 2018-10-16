using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UploadImageAjaxAccess.Startup))]
namespace UploadImageAjaxAccess
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
