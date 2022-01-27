using System;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;

namespace EPaczuchaWeb.Authorization
{
    public class BasicAuthorizationFilter : IAuthorizationFilter
    {
        private const string _username = "admin@admin.pl";
        private const string _password = "123456";
        private const string _realm = "App Realm";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.Filters.OfType<DisableBacisAuthentication>().Any())
                return;

            if (!context.HttpContext.Request.Headers.Keys.Contains(HeaderNames.Authorization))
            {
                context.HttpContext.Response.Headers.Add("WWW-Autheticate",
                    string.Format("Basic realm =\"{0}\"", _realm));
                context.Result = new UnauthorizedResult();
                return;
            }
            string authenticationToken = context.HttpContext.Request.Headers[HeaderNames.Authorization];
            authenticationToken = authenticationToken.Split(" ")[1].Trim();
            var decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
            var usernamePasswordArray = decodedAuthenticationToken.Split(':');
            var username = usernamePasswordArray[0];
            var password = usernamePasswordArray[1];
            if (Validate(username, password))
            {
                var identity = new GenericIdentity(username);
                IPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;
            }
            else
                context.Result = new UnauthorizedResult();
        }

        public static bool Validate(string username, string password) => _username.Equals(username) && _password.Equals(password);
    }

    [AttributeUsage(AttributeTargets.All)]
    public class DisableBacisAuthentication : Attribute, IFilterMetadata
    {
    }
}