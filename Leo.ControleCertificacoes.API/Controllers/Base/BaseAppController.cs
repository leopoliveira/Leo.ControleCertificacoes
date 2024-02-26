using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace Leo.ControleCertificacoes.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class BaseAppController : ControllerBase
    {
    }
}
