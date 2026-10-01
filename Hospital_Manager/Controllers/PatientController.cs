using Microsoft.AspNetCore.Mvc;
using Data_Hospital_Manager;

namespace Hospital_Manager.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalDbContext context;
        public PatientController(HospitalDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
