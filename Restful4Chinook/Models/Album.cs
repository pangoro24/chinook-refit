using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restful4Chinook.Models
{
    public class Album
    {
        [JsonProperty("AlbumId")]
        public long AlbumId { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("ArtistId")]
        public long ArtistId { get; set; }
    }
}
