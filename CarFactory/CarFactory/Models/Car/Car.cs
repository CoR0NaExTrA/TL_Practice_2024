using CarFactory.Models.CarBody;
using CarFactory.Models.Colors;
using CarFactory.Models.Engine;
using CarFactory.Models.Transmission;
using CarFactory.Models.SteeringLocation;
using System.Text;

namespace CarFactory.Models.Car;
public class Car : ICar
{
    public string Name { get; }
    public ICarBody Body { get; }
    public IEngine Engine { get; }
    public IColors Color { get; }
    public ITransmission Transmission { get; }
    public SteeringPosition SteeringLocation { get; }
    public Car( string name, ICarBody body, IEngine engine, IColors color, ITransmission transmission, SteeringPosition steeringLocation )
    {
        Name = name;
        Body = body;
        Engine = engine;
        Color = color;
        Transmission = transmission;
        SteeringLocation = steeringLocation;
    }

    public int GetMaxSpeed()
    {
        return Engine.MaxSpeed;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine( "Car:" );
        sb.AppendLine( $"   Name: {Name}" );
        sb.AppendLine( $"   Car body: {Body.Name}" );
        sb.AppendLine( $"   Engine: {Engine.Name}" );
        sb.AppendLine( $"   Color: {Color.Name}" );
        sb.AppendLine( $"   Transmission: {Transmission.Name}" );
        sb.AppendLine( $"   Steering position: {SteeringLocation}" );
        sb.AppendLine( $"   Max speed: {GetMaxSpeed()}" );

        return sb.ToString();
    }
}
