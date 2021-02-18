using System.ComponentModel.DataAnnotations;

namespace FleetManager.API.Models
{
    // can get inmspioration from WeatherForecast type
    public class VehicleModel
    {
        [Required]
        public int Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }

        // use my custom validator attr :)
        [ProductionYear(AllowShortNotation = true)]
        public int ProductionYear { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FriendlyName { get; set; }

        [Required]
        public int Mileage { get; set; }
    }
}