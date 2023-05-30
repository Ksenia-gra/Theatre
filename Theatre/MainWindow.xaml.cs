using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
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
using Theatre.UserControls;
using Theatre.UserControls.AccountantUC;
namespace Theatre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; set; }
        public static Пользователи ActiveUser { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitDbSets(PostgresContext.Instance);
            Instance = this;

            Instance.myUc.Content = new SignIn();

        }
        private void InitDbSets(DbContext context)
        {
            
            IEnumerable<PropertyInfo> dbSets = context.GetType().GetProperties().Where(x => x.PropertyType.IsGenericType);
            foreach (PropertyInfo dbSet in dbSets)
            {
                object? val = dbSet.GetValue(context);
                MethodInfo? loadMethod = typeof(EntityFrameworkQueryableExtensions).GetMethod("Load");
                Type? modelType = dbSet.PropertyType.GetGenericArguments().First();
                loadMethod?.MakeGenericMethod(new[] { modelType })?.Invoke(val, new[] { val });
                var entity = context.Model.FindEntityType(modelType);
                var dbSetValue = dbSet.GetValue(context);
                
            }
        }
        private void posters_Click(object sender, RoutedEventArgs e)
        {
            Instance.myUc.Content = new Posters();
        }

        private void buyTicket_Click(object sender, RoutedEventArgs e)
        {
            Instance.myUc.Content = new BuyTicket(null);
        }

        private void perfomance_Click(object sender, RoutedEventArgs e)
        {
            Instance.myUc.Content = new Perfomances();
        }

        private void people_Click(object sender, RoutedEventArgs e)
        {
            Instance.myUc.Content = new People();
        }

        private void account_Click(object sender, RoutedEventArgs e)
        {
            Instance.myUc.Content = new Account(MainWindow.ActiveUser);
        }

        private void inventary_Click(object sender, RoutedEventArgs e)
        {
            Instance.myUc.Content=new Inventory();
        }

        private void costumes_Click(object sender, RoutedEventArgs e)
        {
            Instance.myUc.Content = new Costumes();
        }

        private void salesStatistic_Click(object sender, RoutedEventArgs e)
        {
            Instance.myUc.Content = new SaleStatistic();
        }
    }
}
