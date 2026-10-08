using AirportCarbonPOC.Api.Data;
using static AirportCarbonPOC.Api.Models.Dtos;

namespace AirportCarbonPOC.Api.Services
{
    /// <summary>
    /// Core business logic for hotspot detection and intervention simulation.
    /// CONSTRAINT: All assumptions are transparent and returned in API responses.
    /// </summary>
    public class EmissionService
    {
        private readonly SyntheticDataProvider _dataProvider;

        // CONSTRAINT: Transparent Assumptions
        // These emission factors are simplified for POC demonstration.
        // In a real solution, these would come from ICAO/EASA published factors.
        private const double APU_EMISSION_FACTOR_KG_PER_MIN = 2.5;
        private const double VEHICLE_IDLE_FACTOR_KG_PER_MIN = 1.2;

        public EmissionService(SyntheticDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public HotspotResponse GetCurrentHotspot()
        {
            var gates = _dataProvider.GetGateOperations();

            double totalApu = gates.Sum(g => g.ApuRuntimeMinutes * APU_EMISSION_FACTOR_KG_PER_MIN);
            double totalVehicle = gates.Sum(g => g.GroundVehicleIdleMinutes * VEHICLE_IDLE_FACTOR_KG_PER_MIN);
            double total = totalApu + totalVehicle;

            // CONSTRAINT: Focus on ONE operational source
            bool apuIsHotspot = totalApu >= totalVehicle;
            string source = apuIsHotspot ? "Auxiliary Power Unit (APU)" : "Ground Vehicle Idling";
            string description = apuIsHotspot
                ? $"Excess APU runtime detected across {gates.Count} gates in Terminal Zone A."
                : $"Excess ground vehicle idling detected across {gates.Count} gates in Terminal Zone A.";

            // CONSTRAINT: ONE recommendation
            string recommendation = apuIsHotspot
                ? "Connect aircraft to Fixed Electrical Ground Power (FEGP) instead of running APU during turnaround. Target: 50% reduction in APU runtime."
                : "Implement dispatch-based vehicle routing to eliminate unnecessary idling. Target: 30% reduction in idle time.";

            return new HotspotResponse
            {
                TotalEmissionsKg = Math.Round(total, 2),
                ApuEmissionsKg = Math.Round(totalApu, 2),
                VehicleEmissionsKg = Math.Round(totalVehicle, 2),
                HotspotSource = source,
                HotspotDescription = description,
                Recommendation = recommendation,
                RawData = gates,
                Assumptions = new Dictionary<string, double>
            {
                { "APU Emission Factor (kg CO2/min)", APU_EMISSION_FACTOR_KG_PER_MIN },
                { "Ground Vehicle Idle Factor (kg CO2/min)", VEHICLE_IDLE_FACTOR_KG_PER_MIN }
            }
            };
        }

        public SimulationResponse SimulateIntervention(SimulationRequest request)
        {
            var gates = _dataProvider.GetGateOperations();

            double apuBefore = gates.Sum(g => g.ApuRuntimeMinutes * APU_EMISSION_FACTOR_KG_PER_MIN);
            double vehicleBefore = gates.Sum(g => g.GroundVehicleIdleMinutes * VEHICLE_IDLE_FACTOR_KG_PER_MIN);
            double beforeTotal = apuBefore + vehicleBefore;

            double apuAfter = apuBefore;
            double vehicleAfter = vehicleBefore;
            string strategyDesc;

            switch (request.Strategy)
            {
                case "ReduceAPU":
                    // CONSTRAINT: Do not alter aviation safety procedures.
                    // FEGP connection is standard ground ops practice, not a safety change.
                    apuAfter = gates.Sum(g => (g.ApuRuntimeMinutes * 0.5) * APU_EMISSION_FACTOR_KG_PER_MIN);
                    strategyDesc = "Reduce APU runtime by 50% via Fixed Electrical Ground Power (FEGP) connection.";
                    break;

                case "OptimizeVehicles":
                    vehicleAfter = gates.Sum(g => (g.GroundVehicleIdleMinutes * 0.7) * VEHICLE_IDLE_FACTOR_KG_PER_MIN);
                    strategyDesc = "Optimize ground vehicle dispatch routing to reduce idle time by 30%.";
                    break;

                default:
                    throw new ArgumentException($"Unknown strategy: {request.Strategy}");
            }

            double afterTotal = apuAfter + vehicleAfter;
            double savings = beforeTotal - afterTotal;

            return new SimulationResponse
            {
                Strategy = request.Strategy,
                StrategyDescription = strategyDesc,
                BeforeEmissionsKg = Math.Round(beforeTotal, 2),
                AfterEmissionsKg = Math.Round(afterTotal, 2),
                SavingsKg = Math.Round(savings, 2),
                SavingsPercent = Math.Round((savings / beforeTotal) * 100, 2),
                ApuBeforeKg = Math.Round(apuBefore, 2),
                ApuAfterKg = Math.Round(apuAfter, 2),
                VehicleBeforeKg = Math.Round(vehicleBefore, 2),
                VehicleAfterKg = Math.Round(vehicleAfter, 2),
                Assumptions = new Dictionary<string, double>
            {
                { "APU Emission Factor (kg CO2/min)", APU_EMISSION_FACTOR_KG_PER_MIN },
                { "Ground Vehicle Idle Factor (kg CO2/min)", VEHICLE_IDLE_FACTOR_KG_PER_MIN }
            }
            };
        }
    }
}
