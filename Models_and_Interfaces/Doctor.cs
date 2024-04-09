using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAndInterfaces
{
    public class Doctor:Person
    {
       [ForeignKey("DoctorSpecialization")]
        public string Specialization { get; set; }
    }
}
