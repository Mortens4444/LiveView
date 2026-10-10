using Microsoft.IdentityModel.Tokens;

namespace LiveView.WebApi.Authorization
{
    public class JwtOptions
    {
        public const string Issuer = "LiveView.WebApi";
        public const string Audience = "LiveView.WebApi";

        public JwtOptions(SymmetricSecurityKey signingKey)
        {
            SigningKey = signingKey;
        }

        public SymmetricSecurityKey SigningKey { get; }
    }
}
