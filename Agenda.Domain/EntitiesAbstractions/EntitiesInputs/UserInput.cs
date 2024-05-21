namespace Agenda.Domain.EntitiesAbstractions.EntitiesInputs
{
    public class UserInput(string userName, string password)
    {
        public string UserName { get; set; } = userName;
        public string Password { get; set; } = password;

    }
}
