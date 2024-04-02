using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF.Models;
using MvcCoreClienteWCF.Repositories;

namespace MvcCoreClienteWCF.Controllers
{

    public class ClientesController : Controller
    {

        private RepositoryClientesXML repo;

        public ClientesController(RepositoryClientesXML repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Cliente> clientes = this.repo.GetClientes();
            return View(clientes);
        }

        public IActionResult Details(int idcliente)
        {
            Cliente cliente = 
                this.repo.FindCliente(idcliente);
            return View(cliente);
        }
    }
}
