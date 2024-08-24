using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Models.Models
{
    public class Request
    {
        public string? NationalId { get; set; }
        public string? Type { get; set; }


    }
    public class XrayReq
    {
        public string? nationalID { get; set; }
        public string? Type { get; set; }
    }
    public class TestReq
    {
        public string? nationalID { get; set; }
        public string? Type { get; set; }
    }
    public class Requests: BaseModel
    {
        public string? NationalId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public DateTime DateTime { get; set; }
    }
}
