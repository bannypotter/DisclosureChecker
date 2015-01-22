using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.IO;

namespace BannyPotter.DBS.Core.Tests
{
    [TestClass]
    public class StatusCheckProcessorTests
    {
        private IStatusCheckProcessor _processor;
        private Uri _validUri;
        private string _validXml;

        [TestInitialize]
        public void Init()
        {
            _validXml = File.ReadAllText("ExampleResponse.xml");

            Mock<WebClient> webClient = new Mock<WebClient>();
            
            _processor = new StatusCheckProcessor(webClient.Object);
            _validUri = new Uri("https://secure.crbonline.gov.uk/crsc/api/status/1234567890?dateOfBirth=01/01/1984&surname=JONES&organisationName=ORGANISATIONNAME&employeeSurname=QUINN&employeeForename=THOMAS&hasAgreedTermsAndConditions=true");
        }

        [TestMethod]
        public void GenerateUri_Returns_ValidUri()
        {

            var request = new StatusCheckRequest(
                disclosureReferenceNumber: 1234567890,
                dateOfBirth: new DateTime(1984, 1, 1),
                surname: "JONES",
                organisationName: "ORGANISATIONNAME",
                employeeSurname: "QUINN",
                employeeForename: "THOMAS",
                agreesToTermsAndConditions: true
            );

            Uri result = _processor.GenerateUri(request);

            Assert.AreEqual(_validUri, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Check_WithNullStatusCheckRequest_ThrowsArgumentNullException()
        {
            StatusCheckRequest request = null;

            try
            {
                _processor.Check(request);
            }
            catch(ArgumentNullException ex)
            {
                Assert.AreEqual("request", ex.ParamName);
                throw;
            }
        }
    }
}
