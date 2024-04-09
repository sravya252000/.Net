using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsAndInterfaces;
using Database;

namespace Methods
{
    public class PatientServices : IPatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DoctorSpecialization>> GetAllSpecializationsAsync()
        {
            return await _context.DoctorSpecializations.ToListAsync();
        }

        public async Task<List<Doctor>> GetDoctorsBySpecializationAsync(string specializationName)
        {
            return await _context.Doctors.Where(d => d.Specialization == specializationName).ToListAsync();
        }

        public async Task<int> CountDoctorsInSpecializationAsync(string specializationName)
        {
            return await _context.Doctors.CountAsync(d => d.Specialization == specializationName);
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public Task<List<Appointment>> SortAppointmentsByDateAndTimeAsync(List<Appointment> appointments)
        {
            return Task.FromResult(appointments.OrderBy(a => a.AppointmentDateAndTime).ToList());
        }

        public async Task<List<Appointment>> GetAllAppointmentsByPatientIdAsync(int patientId)
        {
            return await _context.Appointments.Where(a => a.PatientId == patientId).ToListAsync();
        }

        public async Task<List<Medicine>> GetMedicinesByPatientIdAsync(int patientId)
        {
            return await _context.Medicines.Where(a => a.PatientId == patientId).ToListAsync();
        }
    }
}
