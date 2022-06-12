using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebStoreAutomobiles.Models;
using WebStoreAutomobiles.Models.ViewModels;

namespace WebStoreAutomobiles.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IStoreRepository _repository;

    public int PageSize = 4;

    public HomeController(IStoreRepository repository,ILogger<HomeController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Catalog(int productPage = 1)
    {
        return View(new ProductsListViewModels
        {
            Products = _repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((productPage-1)*PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = _repository.Products.Count()
            }
        });
    }

    public IActionResult Contacts()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
