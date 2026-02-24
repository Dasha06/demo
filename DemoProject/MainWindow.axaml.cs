using Avalonia.Controls;
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            if (UserFound != null && UserFound.Role.RoleName == "Авторизированный клиент")
            {
                UserWindow userWindow = new UserWindow(); //должна быть вставка юзера, но из-за него ломается проект
                userWindow.Show();
                Close();
            }
            else
            {
                Error_TextBlock.Text = "Логин или пароль введен неправильно";
            }
        }
    }
}