using MvcCoreClienteWCF.Helpers;
using MvcCoreClienteWCF.Models;
using System.Xml.Linq;

namespace MvcCoreClienteWCF.Repositories
{
    public class RepositoryClientesXML
    {
        private HelperPathProvider helper;

        public RepositoryClientesXML(HelperPathProvider helper)
        {
            this.helper = helper;
        }

        public List<Cliente> GetClientes()
        {
            string path = this.helper.MapPath
                ("ClientesID.xml", Folders.Documents);

            //la clase XDocument nos permite usar linq
            XDocument document = XDocument.Load(path);
            //from datos in document.Descendants("TAG")
            //select datos
            var consulta = from datos in document.Descendants("CLIENTE")
                           select datos;
            //extraemos los elementos XElement de la consulta 

            List<Cliente> clientesList = new List<Cliente>();
            foreach (XElement tag in  consulta)
            {
                Cliente cliente = new Cliente();
                //podemos recuperar tanto atributos como datos de etiqueta
                //tag.Attributes("ATTRIBUTE").Value
                //tag.Element("ELEMENT").Value
                cliente.IdCliente = int.Parse(tag.Element("IDCLIENTE").Value);
                cliente.Nombre = tag.Element("NOMBRE").Value;
                cliente.Direccion = tag.Element("DIRECCION").Value;
                cliente.Email = tag.Element("EMAIL").Value;
                cliente.ImagenCliente = tag.Element("IMAGENCLIENTE").Value;

                clientesList.Add(cliente);
            }

            return clientesList;
        }

        public Cliente FindCliente(int idCliente)
        {
            string path = this.helper.MapPath
               ("ClientesID.xml", Folders.Documents);

            XDocument document = XDocument.Load(path);

            //vamos a realizar la consulta generando directamente 
            //las clases que vamos a mapear (CLIENTE)
            var consulta = from datos in document.Descendants("CLIENTE")
                           where datos.Element("IDCLIENTE").Value ==
                           idCliente.ToString() 
                           select new Cliente()
                           {
                               IdCliente = 
                               int.Parse(datos.Element("IDCLIENTE").Value),
                               Nombre =
                               datos.Element("NOMBRE").Value,
                               Direccion =
                               datos.Element("DIRECCION").Value,
                               Email =
                               datos.Element("EMAIL").Value,
                               ImagenCliente =
                               datos.Element("IMAGENCLIENTE").Value,
                           };

            return consulta.FirstOrDefault();
        }
    }
}
