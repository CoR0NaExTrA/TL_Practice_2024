using CarFactory;
using CarFactory.Models.Car;

var carFactory = new CarFactory.CarFactory();
PrintMenu();
List<ICar> _cars = new();
carFactory.Run(_cars);

static void PrintMenu()
{
    Console.WriteLine("Menu: " +
                        "\n 1 - New car; " +
                        "\n 2 - All car; " +
                        "\n 3 - Remove car; " +
                        "\n 4 - Exit");
}
