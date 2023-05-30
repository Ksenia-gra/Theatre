using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для Costumes.xaml
    /// </summary>
    public partial class Costumes : UserControl
    {
        public Costumes()
        {
            InitializeComponent();
            provider.ItemsSource = PostgresContext.Instance.Поставщикиs.Local.ToObservableCollection();
            type.ItemsSource = PostgresContext.Instance.ТипКостюмаs.Local.ToObservableCollection();
            contract.ItemsSource= PostgresContext.Instance.Договорыs.Local.ToObservableCollection();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            if ((provider.SelectedItem is Поставщики postav) && DatePick.SelectedDate!=null)
            {
                Договоры contract = new Договоры
                {
                    IdДоговора= PostgresContext.Instance.Договорыs.Max(x => x.IdДоговора) + 1,
                    КодПоставщика = postav.IdПоставщика,
                    ДатаЗаключенияДоговора = DateOnly.FromDateTime(DatePick.SelectedDate.Value),
                    ДопУсловияДоговора = dopInfo.Text
                };
                PostgresContext.Instance.Договорыs.Local.Add(contract) ;
            }
            try {
                PostgresContext.Instance.SaveChanges();
                MessageBox.Show("Договор успешно сохранен","Успешно",MessageBoxButton.OKCancel,MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения", "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            
        }

        private void Arrange_Click(object sender, RoutedEventArgs e)
        {
            if ((type.SelectedItem is ТипКостюма postav) && DatePickCost.SelectedDate != null && 
                (contract.SelectedItem is Договоры contracts))
            {
                Костюмы costume = new Костюмы
                {
                    IdКостюма = PostgresContext.Instance.Костюмыs.Max(x => x.IdКостюма) + 1,
                    НазваниеКостюма = NameTextBox.Text,
                    КодДоговора = contracts.IdДоговора,
                    Стоимость = decimal.Parse(CostTextBox.Text),
                    ДатаНачалаИспользования = DateOnly.FromDateTime(DatePickCost.SelectedDate.Value),
                    КодТипа=postav.IdТипа


                };
                PostgresContext.Instance.Костюмыs.Local.Add(costume);
                try
                {
                    PostgresContext.Instance.SaveChanges();
                    MessageBox.Show("Костюм успешно сохранен", "Успешно", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка сохранения", "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }

            }

        }

        private void CostTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = CostTextBox.Text.Length != 0 && !decimal.TryParse(CostTextBox.Text, System.Globalization.NumberStyles.Any, 
                System.Globalization.CultureInfo.InvariantCulture, out var _);
        }
    }
}
