using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restful4Chinook.Models
{
    public class Playlist
    {
        [JsonProperty("PlaylistId")]
        public long PlaylistId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
