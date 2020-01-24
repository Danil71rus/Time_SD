using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudio.Wave;
using NAudio.FileFormats;
using NAudio.CoreAudioApi;
using NAudio;

namespace Time_SD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {

        public string ch, mi;
        public MainWindow()
        {
            InitializeComponent();
            /*Window ownedWindow = new Window();
            ownedWindow.Owner = this;
            ownedWindow.Show();*/
            ShowInTaskbar = false;

           
            
            lable_time.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        private void timerTick(object sender,EventArgs e)
        {
            if (CheckBox_Minut.IsChecked == true)
            {
                if (DateTime.Now.Minute / 10 < 1)
                    lable_time.Content = DateTime.Now.Hour + ":0" + DateTime.Now.Minute;
                else
                    lable_time.Content = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            }
            else
            {
                if (DateTime.Now.Minute/10<1)
                lable_time.Content = DateTime.Now.Hour + ":0" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                else
                lable_time.Content = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            }
                CommandManager.InvalidateRequerySuggested();

            if (CheckBox_Ticer.IsChecked == true)
            {
                if(DateTime.Now.Second==0)
                {
                    System.Media.SoundPlayer sp;
                    sp = new System.Media.SoundPlayer("kick-trimmed.wav");
                    sp.Play();
                   
                }
            }
            if(CheckBox_budilnic.IsChecked==true)
            {
                if(DateTime.Now.Hour==Convert.ToInt32(ch)&&DateTime.Now.Minute==Convert.ToInt32(mi))
                {
                    CheckBox_budilnic.IsChecked = false;                    
                    var w = new WaveOut();
                    var r = new Mp3FileReader("Imagine Dragons -Believer - Believer.mp3");
                    w.Init(r);
                    w.Play();
                    MessageBoxResult result = MessageBox.Show("Пришло время твориить!", "", MessageBoxButton.OK);
                    if (result == MessageBoxResult.OK)
                    {
                        w.Stop();
                    }               
                    
                }
            }

            zad.Content = ch + ":" + mi;//------------------------
        }
        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {                  
                lable_time.Foreground = Brushes.White;            
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            lable_time.Foreground = Brushes.Blue;  
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            lable_time.Foreground = Brushes.Red;  
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            lable_time.Foreground = Brushes.Yellow;  
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            lable_time.Foreground = Brushes.Green;  
        }
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            lable_time.Foreground = Brushes.Orange;
        }
        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            lable_time.Foreground = Brushes.Gold;
        }
        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            lable_time.Foreground = Brushes.Turquoise;
        }
        private void MenuItem_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_budilnic(object sender, RoutedEventArgs e)
        {

            bul win = new bul();
            
            CheckBox_budilnic.IsChecked = true;
            win.Show();
           
        }
        
    }
}
