using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CheckPointStatistics
{
    public int CarsCount { get; set; }
    public int TrucksCount { get; set; }
    public int BusesCount { get; set; }
    public int SpeedLimitBreakersCount { get; set; } //количество нарушителей скоростного лимита
    public int CarJackersCount { get; set; } //количество угнанных автомобилей
    public int AverageSpeed { get; set; } //средняя скорость

    public CheckPointStatistics() { 
        CarsCount = TrucksCount = BusesCount = SpeedLimitBreakersCount = CarJackersCount = AverageSpeed = 0;
    }

    public CheckPointStatistics(int cars, int trucks, int buses, int speedBreakers, int carJackers, int averageSpeed) { 
        CarsCount = cars;
        TrucksCount = trucks;
        BusesCount = buses;
        SpeedLimitBreakersCount = speedBreakers;
        CarJackersCount = carJackers;
        AverageSpeed = averageSpeed;
    }

    public override string ToString()
    {
        return "CarsCount: " + CarsCount + "\n" +
               "TrucksCount: " + TrucksCount + "\n" +
               "BusesCount: " + BusesCount + "\n" +
               "SpeedLimitBreakersCount: " + SpeedLimitBreakersCount + "\n" +
               "CarJackersCount: " + CarJackersCount + "\n" +
               "AverageSpeed: " + AverageSpeed + "\n";
    }
}