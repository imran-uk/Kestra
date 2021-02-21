using System.ComponentModel.DataAnnotations;

namespace FleetManager.API.Models
{
    // can get inmspioration from WeatherForecast type
    public class VehicleModel
    {
        // see note about int and defasult value 0 as below
        [Required]
        public int? Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }

        // TODO
        // use my custom validator attr :)
        //[ProductionYear(AllowShortNotation = true)]
        public int ProductionYear { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FriendlyName { get; set; }

        // note that we have to make int fields ? so that it "may be null"
        // otherwise a default value (like 0 in this case)
        // will be set and therefore the validation will not kick-in
        [Required]
        public int? Mileage { get; set; }
    }

    // Piotr has a static class VehicleExtensions here
    // It has Extension method in it
    // Fluent API, method chaining
    //
    // benefits are that it keeps main class simple, only exports what is needed
    //
    // ToModel method (from VehicleCreate to VehicleModel)
}