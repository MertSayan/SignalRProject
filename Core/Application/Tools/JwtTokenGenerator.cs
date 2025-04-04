﻿using Application.Dtos;
using Application.Features.Mediatr.Logins.Results;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseDto GenerateToken(GetUserByUserNameAndPasswordQueryResult result)
		{
			var claims = new List<Claim>();
			if (!string.IsNullOrWhiteSpace(result.RoleName))
				claims.Add(new Claim(ClaimTypes.Role, result.RoleName));

			claims.Add(new Claim(ClaimTypes.NameIdentifier, result.UserId.ToString()));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

			var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			//var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
			var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);

			JwtSecurityToken token = new JwtSecurityToken(
				issuer: JwtTokenDefaults.ValidIssuer,
				audience: JwtTokenDefaults.ValidAudience,
				claims: claims,
				notBefore: DateTime.UtcNow,
				expires: expireDate,
				signingCredentials: signinCredentials
				);

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);


		}
	}
}
