using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShipSim.Players.Module.Contracts.Configuration;
using ShipSim.Players.Module.Contracts.Events;
using ShipSim.Players.Module.Contracts.Requests;
using ShipSim.Players.Module.Contracts.ViewModels;
using ShipSim.Players.Module.Entities;

namespace ShipSim.Players.Module.RequestHandlers;

internal class SignInUserRequestHandler(
    SignInManager<Player> signInManager,
    UserManager<Player> userManager, 
    IOptions<JwtConfig> jwtConfig,
    IMapper mapper,
    IMediator mediator
    ) : IRequestHandler<SignInUserRequest, SignInUserRequestResult>
{
    public async Task<SignInUserRequestResult> Handle(SignInUserRequest request, CancellationToken cancellationToken)
    {
        var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
        
        if (result.Succeeded)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            var token = GenerateAccessToken(user);
            
            await mediator.Publish(new UserSignedInEvent(mapper.Map<PlayerDto>(user)), cancellationToken);
            return new SignInUserRequestResult(token, null);
        }
        else
        {
            throw new Exception("Failed to sign in user");
        }
    }
    
    private string GenerateAccessToken(Player user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtConfig.Value.Secret);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            }),
            Audience = jwtConfig.Value.Audience,
            Issuer = jwtConfig.Value.Issuer,
            Expires = DateTime.UtcNow.AddMinutes(jwtConfig.Value.ExpiryInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}