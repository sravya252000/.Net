using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAndInterfaces
{
    public class Appointment
    {
        public int Id { get; set; }
        public string AppointmentDateAndTime { get; set; }

        [ForeignKey("Patient")]
        public int PatientId {  get; set; }
        //public Patient? Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId {  get; set; }
       
        //public Doctor? Doctor { get; set; }
    }
}
