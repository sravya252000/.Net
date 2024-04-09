using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Methods; // Import DoctorServices
using ModelsAndInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks; // Required for async methods

namespace Controllers.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<List<Patient>> GetAllPatients()
        {
            return await _doctorService.GetAllPatientsAsync();
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _doctorService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpGet]
        public async Task<int> CountDoctorsInSpecialization(string specializationName)
        {
            return await _doctorService.CountDoctorsInSpecializationAsync(specializationName);
        }

        [HttpPost]
        public async Task<IActionResult> AddMedications(Medicine medicine)
        {
            await _doctorService.AddMedicationAsync(medicine);
            return Ok("Medications Added Successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpGet]
        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _doctorService.GetAllDoctorsAsync();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctorByDoctorId(int doctorId, [FromBody] Doctor doctor)
        {
            await _doctorService.UpdateDoctorByDoctorIdAsync(doctorId, doctor);
            return Ok("Updated Successfully");
        }

        [HttpGet]
        public async Task<List<Appointment>> GetAllAppointmentsByDoctorId(int doctorId)
        {
            return await _doctorService.GetAllAppointmentsByDoctorIdAsync(doctorId);
        }

        [HttpGet]
        public async Task<List<string>> GetDoctorNames()
        {
            return await _doctorService.GetDoctorNamesAsync();
        }
    }
}
