using Microsoft.AspNetCore.Mvc;
using Mission08_Team112;

namespace Mission08_Team112.Controllers;

public class TaskController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

