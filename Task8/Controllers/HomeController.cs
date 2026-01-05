using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task8.Models;

namespace Task8.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static readonly List<Product> _products = new List<Product>();
    private static int _nextId = 1;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new IndexModel()
        {
            Products = _products
        };
        
        return View(model);
    }

    [HttpPost("create-product")]
    public IActionResult CreateProduct([FromForm] Product newProduct)
    {
        newProduct.ID = _nextId++;
        _products.Add(newProduct);

        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}