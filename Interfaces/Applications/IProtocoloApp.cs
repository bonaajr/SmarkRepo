using Microsoft.AspNetCore.Mvc;

namespace testeSmark.WebApi.Interfaces.Applications
{
    public interface IProtocoloApp
    {
        string GerarProtocolo(string identificadorEmpresa);
    }
}
