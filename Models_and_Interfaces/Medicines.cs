using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAndInterfaces
{
    public class Medicine
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public int Dosage { get; set; } // Dosage of the medicine
        public string Frequency { get; set; } // Frequency of administration (e.g., once daily, twice daily)
        public string Duration { get; set; } // Duration of use (e.g., 10 days, until finished)
        //public List<string> AdditionalNotes { get; set; }
        [ForeignKey("Patient")]
        public int PatientId {  get; set; }
        //public Patient? Patient { get; set; }
    }
}
