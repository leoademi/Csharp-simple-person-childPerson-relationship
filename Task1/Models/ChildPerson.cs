using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models
{
    internal class ChildPerson
    {
        public int ChildPersonId { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int ParentPersonId { get; set; }
        public Person Parent { get; set; }

        public HealthInsuranceDocument HealthInsuranceDocument { get; set; }

    }
}
