namespace testeSmark.WebApi.Interfaces.Applications
{
    public interface IValidacaoApp
    {
        bool ValidaContadorDeProtocolo(Dictionary<string, int> contadoresDeProtocolo, string identificadorEmpresa);
    }
}
