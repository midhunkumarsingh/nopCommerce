using System;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Nop.Web.Framework.Mvc.Filters
{
    /// <summary>
    /// Represents a filter attribute that specified form size limits to the Microsoft.AspNetCore.Http.HttpRequest.Form.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequestFormSizeLimitAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
    {
        private readonly FormOptions _formOptions;

        public RequestFormSizeLimitAttribute(int valueCountLimit)
        {
            _formOptions = new FormOptions
            {
                ValueCountLimit = valueCountLimit
            };
        }

        public int Order { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //you can see the original code under this link https://stackoverflow.com/a/38360093

            var features = context.HttpContext.Features;
            var formFeature = features.Get<IFormFeature>();

            if (formFeature?.Form == null)
            {
                // Request form has not been read yet, so set the limits
                features.Set<IFormFeature>(new FormFeature(context.HttpContext.Request, _formOptions));
            }
        }
    }
}
