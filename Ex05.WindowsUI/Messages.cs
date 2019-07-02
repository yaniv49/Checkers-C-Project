namespace Ex05.WindowsUI
{
    public class Messages
    {
        public static string s_WrongStep = "Wrong step, please try again";
        public static string s_Win =
@"{0} won!
Another Round?";

        public static string s_ComputerWin =
@"Computer won!
Another Round?";

        public static string s_Tie = string.Format(
@"Tie!
Another Round?");

        public static string s_NameEmpty = string.Format(
@"Player name is empty, please fill it out");
    }
}