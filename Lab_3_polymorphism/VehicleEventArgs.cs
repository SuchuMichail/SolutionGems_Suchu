using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class VehicleEventArgs : EventArgs
{
    public VehicleColor Color { get; }
    public VehicleType BodyType { get; }
    public int LicensePlateNumber { get; }
    public bool HasPassenger { get; }

    public int Speed { get; }

    public VehicleEventArgs(AVehicle vehicle)
    {
        Color = vehicle.Color;
        BodyType = vehicle.Type;
        LicensePlateNumber = vehicle.LicensePlateNumber;
        HasPassenger = vehicle.HasPassenger;
        Speed = vehicle.GetSpeed();
    }

    public override string ToString()
    {
        return $"Номер машины: {LicensePlateNumber}\n" +
               $"Цвет: {Color.ToString()}\n" +
               $"Тип: {BodyType.ToString()}\n" +
               $"Есть ли пассажир: {HasPassenger}\n" +
               $"Скорость: {Speed}\n";
    }
}