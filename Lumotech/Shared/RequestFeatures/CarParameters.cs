namespace Shared.RequestFeatures;

public class CarParameters : RequestParameters
{
    public double MinCapacity { get; set; }
    public double MaxCapacity { get; set; } = double.MaxValue;
    
    public bool ValidCapacityRange => MinCapacity > MaxCapacity;
    
    public string? SearchTerm { get; set; }
}