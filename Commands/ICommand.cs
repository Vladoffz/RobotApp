namespace RobotAppp228322
{
    public interface ICommand
    {
        void General<T>(T message);
        void Success<T>(T message);
        void Error<T>(T message);
        int InputToInt(string message);
    }
}