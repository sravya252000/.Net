using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsAndInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<string> AddPatient([FromBody] Patient patient)
        {
            await _patientService.AddPatientAsync(patient);
            return "Patient Added Successfully";
        }

        [HttpGet]
        public async Task<List<Medicine>> GetMedicinesByPatientId(int id)
        {
            return await _patientService.GetMedicinesByPatientIdAsync(id);
        }

        [HttpGet]
        public async Task<List<DoctorSpecialization>> GetAllSpecializations()
        {
            return await _patientService.GetAllSpecializationsAsync();
        }

        [HttpGet]
        public async Task<List<Doctor>> GetDoctorsBySpecialization(string specializationName)
        {
            return await _patientService.GetDoctorsBySpecializationAsync(specializationName);
        }

        [HttpPost]
        public async Task<string> AddAppointment([FromBody] Appointment appointment)
        {
            await _patientService.AddAppointmentAsync(appointment);
            return "Appointment Added Successfully";
        }

        [HttpPost]
        public async Task<List<Appointment>> SortAppointmentsByDateAndTime([FromBody] List<Appointment> appointments)
        {
            return await _patientService.SortAppointmentsByDateAndTimeAsync(appointments);
        }

        [HttpGet]
        public async Task<List<Appointment>> GetAllAppointmentsByPatientId(int patientId)
        {
            return await _patientService.GetAllAppointmentsByPatientIdAsync(patientId);
        }
    }
}
