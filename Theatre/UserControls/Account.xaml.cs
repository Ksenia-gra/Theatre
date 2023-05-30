using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Theatre.BD_Context;

namespace Theatre.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : UserControl
    {
        public Account(Пользователи user)
        {
            InitializeComponent();
            this.DataContext = user;
          
            if(user.КодРолиNavigation != null && user.КодРолиNavigation.НаименованиеРоли=="accountant")
                    BuyedTickets.Visibility= Visibility.Collapsed;
            ObservableCollection<object> ticketsList = new ObservableCollection<object>();
            foreach (Билеты s in PostgresContext.Instance.Билетыs.Local)
            {
                if (s.КодПользователя == MainWindow.ActiveUser.Idпользователя)

                    ticketsList.Add(new
                    {
                        tickId = s.IdБилета,
                        PerfomanceName = s.КодРасписанияNavigation.КодСпектакляNavigation.НазваниеСпектакля,
                        ScheduleDate = s.КодРасписанияNavigation.ДатаНачала,
                        ScheduleTime = s.КодРасписанияNavigation.ВремяНачала,
                        PlaceRow = s.КодМестаNavigation.Ряд,
                        PlaceNumber = s.КодМестаNavigation.НомерМеста,
                        PlaceTipe = s.КодМестаNavigation.КодТипаМестаNavigation.НазваниеТипа,
                        Cost = s.Стоимость


                    });


            }
            buyedTickets.ItemsSource = ticketsList;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Точно хотите выйти?","Подтверждение выхода",MessageBoxButton.YesNoCancel,MessageBoxImage.Warning)==
                MessageBoxResult.Yes)
            {
                MainWindow.ActiveUser = null;
                MainWindow.Instance.myUc.Content = new SignIn();
                MainWindow.Instance.menuPanel.Visibility = Visibility.Collapsed;
                MainWindow.Instance.accountentPan.Visibility= Visibility.Collapsed;
            }
            else
            {
                return;
            }
            
        }
        
    }
}
