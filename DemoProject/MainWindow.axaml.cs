using Avalonia.Controls;
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Serialization;

namespace DemoProject
{
    public partial class MainWindow : Window
    {
        public static readonly PostgresContext context = new PostgresContext();
        public List<User> users = context.Users.Include(x => x.Role).ToList();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Enter(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var UserFound = users.FirstOrDefault(x => x.UserLogin == TextBlock_login.Text && x.UserPassword == TextBlock_Password.Text);
            if (UserFound != null)
            {
                if (UserFound.Role.RoleName == "Авторизированный клиент")
                {
                    UserWindow userWindow = new UserWindow(); //должна быть вставка юзера, но из-за него ломается проект
                    userWindow.Show();
                    Close();
                }
                else if (UserFound.Role.RoleName == "Менеджер")
                {
                    UserWindow userWindow = new UserWindow(); //должна быть вставка юзера, но из-за него ломается проект
                    userWindow.Show();
                    Close();
                }
                else
                {
                    UserWindow userWindow = new UserWindow(); //должна быть вставка юзера, но из-за него ломается проект
                    userWindow.Show();
                    Close();
                }
            }
            else
            {
                Error_TextBlock.Text = "Логин или пароль введен неправильно";
            }
        }

        private void Button_EnterAsGost(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
            Close();
        }
    }
}