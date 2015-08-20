using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(Server.AuthHelpers.Startup))]
namespace Server.AuthHelpers
{
    
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            System.Diagnostics.Trace.TraceInformation("Application started");
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Account/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

//        #region comments
//        public class Startup
//        {
//            public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
//            public static GoogleOAuth2AuthenticationOptions googleAuthOptions { get; private set; }
//            public static FacebookAuthenticationOptions facebookAuthOptions { get; private set; }

//            public void Configuration(IAppBuilder app)
//            {
//                HttpConfiguration config = new HttpConfiguration();

//                ConfigureOAuth(app);

//                WebApiConfig.Register(config);
//                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
//                app.UseWebApi(config);
//                Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, AngularJSAuthentication.API.Migrations.Configuration>());

//            }

//            public void ConfigureOAuth(IAppBuilder app)
//            {
//                //use a cookie to temporarily store information about a user logging in with a third party login provider
//                app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
//                OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

//                OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
//                {

//                    AllowInsecureHttp = true,
//                    TokenEndpointPath = new PathString("/token"),
//                    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
//                    Provider = new SimpleAuthorizationServerProvider(),
//                    RefreshTokenProvider = new SimpleRefreshTokenProvider()
//                };

//                // Token Generation
//                app.UseOAuthAuthorizationServer(OAuthServerOptions);
//                app.UseOAuthBearerAuthentication(OAuthBearerOptions);

//                //Configure Google External Login
//                googleAuthOptions = new GoogleOAuth2AuthenticationOptions()
//                {
//                    ClientId = "xxxxxx",
//                    ClientSecret = "xxxxxx",
//                    Provider = new GoogleAuthProvider()
//                };
//                app.UseGoogleAuthentication(googleAuthOptions);

//                //Configure Facebook External Login
//                facebookAuthOptions = new FacebookAuthenticationOptions()
//                {
//                    AppId = "xxxxxx",
//                    AppSecret = "xxxxxx",
//                    Provider = new FacebookAuthProvider()
//                };
//                app.UseFacebookAuthentication(facebookAuthOptions);

//            }
//        }
//#endregion comments

    }
}