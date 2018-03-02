using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WorldMapApi.Models;
using WorldMapApi.ViewModels;

namespace WorldMapApi.Controllers
{
  [Route("api/[controller]")]
  public class AccountController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RegisterViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
      }

      var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
      var result = await _userManager.CreateAsync(user, model.Password);

      if (!result.Succeeded)
      {
        return BadRequest(result.Errors.Select(x => x.Description).ToList());
      }

      return new ObjectResult(GenerateToken(user.UserName));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

      if (result.Succeeded)
      {
        return new ObjectResult(GenerateToken(model.Email));
      }
      return BadRequest();
    }

    private string GenerateToken(string username)
    {
      var claims = new Claim[]
      {
          new Claim(ClaimTypes.Name, username),
          new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
          new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
      };

      var token = new JwtSecurityToken(
        new JwtHeader(new SigningCredentials(
          new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("7A735D7B-1A19-4D8A-9CFA-99F55483013F")),
            SecurityAlgorithms.HmacSha256)
          ),
        new JwtPayload(claims)
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
