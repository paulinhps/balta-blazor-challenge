﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace IbgeBlazor.Domain.Shared.Services.Jwt;

public static class Token
{
    public static string GenerateToken(string userId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(ReturnClain(userId)),
            Expires = DateTime.UtcNow.AddHours(6),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.secret)),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private static IEnumerable<Claim> ReturnClain(string Id)
    {
        var userClaim = (new[]
        {
            new Claim(ClaimTypes.Name, Id.ToString()),
        }).ToList();

        return userClaim;
    }
}

