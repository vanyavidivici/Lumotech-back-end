namespace Shared.DataTransferObjects;

public record RobotStationDto(Guid Id, string StationName, string GpsLongitude, string GpsLatitude, Guid LocationId);