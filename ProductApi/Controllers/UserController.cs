using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers;

[Authorize] // L'utilisateur doit être authentifié
[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
  [HttpGet("me")]
  [ProducesResponseType(typeof(object), 200)] // Indique que la réponse réussie retourne un objet avec un code 200
  public IActionResult GetCurrentUser()
  {
    var userName = User.Identity?.Name;
    var claims = User.Claims.Select(c => new { c.Type, c.Value });

    return Ok(new
    {
      Name = userName,
      Claims = claims
    });
  }

  [Authorize(Policy = "EmailPolicy")] // Accessible uniquement aux utilisateurs avec un email @entreprise.com
  [HttpGet("protected")]
  [ProducesResponseType(typeof(string), 200)] // Indique que la réponse réussie retourne une chaîne avec un code 200
  public IActionResult ProtectedEndpoint()
  {
    return Ok("Vous avez accès à cet endpoint car votre email est valide.");
  }
}
