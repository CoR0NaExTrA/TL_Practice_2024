using CarFactory.Models.Car;
using CarFactory.Models.CarBody;
using CarFactory.Models.Engine;
using CarFactory.Models.Colors;
using CarFactory.Models.Transmission;
using CarFactory.Models.SteeringLocation;

namespace CarFactory;
public class CarFactory
{
    public void Run(List<ICar> _cars)
    {
        string command = "";
        while (command != "4")
        {
            command = Console.ReadLine();
            if (command == "4")
            {
                break;
            }
            try
            {
                ExecutingCommands(command, _cars);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("To continue, press the enter");
            command = Console.ReadLine();
        }
    }

    private void ExecutingCommands(string command, List<ICar> _cars)
    {
        switch (command)
        {
            case "1":
                NewCar(_cars);
                break;
            case "2":
                AllCar(_cars);
                break;
            case "3":
                RemoveCar(_cars);
                break;
            case "4":
                break;
            default:
                throw new ArgumentException("Invalid value");
        }
    }

    private void NewCar(List<ICar> _cars)
    {
        Car car = new Car(
            name: GetName(),
            body: GetBody(),
            engine: GetEngine(),
            color: GetColor(),
            transmission: GetTransmission(),
            steeringLocation: GetSteeringLocation()
            );

        _cars.Add(car);
        Console.WriteLine();
        Console.WriteLine(car);
        Console.WriteLine();
        Console.WriteLine("Car was created");

    }

    private string GetName()
    {
        Console.Write("Enter name new car: ");
        string name = Console.ReadLine();
        while (String.IsNullOrEmpty(name))
        {
            Console.WriteLine("The name can't be empty or only made up of spaces");
            Console.Write("Enter again: ");
            name = Console.ReadLine();
        }
        return name;
    }

    private ICarBody GetBody()
    {
        Console.WriteLine("Choose car body: " +
                            "\n Sedan" +
                            "\n Coupe");
        while (true)
        {
            switch (Console.ReadLine())
            {
                case "Sedan":
                    return new Sedan();
                case "Coupe":
                    return new Coupe();
                default:
                    Console.WriteLine("There is no such car body in the list. Try again");
                    break;
            }
        }
    }

    private IEngine GetEngine()
    {
        Console.WriteLine("Choose engine: " +
                            "\n Inline engine" +
                            "\n Engine V type" +
                            "\n Engine W type");
        while (true)
        {
            switch (Console.ReadLine())
            {
                case "Inline engine":
                    return new InlineEngine();
                case "Engine V type":
                    return new EngineVType();
                case "Engine W type":
                    return new EngineWType();
                default:
                    Console.WriteLine("There is no such engine in the list. Try again");
                    break;
            }
        }
    }

    private IColors GetColor()
    {
        Console.WriteLine("Choose color: " +
                            "\n White" +
                            "\n Black");
        while (true)
        {
            switch (Console.ReadLine())
            {
                case "White":
                    return new White();
                case "Black":
                    return new Black();
                default:
                    Console.WriteLine("There is no such color in the list. Try again");
                    break;
            }
        }
    }

    private ITransmission GetTransmission()
    {
        Console.WriteLine("Choose transmission: " +
                            "\n Automatic" +
                            "\n Mechanical" +
                            "\n Robot");
        while (true)
        {
            switch (Console.ReadLine())
            {
                case "Automatic":
                    return new Automatic();
                case "Mechanical":
                    return new Mechanical();
                case "Robot":
                    return new Robot();
                default:
                    Console.WriteLine("There is no such transmission in the list. Try again");
                    break;
            }
        }
    }

    private SteeringPosition GetSteeringLocation()
    {
        Console.WriteLine("Enter steering location(left/right): ");
        SteeringPosition location;
        while (!(Enum.TryParse(Console.ReadLine(), true, out location)))
        {
            Console.WriteLine("There is no such steering location in the list. Try again");
        }
        return location;
    }

    private void AllCar(List<ICar> _cars)
    {
        _cars.ForEach(car => Console.WriteLine(car));
        Console.WriteLine("Cars was printed");
    }

    private void RemoveCar(List<ICar> _cars)
    {
        AllCar(_cars);
        Console.Write("Enter name car: ");
        string name = Console.ReadLine();
        var car = _cars.FirstOrDefault(c => c.Name == name);
        if (car == null)
        {
            throw new ArgumentException($"Car {name} not found");
        }
        _cars.Remove(car);
        Console.WriteLine("Car removed");
    }
}