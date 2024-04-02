using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF.Services;

namespace MvcCoreClienteWCF.Controllers
{
    public class ConversorController : Controller
    {

        public ServiceConversor service;

        public ConversorController(ServiceConversor service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> 
            Index(string numeros)
        {
            string data =
                 await this.service.ConvertNumberToWordsAsync(numeros);
            ViewData["DATOS"] = data;
            return View();
        }
    }
}
