using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;

namespace ESorWebApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private static IAuthenticationManager AuthenticationManager =>
            HttpContext.Current.GetOwinContext().Authentication;

        [HttpGet, Route("SignIn")]
        public void SignIn()
        {
            if (!User.Identity.IsAuthenticated)
            {
                // To execute a policy, you simply need to trigger an OWIN challenge.
                // You can indicate which policy to use by specifying the policy id as the AuthenticationType
                AuthenticationManager.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }
        
        
        [HttpGet, Route("Callback")]
        public void Callback()
        {
            if (!User.Identity.IsAuthenticated)
            {
                // To execute a policy, you simply need to trigger an OWIN challenge.
                // You can indicate which policy to use by specifying the policy id as the AuthenticationType
                AuthenticationManager.Challenge(
                    new AuthenticationProperties{ RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        [HttpGet, Route("SignOut")]
        public void SignOut()
        {
            // To sign out the user, you should issue an OpenIDConnect sign out request
            if (User.Identity.IsAuthenticated)
            {
                var authTypes = AuthenticationManager.GetAuthenticationTypes();
                AuthenticationManager.SignOut(authTypes.Select(t => t.AuthenticationType).ToArray());
            }
        }
    }
}