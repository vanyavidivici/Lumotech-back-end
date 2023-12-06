namespace Entities.Exceptions;

public sealed class MaxCapacityRangeBadRequestException : BadRequestException
{
    public MaxCapacityRangeBadRequestException()
        :base("Max battery capacity can't be less than minimal battery capacity that existed.")
    {
    }
}