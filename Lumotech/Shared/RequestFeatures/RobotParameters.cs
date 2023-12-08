namespace Shared.RequestFeatures;

public class RobotParameters : RequestParameters
{
    public RobotParameters() => OrderBy = "serialNumber";
    public string? SearchTerm { get; set; }
}