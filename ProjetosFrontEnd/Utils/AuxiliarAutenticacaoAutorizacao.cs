using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;

namespace ProjetosFrontEnd.Utils;

public class AuxiliarAutenticacaoAutorizacao
{
    public static bool ValidateToken(string authToken)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters(authToken);

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    private static TokenValidationParameters GetValidationParameters(string key)
    {
        return new TokenValidationParameters()
        {
            ValidateLifetime = false, // Because there is no expiration in the generated token
            ValidateAudience = false, // Because there is no audiance in the generated token
            ValidateIssuer = false,   // Because there is no issuer in the generated token
            ValidIssuer = "Sample",
            ValidAudience = "Sample",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // The same key as the one that generate the token
        };
    }
}
