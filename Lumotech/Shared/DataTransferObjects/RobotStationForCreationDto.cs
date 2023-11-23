namespace Shared.DataTransferObjects;

public record RobotStationForCreationDto(string StationName, string GpsLongitude, string GpsLatitude, Guid LocationId);