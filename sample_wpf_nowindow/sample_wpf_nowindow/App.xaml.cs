using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace sample_wpf_nowindow
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            Task.Run(() =>
            {
                for(int i= 0; i < 5; i++)
                {
                    Dispatcher.Invoke(() => { Trace.WriteLine($"MainWindow Handle={new WindowInteropHelper(MainWindow).EnsureHandle()}"); });
                    Task.Delay(new TimeSpan(0, 0, 1)).Wait();
                }

            });

            SessionEnding += OnSessionEnding;
        }

        private void OnSessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            File.AppendAllLines(@"C:\TestMod\test.txt", new [] { $"{DateTime.Now}:OnSessionEnding, {e.ReasonSessionEnding}" });
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            SessionEnding -= OnSessionEnding;
        }
    }
}
