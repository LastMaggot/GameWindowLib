using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Windows.Forms;

namespace GameWindowLib
{
    public partial class LogConsole : Form
    {
        public enum LogContainer
        {
            All,
            SuccessEvent,
            FailureEvent,
            Player,
        }

        public static readonly string Title = "[日志管理]";
        private LogManager allLogs;
        private LogManager successEvent;
        private LogManager failureEvent;

        /// <summary>
        /// 初始化组件,初始化timer,固定时间间隔检测一次待打印的日志队列,然后将其全部打印出去
        /// </summary>
        public LogConsole()
        {
            InitializeComponent();
            allLogs = new LogManager(RTBConsoleTypeAll, 500);
            successEvent = new LogManager(RTBConsoleTypeSuccessEvent, 1000);
            failureEvent = new LogManager(RTBConsoleTypeFailureEvent, 1000);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, 0); // 设置窗口在屏幕右侧并垂直居中
        }

        private LogManager GetUsingManager(int idx)
        {
            switch (idx)
            {
                case 0:
                    return allLogs;
                case 1:
                    return successEvent;
                case 2:
                    return failureEvent;
                default:
                    return allLogs;
            }
        }

        public void LogLine(LogContainer container, string message, Color textColor)
        {
            Log(container, message + "\n", textColor);
        }

        public void Log(LogContainer container, string message, Color textColor)
        {
            switch (container)
            {
                case LogContainer.All:
                    allLogs.Log(message, textColor); break;
                case LogContainer.SuccessEvent:
                    successEvent.Log(message, textColor);
                    break;
                case LogContainer.FailureEvent:
                    failureEvent.Log(message, textColor);
                    break;
            }
        }

        ///开放给Mod使用的API,100ms内可能被调用多次,需要保证不会阻塞Mod线程(可能会被多个线程同时调用)
        public void LogInfo(string msg)
        {
            allLogs.LogInfo(msg);
        }
        public void LogWarn(string msg)
        {
            allLogs.LogWarn(msg);
        }
        public void LogError(string msg)
        {
            allLogs.LogError(msg);
        }

        public void LogBlock(string msg)
        {
            allLogs.LogBlock(msg);
        }

        public void LogEventInfo(string eventInfo)
        {
            allLogs.LogEventInfo(eventInfo);
        }

        public void LogConfigInfo(string configInfo)
        {
            allLogs.LogConfigInfo(configInfo);
        }

        public void LogSuccess(string message)
        {
            allLogs.LogSuccess(message);
        }

        public void EventLogSuccess(string eventInfo)
        {
            successEvent.LogInfo(eventInfo);
        }

        public void EventLogFailure(string eventInfo)
        {
            failureEvent.LogInfo(eventInfo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int clearRTBIdx = GameConsoleTab.SelectedIndex;
            LogManager usingManager = GetUsingManager(clearRTBIdx);
            usingManager.ClearAllLogs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.allLogs.ClearAllLogs();
            this.successEvent.ClearAllLogs();
            this.failureEvent.ClearAllLogs();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int clearRTBIdx = GameConsoleTab.SelectedIndex;
            LogManager usingManager = GetUsingManager(clearRTBIdx);
            usingManager.SaveAllLogs();
        }
    }
}
