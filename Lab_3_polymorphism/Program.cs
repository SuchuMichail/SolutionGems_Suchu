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

        using var terminalRandom = new TrafficFlowTerminalRandom(point);
        using var terminalSpeeding = new TrafficFlowTerminalSpeeding(point);
        using var terminalStolen = new TrafficFlowTerminalStolen(point);

        Random random = new Random();

        var enumVehicleTypesLength = Enum.GetNames(typeof(VehicleType)).Length;
        int typeVehicle;

        while (!Console.KeyAvailable)
        {
            typeVehicle = random.Next(enumVehicleTypesLength);
            AVehicle vehicle = new Car();

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

            Console.WriteLine("Begin\n");
            
            point.RegisterVehicle(vehicle);

            Console.WriteLine("End\n******************************************\n");


            //point.PrintVehicle(vehicle); //выводил все машины

            System.Threading.Thread.Sleep(random.Next(500, 5000));
        }
        
        Console.WriteLine("\nСтатистика:\n" + point.GetStatistics().ToString());
    }
}