using Microsoft.AspNetCore.Mvc;

namespace HMS_MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminController : Controller
{
    [Route("index")]
    public IActionResult Index()
    {
        return Content("patient view");
    }
}