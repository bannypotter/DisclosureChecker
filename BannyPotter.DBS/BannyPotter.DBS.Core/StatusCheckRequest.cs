using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannyPotter.DBS.Core
{
    public class StatusCheckRequest
    {
        /// <exception cref="System.ArgumentNullException">Thrown when disclosureReference, surname, organisationName, organisationName, employeeSurname or employeeForename is empty</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when dateOfBirth is before 1900 or is in the future</exception>
        public StatusCheckRequest(int disclosureReferenceNumber, DateTime dateOfBirth, string surname,
            string organisationName, string employeeSurname, string employeeForename,
            bool agreesToTermsAndConditions = true)
        {
            if (disclosureReferenceNumber == default(int)) throw new ArgumentNullException("disclosureReferenceNumber", "The disclosureReferenceNumber can not be empty");
            DisclosureReferenceNumber = disclosureReferenceNumber;

            if (dateOfBirth < new DateTime(1900, 01, 01)) throw new ArgumentOutOfRangeException("dateOfBirth", "The date of birth can not be before 1900");
            if (dateOfBirth >= DateTime.Today) throw new ArgumentOutOfRangeException("dateOfBirth", "The date of birth can not be in the future");
            DateOfBirth = dateOfBirth;
            
            if (String.IsNullOrEmpty(surname.Trim())) throw new ArgumentNullException("surname", "The surname can not be empty");
            Surname = surname;
            
            if (String.IsNullOrEmpty(organisationName.Trim())) throw new ArgumentNullException("organisationName", "The organisationName can not be empty");
            OrganisationName = organisationName;
            
            if (String.IsNullOrEmpty(employeeSurname.Trim())) throw new ArgumentNullException("employeeSurname", "The employeeSurname can not be empty");
            EmployeeSurname = employeeSurname;

            if (String.IsNullOrEmpty(employeeForename.Trim())) throw new ArgumentNullException("employeeForename", "The employeeForename can not be empty");
            EmployeeForename = employeeForename;

            AgreesToTermsAndConditions = agreesToTermsAndConditions;
        }

        [DisplayName("Disclosure Reference Number")]
        public int DisclosureReferenceNumber { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Surname")]
        public string Surname { get; set; }

        [DisplayName("Agrees to Terms and Conditions")]
        public bool AgreesToTermsAndConditions { get; set; }

        [DisplayName("Organisation Name")]
        public string OrganisationName { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeSurname { get; set; }

        [DisplayName("Employee Forename")]
        public string EmployeeForename { get; set; }
    }
}
