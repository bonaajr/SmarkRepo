using Microsoft.AspNetCore.Mvc;
using testeSmark.WebApi.Interfaces.Applications;
using testeSmark.WebApi.ViewModels.Request;

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
        public IActionResult Post([FromBody] PayloadCadastro payload)
        {
            _logger.LogInformation($"Iniciando processo de geração de protocolo para empresa: {payload.IdentificadorEmpresa}", payload.IdentificadorEmpresa);
            var teste = _protocoloService.GerarProtocolo(payload.IdentificadorEmpresa);
            return Ok(new { resultado = teste });
        }
    }
}