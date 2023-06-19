using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using StoreCommon.Models;
using System.Diagnostics;
using System.Net.Mime;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace StoreApp.Controllers;
public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) {
        _logger = logger;
    }

    public async Task<IActionResult> Index() {
        // NOTE: Get from API

        var client = new HttpClient();
        var res = await client.GetAsync("https://localhost:7217/products");
        var jsonString = await res.Content.ReadAsStringAsync();

        var products = JsonSerializer.Deserialize<List<Product>>(jsonString, new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return View(products);
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
