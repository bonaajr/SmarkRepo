using testeSmark.WebApi.Interfaces.Applications;

namespace testeSmark.WebApi.Services.Applications
{
    public class ProtocoloApp : IProtocoloApp
    {
        private readonly IValidacaoApp _validacaoService;
        private static readonly object lockObject = new();
        private static Dictionary<string, int> contadorDeProtocolos = new();
        public ProtocoloApp(IValidacaoApp validacaoApp)
        {
            _validacaoService = validacaoApp;
        }

        public string GerarProtocolo(string identificadorEmpresa)
        {
            lock (lockObject)
            {
                if (_validacaoService.ValidaContadorDeProtocolo(contadorDeProtocolos, identificadorEmpresa))
                    contadorDeProtocolos[identificadorEmpresa] = 1;
                else
                    contadorDeProtocolos[identificadorEmpresa]++;

                return $"{identificadorEmpresa}{DateTime.Now:yyyyMMdd}{contadorDeProtocolos[identificadorEmpresa]:D6}";
            }
        }
    }
}
