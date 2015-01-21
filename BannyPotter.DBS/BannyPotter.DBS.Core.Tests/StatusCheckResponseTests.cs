using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace BannyPotter.DBS.Core.Tests
{
    [TestClass]
    public class StatusCheckResponseTests
    {
        string _validXml = String.Empty;
        StatusCheckResponse _validResponse = null;

        [TestInitialize]
        public void Init()
        {
            _validXml = File.ReadAllText("ExampleResponse.xml");
            _validResponse = GetValidStatusCheckResponse();
        }

        [TestMethod]
        public void StatusCheckResponse_DeserializesToValidObject()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(StatusCheckResponse));
            StringReader reader = new StringReader(_validXml);

            StatusCheckResponse result = (StatusCheckResponse)mySerializer.Deserialize(reader);

            Assert.AreEqual(result.CheckResultType, "SUCCESS");
            Assert.AreEqual(result.Forename, "BILLY");
            Assert.AreEqual(result.Surname, "JONES");
            Assert.AreEqual(result.Status, StatusEnum.BLANK_NO_NEW_INFO);
            Assert.AreEqual(result.PrintDate, "2013-06-10");
        }

        private StatusCheckResponse GetValidStatusCheckResponse()
        {
            StatusCheckResponse response = new StatusCheckResponse
            {
                CheckResultType = "SUCCESS",
                Forename = "BILLY",
                Surname = "JONES",
                Status = StatusEnum.BLANK_NO_NEW_INFO,
                PrintDate = new DateTime(2013, 06, 10).ToString("yyyy-MM-dd")
            };

            return response;
        }
    }
}
