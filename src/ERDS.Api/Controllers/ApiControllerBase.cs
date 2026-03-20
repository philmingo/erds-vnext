using Microsoft.AspNetCore.Mvc;

namespace ERDS.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
}
