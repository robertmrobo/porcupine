namespace Porcupine.Robert.Mrobo.IAM.Users.CreateUser;

public class BadRequestException : Exception
{
    public BadRequestException(string guestsCanOnlyBeInTheGuestsGroup) : base(guestsCanOnlyBeInTheGuestsGroup)
    {
        
    }
}