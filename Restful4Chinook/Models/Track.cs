using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful4Chinook.Models
{
    public class Track
    {
        public int TrackId { get; set; }//PK
        public string Name { get; set; }
        public int AlbumId { get; set; }//FK
        public int MediaTypeId { get; set; }//FK
        public int GenreId { get; set; }//FK
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public float UnitPrice { get; set; }
    }

    public enum MediaType
    {
        None = 0,
        MPEG = 1,
        ProtectedAAC = 2,
        ProtectedMPEG4 = 3,
        PurchasedAAC = 4,
        AAC = 5
    }
}
