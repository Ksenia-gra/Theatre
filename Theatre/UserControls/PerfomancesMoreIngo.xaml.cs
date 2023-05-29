using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
using Theatre.BD_Context;

namespace Theatre.UserControls
{
    /// <summary>
    /// Логика взаимодействия для PerfomancesMoreIngo.xaml
    /// </summary>
    public partial class PerfomancesMoreIngo : UserControl
    {
        public PerfomancesMoreIngo(Спектакли perfomance)
        {
            InitializeComponent();

            this.DataContext= perfomance;
            
            if (perfomance.КодРолиs.Count != 0)
            {
                rolesText.Visibility = Visibility.Visible;
                roles.Visibility = Visibility.Visible;
                roles.ItemsSource = perfomance.КодРолиs.Select(x => x.НазваниеРоли);
            }

        }

        private void BackToPerf_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.myUc.Content = new Perfomances();
        }
    }
}
