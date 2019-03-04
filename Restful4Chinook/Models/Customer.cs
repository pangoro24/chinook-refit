using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restful4Chinook.Models
{
    public class Customer
    {
        [JsonProperty("CustomerId")]
        public long CustomerId { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Company")]
        public string Company { get; set; }

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

        [JsonProperty("SupportRepId")]
        public long SupportRepId { get; set; }
    }
}
