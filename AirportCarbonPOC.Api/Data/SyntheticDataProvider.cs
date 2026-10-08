using static AirportCarbonPOC.Api.Models.Dtos;

namespace AirportCarbonPOC.Api.Data
{
    /// <summary>
    /// Provides synthetic airport operational data.
    /// CONSTRAINT: No connection to real operational control systems.
    /// All values are hardcoded mock data for demonstration purposes.
    /// </summary>
    public class SyntheticDataProvider
    {
        public List<GateOperation> GetGateOperations()
        {
            // Terminal Zone A - 6 gates with varying APU and vehicle activity
            return new List<GateOperation>
        {
            new() { GateId = 101, TerminalZone = "A", ApuRuntimeMinutes = 55, GroundVehicleIdleMinutes = 12, AircraftOccupancy = 165 },
            new() { GateId = 102, TerminalZone = "A", ApuRuntimeMinutes = 72, GroundVehicleIdleMinutes = 18, AircraftOccupancy = 189 },
            new() { GateId = 103, TerminalZone = "A", ApuRuntimeMinutes = 38, GroundVehicleIdleMinutes = 22, AircraftOccupancy = 142 },
            new() { GateId = 104, TerminalZone = "A", ApuRuntimeMinutes = 64, GroundVehicleIdleMinutes = 9,  AircraftOccupancy = 178 },
            new() { GateId = 105, TerminalZone = "A", ApuRuntimeMinutes = 41, GroundVehicleIdleMinutes = 15, AircraftOccupancy = 156 },
            new() { GateId = 106, TerminalZone = "A", ApuRuntimeMinutes = 58, GroundVehicleIdleMinutes = 20, AircraftOccupancy = 171 }
        };
        }
    }
}
