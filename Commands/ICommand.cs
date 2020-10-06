namespace RobotAppp228322
{
    public interface ICommand
    {
        void General(object message);
        void Success(object message);
        void Error(object message);
        int InputToInt(string message);
    }
}