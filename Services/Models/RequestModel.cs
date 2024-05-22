using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class FlightSearchRequest
    {

        [Required(ErrorMessage = "origin is a required field")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "destination is a required field")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "deperature is a required field")]
        public DateTime DepartureDate { get; set; }
    }
}
