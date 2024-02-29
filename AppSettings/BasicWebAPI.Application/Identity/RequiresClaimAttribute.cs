/*6
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppSettings.BasicWebAPI.Application.Identity {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequiresClaimAttribute : Attribute, IAuthorizationFilter {
        private readonly string _claimName;
        private readonly string _claimValue;
        public RequiresClaimAttribute(string claimName, string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }
        public void OnAuthorization(AuthorizationFilterContext context) {
            if(!context.HttpContext.User.HasClaim(_claimName, _claimValue)) {
                context.Result = new ForbidResult(); //or Unauthorized
            }
            
        }
    }

    /*public class RequiresClaimAttribute : Attribute, IAsyncAuthorizationFilter {
        private readonly string _claimName;
        private readonly string _claimValue;
        public RequiresClaimAttribute(string claimName , string claimValue) {
            _claimName = claimName;
            _claimValue = claimValue;
        }
        public Task OnAuthorizationAsync(AuthorizationFilterContext context) {
            if(!context.HttpContext.User.HasClaim(_claimName , _claimValue) {
                context.Result = new ForbidResult(); //or Unauthorized
            }
            return Task.CompletedTask;
        }

        /*Task IAsyncAuthorizationFilter.OnAuthorizationAsync(AuthorizationFilterContext context) {
            throw new NotImplementedException();
        }*
    }/
}
*/
