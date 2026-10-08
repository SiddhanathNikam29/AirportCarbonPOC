namespace AirportCarbonPOC.Api.Models;
public class Dtos
{
    /// <summary>
    /// Represents synthetic data for a single gate operation snapshot.
    /// </summary>
    public class GateOperation
    {
        public int GateId { get; set; }
        public string TerminalZone { get; set; } = string.Empty;
        public double ApuRuntimeMinutes { get; set; }
        public double GroundVehicleIdleMinutes { get; set; }
        public int AircraftOccupancy { get; set; }
    }

    public class SimulationRequest
    {
        /// <summary>
        /// Strategy to simulate: "ReduceAPU" or "OptimizeVehicles"
        /// </summary>
        public string Strategy { get; set; } = string.Empty;
    }

    public class HotspotResponse
    {
        public double TotalEmissionsKg { get; set; }
        public double ApuEmissionsKg { get; set; }
        public double VehicleEmissionsKg { get; set; }
        public string HotspotSource { get; set; } = string.Empty;
        public string HotspotDescription { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;
        public List<GateOperation> RawData { get; set; } = new();
        public Dictionary<string, double> Assumptions { get; set; } = new();
    }

    public class SimulationResponse
    {
        public string Strategy { get; set; } = string.Empty;
        public string StrategyDescription { get; set; } = string.Empty;
        public double BeforeEmissionsKg { get; set; }
        public double AfterEmissionsKg { get; set; }
        public double SavingsKg { get; set; }
        public double SavingsPercent { get; set; }
        public double ApuBeforeKg { get; set; }
        public double ApuAfterKg { get; set; }
        public double VehicleBeforeKg { get; set; }
        public double VehicleAfterKg { get; set; }
        public Dictionary<string, double> Assumptions { get; set; } = new();
    }
}