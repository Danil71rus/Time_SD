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
using System.Windows.Shapes;

namespace Time_SD
{
    /// <summary>
    /// Логика взаимодействия для bul.xaml
    /// </summary>

    public partial class bul : Window 
    {
        
        public bul()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow log = Application.Current.Windows[0] as MainWindow; // форма в которую нужно передать значения
            log.ch = textbox_chas.Text;
            log.mi = textbox_minut.Text;
            this.Close();
        }
    }
}
