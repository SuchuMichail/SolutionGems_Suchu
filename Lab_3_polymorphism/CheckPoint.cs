using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CheckPoint
{
    private int speed;

    private CheckPointStatistics statistics;
    private List<int> stolenNumbers;

    public event EventHandler<VehicleEventArgs>? OnVehiclePass;
    public event EventHandler<VehicleEventArgs>? OnVehicleSpeeding;
    public event EventHandler<VehicleEventArgs>? OnVehicleStolen;

    public CheckPoint(List<int> stolen_num)
    {
        speed = 0;
        statistics = new CheckPointStatistics();

        stolenNumbers = new List<int>();
        foreach (int iter in stolen_num)
        {
            stolenNumbers.Add(iter);
        }
    }

    public void RegisterVehicle(AVehicle/*?*/ vehicle)
    {
        /* if(vehicle == null)
         {
             throw new ArgumentNullException();
         }*/

        OnVehiclePass?.Invoke(vehicle, new VehicleEventArgs(vehicle));

        int iterator = 0;
        bool flag = false;//является ли машина угнанной

        while (iterator != stolenNumbers.Count && flag == false)
        {
            if (stolenNumbers[iterator] == vehicle.LicensePlateNumber)
            {
                //Console.WriteLine("Угнанная машина. Перехват!");
                OnVehicleStolen?.Invoke(vehicle, new VehicleEventArgs(vehicle));

                flag = true;
                statistics.CarJackersCount++;
            }
            iterator++;
        }

        if(vehicle.GetSpeed() > 110)
        {
            //Console.WriteLine("Превышение скорости!");
            OnVehicleSpeeding?.Invoke(vehicle, new VehicleEventArgs(vehicle));

            statistics.SpeedLimitBreakersCount++;
        }

        if(vehicle.Type == VehicleType.Car)
        {
            statistics.CarsCount++;
        }
        if(vehicle.Type == VehicleType.Truck)
        {
            statistics.TrucksCount++;
        }
        if(vehicle.Type == VehicleType.Bus)
        {
            statistics.BusesCount++;
        }

        speed += vehicle.GetSpeed();
        statistics.AverageSpeed = speed / (statistics.CarsCount + statistics.TrucksCount + statistics.BusesCount);
        
    }

    public CheckPointStatistics GetStatistics()
    {
        return statistics;
    }


    /*
    public void PrintVehicle(AVehicle? vehicle)
    {
        if (vehicle == null)
        {
            throw new ArgumentNullException();
        }

        Console.WriteLine($"Номер машины: {vehicle.LicensePlateNumber}");
        Console.WriteLine($"Цвет: {vehicle.Color.ToString()}");
        Console.WriteLine($"Тип: {vehicle.Type.ToString()}");
        Console.WriteLine($"Есть ли пассажир: {vehicle.HasPassenger}");
        Console.WriteLine($"Скорость: {vehicle.GetSpeed()}");
        Console.WriteLine();
    }
   */
}