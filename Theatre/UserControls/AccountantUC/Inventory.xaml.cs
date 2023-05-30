using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Theatre.UserControls.AccountantUC
{
    /// <summary>
    /// Логика взаимодействия для Inventory.xaml
    /// </summary>
    public partial class Inventory : UserControl
    {
        public Inventory()
        {
            InitializeComponent();
            inventoryDG.ItemsSource = PostgresContext.Instance.Инвентарьs.Local.ToObservableCollection();
        }

        private void inventoryDG_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyInfo? propertyInfo = typeof(Инвентарь).GetProperty(e.PropertyName);
            DescriptionAttribute? descriptionAttribute = propertyInfo.GetCustomAttribute<DescriptionAttribute>();
            ReadOnlyAttribute? readOnlyAttribute = propertyInfo.GetCustomAttribute<ReadOnlyAttribute>();
            if (descriptionAttribute == null)
            {
                e.Cancel = true;
            }
            else
            {
                e.Column.Header = descriptionAttribute.Description;
            }

            if (readOnlyAttribute != null && readOnlyAttribute.IsReadOnly)
            {
                e.Column.IsReadOnly = true;
            }
            if (e.PropertyType == typeof(DateTime?))
            {
               (e.Column as DataGridTextColumn).Binding.StringFormat = "yyyy-MM-dd";
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PostgresContext.Instance.SaveChanges();
                MessageBox.Show("Изменения успешно сохранены", "Успешно", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
            catch 
            {
                MessageBox.Show("Ошибочный формат данных", "Ошибка добавления", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }

            
        }

        private void inventoryDG_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            e.NewItem = new Инвентарь()
            {
                IdИнвентаря = PostgresContext.Instance.Инвентарьs.Max(x => x.IdИнвентаря) + 1
            };
        }

        private void Searh_TextChanged(object sender, TextChangedEventArgs e)
        {
            IEnumerable<Инвентарь> inventory= PostgresContext.Instance.Инвентарьs.Local.ToObservableCollection().Where(x => x.НазваниеИнвентаря.Contains(Searh.Text) ||

           x.СрокИспользования.ToString() == (Searh.Text) || x.Стоимость.ToString() == (Searh.Text) || x.КодТипаNavigation.ToString().Contains(Searh.Text));
            if (inventory.Count()!=0)
                inventoryDG.ItemsSource = inventory;
            else
                inventoryDG.ItemsSource = PostgresContext.Instance.Инвентарьs.Local.ToObservableCollection();
        }

        private void Searh_LostFocus(object sender, RoutedEventArgs e)
        {
            inventoryDG.ItemsSource = PostgresContext.Instance.Инвентарьs.Local.ToObservableCollection();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            IEnumerable<Инвентарь> inventory = PostgresContext.Instance.Инвентарьs.Local.ToObservableCollection().Where(x => x.ДатаНачалаИспользования==DatePick.SelectedDate ||

           x.ДатаСписания == DatePick.SelectedDate );
            if (inventory.Count() != 0)
                inventoryDG.ItemsSource = inventory;
            else
                inventoryDG.ItemsSource = PostgresContext.Instance.Инвентарьs.Local.ToObservableCollection();
        }

        private void DatePick_LostFocus(object sender, RoutedEventArgs e)
        {
            inventoryDG.ItemsSource = PostgresContext.Instance.Инвентарьs.Local.ToObservableCollection();
        }
    }
}
