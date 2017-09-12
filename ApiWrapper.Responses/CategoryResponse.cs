using System.Xml.Serialization;

namespace ApiWrapper.Responses
{
    public class CategoryResponse
    {
        [XmlType("category")]
        public class Category
        {
            [XmlElement("id")]
            public int Id { get; set; }

            [XmlElement("name")]
            public string Name { get; set; }
        }

        [XmlType("data")]
        public class Data
        {
            [XmlArray("categories")]
            [XmlArrayItem("category", typeof(Category))]
            public Category[] Categories { get; set; }
        }

        [XmlRoot("response")]
        public class Response
        {
            [XmlElement("data")]
            public Data Data { get; set; }
        }
    }
}