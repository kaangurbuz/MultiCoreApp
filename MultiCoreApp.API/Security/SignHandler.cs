using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MultiCoreApp.API.Security
{
    public static class SignHandler
    {
        public static SecurityKey GetSymetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }        
    }
}
