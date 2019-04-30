namespace DiabloSharp.Exceptions
{
    public class DiabloApiBattleTagException : DiabloApiException
    {
        public DiabloApiBattleTagException(string battleTag)
            : base($"Invalid BattleTag {battleTag}.")
        {
        }
    }
}