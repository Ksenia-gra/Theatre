using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
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
    /// Логика взаимодействия для BuyTicket.xaml
    /// </summary>
    public partial class BuyTicket : UserControl
    {
        
        public BuyTicket(string perfName)
        {
            InitializeComponent();
           
            PerfName.ItemsSource=PostgresContext.Instance.Спектаклиs.Local.Select(x=>x.НазваниеСпектакля);
            if (!string.IsNullOrEmpty(perfName))
            {
                PerfName.SelectedValue = perfName;
            }
            
        }

        private void BuyTick_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Точно хотите купить?", "Подтверждение покупки", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) ==
                MessageBoxResult.Yes)
            {
                try
                {
                    int id = (int)((tikets as ComboBox).SelectedItem.GetType().GetProperty("tickId").GetValue(tikets.SelectedItem));
                    Билеты ticket = PostgresContext.Instance.Билетыs.Local.Where(x => x.IdБилета == id).FirstOrDefault();
                    ticket.КодПользователя = MainWindow.ActiveUser.Idпользователя;
                    ticket.Продан = true;
                    PostgresContext.Instance.SaveChanges();
                    MessageBox.Show("Билет успешно куплен", "Успешно", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
                catch 
                {
                    MessageBox.Show("Ошибка покупки", "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }

               
            }
            else
            {
                return;
            }
           
            
        }

        private void PerfName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObservableCollection<object> ticketsList = new ObservableCollection<object>();
            foreach (Билеты s in PostgresContext.Instance.Билетыs.Local)
            {
                if (!s.Продан && s.КодРасписанияNavigation.КодСпектакляNavigation.НазваниеСпектакля == PerfName.SelectedValue)

                    ticketsList.Add(new
                    {
                        tickId=s.IdБилета,
                        PerfomanceName = s.КодРасписанияNavigation.КодСпектакляNavigation.НазваниеСпектакля,
                        ScheduleDate = s.КодРасписанияNavigation.ДатаНачала,
                        ScheduleTime = s.КодРасписанияNavigation.ВремяНачала,
                        PlaceRow = s.КодМестаNavigation.Ряд,
                        PlaceNumber = s.КодМестаNavigation.НомерМеста,
                        PlaceTipe = s.КодМестаNavigation.КодТипаМестаNavigation.НазваниеТипа,
                        Cost = s.Стоимость


                    });


            }
            tikets.ItemsSource = ticketsList;
        }
    }
}
