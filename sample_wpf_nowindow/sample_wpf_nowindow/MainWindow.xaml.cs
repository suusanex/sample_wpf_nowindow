using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            Trace.WriteLine($"{string.Join(",", hwnd, msg, wparam, lparam)}");
            return IntPtr.Zero;
        }

        private void MainWindow_OnInitialized(object sender, EventArgs e)
        {
            var helper = new WindowInteropHelper(this);
            helper.EnsureHandle();
            var source = HwndSource.FromHwnd(helper.Handle);
            source.AddHook(WndProc);

        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Closing");
        }
    }
}
