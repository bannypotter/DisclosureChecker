using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BannyPotter.DBS.Core.Tests
{
    [TestClass]
    public class StatusCheckRequestTests
    {
        int _disclosureReferenceNumber = 1234567890;
        DateTime _dateOfBirth = new DateTime(1990, 01, 01);
        string _surname = "Bloggs";
        string _organisationName = "your council name";
        string _employeeSurname = "Doe";
        string _employeeForename = "Joe";
        bool _agreesToTermsAndConditions = true;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WithEmptyDisclosureReferenceNumber_ThrowsArgumentNullException()
        {
            try
            {
                StatusCheckRequest target = new StatusCheckRequest(
                    disclosureReferenceNumber: default(int),
                    dateOfBirth: _dateOfBirth,
                    surname: _surname,
                    organisationName: _organisationName,
                    employeeSurname: _employeeSurname,
                    employeeForename: _employeeForename,
                    agreesToTermsAndConditions: _agreesToTermsAndConditions
                );
            }
            catch(ArgumentNullException ex)
            {
                Assert.AreEqual(ex.ParamName, "disclosureReferenceNumber");
                Assert.IsTrue(ex.Message.StartsWith("The disclosureReferenceNumber can not be empty"));
                throw;
            }        
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_WithDateOfBirthUnder1900_ThrowsArgumentOutOfRangeException()
        {
            try
            {
                StatusCheckRequest target = new StatusCheckRequest(
                    disclosureReferenceNumber: _disclosureReferenceNumber,
                    dateOfBirth: new DateTime(1899,12,31),
                    surname: _surname,
                    organisationName: _organisationName,
                    employeeSurname: _employeeSurname,
                    employeeForename: _employeeForename,
                    agreesToTermsAndConditions: _agreesToTermsAndConditions
                );
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual(ex.ParamName, "dateOfBirth");
                Assert.IsTrue(ex.Message.StartsWith("The date of birth can not be before 1900"));
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_WithDateOfBirthInFuture_ThrowsArgumentOutOfRangeException()
        {
            try
            {
                StatusCheckRequest target = new StatusCheckRequest(
                    disclosureReferenceNumber: _disclosureReferenceNumber,
                    dateOfBirth: DateTime.Today.AddDays(2),
                    surname: _surname,
                    organisationName: _organisationName,
                    employeeSurname: _employeeSurname,
                    employeeForename: _employeeForename,
                    agreesToTermsAndConditions: _agreesToTermsAndConditions
                );
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual(ex.ParamName, "dateOfBirth");
                Assert.IsTrue(ex.Message.StartsWith("The date of birth can not be in the future"));
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WithEmptySurname_ThrowsArgumentNullException()
        {
            try
            {
                StatusCheckRequest target = new StatusCheckRequest(
                    disclosureReferenceNumber: _disclosureReferenceNumber,
                    dateOfBirth: _dateOfBirth,
                    surname: String.Empty,
                    organisationName: _organisationName,
                    employeeSurname: _employeeSurname,
                    employeeForename: _employeeForename,
                    agreesToTermsAndConditions: _agreesToTermsAndConditions
                );
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(ex.ParamName, "surname");
                Assert.IsTrue(ex.Message.StartsWith("The surname can not be empty"));
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WithEmptyOrganisationName_ThrowsArgumentNullException()
        {
            try
            {
                StatusCheckRequest target = new StatusCheckRequest(
                    disclosureReferenceNumber: _disclosureReferenceNumber,
                    dateOfBirth: _dateOfBirth,
                    surname: _surname,
                    organisationName: String.Empty,
                    employeeSurname: _employeeSurname,
                    employeeForename: _employeeForename,
                    agreesToTermsAndConditions: _agreesToTermsAndConditions
                );
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(ex.ParamName, "organisationName");
                Assert.IsTrue(ex.Message.StartsWith("The organisationName can not be empty"));
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WithEmptyEmployeeSurname_ThrowsArgumentNullException()
        {
            try
            {
                StatusCheckRequest target = new StatusCheckRequest(
                    disclosureReferenceNumber: _disclosureReferenceNumber,
                    dateOfBirth: _dateOfBirth,
                    surname: _surname,
                    organisationName: _organisationName,
                    employeeSurname: String.Empty,
                    employeeForename: _employeeForename,
                    agreesToTermsAndConditions: _agreesToTermsAndConditions
                );
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(ex.ParamName, "employeeSurname");
                Assert.IsTrue(ex.Message.StartsWith("The employeeSurname can not be empty"));
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WithEmptyEmployeeForename_ThrowsArgumentNullException()
        {
            try
            {
                StatusCheckRequest target = new StatusCheckRequest(
                    disclosureReferenceNumber: _disclosureReferenceNumber,
                    dateOfBirth: _dateOfBirth,
                    surname: _surname,
                    organisationName: _organisationName,
                    employeeSurname: _employeeSurname,
                    employeeForename: String.Empty,
                    agreesToTermsAndConditions: _agreesToTermsAndConditions
                );
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(ex.ParamName, "employeeForename");
                Assert.IsTrue(ex.Message.StartsWith("The employeeForename can not be empty"));
                throw;
            }
        }
    }
}
