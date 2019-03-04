using Refit;
using Restful4Chinook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful4Chinook.Interfaces
{
    public interface IchinookAPI
    {
        [Get("/api/v1/artistsAll")]
        Task<List<Artist>> GetAllArtists();
        [Get("/api/v1/customer/?email={email}")]
        Task<Customer> GetCustomer(string email);
        [Get("/api/v1/albumsByArtist/{artistName}")]
        Task<List<Response1>> GetAlbumsOfArtist(string artistName);
        [Get("/api/v1/tracksOfAlbum/{albumName}")]
        Task<List<Response2>> GetTracksOfAlbum(string albumName);
    }
}
