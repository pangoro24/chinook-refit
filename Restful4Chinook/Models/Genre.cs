using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restful4Chinook.Models
{
    public class Genre
    {
        [JsonProperty("GenreId")]
        public long GenreId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
