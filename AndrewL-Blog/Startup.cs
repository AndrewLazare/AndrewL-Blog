using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AndrewL_Blog.Startup))]
namespace AndrewL_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
