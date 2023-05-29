using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
    /// Логика взаимодействия для Perfomances.xaml
    /// </summary>
    public partial class Perfomances : UserControl
    {
        public Perfomances()
        {
            InitializeComponent();
            PostgresContext.Instance.Спектаклиs.Include(x => x.КодРолиs).Load();
            icPerf.ItemsSource = PostgresContext.Instance.Спектаклиs.Local.ToObservableCollection();
            
        }

        private void moreInfo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.myUc.Content = new PerfomancesMoreIngo((sender as Button).DataContext as Спектакли);
        }
    }
}
