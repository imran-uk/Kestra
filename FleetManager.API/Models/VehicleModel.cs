namespace FleetManager.API.Models
{
    // can get inmspioration from WeatherForecast type
    public class VehicleModel
    {
        public string Model { get; set; }
        public string Make { get; set; }
        public int ProductionYear { get; set; }
        public string FriendlyName { get; set; }
    }
}