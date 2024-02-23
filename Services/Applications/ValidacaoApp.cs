using testeSmark.WebApi.Helper.Validators;
using testeSmark.WebApi.Interfaces.Applications;

namespace testeSmark.WebApi.Services.Applications
{
    public class ValidacaoApp : IValidacaoApp
    {
        public bool EhIdentificadorValido(string identificadorEmpresa) 
            => new ProtocoloValidator().Validate(identificadorEmpresa).IsValid;

        public bool EhDataRegistrada(Dictionary<string, List<string>> registroDaEmpresa, string dataAtual) 
            => registroDaEmpresa.ContainsKey(dataAtual);

        public bool EhEmpresaRegistrada(Dictionary<string, Dictionary<string, List<string>>> registrosDeProtocolos, string identificadorEmpresa) 
            => registrosDeProtocolos.ContainsKey(identificadorEmpresa);
    }
}
