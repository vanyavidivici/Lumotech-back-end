namespace Shared.DataTransferObjects;

public record OrderDto(Guid Id, DateTime OrderDate, DateTime? ArrivalTime, string? Note, string Status, Guid CarId,
    Guid RobotId, string GpsLatitude, string GpsLongitude, string UserId)
{
    public OrderDto() : this(Guid.Empty, DateTime.Now, null, null, "", Guid.Empty, Guid.Empty, "", "", "") { }
}