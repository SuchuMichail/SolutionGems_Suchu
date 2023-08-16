using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TrafficFlowTerminalStolen : IDisposable
{
    private CheckPoint _checkPoint;

    public TrafficFlowTerminalStolen(CheckPoint checkPoint)
    {
        _checkPoint = checkPoint;
        _checkPoint.OnVehicleStolen += EventHandler;
    }

    private void EventHandler(object? sender, VehicleEventArgs args)
    {
        Console.WriteLine("Угнанная машина!");
    }

    public void Dispose()
    {
        _checkPoint.OnVehicleStolen -= EventHandler;
    }
}
