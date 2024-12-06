using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementLibrary.Controllers;
[Route("[controller]")]
[ApiController]
public abstract class ManagementLibraryBaseController : ControllerBase
{
}
