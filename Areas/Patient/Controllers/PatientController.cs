using HMS_MVC_Two.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HMS_MVC_Two.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class PatientController : Controller
    {
        private readonly StudentPortalDbContext _context;
        private readonly PasswordHasher<ApplicationUser> _passwordHasher;
        public PatientController(StudentPortalDbContext context_)
        {
            _context = context_;
            _passwordHasher = new PasswordHasher<ApplicationUser>();
        }

        public IActionResult Index()
        {
            var doctors = _context.Doctors.ToList();
            return View(doctors);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            return View();
        }



        [HttpPost]
        public IActionResult EditProfile(ApplicationUser model)
        {
            if (!ModelState.IsValid)
                return View(model);


            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Email == model.Email);


            if (user == null) return NotFound("User not found");

            user.Name = model.Name;
            user.Phone = model.Phone;

            if (!string.IsNullOrEmpty(model.Password))
            {
                user.Password = _passwordHasher.HashPassword(user, model.Password);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult BookAppointment(Guid id)
        {
            var patientId = HttpContext.Session.GetString("UserId");

            var model = new Appointment
            {
                PatientId = Guid.Parse(patientId),
                DoctorId = id
                
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult BookAppointment(Appointment appointment)
        {
            //need to perform the db operation
            return Content("");
        }


    }
}
