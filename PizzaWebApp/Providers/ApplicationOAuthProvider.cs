using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using PizzaWebApp.App_Start;

namespace PizzaWebApp.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }


        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            var form = await context.Request.ReadFormAsync();

            var loginResult = AuthenticateUser(context);

            if (loginResult.Result != 1)
            {
                context.SetError(loginResult.Result.ToString(), "Invalid UserName or password");
                return;
            }


            ClaimsIdentity oAuthIdentity =
            new ClaimsIdentity(context.Options.AuthenticationType);

            var props = GetProperties(loginResult);
            AuthenticationProperties properties = new AuthenticationProperties(props);
            foreach (var prop in props)
            {
                oAuthIdentity.AddClaim(new Claim(prop.Key, prop.Value));
            }
            AuthenticationTicket ticket =
            new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(oAuthIdentity);


        }

        private IDictionary<string, string> GetProperties(UserDetail user)
        {

            string pwd = String.Empty;

            return new Dictionary<string, string>
            {
                 { ClaimTypes.NameIdentifier, user.UserId.ToString() },
                {"Result",user.Result.ToString()},
                {"UserId", user.UserId.ToString() }
            };

        }

        private UserDetail AuthenticateUser(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                UserService userService = new UserService();
                UserDetail userDetail = new UserDetail();
                userDetail.Email = context.UserName;
                userDetail.Password = context.Password;
                userDetail = userService.SignIn(userDetail);

                return userDetail;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }
    }
}