namespace testeSmark.WebApi.Interfaces.Applications
{
    public interface IValidacaoApp
    {
        bool EhIdentificadorValido(string identificadorEmpresa);
        bool EhDataRegistrada(Dictionary<string, List<string>> registroDaEmpresa, string dataAtual);
        bool EhEmpresaRegistrada(Dictionary<string, Dictionary<string, List<string>>> registrosDeProtocolos, string identificadorEmpresa);
    }
}
