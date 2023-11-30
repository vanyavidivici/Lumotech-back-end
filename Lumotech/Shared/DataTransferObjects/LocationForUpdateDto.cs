namespace Shared.DataTransferObjects;

public record LocationForUpdateDto(string Country, string City, IEnumerable<RobotStationForCreationDto>? RobotStations);