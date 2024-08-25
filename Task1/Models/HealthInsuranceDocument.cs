using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models
{
    internal class HealthInsuranceDocument
    {
        public int HealthInsuranceDocumentId { get; set; }
        public DateTime DateOfAccident { get; set; }
        public string DocumentIdentificationNumber { get; set; }
        public string DoctorName { get; set; }
        public string BodilyInjuries { get; set; }

        public int? ParentPersonId { get; set; }
        public Person ParentPerson { get; set; }

        public int? ChildPersonId { get; set; }
        public ChildPerson ChildPerson { get; set; }
    }
}
