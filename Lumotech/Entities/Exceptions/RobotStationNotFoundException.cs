namespace Entities.Exceptions;

public class RobotStationNotFoundException : NotFoundException
{
    public RobotStationNotFoundException(Guid robotStationId) 
        : base($"The robot station with id: {robotStationId} doesn't exist in the database.")
    {
    }
}