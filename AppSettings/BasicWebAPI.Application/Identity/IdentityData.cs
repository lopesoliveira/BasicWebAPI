namespace AppSettings.BasicWebAPI.Application.Identity {
    //There is also another level of authorization that is implemented with claims, for example everybody is allowed to get Logins but only admins can delete Logins
    public class IdentityData {
        public const string AdminUserClaimName = "admin";
        public const string AdminUserPolicyName = "Admin";
    }
}

//ALTERNATIVE
// Another option is to use only claims without the need of Policies
// RequiresClaimAttribute.cs
