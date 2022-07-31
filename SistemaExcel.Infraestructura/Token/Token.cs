using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SistemaExcel.Applicacion.Constantes;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using SistemaExcel.Dominio.Repository;

namespace SistemaExcel.Infraestructura.Token
{
    public class Token: IToken
    {
        private readonly IConfiguration _configuration;

        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GenerarTokenJwt(string username)
        {
            // appsetting for Token JWT
            var secretKey = _configuration.GetSection(ConstantesJwt.secretKey).Value;
            var audienceToken = _configuration.GetSection(ConstantesJwt.audienceToken).Value;
            var issuerToken = _configuration.GetSection(ConstantesJwt.issuerToken).Value;
            var expireTime = _configuration.GetSection(ConstantesJwt.expireTime).Value;

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });

            // crea token para el usuario
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}
