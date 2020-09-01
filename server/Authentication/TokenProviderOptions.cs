using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace StudentRegistration.Authentication
{
    public class TokenProviderOptions
    {
        public static string Audience { get; } = "StudentRegistrationAudience";
        public static string Issuer { get; } = "StudentRegistration";
        public static SymmetricSecurityKey Key { get; } = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("StudentRegistrationSecretSecurityKeyStudentRegistration"));
        public static TimeSpan Expiration { get; } = TimeSpan.FromMinutes(5);
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
    }
}
