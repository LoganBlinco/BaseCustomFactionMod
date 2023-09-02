namespace BaseCustomFactions.Scripts.Logging
{
    public interface ILog
    {
        public void Debug(string message);
        public void LogInformation(string message);
        public void LogWarning(string message);
        public void LogError(string message);
    }
}

