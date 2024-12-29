using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SGame.Infrasture.JwtService
{
    public static class JwtService
    {
        public static ClaimsPrincipal DecodeJwtToken(string token, IConfiguration _configuration)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);
                var tokenhandleParam = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                SecurityToken securityToken;
                return tokenHandler.ValidateToken(token,tokenhandleParam, out securityToken); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Tuple<bool, ClaimsPrincipal> CheckAuthorize(ClaimsPrincipal claimsPrincipal)
        {
            var createId = claimsPrincipal.Identities.FirstOrDefault()?.Claims.Where(x => x.Type == "UserId").Select(x => x.Value).FirstOrDefault();
            var createName = claimsPrincipal.Identities.FirstOrDefault()?.Claims.Where(x => x.Type == "Name").Select(x => x.Value).FirstOrDefault();
            var exp = claimsPrincipal.Identities.FirstOrDefault()?.Claims.Where(x => x.Type == "exp").Select(x => x.Value).FirstOrDefault();
            var uniEpochTime = long.TryParse(exp, out var uniEpoch) ? uniEpoch : 0;
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            DateTime dateTimeToken = unixEpoch.AddSeconds(uniEpochTime);
            TimeZoneInfo indonesiaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime dateTimeIndonesia = TimeZoneInfo.ConvertTimeFromUtc(dateTimeToken, indonesiaTimeZone);
            if (dateTimeIndonesia <= DateTime.Now)
            {
                return Tuple.Create(false,claimsPrincipal);
            }
            else
            {
                return Tuple.Create(true,claimsPrincipal);
            }
        }



        public static string FetchTokenFromHeader(AuthorizationFilterContext context)
        {
            string requestToken = string.Empty;
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer ")) ;
            {
                requestToken = authorizationHeader.Substring("Bearer ".Length).Trim();
            }
            return requestToken;
        }



        public static string FetchToken(IHeaderDictionary headers)
        {
            string requestToken = string.Empty;
            var authorizationHeader = headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                requestToken = authorizationHeader.Substring("Bearer ".Length).Trim();
            }
            return requestToken;
        }


    }
}
