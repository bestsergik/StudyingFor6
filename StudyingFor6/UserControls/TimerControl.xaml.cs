using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StudyingFor6.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TimerControl.xaml
    /// </summary>
    public partial class TimerControl : UserControl
    {
        long counter = 0;
        DispatcherTimer timer;
        public TimerControl()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timelbl.Content = new DateTime().ToString("mm\\:ss");
        }

        public void RefreshTimer()
        {
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public void ResetTimer()
        {
            timelbl.Content = new DateTime().ToString("mm\\:ss");
        }

        public void StopTimer()
        {
            counter = 0;
            timer.Tick -= Timer_Tick;
        }

        public DateTime GetCurrentTime()
        {
            var currentTime = DateTimeFromUnixTime(counter);
            return currentTime;
        }

        public long GetCurrentCounterTime()
        {
            return counter;
        }

        public DateTime DateTimeFromUnixTime(long unixTimeStamp)
        {
            return DateTimeOffset
                 .FromUnixTimeSeconds(unixTimeStamp)
                 .UtcDateTime;
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            DateTime countdown = new DateTime().AddSeconds(counter);
            timelbl.Content = countdown.ToString("mm\\:ss");
            //timelbl.Content = countdown.ToLongTimeString();
            counter++;
        }
    }
}
