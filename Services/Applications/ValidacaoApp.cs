using testeSmark.WebApi.Interfaces.Applications;

namespace testeSmark.WebApi.Services.Applications
{
    public class ValidacaoApp : IValidacaoApp
    {
        public bool ValidaContadorDeProtocolo(Dictionary<string, int> contadoresDeProtocolo, string identificadorEmpresa)
        {
            return !contadoresDeProtocolo.ContainsKey(identificadorEmpresa) || DateTime.Now.Date.ToString("yyyyMMdd") != contadoresDeProtocolo[identificadorEmpresa].ToString().Substring(0, 8);
        }
    }
}
