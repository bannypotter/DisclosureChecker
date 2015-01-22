using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BannyPotter.DBS.Core
{
    public class StatusCheckProcessor : IStatusCheckProcessor
    {
        private string _baseUri = "https://secure.crbonline.gov.uk/crsc/api/status/";
        private WebClient _webClient;
        private XmlSerializer _xmlSerializer;

        public StatusCheckProcessor(WebClient webClient)
        {
            _webClient = webClient;
            _xmlSerializer = new XmlSerializer(typeof(StatusCheckResponse));
        }

        public StatusCheckResponse Check(StatusCheckRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            Uri uri = GenerateUri(request);
            string xml = _webClient.DownloadString(uri);
            StringReader stringReader = new StringReader(xml);

            StatusCheckResponse response = (StatusCheckResponse)_xmlSerializer.Deserialize(stringReader);

            return response;
        }

        public async Task<StatusCheckResponse> CheckAsync(StatusCheckRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            Uri uri = GenerateUri(request);
            string xml = await _webClient.DownloadStringTaskAsync(uri);

            StringReader stringReader = new StringReader(xml);
            StatusCheckResponse response = (StatusCheckResponse)_xmlSerializer.Deserialize(stringReader);

            return response;
        }

        public Uri GenerateUri(StatusCheckRequest request)
        {
            string format = _baseUri + "{0}?dateOfBirth={1}&surname={2}&organisationName={3}&employeeSurname={4}&employeeForename={5}&hasAgreedTermsAndConditions={6}";
            string url = string.Format(format,
                request.DisclosureReferenceNumber.ToString(),
                request.DateOfBirth.ToShortDateString(),
                request.Surname,
                request.OrganisationName,
                request.EmployeeSurname,
                request.EmployeeForename,
                request.AgreesToTermsAndConditions.ToString().ToLower());

            return new Uri(url);
        }
    }
}
