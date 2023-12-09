namespace Shared.DataTransferObjects;

public record CarDto(Guid Id, string PlateNumber, string SerialNumber, string CarModel, double BatteryCapacity);