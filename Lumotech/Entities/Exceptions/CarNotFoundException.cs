namespace Entities.Exceptions;

public class CarNotFoundException : NotFoundException
{
    public CarNotFoundException(Guid carId) 
        : base($"The car with id: {carId} doesn't exist in the database.")
    {
    }
}