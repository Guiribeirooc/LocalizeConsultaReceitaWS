using LocalizeConsultaReceitaWS.Domain.Receita;
using LocalizeConsultaReceitaWS.Infra.Interfaces;
using RestSharp;

namespace LocalizeConsultaReceitaWS.Infra.Requests
{
    public class ReceitaRequest : IReceitaRequest
    {
        public ResponseReceita ConsultarReceitaWS(string cnpj)
        {
            var responseReceita = new ResponseReceita();
            var client = new RestClient(new Uri("https://receitaws.com.br/v1/"));
            var request = new RestRequest($"cnpj/{cnpj}");

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                responseReceita.Sucesso = true;
                responseReceita.Retorno = response.Content;
            }

            return responseReceita;
        }
    }
}
