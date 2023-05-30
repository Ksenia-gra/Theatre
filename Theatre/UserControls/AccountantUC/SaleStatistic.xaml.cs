using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
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
using Theatre.BD_Context;

namespace Theatre.UserControls.AccountantUC
{
    /// <summary>
    /// Логика взаимодействия для SaleStatistic.xaml
    /// </summary>
    public partial class SaleStatistic : UserControl
    {
        public SaleStatistic()
        {
            InitializeComponent();
            sales.ItemsSource=PostgresContext.Instance.Sales.Local.ToObservableCollection();
        }

        private void DatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            IEnumerable<Sale> inventory = PostgresContext.Instance.Sales.Local.ToObservableCollection().Where(x => x.ДатаПродаж ==DateOnly.FromDateTime(DatePick.SelectedDate.Value));
            if (inventory.Count() != 0)
                sales.ItemsSource = inventory;
            else
                sales.ItemsSource = PostgresContext.Instance.Sales.Local.ToObservableCollection();
        }
    }
}
