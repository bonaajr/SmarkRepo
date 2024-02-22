using Microsoft.AspNetCore.Mvc;
using testeSmark.WebApi.Interfaces.Applications;

namespace testeSmark.WebApi.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProtocoloController : ControllerBase
    {
        private readonly IProtocoloApp _protocoloService;
        private readonly ILogger<ProtocoloController> _logger;

        public ProtocoloController(IProtocoloApp protocoloService,
                                   ILogger<ProtocoloController> logger)
        {
            _logger = logger;
            _protocoloService = protocoloService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string identificadorEmpresa)
        {
            return Ok(_protocoloService.GerarProtocolo(identificadorEmpresa));
        }
    }
}