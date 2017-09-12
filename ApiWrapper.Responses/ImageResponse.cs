using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApiWrapper.Responses
{
    public class ImageResponse
    {
        [XmlType("image")]
        public class Image
        {
            [XmlElement("url")]
            public string Url { get; set; }

            [XmlElement("id")]
            public string Id { get; set; }

            [XmlElement("source_url")]
            public string SourceUrl { get; set; }
        }

        [XmlType("data")]
        public class Data
        {
            [XmlArray("images")]
            [XmlArrayItem("image", typeof(Image))]
            public Image[] Images { get; set; }
        }

        [XmlRoot("response")]
        public class Response
        {
            [XmlElement("data")]
            public Data Data { get; set; }
        }
    }
}
