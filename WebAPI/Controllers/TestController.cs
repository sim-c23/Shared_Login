using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
/*Det betyder, at denne controller kunkaninterageres med, hvis den, der ringer op, leverer en gyldig JWT.
  Som standard kan alle slutpunkter i denne klasse kun kaldes med et gyldigt token.
*/
[Authorize]
public class TestController : ControllerBase
{
    [HttpGet("allowanon"), AllowAnonymous]
    public ActionResult GetAsAnon()
    {
        return Ok("This was accepted as anonymous");
    }

    // role
    [HttpGet("authorized")]
    public ActionResult GetAsAuthorized()
    {
        return Ok("This was accepted as authorized");
    }

    // policy MustBeVia
    [HttpGet("mustbevia"), Authorize("MustBeVia")]
    public ActionResult GetAsVia()
    {
        return Ok("This was accepted as via domain");
    }

    /*
    // manual checking
    [HttpGet("manualcheck")]
    public ActionResult GetWithManualCheck()
    {
        Claim? claim = User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Role));
        if (claim == null)
        {
            return StatusCode(403, "You have no role");
        }

        if (!claim.Value.Equals("Teacher"))
        {
            return StatusCode(403, "You are not a teacher");
        }

        return Ok("You are a teacher, you may proceed");
    }
    */
}