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
using System.Security.Cryptography;
using Theatre.UserControls.AccountantUC;

namespace Theatre.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : UserControl
    {
        public SignIn()
        {
            InitializeComponent();
            
        }

        private void Sign_In_Click(object sender, RoutedEventArgs e)
        {
            CheckUserSignIn();
        }

        private void toSignUp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.myUc.Content = new SignUp();
        }
        private void CheckUserSignIn()
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                foreach (var user in PostgresContext.Instance.Пользователиs)
                {
                    string s = string.Join("", mySHA256.ComputeHash(Encoding.UTF8.GetBytes(Password.Password+user.Соль)).Select(b => b.ToString("x2")));

                    if (user.Логин == Login.Text && user.Пароль == s)
                    {
                        if (user.КодРолиNavigation!=null)
                        {
                            if (user.КодРолиNavigation.НаименованиеРоли == "accountant")
                            {
                                MainWindow.ActiveUser = user;
                                MainWindow.Instance.myUc.Content = new Inventory();
                                MainWindow.Instance.accountentPan.Visibility = Visibility.Visible;

                            }


                        }
                        else
                        {
                            MainWindow.ActiveUser = user;
                            MainWindow.Instance.myUc.Content = new Posters();
                            MainWindow.Instance.menuPanel.Visibility = Visibility.Visible;
                        }
                    }
                    
                }
            }
                
        }
    }
}
