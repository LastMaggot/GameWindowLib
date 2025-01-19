using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWindowLib
{
    internal static class Program
    {
        private static Thread windowThread;
        private static LogConsole logWindow;
        private static bool isRunning = false;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 运行日志窗口
            if (windowThread == null || !windowThread.IsAlive)
            {
                windowThread = new Thread(() =>
                {
                    logWindow = new LogConsole();
                    isRunning = true;
                    Application.Run(logWindow);
                })
                {
                    IsBackground = true, // 设置为后台线程，这样当主程序退出时，窗口线程也会自动关闭
                    ApartmentState = ApartmentState.STA // 设置线程的公寓状态为STA，因为WinForms需要
                };
                windowThread.Start();
            }

            ///在下面添加一个逻辑确保logWindow完全初始化再执行后面的内容
            while (!isRunning) ;
            ///逻辑代码结束

            Task.Run(() =>
            {
                SimulateLogging();
                //SimulateConcurrentLogging(logWindow);
            });

            while (true) ;
        }

        static void SimulateLogging()
        {
            // 等待日志窗口完全加载
            while (logWindow == null) ;
            //Thread.Sleep(3000); // 暂停1秒以确保窗口加载

            // 模拟日志记录
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Call each public API synchronously
            logWindow.LogInfo("正在测试 LogInfo 方法（同步）");
            logWindow.LogWarn("正在测试 LogWarn 方法（同步）");
            logWindow.LogError("正在测试 LogError 方法（同步）");
            logWindow.LogBlock("正在测试 LogBlock 方法（同步）");
            logWindow.LogEventInfo("正在测试 LogEventInfo 方法（同步）");
            logWindow.LogConfigInfo("正在测试 LogConfigInfo 方法（同步）");
            logWindow.LogSuccess("正在测试 LogSuccess 方法（同步）");
            logWindow.EventLogSuccess("正在测试 EventLogSuccess 方法（同步）");
            logWindow.EventLogFailure("正在测试 EventLogFailure 方法（同步）");

            stopwatch.Stop();
            logWindow.LogSuccess($"同步测试完成：1 次迭代在 {stopwatch.ElapsedMilliseconds} 毫秒内完成");

        }

        static void SimulateConcurrentLogging(LogConsole logConsole)
        {
            int numberOfTasks = 10; // 并发任务数量
            int logsPerTask = 100; // 每个任务生成的日志条数

            Task[] tasks = new Task[numberOfTasks];
            while (logConsole == null) ;
            for (int i = 0; i < numberOfTasks; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    for (int j = 0; j < logsPerTask; j++)
                    {
                        string messageType;
                        if (j % 3 == 0)
                        {
                            messageType = "Info";
                        }
                        else if (j % 3 == 1)
                        {
                            messageType = "Warn";
                        }
                        else // j % 3 == 2
                        {
                            messageType = "Error";
                        }

                        string message = $"Message {j} from Task {Task.CurrentId}";

                        switch (messageType)
                        {
                            case "Info":
                                logConsole.LogInfo(message);
                                break;
                            case "Warn":
                                logConsole.LogWarn(message);
                                break;
                            case "Error":
                                logConsole.LogError(message);
                                break;
                        }
                    }
                });
            }

            Task.WaitAll(tasks); // 等待所有任务完成
            Console.WriteLine("所有并发日志记录任务已完成。");
        }
    }
}