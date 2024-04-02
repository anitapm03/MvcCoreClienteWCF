using ServiceReferenceConversor;

namespace MvcCoreClienteWCF.Services
{
    public class ServiceConversor
    {
        NumberConversionSoapTypeClient client;
        public ServiceConversor()
        {
            this.client =
                new NumberConversionSoapTypeClient
                (NumberConversionSoapTypeClient.EndpointConfiguration
                .NumberConversionSoap);
        }

        public async Task<string> 
            ConvertNumberToWordsAsync(string numbers)
        {
            ulong numeros = ulong.Parse (numbers);
            NumberToWordsResponse response =
                await this.client.NumberToWordsAsync(numeros);
            string data = response.Body.NumberToWordsResult;
            return data;

        }
    }
}
