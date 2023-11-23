namespace Entities.Exceptions;

public class RobotNotFoundException : NotFoundException
{
    public RobotNotFoundException(Guid robotId) 
        : base($"Robot with id: {robotId} doesn't exist in the database.")
    {
    }
}