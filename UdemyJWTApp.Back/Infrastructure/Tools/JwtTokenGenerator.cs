﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {
        public static JwtTokenResponse GenerateToken(CheckUserResponseDto dto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key));
            SigningCredentials credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, dto.Role));
            claims.Add(new Claim(ClaimTypes.Name, dto.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));
            var expireDate = DateTime.UtcNow.AddMinutes(1);
            JwtSecurityToken token = new JwtSecurityToken(issuer:JwtTokenSettings.Issuer,audience:JwtTokenSettings.Audience,claims:claims,notBefore:DateTime.UtcNow,expires:expireDate, signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return new JwtTokenResponse(handler.WriteToken(token),expireDate);
        }



    }
}