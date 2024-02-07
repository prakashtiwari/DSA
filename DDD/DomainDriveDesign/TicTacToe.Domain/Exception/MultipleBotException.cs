namespace TicTacToe.Domain.ExceptionDomain
{
    public class MultipleBotException : Exception
    {
        public MultipleBotException(string message) : base(message) { }
    }
}
