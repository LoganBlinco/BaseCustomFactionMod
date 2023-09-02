using System;
using System.Collections.Generic;

namespace BaseCustomFactions.Scripts.Logging
{
    public class Log : ILog
    {
        private static readonly LogLevelsEnum[] LogLevels = (LogLevelsEnum[]) Enum.GetValues(typeof(LogLevelsEnum));
        private readonly Type _sourceType;
        private readonly Dictionary<LogLevelsEnum, bool> _logLevelMap;
        private readonly Action<string> _logFunction;
        
        public Log(Type sourceType, LogLevelsEnum logLevelEnum, Action<string> logFunction)
        {
            _sourceType = sourceType;
            _logFunction = logFunction;
            _logLevelMap = new Dictionary<LogLevelsEnum, bool>();

            PopulateMap(logLevelEnum);
        }

        private void PopulateMap(LogLevelsEnum logLevelEnum)
        {
            for (int index = 0; index < LogLevels.Length; index++)
            {
                if (index >= (int) logLevelEnum)
                {
                    _logLevelMap[LogLevels[index]] = true;
                }
                else
                {
                    _logLevelMap[LogLevels[index]] = false;
                }
            }
        }

        private string GetOutputMessage(string message)
        {
            string msg = $"[{_sourceType}]: {message}";
            return msg;
        }

        public void Debug(string message)
        {
            if (_logLevelMap[LogLevelsEnum.Debug])
            {
                _logFunction(GetOutputMessage(message));
            }
        }

        public void LogInformation(string message)
        {
            if (_logLevelMap[LogLevelsEnum.Information])
            {
                _logFunction(GetOutputMessage(message));
            }
        }

        public void LogWarning(string message)
        {
            if (_logLevelMap[LogLevelsEnum.Warning])
            {
                _logFunction(GetOutputMessage(message));
            }
        }

        public void LogError(string message)
        {
            if (_logLevelMap[LogLevelsEnum.Error])
            {
                _logFunction(GetOutputMessage(message));
            }
        }
    }
}