using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restful4Chinook.Models
{
    public class InvoiceItem
    {
        [JsonProperty("InvoiceLineId")]
        public long InvoiceLineId { get; set; }

        [JsonProperty("InvoiceId")]
        public long InvoiceId { get; set; }

        [JsonProperty("TrackId")]
        public long TrackId { get; set; }

        [JsonProperty("UnitPrice")]
        public double UnitPrice { get; set; }

        [JsonProperty("Quantity")]
        public long Quantity { get; set; }
    }
}
