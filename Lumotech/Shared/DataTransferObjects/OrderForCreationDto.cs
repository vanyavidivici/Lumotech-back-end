namespace Shared.DataTransferObjects;

public record OrderForCreationDto(string Note, string Status, string GpsLatitude, string GpsLongitude, 
    Guid CarId, Guid RobotId);