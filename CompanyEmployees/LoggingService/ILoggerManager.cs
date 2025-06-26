namespace LoggingService
{
    public interface ILoggerManager
    {
        void LogDebug(string message);//gỡ lỗi
        void LogInformation(string message);// Thông tin
        void LogWarning(string message);// cảnh báo
        void LogError(string message);// Thông báo lỗi
    }
}
