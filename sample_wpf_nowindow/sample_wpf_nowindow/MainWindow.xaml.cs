using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sample_wpf_nowindow
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Loaded");
        }

        private void MainWindow_OnInitialized(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    Dispatcher.Invoke(() => { Trace.WriteLine($"this Handle={new WindowInteropHelper(this).Handle}"); });
                    Task.Delay(new TimeSpan(0, 0, 1)).Wait();
                }

            });


            //Task.Run(() =>
            //{
            //    Task.Delay(new TimeSpan(0, 0, 3)).Wait();
            //    Dispatcher.Invoke(() =>
            //    {
            //        var wnd = new MenuWindow();
            //        wnd.ShowDialog();
            //        Close();
            //    });
            //});
        }
    }
}
