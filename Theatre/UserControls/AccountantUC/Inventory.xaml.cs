using System;
using System.Collections.Generic;
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
        }
    }
}
