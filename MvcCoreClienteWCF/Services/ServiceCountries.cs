using ServiceCountriesNameSpace;

namespace MvcCoreClienteWCF.Services
{
    public class ServiceCountries
    {
        CountryInfoServiceSoapTypeClient client;

        public ServiceCountries()
        {
            this.client =
                new CountryInfoServiceSoapTypeClient
                (CountryInfoServiceSoapTypeClient
                .EndpointConfiguration.CountryInfoServiceSoap);
        }

        public async Task<tCountryCodeAndName[]> GetCountriesAsync()
        {
            ListOfCountryNamesByNameResponse response =
                await this.client.ListOfCountryNamesByNameAsync();

            tCountryCodeAndName[] data =
                response.Body.ListOfCountryNamesByNameResult;

            return data;
        }

        public async Task<tCountryInfo> GetCountryInfoAsync(string isoCode)
        {
            FullCountryInfoResponse response =
                await this.client.FullCountryInfoAsync(isoCode);

            tCountryInfo country =
                response.Body.FullCountryInfoResult;

            return country;
        }
    }
}
