using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWindowLib
{

    public class LogConstant
    {
        private static string GenerateLogTitleRtf()
        {
            var currentTime = DateTime.Now.ToString("hh:mm:ss.fff");
            return @"{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Arial;}}"
                    + @"{\colortbl ;\red0\green128\blue0;\red0\green255\blue255;\red255\green255\blue255;}"
                    + @"\cf1\f0\fs20 [" + currentTime + @"] \cf2 " + LogConsole.Title + @" \cf3\par}";
        }
    }

    public class LogMessage
    {
        public string message { get; private set; }  // 存储 RTF 格式的文本

        public LogMessage(string message, Color textColor)
        {
            this.message = CreateRtfString(message, textColor);
        }

        private string CreateRtfString(string message, Color textColor)
        {
            using (RichTextBox rtfHelper = new RichTextBox())
            {
                rtfHelper.AppendText(message);
                rtfHelper.Select(0, message.Length);
                rtfHelper.SelectionColor = textColor;
                return rtfHelper.Rtf;
            }
        }
    }

    internal class LogManager
    {
        private readonly ConcurrentQueue<Action> logActions;
        private readonly System.Threading.Timer logTimer;
        private readonly RichTextBox logContainer;
        private List<string> messages;

        public LogManager(RichTextBox gameConsoleRTB, int period)
        {
            this.logContainer = gameConsoleRTB;
            logActions = new ConcurrentQueue<Action>();
            logTimer = new System.Threading.Timer(ProcessLogQueue, null, 0, period);
        }

        public void ClearAllLogs()
        {
            if (logContainer.InvokeRequired)
            {
                logContainer.Invoke(new Action(() => logContainer.Clear()));
            }
            else
            {
                logContainer.Clear();
            }
        }

        public async Task SaveAllLogs()
        {
            // 确定日志目录路径
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
            // 确保目录存在
            Directory.CreateDirectory(logDirectory); // 如果目录已存在，则不会执行任何操作

            // 构造基于当前日期和时间的日志文件名
            string fileName = Path.Combine(logDirectory, $"Logs_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
            string logContent = "";

            // 检查是否需要跨线程访问logContainer.Text
            if (logContainer.InvokeRequired)
            {
                logContainer.Invoke(new Action(() => logContent = logContainer.Text));
            }
            else
            {
                logContent = logContainer.Text;
            }

            // 异步写入日志内容到文件
            await Task.Run(() =>
            {
                File.WriteAllText(fileName, logContent);
            });
        }

        private void ProcessLogQueue(object state)
        {
            while (logActions.TryDequeue(out var action))
            {
                if (logContainer.InvokeRequired)
                {
                    logContainer.Invoke(action);
                }
                else
                {
                    action();
                }
            }
        }

        public void Log(string message, Color textColor)
        {
            EnqueueLog(() =>
            {
                logContainer.SelectionColor = textColor;
                logContainer.AppendText(message);
            });
        }

        public void LogInfo(string msg)
        {
            EnqueueLog(() =>
            {
                LogTitle();
                logContainer.SelectionColor = Color.Cyan;
                logContainer.AppendText($"[Info]: {msg}\n");
            });
        }

        public void LogWarn(string msg)
        {
            EnqueueLog(() =>
            {
                LogTitle();
                logContainer.SelectionColor = Color.YellowGreen; // 警告日志颜色
                logContainer.AppendText($"[Warning]: {msg}\n");
            });
        }

        public void LogError(string msg)
        {
            EnqueueLog(() =>
            {
                LogTitle();
                logContainer.SelectionColor = Color.Red; // 错误日志颜色
                logContainer.AppendText($"[Error]: {msg}\n");
            });
        }

        public void LogFailure(string msg)
        {
            EnqueueLog(() =>
            {
                LogTitle();
                logContainer.SelectionColor = Color.Pink; // 错误日志颜色
                logContainer.AppendText($"[Failure]: {msg}\n");
            });
        }

        /// <summary>
        /// 每个日志都必须使用LogTitle先打印出日志头部信息
        /// </summary>
        private void LogTitle()
        {
            logContainer.Invoke(new Action(() =>
            {
                logContainer.SelectionColor = Color.Green;
                logContainer.AppendText($"[{DateTime.Now:hh:mm:ss.fff}] ");
                logContainer.SelectionColor = Color.Cyan;
                logContainer.AppendText($"{LogConsole.Title} ");
                logContainer.SelectionColor = Color.White;
                logContainer.ScrollToCaret();
            }));
        }

        public void LogBlock(string msg)
        {
            EnqueueLog(() =>
            {
                // 打印块状消息
                logContainer.SelectionColor = Color.Magenta;
                logContainer.AppendText("********************************************************\n");
                logContainer.SelectionColor = Color.White;
                logContainer.AppendText(msg + "\n");
                logContainer.SelectionColor = Color.Magenta;
                logContainer.AppendText("********************************************************\n");
                logContainer.ScrollToCaret();
            });
        }

        public void LogEventInfo(string eventInfo)
        {
            EnqueueLog(() =>
            {
                LogTitle(); // 使用已经存在的LogTitle方法
                logContainer.SelectionColor = Color.Blue;
                logContainer.AppendText("[Event]\n" + eventInfo + "\n");
                logContainer.AppendText("--------------------------------------------------------\n");
                logContainer.ScrollToCaret();
            });
        }

        public void LogConfigInfo(string configInfo)
        {
            EnqueueLog(() =>
            {
                LogTitle(); // 使用已经存在的LogTitle方法
                logContainer.SelectionColor = Color.Blue;
                logContainer.AppendText("[Mod配置信息]" + configInfo + "\n");
                logContainer.ScrollToCaret();
            });
        }

        public void LogSuccess(string message)
        {
            EnqueueLog(() =>
            {
                LogTitle(); // 使用已经存在的LogTitle方法
                logContainer.SelectionColor = Color.Green;
                logContainer.AppendText("[Success]" + message + "\n");
                logContainer.ScrollToCaret();
            });
        }

        private void EnqueueLog(Action logAction)
        {
            logActions.Enqueue(logAction);
        }
    }
}
