using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models
{
    internal class Person
    {
        public int PersonId { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public ChildPerson Child { get; set; }

        public HealthInsuranceDocument HealthInsuranceDocument { get; set; }

    }
}
