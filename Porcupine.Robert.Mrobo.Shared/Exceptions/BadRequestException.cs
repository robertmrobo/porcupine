namespace Porcupine.Robert.Mrobo.Shared.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string guestsCanOnlyBeInTheGuestsGroup) : base(guestsCanOnlyBeInTheGuestsGroup)
    {
        
    }
}