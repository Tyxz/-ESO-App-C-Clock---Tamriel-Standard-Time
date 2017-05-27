﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace Clock {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Data.TST tst;
        public MainWindow() {
            InitializeComponent();

            tst = new Data.TST();


            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(Update);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Start();
            tst.StartClock();
        }

        private void Update(object sender, EventArgs eArgs) {
            string time = tst.Hour + ":" + tst.Minute + ":" + tst.Second;
            if (DateTime.TryParseExact(time, "H:m:s",
                                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime)) {
                time = dateTime.ToString("T", CultureInfo.CurrentCulture);
            } else {
                Console.WriteLine(time);
            }
            clockLabel.Content = time + " " + tst.Day + "." + tst.Month + "." + tst.Era + "E" + tst.Year;
            moonLabel.Content = tst.moonState + " " + Math.Round(tst.moonWay, 2) * 100 + "% finished";
            CommandManager.InvalidateRequerySuggested();
        }
        
    }
}
