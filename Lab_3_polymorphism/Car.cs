using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Car : AVehicle
{
    private int Speed;

    public override VehicleType Type => VehicleType.Car;

    public override VehicleColor Color { get; }
    public override int LicensePlateNumber { get; }
    public override bool HasPassenger { get; }
 
    public Car() /*: base()*/
    {
        var enumColorLength = Enum.GetNames(typeof(VehicleColor)).Length;

        Color = (VehicleColor)new Random().Next(enumColorLength);
        LicensePlateNumber = new Random().Next(100, 999);
        HasPassenger = new Random().NextDouble() > 0.5;

        Speed = new Random().Next(90, 150);
    }

    public override int GetSpeed()
    {
        return Speed;
    }
}