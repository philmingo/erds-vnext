using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERDS.Api.Controllers;

public class SystemController : ApiControllerBase
{
    [AllowAnonymous]
    [HttpGet("/api/v1/system/status")]
    public IActionResult GetStatus()
    {
        return Ok(new
        {
            Application = "ERDS vNext",
            Status = "Running",
            Timestamp = DateTimeOffset.UtcNow
        });
    }
}
