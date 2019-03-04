using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restful4Chinook.Models
{
    public partial class Employee
    {
        [JsonProperty("EmployeeId")]
        public long EmployeeId { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("ReportsTo")]
        public long? ReportsTo { get; set; }

        [JsonProperty("BirthDate")]
        public DateTimeOffset BirthDate { get; set; }

        [JsonProperty("HireDate")]
        public DateTimeOffset HireDate { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Fax")]
        public string Fax { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }
    }
}
