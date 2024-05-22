using Services.Models;

namespace Services.Repositories.Abstract
{
    public interface IFlightService
    {
        Task<FlightSearchResponse> SearchFlightAsync(FlightSearchRequest value);
        Task<FlightDetail> GetFlightDetailById(int id);  
    }
}
