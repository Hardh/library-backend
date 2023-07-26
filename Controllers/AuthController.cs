using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using library_backend.Application.Request;
using library_backend.Application.services;
using library_backend.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace library_backend.Controllers;

[ApiController]
[Route("auth")]
public class AuthController: ControllerBase
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [AllowAnonymous]
    [HttpPost(Name = "login")]
    public async Task<TokenResponse> Post([FromBody] UserRequest userRequest)
    {
        string token = await _authService.login(userRequest.UserName, userRequest.Password);
        var response = new TokenResponse { Token = token };
        return response;
    }
    
}