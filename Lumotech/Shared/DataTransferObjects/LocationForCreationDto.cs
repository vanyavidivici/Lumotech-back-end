namespace Shared.DataTransferObjects;

public record LocationForCreationDto(string Country, string City, IEnumerable<RobotStationForCreationDto>? RobotStations);