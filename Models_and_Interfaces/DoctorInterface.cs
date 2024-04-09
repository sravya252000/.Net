using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAndInterfaces
{
    public interface IDoctorService
    {
        //Task<List<Appointment>> GetAllAppointmentsAsync();
        Task<List<Patient>> GetAllPatientsAsync();
        Task AddMedicationAsync(Medicine medicine);
        Task<Patient> GetPatientByIdAsync(int id);
        //void AssignMedicationToPatient(int patientId, Medicine medication);
        Task<List<DoctorSpecialization>> GetAllSpecializationsAsync();
        Task<int> CountDoctorsInSpecializationAsync(string specializationName);
        Task<List<Doctor>> GetDoctorsBySpecializationAsync(string specializationName);
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task UpdateDoctorByDoctorIdAsync(int doctorId, Doctor doctor);
        Task<List<Appointment>> GetAllAppointmentsByDoctorIdAsync(int doctorId);
        //List<Appointment> GetAllAppointmentsByDoctorSpecialization(string specializationName);
        Task<List<string>> GetDoctorNamesAsync();
    }
}
