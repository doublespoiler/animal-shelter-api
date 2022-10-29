using AnimalShelterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AnimalShelterApi.Repository
{
	public class JWTManagerRepository : IJWTManagerRepository
	{

		Dictionary<string, string> UsersRecords = new Dictionary<string, string>
		{
			{"admin","admin"},
		};

		private readonly IConfiguration iConfiguration;
		public JWTManagerRepository(IConfiguration iconfiguration)
		{
			this.iConfiguration = iconfiguration;
		}
		public Tokens Authenticate(User user)
		{
      // If no user authenticated, return null
			if (!UsersRecords.Any(x => x.Key == user.Name && x.Value == user.Password)) {
				return null;
			}
			// Else we generate JSON Web Token
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(iConfiguration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
				new Claim(ClaimTypes.Name, user.Name)                    
				}),
				Expires = DateTime.UtcNow.AddMinutes(525600),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new Tokens { Token = tokenHandler.WriteToken(token) };

		}
	}
}