using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using MultiCoreApp.API.Security;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.API.Security
{
    public class TokenHandler:ITokenHandler
    {
        private CustomTokenOptions _tokenOptions;

        public TokenHandler(CustomTokenOptions tokenOptions)
        {
            _tokenOptions = tokenOptions;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var secretKey = SignHandler.GetSymetricSecurityKey(_tokenOptions.SecretKey);
            SigningCredentials signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                notBefore: DateTime.Now,
                expires: accessTokenExpiration,
                claims: GetClaims(user),
                signingCredentials: signingCredentials
            );
            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);
            AccessToken accessToken = new AccessToken();
            accessToken.Token = token;
            accessToken.RefreshToken = CreateRefreshToken();
            accessToken.Expiration = accessTokenExpiration;
            
            return accessToken;
        }

        public void RevokeRefreshToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}


