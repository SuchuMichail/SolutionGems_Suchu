using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TrafficFlowTerminalSpeeding : IDisposable
{
    private CheckPoint _checkPoint;

    public TrafficFlowTerminalSpeeding(CheckPoint checkPoint)
    {
        _checkPoint = checkPoint;
        _checkPoint.OnVehicleSpeeding += EventHandler;
    }

    private void EventHandler(object? sender, VehicleEventArgs args)
    {
        Console.WriteLine("Превышение скорости!");
    }

    public void Dispose()
    {
        _checkPoint.OnVehicleSpeeding -= EventHandler;
    }
}
