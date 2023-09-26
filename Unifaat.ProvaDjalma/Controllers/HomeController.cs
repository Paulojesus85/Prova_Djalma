using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Unifaat.ProvaDjalma.Data;
using Unifaat.ProvaDjalma.Models;
using Unifaat.ProvaDjalma.ViewModel;

namespace Unifaat.ProvaDjalma.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var nomesVendedores = _context.Vendedores.Select(v => v.NomeCompleto).ToList();
            var nomesClientes = _context.Clientes.Select(v => v.NomeCompleto).ToList();
            var nomesProdutos = _context.Produtos.Select(v => v.ProdutoNome).ToList();
            var nomesMarcas = _context.Marcas.Select(v => v.NomeMarca).ToList();
            var viewModel = new ListViewModel
            {
                NomesVendedores = nomesVendedores,
                NomesClientes = nomesClientes,
                NomesProdutos = nomesProdutos,
                NomesMarcas = nomesMarcas
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}