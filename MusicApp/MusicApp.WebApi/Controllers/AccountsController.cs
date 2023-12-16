using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.DTOs.AccountDTOs;
using MusicApp.Application.Features.AccountFeatures.Commands.ForgotPasswordCmd;
using MusicApp.Application.Features.AccountFeatures.Commands.LoginCmd;
using MusicApp.Application.Features.AccountFeatures.Commands.LogoutCmd;
using MusicApp.Application.Features.AccountFeatures.Commands.RegisterCmd;
using MusicApp.Application.Features.AccountFeatures.Commands.RenewTokenCmd;
using MusicApp.Application.Features.AccountFeatures.Commands.ResendOTPCmd;
using MusicApp.Application.Features.AccountFeatures.Commands.ResetPasswordCmd;
using MusicApp.Application.Features.AccountFeatures.Commands.VerifyAccountCmd;
using MusicApp.Application.Features.AccountFeatures.Queries.ValidateResetPasswordTokenQry;
using MusicApp.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace MusicApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly UserManager<AppUser> _userManager;

    public AccountsController(IMediator mediator, UserManager<AppUser> userManager)
    {
        _mediator = mediator;
        _userManager = userManager;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<AccountsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }


    [Route("register")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(RegisterDTO registerDTO)
    {
        var command = new RegisterCommand(registerDTO);
        var response = await _mediator.Send(command);

        return Ok(new { userId = response });
    }



    [HttpPost("verify-account/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> VerifyAccount(string userId, VerifyAccountDTO verifyAccountDTO)
    {
        var command = new VerifyAccountCommand(userId, verifyAccountDTO);
        var response = await _mediator.Send(command);

        return Ok(response);
    }


    [HttpPost("resend-otp/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResendOTP(string userId)
    {
        var command = new ResendOTPCommand(userId);
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [Route("forgot-password")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
    {
        var command = new ForgotPasswordCommand(forgotPasswordDTO);
        var response = await _mediator.Send(command);
        return Ok(new { Message = response });
    }


    [Route("login")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        var command = new LoginCommand(loginDTO);
        var loginResponse = await _mediator.Send(command);

        //// Set the access token cookie
        //SetAccessTokenCookie(loginResponse.AccessToken);

        // Set the refresh token cookie
        SetRefreshTokenCookie(loginResponse.RefreshToken);

        return Ok(new
        {
            AccessToken = loginResponse.AccessToken,
            RefreshToken = loginResponse.RefreshToken.Token
        });
    }

    [Route("renew-token")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RenewToken()
    {
        // Retrieve the refreshToken from HttpContext.Items
        if (!HttpContext.Items.TryGetValue("refreshToken", out var refreshTokenObject) || !(refreshTokenObject is string refreshToken))
        {
            // Handle the case where refreshToken is not found or is not a string
            return BadRequest(new { message = "Invalid refresh token." });
        }

        // Create the RenewTokenDTO using the captured refreshToken
        var renewTokenDTO = new RenewTokenDTO { Token = refreshToken };

        var command = new RenewTokenCommand(renewTokenDTO);
        var response = await _mediator.Send(command);

        //// Update the HttpOnly access token cookie
        //SetAccessTokenCookie(response);

        return Ok(new { AccessToken = response });
    }


    [HttpPost("reset-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO)
    {
        var command = new ResetPasswordCommand(resetPasswordDTO);
        var response = await _mediator.Send(command);
        return Ok(new { Message = response });
    }
     

    [HttpGet("validate-reset-password-token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ValidateResetPasswordToken(string email, string token)
    {
        var query = new ValidateResetPasswordTokenQuery(email, token);
        var response = await _mediator.Send(query);
        return Ok(new { Message = response });
    }

    //-----> Logout (Initial Version) -> Deleting refreshToken cookie whcih didn't work when request came from client-side (react)
    //[HttpPost("logout")]
    //[Authorize] // Requires authentication
    //public async Task<IActionResult> Logout()
    //{
    //    // Retrieve the user's ID from the JWT claims
    //    //var userId = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value; // initial version
    //    var userIdClaim = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
    //    var userId = userIdClaim?.Value;


    //    if (string.IsNullOrEmpty(userId))
    //    {
    //        // Handle the case where the user ID is not found
    //        throw new Application.Exceptions.BadRequestException(new string[] { "User not authenticated" });
    //    }

    //    // Send a command to handle the logout
    //    var command = new LogoutCommand(userId);
    //    var response = await _mediator.Send(command);

    //    if (response)
    //    {
    //        // Sign out the user
    //        await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

    //        // Clear any authentication cookies, including access and refresh tokens
    //        //Response.Cookies.Delete("accessToken");
    //        Response.Cookies.Delete("refreshToken");

    //        // Return a successful logout response
    //        return Ok(new { message = "Logout successful" });
    //    }
    //    else
    //    {
    //        // Handle the error, such as token invalidation failure
    //        throw new Application.Exceptions.BadRequestException(new string[] { "Logout failed" });
    //    }

    //}


    [HttpPost("logout")]
    [Authorize] // Requires authentication
    public async Task<IActionResult> Logout()
    {
        // Retrieve the user's ID from the JWT claims
        //var userId = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value; // initial version
        var userIdClaim = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
        var userId = userIdClaim?.Value;


        if (string.IsNullOrEmpty(userId))
        {
            // Handle the case where the user ID is not found
            throw new Application.Exceptions.BadRequestException(new string[] { "User not authenticated" });
        }

        // Send a command to handle the logout
        var command = new LogoutCommand(userId);
        var response = await _mediator.Send(command);

        if (response)
        {
            // Sign out the user
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            // Clear any authentication cookies, including access and refresh tokens
            //Response.Cookies.Delete("accessToken");
            Response.Cookies.Append(
                  "refreshToken",
                  "", // Empty value
                  new CookieOptions
                  {
                      HttpOnly = true,
                      Secure = true,
                      SameSite = SameSiteMode.None,
                      Expires = DateTimeOffset.UtcNow.AddMinutes(-5) // Set expiration to past time
                  }
              );

            // Return a successful logout response
            return Ok(new { message = "Logout successful" });
        }
        else
        {
            // Handle the error, such as token invalidation failure
            throw new Application.Exceptions.BadRequestException(new string[] { "Logout failed" });
        }

    }

    // PUT api/<AccountsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<AccountsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }

    private void SetAccessTokenCookie(string accessToken)
    {
        // Decode the access token to get the expiration time
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(accessToken);
        var tokenExpirationTime = jwtToken.ValidTo;

        // Set the HttpOnly access token cookie
        Response.Cookies.Append(
            "accessToken",
            accessToken,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = tokenExpirationTime
            }
        );
    }

    private void SetRefreshTokenCookie(RefreshToken refreshToken)
    {
        // Set the HttpOnly refresh token cookie
        Response.Cookies.Append(
            "refreshToken",
            refreshToken.Token,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = refreshToken.Expires
            }
        );
    }

}
