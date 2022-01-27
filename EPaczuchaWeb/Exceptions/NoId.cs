using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EPaczuchaWeb.Exceptions
{
    public class NoId : Exception
    {
        public NoId() : base()
        {
        }

        public NoId(string? message) : base(message)
        {
        }

        public NoId(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class NoIdAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NoId)
            {
                var body = new Dictionary<string, Object>();
                body["error"] = context.Exception.Message;
                context.Result = new BadRequestObjectResult(body);
            }
        }
    }
}
