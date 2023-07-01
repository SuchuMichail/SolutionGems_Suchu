using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class AVehicle
{
    public abstract VehicleType Type { get; }

    public abstract VehicleColor Color { get; }
    public abstract int LicensePlateNumber { get; }
    public abstract bool HasPassenger { get; }

    /*public AVehicle()
    {
        var enumColorLength = Enum.GetNames(typeof(VehicleColor)).Length;


        Color = (VehicleColor)new Random().Next(enumColorLength);
        LicensePlateNumber = new Random().Next(100, 999);
        HasPassenger = new Random().NextDouble() > 0.5;
    }*/

    public abstract int GetSpeed();
}