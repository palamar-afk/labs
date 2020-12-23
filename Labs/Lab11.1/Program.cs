using System;

namespace Lab11
{    class Program
    {
        static void Main(string[] args)
        {
            ServiceStation service = new ServiceStation();

            Console.WriteLine("Car1 is required full revision");
            Car car1 = new Car();
            car1.show();
            FullService(service).Invoke(car1);
            Console.WriteLine(new string('=', 30));
            car1.show();

            Console.WriteLine(new string('=', 50));

            Car car2 = new Car();
            car2.show();
            Console.WriteLine(new string('=', 30));
            WheelService(service).Invoke(car2);
            car2.show();

            Console.WriteLine(new string('=', 50));

            Car car3 = new Car();
            car3.show();
            Console.WriteLine(new string('=', 30));
            BodyService(service).Invoke(car3);
            car3.show();

            Console.WriteLine(new string('=', 50));

            Car car4 = new Car();
            car4.show();
            Console.WriteLine(new string('=', 30));
            CustomService(service).Invoke(car4);
            car4.show();

            Console.WriteLine(new string('=', 50));
        }
        static ServiceStation.Service FullService(ServiceStation carInService)
        {
            ServiceStation.Service operation = null;
            operation += carInService.set_IsCorrectWheelAngles;
            operation += carInService.set_IsPainted;
            operation += carInService.set_IsOilChanged;
            operation += carInService.set_IsFullRevision;
            operation += carInService.set_IsWheelReplaced;
            operation += carInService.set_IsCarBodyRepaired;
            return operation;
        }
        static ServiceStation.Service WheelService(ServiceStation carInService)
        {
            ServiceStation.Service operation = null;
            operation += carInService.set_IsCorrectWheelAngles;
            operation += carInService.set_IsWheelReplaced;
            return operation;
        }
        static ServiceStation.Service BodyService(ServiceStation carInService)
        {
            ServiceStation.Service operation = null;
            operation += carInService.set_IsPainted;
            operation += carInService.set_IsFullRevision;
            operation += carInService.set_IsCarBodyRepaired;
            return operation;
        }
        static ServiceStation.Service CustomService(ServiceStation carInService)
        {
            ServiceStation.Service operation = null;
            while (true)
            {
                Console.Write("Хотите проверить развал-схождение?(1-да, 0-нет):");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    operation += carInService.set_IsCorrectWheelAngles;
                    break;
                }
                else break;
            }
            while (true)
            {
                Console.Write("Хотите покрасить?(1-да, другое число-нет):");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    operation += carInService.set_IsPainted;
                    break;
                }
                else break;
            }
            while (true)
            {
                Console.Write("Хотите поменять масло?(1-да, другое число-нет):");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    operation += carInService.set_IsOilChanged;
                    break;
                }
                else break;
            }
            while (true)
            {
                Console.Write("Хотите провести полный осмотр?(1-да, другое число-нет):");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    operation += carInService.set_IsFullRevision;
                    break;
                }
                else break;
            }
            while (true)
            {
                Console.Write("Хотите поменять колёса?(1-да, другое число-нет):");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    operation += carInService.set_IsWheelReplaced;
                    break;
                }
                else break;
            }
            while (true)
            {
                Console.Write("Хотите починить кузов?(1-да, другое число-нет):");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    operation += carInService.set_IsCarBodyRepaired;
                    break;
                }
                else break;
            }
            return operation;
        }
    }
}