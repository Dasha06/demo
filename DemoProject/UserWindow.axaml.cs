using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemoProject;

public partial class UserWindow : Window
{
    public static readonly PostgresContext context = new PostgresContext();
    public List<Tovar> tovars = context.Tovars
        .Include(x => x.Category)
        .Include(x => x.Postav)
        .Include(x => x.Proizvod)
        .Include(x => x.Type).ToList();

    public UserWindow()
    {
        InitializeComponent();
        ListBoxTovar.ItemsSource = tovars;
        //User_TextBlock.Text = user.UserFio;
    }

    private void Button_GoBack(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}