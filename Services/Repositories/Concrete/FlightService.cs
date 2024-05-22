using FlightService;
using Microsoft.Extensions.Configuration;
using Services.Models;
using Services.Repositories.Abstract;
using static FlightService.AirSearchClient;

namespace Services.Repositories.Concrete
{
    public class FlightServices : IFlightService
    {
        private readonly string _remoteAddress;
        public FlightServices( IConfiguration configuration)
        {
            _remoteAddress = configuration.GetSection("SoapExternalServiceRemoteAddress").Value;
        }

        public async Task<FlightDetail> GetFlightDetailById(int id)
        {
            try
            {
                var flightDetail = new FlightDetail();
                if(id == 1) {
                    flightDetail.Id = id;
                    flightDetail.MealIsFree = true;
                    flightDetail.Stop = 0;
                    flightDetail.BaggageAllowance = 15;
                }
                else if(id == 2)
                {
                    flightDetail.Id = id;
                    flightDetail.MealIsFree = false;
                    flightDetail.Stop = 1;
                    flightDetail.BaggageAllowance = 15;
                }
                else
                {
                    flightDetail.Id = id;
                    flightDetail.MealIsFree = true;
                    flightDetail.Stop = 2;
                    flightDetail.BaggageAllowance = 15;
                }
                return await Task.FromResult(flightDetail);
            }

            catch
            {

                throw;
            }

        }

        public async Task<FlightSearchResponse> SearchFlightAsync(FlightSearchRequest value)
        {


            try
            {
                var request = new SearchRequest
                {
                    Origin = value.Origin,
                    Destination = value.Destination,
                    DepartureDate = value.DepartureDate
                };
                SearchResult? result;
                using (var client = new AirSearchClient(EndpointConfiguration.BasicHttpBinding_IAirSearch, _remoteAddress))
                {
                    result = await client.AvailabilitySearchAsync(request);

                }

                List<Flight> flightList = result.FlightOptions.Select((l, i) => new Flight
                {
                    Id = i + 1,
                    DepartureDateTime = l.DepartureDateTime,
                    ArrivalDateTime = l.ArrivalDateTime,
                    FlightNumber = l.FlightNumber,
                    Price = l.Price
                }).ToList();

                var response = new FlightSearchResponse
                {
                    Flights = flightList,
                    HasError = result.HasError
                };


                return response;
            }
            catch
            {

                throw;
            }
        }
    }
}
