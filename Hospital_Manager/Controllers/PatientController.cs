using Microsoft.AspNetCore.Mvc;
using Data_Hospital_Manager;
using Microsoft.EntityFrameworkCore;
using Hospital_Manager.ViewModels.Patient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital_Manager.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalDbContext context;
        public PatientController(HospitalDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await context.Patients.Include(p => p.DoctorPatients).ThenInclude(dp => dp.Doctor).ToListAsync();
            var model = new List<PatientIndexViewModel>();
            foreach (var patient in patients)
            {
                model.Add(new PatientIndexViewModel
                {
                    Id = patient.Id,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Email = patient.Email,
                    PhoneNumber = patient.PhoneNumber,
                    DoctorNames = string.Join(", ", patient.DoctorPatients.Select(dp => dp.Doctor.FirstName + " " + dp.Doctor.LastName))
                });
            }
            return View(patients);
        }
        public async Task<IActionResult> Details(int id)
        {
            var patient = await context.Patients.Include(p => p.DoctorPatients).ThenInclude(dp => dp.Doctor).FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            var model = new PatientIndexViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                DoctorNames = string.Join(", ", patient.DoctorPatients.Select(dp => dp.Doctor.FirstName + " " + dp.Doctor.LastName))
            };
            return View(model);

        }
        public async Task LoadDoctors(List<int> selectedDoctors = null)
        {
            var doctors = await context.Doctors.Select(x => new { x.Id, FullName = x.FirstName + " " + x.LastName }).ToListAsync();
            ViewBag.Doctors = new MultiSelectList(doctors, "Id", "FullName", selectedDoctors);
        }
        public async Task<IActionResult> Create()
        {
            await LoadDoctors();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var patient = new Data_Hospital_Manager.Entities.Patient
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                context.Patients.Add(patient);
                await context.SaveChangesAsync();

                if (model.DoctorIds != null && model.DoctorIds.Any())
                {
                    foreach (var doctorId in model.DoctorIds)
                    {
                        context.Add(new Data_Hospital_Manager.Entities.DoctorPatient { DoctorId = doctorId, PatientId = patient.Id });
                    }
                    await context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            await LoadDoctors(model.DoctorIds);
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await context.Patients.Include(p => p.DoctorPatients).FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            var model = new PatientEditViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                DoctorIds = patient.DoctorPatients.Select(dp => dp.DoctorId).ToList()
            };
            await LoadDoctors(model.DoctorIds);
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PatientEditViewModel model)
        {

            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var patient = await context.Patients.Include(p => p.DoctorPatients).FirstOrDefaultAsync(p => p.Id == id);
                if (patient == null)
                {
                    return NotFound();
                }

                patient.FirstName = model.FirstName;
                patient.LastName = model.LastName;
                patient.Email = model.Email;
                patient.PhoneNumber = model.PhoneNumber;

                var existingDoctorIds = patient.DoctorPatients.Select(dp => dp.DoctorId).ToList();
                var newDoctorIds = model.DoctorIds ?? new List<int>();

                foreach (var doctorId in existingDoctorIds.Except(newDoctorIds))
                {
                    var doctorPatient = patient.DoctorPatients.FirstOrDefault(dp => dp.DoctorId == doctorId);
                    if (doctorPatient != null)
                    {
                        context.Remove(doctorPatient);
                    }
                }

                foreach (var doctorId in newDoctorIds.Except(existingDoctorIds))
                {
                    context.Add(new Data_Hospital_Manager.Entities.DoctorPatient { DoctorId = doctorId, PatientId = patient.Id });
                }

                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await LoadDoctors(model.DoctorIds);
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            context.Patients.Remove(patient);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            context.Patients.Remove(patient);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
