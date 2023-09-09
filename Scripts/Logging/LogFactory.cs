using System;
using UnityEngine;

namespace BaseCustomFactions.Scripts.Logging
{
    public static class LogFactory
    {
        private const LogLevelsEnum DEFAULT_LOG_LEVEL = LogLevelsEnum.Information;
        public static ILog GetLogger(Type sourceType, LogLevelsEnum logLevelsEnum = DEFAULT_LOG_LEVEL)
        {
            return new Log(sourceType, logLevelsEnum, Debug.Log);
        }
    }
}