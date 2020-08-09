using System;
using log4net;

namespace aspnet_empty.Logging
{
    public interface IMyLog : ILog
    {
        void Debug(int operatorID, string operand, int actionType, object message, string ip, string browser, string machineName);
        void Debug(int operatorID, string operand, int actionType,object message, string ip, string browser, string machineName, Exception t);


        void Info(int operatorID, string operand, int actionType, object message, string ip, string browser, string machineName);
        void Info(int operatorID, string operand, int actionType, object message, string ip, string browser, string machineName, Exception t);


        void Warn(int operatorID, string operand, int actionType, object message, string ip, string browser, string machineName);
        void Warn(int operatorID, string operand, int actionType, object message, string ip, string browser, string machineName, Exception t);


        void Error(int operatorID, string operand, int actionType, object message, string ip, string browser, string machineName);
        void Error(int operatorID, string operand, int actionType, object message, string ip, string browser, string machineName, Exception t);


        void Fatal(int operatorID, string operand, int actionType, object message, string ip, string browser, string machineName);
        void Fatal(int operatorID, string operand, int actionType, object message, string ip, string browser, string machineName, Exception t);

    }
}