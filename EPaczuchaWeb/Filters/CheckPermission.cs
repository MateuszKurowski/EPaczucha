using System;

using Microsoft.AspNetCore.Mvc.Filters;

namespace EPaczuchaWeb.Filters
{
    public class CheckPermission : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        
        }
    }
}