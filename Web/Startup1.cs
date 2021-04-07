using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Web.Startup1))]

namespace Web
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            //app.UseMicrosoftAccountAuthentication(new MicrosoftProvider().GetAuthenticationOptions());
            //app.UseTwitterAuthentication(new TwitterProvider().GetAuthenticationOptions());
            //app.UseFacebookAuthentication(new FacebookProvider().GetAuthenticationOptions());
            //app.UseGoogleAuthentication(new GoogleProvider().GetAuthenticationOptions());
            app.MapSignalR();//Maping /signalr
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                ExpireTimeSpan = TimeSpan.FromDays(1),
                LoginPath = new PathString("/Account/Login")
            });
          
        }
          

    }
}
