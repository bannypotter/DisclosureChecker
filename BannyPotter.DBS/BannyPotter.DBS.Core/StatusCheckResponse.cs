using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BannyPotter.DBS.Core
{
    [XmlRoot(ElementName = "statusCheckResult")]
    public class StatusCheckResponse
    {
        [XmlElement(ElementName = "statusCheckResultType")]
        public string CheckResultType { get; set; }

        [XmlElement(ElementName = "status")]
        public StatusEnum Status { get; set; }

        [XmlElement(ElementName = "forename")]
        public string Forename { get; set; }

        [XmlElement(ElementName = "surname")]
        public string Surname { get; set; }

        [XmlElement(ElementName = "printDate")]
        public string PrintDate { get; set; }
    }
}
