namespace Shared.DataTransferObjects;

public record RobotStationForUpdateDto(string StationName, string GpsLongitude, string GpsLatitude, Guid LocationId,
    IEnumerable<RobotForCreationDto>? Robots);