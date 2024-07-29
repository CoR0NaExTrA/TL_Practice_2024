namespace CarFactory.Models.Engine;
internal class InlineEngine : IEngine
{
    public string Name => "Inline engine";

    public int MaxSpeed => 180;
}
