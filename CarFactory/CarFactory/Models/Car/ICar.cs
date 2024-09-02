using CarFactory.Models.CarBody;
using CarFactory.Models.Engine;
using CarFactory.Models.Colors;
using CarFactory.Models.SteeringLocation;
using CarFactory.Models.Transmission;

namespace CarFactory.Models.Car;
public interface ICar
{
    string Name { get; }
    ICarBody Body { get; }
    IEngine Engine { get; }
    IColors Color { get; }
    ITransmission Transmission { get; }
    SteeringPosition SteeringLocation { get; }
    public int GetMaxSpeed();


}
