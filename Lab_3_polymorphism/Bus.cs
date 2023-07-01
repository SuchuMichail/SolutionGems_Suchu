using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Bus : AVehicle
{
    private int Speed;

    public override VehicleType Type => VehicleType.Bus;

    public override VehicleColor Color { get; }
    public override int LicensePlateNumber { get; }
    public override bool HasPassenger { get; }

    public Bus() 
    {
        var enumColorLength = Enum.GetNames(typeof(VehicleColor)).Length;

        Color = (VehicleColor)new Random().Next(enumColorLength);
        LicensePlateNumber = new Random().Next(100, 999);
        HasPassenger = new Random().NextDouble() > 0.5;

        Speed = new Random().Next(80, 110);
    }

    public override int GetSpeed()
    {
        return Speed;
    }
}