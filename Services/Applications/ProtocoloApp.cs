using testeSmark.WebApi.Interfaces.Applications;

namespace testeSmark.WebApi.Services.Applications
{
    public class ProtocoloApp : IProtocoloApp
    {
        private readonly IValidacaoApp _validacaoService;
        private static readonly object lockObject = new();
        private static readonly Dictionary<string, Dictionary<string, List<string>>> registrosDeProtocolos = new();
        public ProtocoloApp(IValidacaoApp validacaoApp)
        {
            _validacaoService = validacaoApp;
        }

        public string GerarProtocolo(string identificadorEmpresa)
        {
            if (!_validacaoService.EhIdentificadorValido(identificadorEmpresa)) throw new Exception("Identificador da Empresa deve ter exatamente 6 caracteres!");

            lock (lockObject) return RegistrarProtocolo(identificadorEmpresa);
        }

        private string RegistrarProtocolo(string identificadorEmpresa)
        {
            if (!_validacaoService.EhEmpresaRegistrada(registrosDeProtocolos, identificadorEmpresa))
                registrosDeProtocolos.Add(identificadorEmpresa, new Dictionary<string, List<string>>());

            return ObterNovoProtocolo(registrosDeProtocolos[identificadorEmpresa], identificadorEmpresa, DateTime.Now.ToString("yyyyMMdd"));
        }

        private string ObterNovoProtocolo(Dictionary<string, List<string>> registroDaEmpresa, string identificadorEmpresa, string dataAtual)
        {
            if (!_validacaoService.EhDataRegistrada(registroDaEmpresa, dataAtual))
                registroDaEmpresa[dataAtual] = new();

            List<string> protocolosParaDataAtual = registroDaEmpresa[dataAtual];
            string novoProtocolo = $"{identificadorEmpresa}{dataAtual}{protocolosParaDataAtual.Count + 1:D6}";

            protocolosParaDataAtual.Add(novoProtocolo);

            return novoProtocolo;
        }
    }
}