using Microsoft.AspNetCore.Mvc;

using HMS_MVC_Two.Models;
using Microsoft.AspNetCore.Identity;
namespace HMS_MVC_Two.Controllers;

[Route("api/[controller]/[action]")]
public class AccountController : Controller
{
    private readonly StudentPortalDbContext _context;

    public AccountController(StudentPortalDbContext context)
    {
        _context = context;
    }



    public IActionResult Register()
    {
        return View();
    }



    [HttpPost]
    public IActionResult Register(ApplicationUser model)
    {
        if (ModelState.IsValid)
        {

            var passwordHasher = new PasswordHasher<ApplicationUser>();                  // from asp.net core Identity
            model.Password = passwordHasher.HashPassword(model, model.Password);
            model.ConfirmPassword = "";
            model.UserId = Guid.NewGuid();

            _context.ApplicationUsers.Add(model);
            _context.SaveChanges();

            return Content("checkDb");
        }

        return View(model);
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }




    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {

        if (ModelState.IsValid == false)
        {
            return View(model);
        }

        var user = _context.ApplicationUsers
                    .FirstOrDefault(u => u.Email == model.EmailId && u.Role == model.Role);



        if (user != null)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var passwordMatcherResult = passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);


            if (passwordMatcherResult == PasswordVerificationResult.Success)
            {
                HttpContext.Session.SetString("UserId", user.UserId.ToString());
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("Role", user.Role);
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }
                else if (user.Role == "Doctor")
                {
                    return RedirectToAction("Index", "Doctor", new { area = "Doctor" });
                }
                else if (user.Role == "Patient")
                {
                    return RedirectToAction("Index", "Patient", new { area = "Patient" });
                }
            }
        }
        ModelState.AddModelError("", "Invalid Email,Password or Role");
        return View(model);
    }


    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

}

