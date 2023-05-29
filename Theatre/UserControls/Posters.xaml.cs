using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для Posters.xaml
    /// </summary>
    public partial class Posters : UserControl
    {
        public Posters()
        {
            InitializeComponent();
            icPost.ItemsSource = PostgresContext.Instance.Расписаниеs.Local.ToObservableCollection();
         
        }
        private void buyTicket_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow.Instance.myUc.Content = new BuyTicket((sender as Button).DataContext.ToString());
        }
    }
}
