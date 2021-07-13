using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace api.Models.Base
{
    [XmlRoot("Result")]
    public class DatabaseActionResultModel
    {
        [XmlElement("Success")]
        public bool Success { get; set; }
        [XmlElement("Message")]
        public string Message { get; set; }
        [XmlElement("ErrorNumber")]
        public int? ErrorNumber { get; set; }
        [XmlElement("ErrorState")]
        public int? ErrorState { get; set; }
        public string Kode { get; set; }
        public string Pesan { get; set; }
        public object Data { get; set; }
        public object Data2 { get; set; }
        public int? RecordsTotal { get; set; }

        public DatabaseActionResultModel()
        {
            Success = false;
            Message = string.Empty;
            ErrorNumber = null;
            ErrorState = null;
            Kode = string.Empty;
            Pesan = string.Empty;
            Data = null;
            Data2 = null;
            RecordsTotal = null;
        }
    }
}
