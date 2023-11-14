namespace Porcupine.Robert.Mrobo.Shared.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message, int requestId = 0) : base(message)
    {
        
    }
}