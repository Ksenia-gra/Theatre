using MaterialDesignColors;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        public SignUp()
        {
            InitializeComponent();
            
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            CheckUserSignIn();
        }

        private void toSignIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.myUc.Content = new SignIn();
        }
        private void CheckUserSignIn()
        {
            if (!CheckPassword(Password.Password))
            {
                MessageBox.Show("Ненадежный пароль", "Ошибка регистрации", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;

            }
            if (!IsValid(Email.Text))
            {
                MessageBox.Show("Неверный формат почты", "Ошибка регистрации", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(Login.Text))
            {
                MessageBox.Show("Неверный логин", "Ошибка регистрации", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
            if (!(PostgresContext.Instance.Пользователиs.Any(x=>x.Логин==Login.Text)))
            {
                var user = new Пользователи
                {
                    Логин = Login.Text,
                    Пароль = Password.Password,
                    Почта = Email.Text

                };

                PostgresContext.Instance.Пользователиs.Add(user);
                PostgresContext.Instance.SaveChanges();
                MainWindow.ActiveUser = user;
                MainWindow.Instance.menuPanel.Visibility = Visibility.Visible;
                MainWindow.Instance.myUc.Content = new Posters();
            }
            else
            {
                MessageBox.Show("Такой пользователь уже существует","Неверный логин",MessageBoxButton.OKCancel,MessageBoxImage.Error);
            }
  

        }
        private bool CheckPassword(string pass)
        {
            bool res = true;
            if (pass.Length < 6 || (!pass.Any(x=>char.IsDigit(x)) && !pass.Any(x => char.IsLetter(x)) 
                && !pass.Any(x=>char.IsSymbol(x))))
                res = false;
            return res;
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
