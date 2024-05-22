namespace Services.Models
{
    public class FlightSearchResponse
    {
        public List<Flight> Flights { get; set; }
        public bool HasError { get; set; }
    }

    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public decimal Price { get; set; }
    }

    public class FlightDetail
    {
        public int Id { get; set; }
        public int BaggageAllowance { get; set; }
        public bool MealIsFree { get; set; }
        public int Stop { get; set; }

    }
}
