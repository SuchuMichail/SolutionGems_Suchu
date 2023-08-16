using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TrafficFlowTerminalRandom : IDisposable
{
    private CheckPoint _checkPoint;
    private Random _random;

    public TrafficFlowTerminalRandom(CheckPoint checkPoint)
    {
        _checkPoint = checkPoint;
        _random = new Random();
        _checkPoint.OnVehiclePass += EventHandler;
    }

    private void EventHandler(object? sender, VehicleEventArgs args)
    {
        if (_random.Next(0, 2) == 1)
        {   
            Console.WriteLine(args.ToString());
        }
    }

    public void Dispose()
    {
        _checkPoint.OnVehiclePass -= EventHandler;
    }
}