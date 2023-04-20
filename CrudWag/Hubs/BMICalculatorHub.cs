using CrudWag.Models;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreSignalRProductCount.Hubs
{
    public class BMICalculatorHub : Hub
    {
        public async Task CalculateBMI(BMIData data)
        {
            double heightInMeters = data.Height / 100.0; // convert height to meters
            double bmi = data.Weight / (heightInMeters * heightInMeters);

            await Clients.Caller.SendAsync("BMICalculated", bmi);
        }
    }
}
