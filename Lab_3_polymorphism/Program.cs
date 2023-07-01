using System.Drawing;

class Program
{
    public static void Main()
    {
        List<int> stolenNumbers = new List<int>();
        for(int i = 100; i < 300; i++)
        {
            //пусть номера украденных машин от 100 до 299
            stolenNumbers.Add(i);
        }

        CheckPoint point = new CheckPoint(stolenNumbers);
        Random random = new Random();

        var enumVehicleTypesLength = Enum.GetNames(typeof(VehicleType)).Length;
        int typeVehicle;

        while (!Console.KeyAvailable)
        {
            typeVehicle = random.Next(enumVehicleTypesLength);
            AVehicle vehicle = null;

            if(typeVehicle == (int)VehicleType.Car)
            {
                vehicle = new Car();
            }
            if(typeVehicle == (int)VehicleType.Truck)
            {
                vehicle = new Truck();
            }
            if(typeVehicle == (int)VehicleType.Bus)
            {
                vehicle = new Bus();
            }

            point.RegisterVehicle(vehicle);
            point.PrintVehicle(vehicle);

            System.Threading.Thread.Sleep(random.Next(500, 5000));
        }
        
        Console.WriteLine("\nСтатистика:\n" + point.GetStatistics().ToString());
    }
}