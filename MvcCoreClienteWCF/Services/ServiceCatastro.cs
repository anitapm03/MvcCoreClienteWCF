using MvcCoreClienteWCF.Models;
using ServiceReferenceCatastro;
using System.Xml;
using System.Xml.Linq;

namespace MvcCoreClienteWCF.Services
{
    public class ServiceCatastro
    {
        CallejerodelasedeelectrónicadelcatastroSoapClient client;

        public ServiceCatastro
            (CallejerodelasedeelectrónicadelcatastroSoapClient client)
        {
            this.client = client;
        }

        public async Task<List<Provincia>> GetProvinciasAsync()
        {
            ConsultaProvincia1 response =
                await this.client.ObtenerProvinciasAsync();
            XmlNode nodoProvincias = response.Provincias;

            //extraemos del nodo el contenido xml
            string dataXML = nodoProvincias.OuterXml;

            //usamos linq to xml para extraer los datos
            XDocument document = XDocument.Parse(dataXML);
            XNamespace ns = "http://www.catastro.meh.es/";
            //usamos linq para recuperar el contenido de xelement
            //y transformarlo a clase provincia
            var consulta = from datos in document.Descendants(ns + "prov")
                           select new Provincia()
                           {
                               IdProvincia =
                               int.Parse(datos.Element(ns + "cpine").Value),
                               Nombre =
                               datos.Element(ns + "np").Value
                           };

            return consulta.ToList();
        }

        public async Task<List<string>> GetMunicipiosProvincia
            (string provincia)
        {
            ConsultaMunicipio1 response =
                await this.client.ObtenerMunicipiosAsync(provincia, null);

            XmlNode nodo = response.Municipios;

            string dataXML = nodo.OuterXml;
            XDocument document = XDocument.Parse(dataXML);
            XNamespace ns = "http://www.catastro.meh.es/";

            var consulta = from datos in document.Descendants(ns + "muni")
                           select datos.Element(ns + "nm").Value;

            return consulta.ToList();
        }
    }
}
